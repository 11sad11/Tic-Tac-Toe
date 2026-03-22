using UnityEngine;

public class BootstrapperSystem : MonoBehaviour
{
    public GameObject Background = null;

    private void Start()
    {
        DontDestroyOnLoad(Background);
        //Ожидание конца анимации после чего открывается меню
        SceneLoader.Instance.LoadMainMenu();
    }
}