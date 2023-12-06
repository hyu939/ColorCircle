using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_G1 : MonoBehaviour
{
    private float jumpForce = 7.5f;
	private Rigidbody2D rb;

	//player Rotation
	private int rota = 0;
    private Transform player;

	//Camera
	private Transform cameraPos;
	private UI_G1_Ctrl gameIsPaused;
	//Spawn
	private Spawn spawn;
	//Skin
	private SkinBalls skinBalls;
	//Score
	private Score_G1 score_G1;
	public Shopscore shopScore;
	//Sound
	public Audio_G1_Ctrl audio_g1;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
		player = GetComponent<Transform>();
		cameraPos = GameObject.FindWithTag("MainCamera").GetComponent<Transform>(); 
		gameIsPaused = GameObject.FindWithTag("Canvas").GetComponent<UI_G1_Ctrl>();
		spawn = GameObject.FindWithTag("Spawn").GetComponent<Spawn>();
		skinBalls = GetComponent<SkinBalls>();
		score_G1 = GameObject.FindWithTag("Canvas").GetComponent<Score_G1>();
		audio_g1 = GameObject.FindWithTag("Audio").GetComponent<Audio_G1_Ctrl>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			rb.velocity = Vector2.up * jumpForce;
			PlayerRota_Up();
			audio_g1.AudioTap();
		}
		PlayerRota_Down();
    }

    void OnTriggerEnter2D (Collider2D col)
	{
		//Tăng điểm, lực nhảy, tiền, tạo lv khi chạm vào tag Star
		if (col.tag == "Star")
		{
			Destroy(col.gameObject);
			if(jumpForce < 9f){
				jumpForce = jumpForce + 0.03f;
			}
			score_G1.ScorePlus();
			spawn.Spawnlv();
			shopScore.ScoreShopPlus();
			return;
		}

		//Đổi màu ngẫu nhiên khi chạm vào tag
		if (col.tag == "ColorChanger")
		{
			audio_g1.AudioColorChange();
			skinBalls.SetColorSkin();
			Destroy(col.gameObject);
			return;
		}

		//Load lại Senne khi thua
		if (col.tag != skinBalls.currentColor)
		{
			Debug.Log("GAME OVER!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}


	//Xoay lên khi nhảy & xuống khi rơi
	void PlayerRota_Up(){
		if (rota > 0 && !gameIsPaused.GameIsPaused)
		{
			player.Rotate(0f, 0f, - 40f, Space.Self);
			rota = rota - 40;
		}
	}
	void PlayerRota_Down(){
		if(transform.position.y < cameraPos.position.y && rota <= 160 && !gameIsPaused.GameIsPaused)
		{
			player.Rotate(0f, 0f, 2f, Space.Self);
			rota = rota + 2;
		}
	}
}
