using UnityEngine;

public class ButtonSystem : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneLoader.Instance.LoadMainLVL();
    }
}