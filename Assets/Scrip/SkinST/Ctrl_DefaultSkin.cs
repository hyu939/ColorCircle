using UnityEngine;
using UnityEngine.UI;

public class Ctrl_DefaultSkin : MonoBehaviour
{
    public int skinId;
    public string thisSkin;
    public Text isUse;
    public Save saveUseSkin;
    public int isBuy_DefaultSkin;

    public int prize;
    // public string nameSkin;

    // Start is called before the first frame update
    void Start()
    {
        isBuy_DefaultSkin = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBuy_DefaultSkin == 0 && thisSkin != Save.Instance.currentSkin){
            isUse.text = prize+"$";
        }
        else isUse.text = (Save.Instance.currentSkin == thisSkin) ? isUse.text = "USED" : isUse.text = "USE";
    }

    public void BuyDefaultSkin(){
        if(isBuy_DefaultSkin == 0){
            Save.Instance.scoreShop = Save.Instance.scoreShop - prize;
        }
        Save.Instance.currentSkin = thisSkin;
        Save.Instance.SaveCurretSkin();
        Save.Instance.skinId = skinId;
        Save.Instance.SaveSkinId();
    }
}
