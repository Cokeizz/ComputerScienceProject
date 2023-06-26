using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float direction;
    private float lifetime;
    [SerializeField]private float bombTimer = 3.0f;

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D boxCollider;
   
    private void Awake()
    {
       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        lifetime += Time.deltaTime;
        if (lifetime > bombTimer) 
            OnBomb();
           // anim.SetTrigger("explode");
            //gameObject.SetActive(false);
    }
    private void OnBomb()
    {
        boxCollider.enabled = true;
        anim.SetTrigger("explode");
        

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

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            collision.GetComponent<Health>().TakeDamage(1);
            Debug.Log("Hit Player");
    }
    
}