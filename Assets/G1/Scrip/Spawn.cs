using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Transform spawnlocal;
	private Transform playerLocal;

	[SerializeField] public GameObject[] levels;

	private int lvscore = 0;
	private Score_G1 curScore;

	private void Start() {
		spawnlocal = GetComponent<Transform>();
		playerLocal = GameObject.FindWithTag("Player").GetComponent<Transform>();
		curScore = GameObject.FindWithTag("Canvas").GetComponent<Score_G1>();
	}

    void Update()
    {
		if ((spawnlocal.position.y +20) > playerLocal.position.y)
		{
			spawnlocal.position = new Vector3(playerLocal.position.x, playerLocal.position.y +20, playerLocal.position.z);
		}
    }

	//Spawn lv mới khi người chơi đc 18 điểm
	public void Spawnlv()
	{
		if(curScore.score_g1 > 18 && lvscore < curScore.score_g1){
        	Instantiate(levels[Random.Range(0, levels.Length)], spawnlocal.position, spawnlocal.rotation);
			lvscore = curScore.score_g1;
		}
    }
}
