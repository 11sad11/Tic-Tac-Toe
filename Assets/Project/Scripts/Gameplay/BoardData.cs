using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BoardData : MonoBehaviour
{
    public RectTransform[] Buttons = null;
    [HideInInspector] public GameBoard GameBoard = null;

    private void Start()
    {
        if (System.Array.TrueForAll(Buttons, b => b == null)) return;
        for (int index = 0; index < Buttons.Length; index++)
        {
            int i = index;
            Buttons[index].GetComponent<Button>().onClick.AddListener(() => GameBoard.OnSet(i));
        }
    }
}