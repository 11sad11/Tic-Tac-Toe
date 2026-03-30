using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public Scene Scene { get; private set; }


    private void OnEnable() => SceneManager.sceneLoaded += OnLoadedScene;
    private void OnDisable() => SceneManager.sceneLoaded -= OnLoadedScene;
    private void OnLoadedScene(Scene scene, LoadSceneMode loadSceneMode) => Scene = scene;

    public void ResetScene() => StartCoroutine(LoadScene(Scene.buildIndex));
    public void LoadMainMenu() => StartCoroutine(LoadScene(1));
    public void LoadMainLVL() => StartCoroutine(LoadScene(2));

    private IEnumerator LoadScene(int buildIndex)
    {
        yield return StartCoroutine(SceneTransitionHandler.Instance.CloseScene());
        SceneManager.LoadScene(buildIndex);
    }
}