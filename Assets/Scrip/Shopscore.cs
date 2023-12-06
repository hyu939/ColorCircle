using UnityEngine;
using UnityEngine.UI;

public class Shopscore : MonoBehaviour
{
    private Text scoreShopText;

    private void Start() {
        scoreShopText = GetComponent<Text>();
        scoreShopText.text ="$ " + Save.Instance.scoreShop;
    }

    public void ScoreShopPlus(){
        Save.Instance.scoreShop++;
        scoreShopText.text ="$ " + Save.Instance.scoreShop;
    }

    public void ScoreShopMinus(int minus){
        Save.Instance.SaveScoreShop(minus);
        scoreShopText.text ="$ " + Save.Instance.scoreShop;
    }
}
