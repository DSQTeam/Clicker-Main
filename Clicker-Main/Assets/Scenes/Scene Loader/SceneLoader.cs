using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Slider ProgressSliger;

    private static SceneLoader instance;
    private static bool shouldPlayEndAnimation = false;

    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

    public static void SwitchToScene(string sceneName)
    {
        instance.componentAnimator.SetTrigger(name:"sceneStart");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        instance.loadingSceneOperation.allowSceneActivation = false;
    }

    private void Start()
    {
        instance = this;

        componentAnimator = GetComponent<Animator>();

        if (shouldPlayEndAnimation) componentAnimator.SetTrigger(name:"sceneEnd");
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            ProgressSliger.value = loadingSceneOperation.progress;
        }
    }

    public void OnAnimatorOver()
    {
        shouldPlayEndAnimation = true;
        instance.loadingSceneOperation.allowSceneActivation = true;
    }
}
