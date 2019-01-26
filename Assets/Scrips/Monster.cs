using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Enums.MonsterClass type;
    [Range(1, 3)]
    [SerializeField] private float atk;
    [Range(1, 5)]
    [SerializeField] private float hp;
    [SerializeField] private Word drop;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private Movement movement;

    private int i;
    private Rigidbody2D rb;

    [SerializeField] private Vector3[] way;
    private float hInput;
    private Vector3 nextWayPoint;
    private int currentWayPointIndex;

    private void Start()
    {
        way = buildWay();
        currentWayPointIndex = 0;
        hInput = -1;
        nextWayPoint = way[currentWayPointIndex];
        rb = GetComponent<Rigidbody2D>();
    }

    public void takeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            dropItem();
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * hInput * Time.deltaTime * movement.speed);

        if (Mathf.Abs(transform.position.x - nextWayPoint.x) < 0.1f)
        {
            currentWayPointIndex++;
            nextWayPoint = way[currentWayPointIndex % way.Length];
            hInput *= -1;
        }
        Debug.Log(nextWayPoint);
    }

    private void dropItem()
    {
        Debug.Log(name + "died and drop " + drop.ToString());
    }

    private Vector3[] buildWay()
    {
        Vector3[] array = new Vector3[wayPoints.Length];

        for (int i = 0; i < wayPoints.Length; i++)
        {
            array[i] = new Vector3(wayPoints[i].position.x, 0);
        }

        return array;
    }
}
