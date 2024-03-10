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
        ReadCurrentBomb();
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
        this.CurrentBomb = GlobalVariable.gCurrentBomb;       
    }
   
}
