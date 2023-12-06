using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_G2_Ctrl : MonoBehaviour
{
    private SkinBalls skinBalls;
    private Score_G2 score_G2;
    public Shopscore scoreShop;
    public ParticleSystem plus_1;

    void Start ()
    {
        skinBalls = GetComponent<SkinBalls>();
        score_G2 = GameObject.FindWithTag("Canvas").GetComponent<Score_G2>();

    }
    void OnTriggerEnter2D (Collider2D col)
	{
        //Nếu khác màu load lại Scene
		if (col.tag != skinBalls.currentColor)
		{
			Debug.Log("GAME OVER!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
        
        //Chạm vào cùng màu tăng điểm
        if (col.tag == skinBalls.currentColor)
		{
			score_G2.ScorePlus();
            scoreShop.ScoreShopPlus();
            plus_1.Play();
		}

	}
}
