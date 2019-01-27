using UnityEngine;

public class SlimeIA : IA
{
    [SerializeField] private Transform[] wayPoints;

    private Vector3[] way;
    private float hInput;
    private Vector3 nextWayPoint;
    private int currentWayPointIndex;

    private void Start()
    {
        way = buildWay();
        currentWayPointIndex = 0;
        hInput = -1;
        nextWayPoint = way[currentWayPointIndex];
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);

        if (Mathf.Abs(transform.position.x - nextWayPoint.x) < 0.1f)
        {
            currentWayPointIndex++;
            nextWayPoint = way[currentWayPointIndex % way.Length];
            hInput *= -1;
        }
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
