using Unity.Mathematics;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [Header ("Patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        MoveInDirection(1);
    }

    private void MoveInDirection(int direction)
    {
        //Розвертає лицем до цілі
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);

        //Рух до цілі

        enemy.position = new Vector3(enemy.position.x +Time.deltaTime * direction * speed,
            enemy.position.y, enemy.position.z); 
    }
}
