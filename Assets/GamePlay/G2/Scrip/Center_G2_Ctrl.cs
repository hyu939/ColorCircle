using UnityEngine;

public class Center_G2_Ctrl : MonoBehaviour
{
    private float rotateSpeed = 500;
    private Transform Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        //Xoay qua trái phải = chuột or A/D
        if(Input.GetMouseButton(0) || Input.GetKey("a")){
            transform.Rotate( 0, 0, rotateSpeed * Time.deltaTime);
            Player.Rotate( 0, 0, (rotateSpeed/5) * Time.deltaTime);
        }
        else if(Input.GetMouseButton(1) || Input.GetKey("d")){
            transform.Rotate( 0, 0, -rotateSpeed * Time.deltaTime);
            Player.Rotate( 0, 0, -(rotateSpeed/5) * Time.deltaTime);
        }
	}
}
