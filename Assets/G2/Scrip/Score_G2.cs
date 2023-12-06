using UnityEngine;
using UnityEngine.UI;

public class Score_G2 : MonoBehaviour
{
    private int score_g2 = 0;
    public Text scoreText_g2;

    private int hightScore_g2;
    public Text hightScoreText_g2;

    void Start()
    {
        scoreText_g2.text = score_g2 + " ";
        hightScore_g2 = PlayerPrefs.GetInt("hightScore_g2", 0);
        hightScoreText_g2.text = "Hight Score: " + hightScore_g2;
    }

    void Update()
    {
        // kiểm tra điểm cao
        if(score_g2 > hightScore_g2){
            hightScore_g2 = score_g2;
            PlayerPrefs.SetInt("hightScore_g2", hightScore_g2);
            hightScoreText_g2.text = "Hight Score: " + hightScore_g2;
        }
    }
    
    public void ScorePlus(){
        score_g2++;
        scoreText_g2.text = score_g2 + " ";
    }
}
