using UnityEngine;
using UnityEngine.UI;

public class GameBoard : Singleton<GameBoard>
{
    protected override bool _isPersistent => false;

    public GameObject PrefabImage = null;
    public GameObject PrefabBoard = null;
    public Sprite Sprite1 = null;
    public Sprite Sprite2 = null;

    [SerializeField] private Transform _canvas = null;
    [SerializeField] private GameObject _board = null;
    private Sprite _currentPlayerSprite = null;
    private RectTransform[] _buttons = null;
    private readonly int[] _cellStates = new int[9];
    private static readonly int[][] _winCombos = new int[][]
    {
    new int[]{0,1,2},
    new int[]{3,4,5},
    new int[]{6,7,8},
    new int[]{0,3,6},
    new int[]{1,4,7},
    new int[]{2,5,8},
    new int[]{0,4,8},
    new int[]{2,4,6},
    };


    void Start()
    {
        if (Sprite1 == null || Sprite2 == null) return;
        _currentPlayerSprite = Sprite1;
        if (_board == null) ResetBoard();
        else _buttons = _board.GetComponent<BoardData>().Buttons;
        _board.GetComponent<BoardData>().GameBoard = this;
    }

    public void OnSet(int indexButton)
    {
        if (_buttons[indexButton] == null) return;
        CreatePrefab(indexButton);
        _cellStates[indexButton] = _currentPlayerSprite == Sprite1 ? 1 : 2;

        Winner winner = CheckWinner();
        if (winner != Winner.None)
        {
            GameManager.Instance.AddPoint(winner);
            ResetBoard();
            return;
        }
        else if (System.Array.TrueForAll(_cellStates, b => b != 0))
            ResetBoard();

        Switch();
    }

    private void CreatePrefab(int indexButton)
    {
        //Create
        GameObject gameObject = Instantiate(PrefabImage);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        gameObject.transform.SetParent(_board.transform, false);

        //Set position
        rectTransform.anchoredPosition = _buttons[indexButton].anchoredPosition;
        Destroy(_buttons[indexButton].gameObject);
        _buttons[indexButton] = null;

        //Set sptite 
        Image image = gameObject.GetComponent<Image>();
        image.sprite = _currentPlayerSprite;
    }

    private void Switch()
    {
        _currentPlayerSprite = _currentPlayerSprite == Sprite1 ? Sprite2 : Sprite1;
    }

    private Winner CheckWinner()
    {
        foreach (var combo in _winCombos)
        {
            int a = combo[0];
            int b = combo[1];
            int c = combo[2];

            if (_cellStates[a] != 0 &&
                _cellStates[a] == _cellStates[b] &&
                _cellStates[a] == _cellStates[c]) return (Winner)_cellStates[a];
        }

        return Winner.None;
    }

    void ResetBoard()
    {
        if (_board != null) Destroy(_board);
        _board = Instantiate(PrefabBoard, _canvas);
        BoardData boardData = _board.GetComponent<BoardData>();
        boardData.GameBoard = this;
        _buttons = boardData.Buttons;
        System.Array.Clear(_cellStates, 0, _cellStates.Length);
    }
}