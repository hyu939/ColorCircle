using UnityEngine;

public class Destroylv : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col2){
        if(col2.tag == "Destroyzone"){
        //     Debug.Log("HIT");
            Destroy(gameObject);

        }
    }
}
