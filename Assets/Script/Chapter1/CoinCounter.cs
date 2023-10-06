using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text coinText;
    public int currentCoin = 0;
    [SerializeField]private AudioSource coinCollectSFX;
    // Start is called before the first frame update
    void Awake() {
        instance = this;
    }

    void Start()
    {
        coinText.text = currentCoin.ToString()+"x";
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = currentCoin.ToString()+"x";
    }
    public void IncreaseCoins(){
        currentCoin += 1 ;
        coinCollectSFX.Play();
    }
}
