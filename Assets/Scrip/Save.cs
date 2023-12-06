using UnityEngine;


public class Save : MonoBehaviour
{
    public static Save Instance;
    public string currentSkin;
    public int skinId;
    public int scoreShop;
    [SerializeField] public SkinSprite[] skinBalls;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        currentSkin = PlayerPrefs.GetString("currentSkin", "defaultSkin");
        skinId = PlayerPrefs.GetInt("skinId", 0);
        scoreShop = PlayerPrefs.GetInt("scoreShop", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("p")){
            scoreShop = scoreShop + 10000;
        }
    }

    public void SaveCurretSkin()
    {
        PlayerPrefs.SetString("currentSkin", currentSkin);
    }

    public void SaveSkinId()
    {
        PlayerPrefs.SetInt("skinId", skinId);
    }

    public void SaveScoreShop(int index)
    {
        scoreShop += index;
        PlayerPrefs.SetInt("scoreShop", scoreShop);
    }

}

[System.Serializable]
public class SkinSprite
{
    public int skinId;
    public string skinName;
    public Sprite colorCyan;
    public Sprite colorYellow;
    public Sprite colorMagenta;
    public Sprite colorPink;
}