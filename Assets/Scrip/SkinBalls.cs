using UnityEngine;

public class SkinBalls : MonoBehaviour
{
    private SpriteRenderer sr;
    public string currentColor;

    void Start()
    {
		sr = GetComponent<SpriteRenderer>();
        SetColorSkin();
    }

    public void SetColorSkin ()
	{
		for(int i=0; i <= Save.Instance.skinBalls.Length; i++){
            if(i == Save.Instance.skinId)
            {
                SetRandomColor(i);
                Debug.Log("SetRandomColor");
                Debug.Log(i);
                Debug.Log(Save.Instance.skinBalls[i].skinName);

            }
        }
	}

    public void SetRandomColor(int i)
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
			case 0:
				currentColor = "Cyan";
				sr.sprite = Save.Instance.skinBalls[i].colorCyan;
				break;
			case 1:
				currentColor = "Yellow";
				sr.sprite = Save.Instance.skinBalls[i].colorYellow;
				break;
			case 2:
				currentColor = "Magenta";
				sr.sprite = Save.Instance.skinBalls[i].colorMagenta;
				break;
			case 3:
				currentColor = "Pink";
				sr.sprite = Save.Instance.skinBalls[i].colorPink;
				break;
		}
	}

}