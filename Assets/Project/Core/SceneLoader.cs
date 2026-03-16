using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public void LoadMainMenu() => SceneManager.LoadScene(1);
    public void LoadMainLVL() => SceneManager.LoadScene(2);
}