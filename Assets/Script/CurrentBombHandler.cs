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
        String line;
            try
            {
                string filePath = Path.Combine(Application.dataPath, "Script/CurrentBomb.txt");
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                this.currentBomb = line;
                Debug.Log(line); 
                //close the file
                sr.Close();

            }
            catch(Exception e)
            {
                Debug.Log("Exception: " + e.Message);
            }
            finally
            {
                Debug.Log("Executing finally block.");
            }
    }

    public void WriteCurrentBomb(){
    try
        {
            string filePath = Path.Combine(Application.dataPath, "Script/CurrentBomb.txt");
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine(this.currentBomb);
            sw.Close();
        }
        catch (Exception e)
        {

            Debug.Log("Exception: " + e.Message);
        }
        finally
        {

            Debug.Log("Executing finally block.");
        }
    }

     public void ReadHasBomb(){
        String line;
            try
            {
                string filePath = Path.Combine(Application.dataPath, "Script/hasBomb.txt");
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                this.hasBomb = line;
                Debug.Log(line); 
                //close the file
                sr.Close();

            }
            catch(Exception e)
            {
                Debug.Log("Exception: " + e.Message);
            }
            finally
            {
                Debug.Log("Executing finally block.");
            }
    }
}
