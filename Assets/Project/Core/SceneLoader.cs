using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public Scene Scene { get; private set; }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += LoadedScene;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LoadedScene;
    }
    private void LoadedScene(Scene scene, LoadSceneMode loadSceneMode) => Scene = scene;

    public void ResetScene()
    {
        SceneManager.LoadScene(Scene.buildIndex);
    }
    public void LoadMainMenu() => SceneManager.LoadScene(1);
    public void LoadMainLVL() => SceneManager.LoadScene(2);
}