using UnityEngine;
using UnityEngine.UI;

public class Score_G1 : MonoBehaviour
{
    public int score_g1;
    public Text scoreText_g1;

    private int hightScore_g1;
    public Text hightScoreText_g1;
    public Audio_G1_Ctrl audio_g1;
    private bool isRun; 
    
    // Start is called before the first frame update
    void Start()
    {
        score_g1 = 0;
        scoreText_g1.text = score_g1 + " ";
        hightScore_g1 = PlayerPrefs.GetInt("hightScore_g1", 0);
        isRun = false;
        hightScoreText_g1.text = "Hight Score: " + hightScore_g1;
    }

    // Update is called once per frame
    void Update()
    {
        if(score_g1 > hightScore_g1){
            hightScore_g1 = score_g1;
            HightScoreAudio();
            PlayerPrefs.SetInt("hightScore_g1", hightScore_g1);
            hightScoreText_g1.text = "Hight Score: " + hightScore_g1;
        }
    }

    //Tăng điểm in game
    public void ScorePlus(){
        score_g1++;
        scoreText_g1.text = score_g1 + " ";
    }

    //Phát nhạc điểm cao 1 lần
    void HightScoreAudio(){
        if(!isRun){
            isRun = true;
            audio_g1.AudioHightScore();
        }
    }
}
