using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public Transform playertf;

    private void Start() {
        playertf = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    
    void Update()
    {
        if ((transform.position.y -20) < playertf.position.y)
		{
			transform.position = new Vector3(transform.position.x, playertf.position.y -20, transform.position.z);
		}
    }
}
