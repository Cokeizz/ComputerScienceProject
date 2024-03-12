using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using TMPro;

public class BombShop : MonoBehaviour
{
    private int currentCoin;
    private String currentBomb;
    private String hasBomb;
    private int updateCoin;
    [SerializeField] TMP_Text coinText;
    [SerializeField] private GameObject toggleHandler;
    [SerializeField] private int index;


    void Start()
    {
        ReadHasBomb();
        alreadyHas();
    }

    
    void Update()
    {

        ReadHasBomb();

    }
    public void alreadyHas(){
        if(hasBomb[index] == '1'){
            toggleHandler.SetActive(true);
        }
    }

     public void ReadCurrentBomb(){
                this.currentBomb =  GlobalVariable.gCurrentBomb;       
    }


     public void ReadHasBomb(){
                this.hasBomb = "1111";

    }

}
