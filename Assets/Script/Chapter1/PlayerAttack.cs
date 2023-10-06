using UnityEngine;
using XboxCtrlrInput;
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
    private bool[] bombs_status = {false,false,false};

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
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
        bombs[0].transform.position = bombPoint.position;
        bombs[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        throwBombSFX.Play();
        onBombSFX.Play();
    }
   
}
