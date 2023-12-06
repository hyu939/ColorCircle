using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_G2_Ctrl : MonoBehaviour
{
    public GameObject taptostart;
    public bool tapToStart = false;
    public bool GameIsPaused = false;
    public bool OptionsWin = false;

    public GameObject pauseMenuUI;

    public AudioSource music;

    void Start(){
        Loadinggame();
        Time.timeScale = 0f;
        GameIsPaused = true;
        tapToStart = true;
        OptionsWin = false;
        music.Pause();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused && !OptionsWin){
                Resume();
            } else
            {
                Pause();
            }
        }
        if (Input.GetMouseButtonDown(0)&& GameIsPaused == true && tapToStart){
            TtoT();
        }
        
    }

    void Loadinggame(){
        new WaitForSeconds(1f);
    }

    void TtoT(){
        taptostart.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        tapToStart = false;
        music.Play();
    }

    public void Resume (){
        pauseMenuUI.SetActive(false);
        taptostart.SetActive(true);
        tapToStart = true;
    }

    public void Pause (){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        music.Pause();
        
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void MenuBt (){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        StartCoroutine(LoadLevel(0));
        music.Play();
    }

    public void OptionsBt (){
        OptionsWin = !OptionsWin ? OptionsWin = true : OptionsWin = false;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(levelIndex);
    }
}
