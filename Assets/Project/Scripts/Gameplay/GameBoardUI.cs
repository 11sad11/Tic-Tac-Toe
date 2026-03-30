using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameBoardUI : MonoBehaviour
{
    public RectTransform[] Buttons = null;
    public Animator AnimatorBoard = null;
    [HideInInspector] public GameBoard GameBoard = null;

    private void Start()
    {
        for (int index = 0; index < Buttons.Length; index++)
        {
            int i = index;
            Buttons[index].GetComponent<Button>().onClick.AddListener(() => GameBoard.OnSet(i));
        }
    }

    public IEnumerator CloseAnimationBoard()
    {
        AnimatorBoard.SetTrigger("Close");
        yield return new WaitUntil(() =>
            AnimatorBoard.GetCurrentAnimatorStateInfo(0).IsTag("Close") &&
            AnimatorBoard.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        Destroy(gameObject);
    }

    public void OpenAnimationBoard() => AnimatorBoard.SetTrigger("Open");
}