using UnityEngine;

public class Rotator : MonoBehaviour {
	
	//Giúp các vòng tròn quay
	public float speed = 100f;

	void Update () {
		transform.Rotate(0f, 0f, speed * Time.deltaTime);
	}
}
