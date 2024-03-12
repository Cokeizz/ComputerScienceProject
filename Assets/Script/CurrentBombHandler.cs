using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using TMPro;

public class CurrentBombHandler : MonoBehaviour
{
    //[SerializeField] private GameObject[] bombs;
    [SerializeField] TMP_Text status;
    private String currentBomb;
    private String hasBomb;
    [SerializeField] private String bombIndex;




    void Start()
    {
        ReadCurrentBomb();
    }


    void Update()
    {
        ReadCurrentBomb();
        isUsing();
        
    }
    public void toggleBomb(){
        this.currentBomb = bombIndex;
        WriteCurrentBomb();
    }
    public void isUsing(){
        if(currentBomb == bombIndex){
            status.text = "Using";
        }else{
             status.text = "USE";
        }
    }


    public void ReadCurrentBomb(){
                this.currentBomb = GlobalVariable.gCurrentBomb;       
    }

    public void WriteCurrentBomb(){
        GlobalVariable.gCurrentBomb = bombIndex;
    }

     public void ReadHasBomb(){
        this.hasBomb = "1111";
    }
}
