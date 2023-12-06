using UnityEngine;

public class Circle_G2_Script : MonoBehaviour
{
    public GameObject circle;
    public float m_Scale;

    void Start()
    {
        //Khi sinh ra quay góc ngẫu nhiên
        int rand = Random.Range(-180,180);
        circle.transform.localRotation = Quaternion.Euler(new Vector3(0,0,rand));
    }

    void Update()
    {
        //Thu nhỏ đến khi = 0 thì phá hủy
        circle.transform.localScale -= new Vector3(m_Scale * Time.deltaTime, m_Scale * Time.deltaTime, m_Scale * Time.deltaTime);
        if(circle.transform.localScale.x <= 0){
            Destroy(gameObject);
        }
    }
}
