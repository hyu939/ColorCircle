using UnityEngine;
using UnityEngine.UI;

public class Ctrl_Skin : MonoBehaviour
{
    //public Save saveUseSkin;
    public Shopscore shopScore;
    public int skinId;
    public string thisSkin;
    public Text isUse;
    public int isBuySkin;

    public int prize;

    // Start is called before the first frame update
    void Start()
    {
        // saveUseSkin = GetComponent<Save>();
        isBuySkin = PlayerPrefs.GetInt(thisSkin, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if(isBuySkin == 0 && thisSkin != saveUseSkin.currentSkin){
        if (isBuySkin == 0 && thisSkin != Save.Instance.currentSkin)
        {
             isUse.text = prize+"$";
        }
        else isUse.text = (Save.Instance.currentSkin == thisSkin) ? isUse.text = "USED" : isUse.text = "USE";
    }

    public void BuySkin(){
        if(isBuySkin == 0 && Save.Instance.scoreShop >= prize){
            // saveUseSkin.scoreShop = saveUseSkin.scoreShop - prize;
            shopScore.ScoreShopMinus(-prize);
            isBuySkin = 1;
            PlayerPrefs.SetInt(thisSkin, isBuySkin);
        }
        if(isBuySkin == 1){
            Save.Instance.currentSkin = thisSkin;
            Save.Instance.SaveCurretSkin();
            Save.Instance.skinId = skinId;
            Save.Instance.SaveSkinId();
        }
    }
}
