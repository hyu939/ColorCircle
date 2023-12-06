using UnityEngine;

public class DeadZone : MonoBehaviour
{
    //deadzone will follow camera with Y -7
    private Transform camPos;

	private void Start() {
		camPos = GameObject.FindWithTag("MainCamera").GetComponent<Transform>(); 
	}
	void Update ()
	{
		if (camPos.position.y > transform.position.y)
		{
			transform.position = new Vector3(transform.position.x, camPos.position.y -7, transform.position.z);
		}
	}
}
