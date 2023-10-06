using UnityEngine;

public class EnemyPatrolY : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform topEdge;
    [SerializeField] private Transform bottomEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private bool movingUp;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    private void Update()
    {
        if (movingUp)
        {
            if (enemy.position.y <= topEdge.position.y)
            {
                MoveInDirection(1);
            }
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.y >= bottomEdge.position.y)
            {
                MoveInDirection(-1);
            }
            else
                DirectionChange();
        }


    }

    private void DirectionChange()
    {
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingUp = !movingUp;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        enemy.position = new Vector3(enemy.position.x, enemy.position.y + Time.deltaTime * _direction * speed, enemy.position.z);
        enemy.localRotation = Quaternion.Euler(enemy.localRotation.x, enemy.localRotation.y, -90 * _direction);

    }
}