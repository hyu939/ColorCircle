using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_G1_Ctrl : MonoBehaviour
{
    public GameObject taptostart;
    private bool tapToStart = false;
    public bool GameIsPaused = false;
    public bool OptionsWin = false;

    public GameObject pauseMenuUI;
    public GameObject player;
    public Rigidbody2D rb;

    void Start(){
        Loadinggame();
        GameIsPaused = true;
        tapToStart = true;
        OptionsWin = false;
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
        rb.gravityScale=3;
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
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void MenuBt (){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        rb.gravityScale=0;
        StartCoroutine(LoadLevel(0));
    }

    public void OptionsBt (){
        if(!OptionsWin){
            OptionsWin = true;
        }
        else{
            OptionsWin = false;
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(levelIndex);
    }
}
