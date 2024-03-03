using UnityEngine;

public class Health : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float startingHealth;
    [SerializeField]private AudioSource hurtSFX;
    public float currentHealth { get; private set; }
    private Animator anim;
   
  

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

       
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
           Debug.Log("-1 {hurt}");
           hurtSFX.Play();
        }
        else
        {
           anim.SetTrigger("die");
           Debug.Log("-1 {die}");
           
        }
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void gotAttack()
    {
        body.velocity = new Vector2(8,15);
    }
   
}