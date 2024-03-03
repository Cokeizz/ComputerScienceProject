using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using TMPro;


public class CoinHandler : MonoBehaviour
{
    [SerializeField] TMP_Text coinText;
    private String cointxt ="10000";
    private int updateCoin;
    // Start is called before the first frame update
    void Start()
    {

       ReadCoin();
       coinText.text = cointxt + "X" ;
    }
     void Update()
    {
    }

    public void WriteCoin(){
        this.updateCoin = CoinCounter.instance.UpdateCoin() + int.Parse(cointxt);


    try
        {
            string filePath = Path.Combine(Application.dataPath, "Script/Coin.txt");
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine(this.updateCoin);
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

    public void ReadCoin(){
        String line;
            try
            {
                string filePath = Path.Combine(Application.dataPath, "Script/Coin.txt");
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                cointxt = line;
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
