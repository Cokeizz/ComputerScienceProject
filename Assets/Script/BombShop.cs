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
        ReadCoin();
        ReadHasBomb();
        alreadyHas();
    }

    
    void Update()
    {
        ReadCoin();
        ReadHasBomb();

    }
    public void alreadyHas(){
        if(hasBomb[index] == '1'){
            toggleHandler.SetActive(true);
        }
    }

    public void buyBomb(int BombIndex){
        if(currentCoin >= 500 && hasBomb[BombIndex] == '0' ){
             currentCoin = currentCoin - 500;

            // Convert the string to a char array
            char[] hasBombArray = hasBomb.ToCharArray();
            // Modify the char array
            hasBombArray[BombIndex] = '1';
            // Convert the char array back to a string
            hasBomb = new string(hasBombArray);
            Debug.Log("Bought Bomb");
            Debug.Log(hasBomb[1]);
            WriteCoin();
            WriteHasBomb();
            toggleHandler.SetActive(true);
        }
    }
  
     public void ReadCoin(){
        String line;
            try
            {
                string filePath = Path.Combine(Application.dataPath, "Script/Coin.txt");
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                this.currentCoin = int.Parse(line);
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
     public void WriteCoin(){
        coinText.text = this.currentCoin + "x";
    try
        {
            string filePath = Path.Combine(Application.dataPath, "Script/Coin.txt");
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine(currentCoin);
            sw.Close();
        }
        catch (Exception e)
        {

            
        }
        finally
        {

            
        }
    }
     public void ReadCurrentBomb(){
        String line;
            try
            {
                string filePath = Path.Combine(Application.dataPath, "Script/CurrentBomb.txt");
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                currentBomb = line;
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

    public void WriteHasBomb(){
    try
        {
            string filePath = Path.Combine(Application.dataPath, "Script/hasBomb.txt");
            StreamWriter sw = new StreamWriter(filePath);


            sw.WriteLine(this.hasBomb);
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






}
