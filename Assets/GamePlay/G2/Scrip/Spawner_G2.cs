using UnityEngine;

public class Spawner_G2 : MonoBehaviour
{
    private float startTimeBetween = 2.5f;
    float timeBetween;
    public GameObject circle;
    public UI_G2_Ctrl pause;

    // Update is called once per frame
    void Update()
    {
        if(timeBetween <= 0 && !pause.GameIsPaused){
            Instantiate(circle, transform.position,Quaternion.identity);
            timeBetween = startTimeBetween;
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}
