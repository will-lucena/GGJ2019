using UnityEngine;

public class Monster : MonoBehaviour, IHittable
{
    [SerializeField] private Enums.MonsterClasses type;
    [Range(1, 5)]
    [SerializeField] private float hp;
    [SerializeField] private Word drop;
    [SerializeField] private Movement movement;
    private IA behaviour;
    
    private void Awake()
    {
        behaviour = GetComponent<IA>();
        behaviour.speed = movement.speed;
    }

    public void receiveDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            if (drop)
            {
                Debug.Log("drop word");
            }
            Destroy(gameObject);
        }
    }
}
