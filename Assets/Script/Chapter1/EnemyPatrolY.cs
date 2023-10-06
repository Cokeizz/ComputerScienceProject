using UnityEngine;

public class EnemyPatrolY : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform topEdge;
    [SerializeField] private Transform bottomEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void Update()
    {
        enemy.localRotation = Quaternion.Euler(0, 0, 0);
        if (movingLeft)
        {
            if (enemy.position.y >= topEdge.position.y)
            {
                MoveInDirection(-1);
                enemy.localScale = new Vector3(2,2,2);
            }
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.y <= bottomEdge.position.y)
            {
                MoveInDirection(1);
                enemy.localScale = new Vector3(-2,2,2);
            }
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(initScale.x,
            Mathf.Abs(initScale.y) * _direction, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x,
            enemy.position.y + Time.deltaTime * _direction * speed, enemy.position.z);
    }
}