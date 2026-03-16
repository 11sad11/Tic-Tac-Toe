using UnityEngine;

public class BootstrapperSystem : MonoBehaviour
{
    private void Start()
    {
        //Ожидание конца анимации после чего открывается меню
        SceneLoader.Instance.LoadMainMenu();
    }
}