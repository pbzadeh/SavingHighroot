using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{

    public static CoinCounter instance;
    public TMP_Text coinText;
    public int coinCount;
    // Start is called before the first frame update
    private void Awake(){
        instance = this; 
    }
    void Start()
    {
            coinText.text = "MONEY: " + coinCount.ToString();
    }

    public void increaseCoins(int v){
        coinCount += v;
        coinText.text = "MONEY: " + coinCount.ToString();
    }
    public void SetCoinText(TMP_Text newText) {
    coinText = newText;
    coinText.text = "MONEY: " + coinCount.ToString();
    }
}
