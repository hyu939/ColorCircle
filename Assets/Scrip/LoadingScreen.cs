using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public Animator Transition;
    public float transitionTime = 1f;

    void Start(){
        Time.timeScale = 1f;
    }

    //Load Scene
    public void LoadMenuScreen(){
        StartCoroutine(LoadLevel(0));
    }
    public void LoadGame1Screen(){
        StartCoroutine(LoadLevel(1));
    }
    public void LoadGame2Screen(){
        StartCoroutine(LoadLevel(2));
    }

    //Run anim chuyển scene
    IEnumerator LoadLevel(int levelIndex)
    {
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
        Debug.Log("LoadingScreenRun");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
