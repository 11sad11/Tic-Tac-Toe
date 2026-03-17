using UnityEngine;
using UnityEngine.UI;

public class GameBoard : Singleton<GameBoard>
{
    protected override bool _isPersistent => false;

    public GameObject Prefab = null;
    public GameObject Parent = null;
    public RectTransform[] Buttons = null;
    public Sprite Sprite1 = null;
    public Sprite Sprite2 = null;

    private Sprite _currentPlayerSprite = null;
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
    }

    public void OnSet(int indexButton)
    {
        if (Buttons[indexButton] == null) return;

        //Create
        GameObject gameObject = Instantiate(Prefab);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        gameObject.transform.SetParent(Parent.transform, false);

        //Set position
        rectTransform.anchoredPosition = Buttons[indexButton].anchoredPosition;
        Destroy(Buttons[indexButton].gameObject);
        Buttons[indexButton] = null;

        //Set sptite 
        Image image = gameObject.GetComponent<Image>();
        image.sprite = _currentPlayerSprite;


        _cellStates[indexButton] = _currentPlayerSprite == Sprite1 ? 1 : 2;
        if (CheckWinner()) Debug.Break();
        Switch();
    }

    private void Switch()
    {
        _currentPlayerSprite = _currentPlayerSprite == Sprite1 ? Sprite2 : Sprite1;
    }

    private bool CheckWinner()
    {
        foreach (var combo in _winCombos)
        {
            int a = combo[0];
            int b = combo[1];
            int c = combo[2];

            if (_cellStates[a] != 0 &&
                _cellStates[a] == _cellStates[b] &&
                _cellStates[a] == _cellStates[c])
            {
                Debug.Log("Player " + _cellStates[a] + " wins");
                return true;
            }
        }

        return false;
    }
}