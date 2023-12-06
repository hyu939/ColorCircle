using UnityEngine;

public class Collect_levels : MonoBehaviour
{
    public Rigidbody2D[] levels; 

    private void OnValidate() {
		if(levels == null || levels.Length == 0){
			levels = GetComponentsInChildren<Rigidbody2D>();
		}
	}

}
