using System.Collections;
using UnityEngine;

public class CameraRota_G2 : MonoBehaviour
{
    [SerializeField] bool _useTestBeat;
    private Vector3 startSize;

    private float speedrota = 30f;
    public AnimationCurve curve;
    private float TimeUse;
    private int beatCount;
    private bool rotaStyle = true;
    private bool rotaStyleLast = false;

    public UI_G2_Ctrl pause;

    // Start is called before the first frame update
    void Start()
    {
        beatCount = 0;
        startSize = transform.localScale;
        if(_useTestBeat) {
            StartCoroutine(TestBeat());
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (rotaStyle){
            transform.Rotate(0f, 0f, -speedrota * Time.deltaTime);
        }
         
    }

    //Đếm nhịp và thực hiện di chuyển một khoảng
    public void Pulse() {
        if(!pause.GameIsPaused){
            RotatonStyle();
            if (!rotaStyle || rotaStyleLast)
            {
                TimeUse += Time.deltaTime;
                float strength = curve.Evaluate(TimeUse / 1f);
                transform.Rotate(0f, 0f, + speedrota);
                beatCount++;
            }else{
                beatCount++;
            }
        }
    }

    // Nhịp 0: Xoay Z+
    // Nhịp 36: Xoay một khoảng hướng Z+
    // Nhịp 118: Xoay Z+ và Xoay một khoảng hướng Z+
    // Nhịp 158: Z+20 và Xoay Z+
    // Nhịp 243: Xoay một khoảng hướng Z-
    // Nhịp 272: Xoay Z- và Xoay một khoảng hướng Z-
    // Nhịp 409: Nhịp = -1
    public void RotatonStyle(){
        switch (beatCount)
        {
            case 0:
                rotaStyle = true;
                rotaStyleLast = false;
                break;
            case 36:
                rotaStyle = false;
                rotaStyleLast = false;
                break;
            case 118:
                rotaStyle = true;
                rotaStyleLast = true;
                break;
            case 158:
                rotaStyle = false;
                rotaStyleLast = false;
                speedrota = speedrota + 20;
                break;
            case 234:
                rotaStyle = true;
                speedrota = -speedrota;
                break;
            case 272:
                rotaStyle = true;
                rotaStyleLast = true;
                break;
            case 409:
                rotaStyle = true;
                beatCount = -1;
                speedrota = -speedrota;
                break;
            default:
                break;
        }
    }

    IEnumerator TestBeat(){
        while(true){
            yield return new WaitForSeconds(1f);
            Pulse();
        }
    }
}
