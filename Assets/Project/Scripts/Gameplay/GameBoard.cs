using UnityEngine;
using UnityEngine.UI;

public class GameBoard : Singleton<GameBoard>
{
    protected override bool isPersistent => false;

    public GameObject prefab = null;
    public GameObject parent = null;
    public RectTransform[] buttons = null;
    public Sprite sprite1 = null;
    public Sprite sprite2 = null;

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
        if (sprite1 == null || sprite2 == null) return;

        _currentPlayerSprite = sprite1;
    }

    public void OnSet(int indexButton)
    {
        if (buttons[indexButton] == null) return;

        //Create
        GameObject gameObject = Instantiate(prefab);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        gameObject.transform.SetParent(parent.transform, false);

        //Set position
        rectTransform.anchoredPosition = buttons[indexButton].anchoredPosition;
        Destroy(buttons[indexButton].gameObject);
        buttons[indexButton] = null;

        //Set sptite 
        Image image = gameObject.GetComponent<Image>();
        image.sprite = _currentPlayerSprite;


        _cellStates[indexButton] = _currentPlayerSprite == sprite1 ? 1 : 2;
        if (CheckWinner()) Debug.Break();
        Switch();
    }

    private void Switch()
    {
        _currentPlayerSprite = _currentPlayerSprite == sprite1 ? sprite2 : sprite1;
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