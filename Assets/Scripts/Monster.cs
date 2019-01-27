using UnityEngine;

public class Monster : MonoBehaviour
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

    public void takeDamage(float damage)
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
