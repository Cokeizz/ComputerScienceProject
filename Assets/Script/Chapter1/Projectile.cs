using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float direction;
    private float lifetime;
    [SerializeField]private float bombTimer = 3.0f;

    private Rigidbody2D rb;
    private Animator anim;
    //private BoxCollider2D boxCollider;

    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField]private BoxCollider2D boxCollider;
    [SerializeField]private LayerMask playerLayer;
   // private float cooldownTimer = Mathf.Infinity;

    private Health playerHealth;
   
    private void Awake()
    {
       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
      //  boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        lifetime += Time.deltaTime;
        if (lifetime > bombTimer) 
            OnBomb();
           // break;
           //anim.SetTrigger("explode");
            //gameObject.SetActive(false);

    }
    private void OnBomb()
    {
        boxCollider.enabled = true;
        anim.SetTrigger("explode");
        lifetime = 0;
        DamageEnemy();
        Debug.Log("Exploded");
        
        //gameObject.SetActive(false);
    }
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
       
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private bool EnemyInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center+transform.right*range*transform.localScale.x*colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left,0,playerLayer);

        if(hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();
        return hit.collider != null;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center+transform.right*range*transform.localScale.x*colliderDistance, 
       new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * range, boxCollider.bounds.size.z));
    }

    private void DamageEnemy()
    {
            //Damage health
            if(EnemyInSight())
            {
                 Debug.Log("IN");
                playerHealth.TakeDamage(damage);
                Debug.Log(playerHealth.currentHealth);
            }
    }

    
    
}