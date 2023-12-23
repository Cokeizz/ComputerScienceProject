using XboxCtrlrInput;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using TMPro;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform bombPoint;
    [SerializeField] private GameObject[] bombs;
    [SerializeField] private AudioSource throwBombSFX;
     [SerializeField]private AudioSource onBombSFX;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private String CurrentBomb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        ReadCurrentBomb();
    }

    private void Update()
    {
        if ((Input.GetKey(KeyCode.X) || XCI.GetButton(XboxButton.A)) && cooldownTimer > attackCooldown )
            Attack();
             cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 3;
        bombs[int.Parse(CurrentBomb)].transform.position = bombPoint.position;
        bombs[int.Parse(CurrentBomb)].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        throwBombSFX.Play();
        onBombSFX.Play();
    }

     public void ReadCurrentBomb(){
        String line;
            try
            {
                string filePath = Path.Combine(Application.dataPath, "Script/CurrentBomb.txt");
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                CurrentBomb = line;
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
