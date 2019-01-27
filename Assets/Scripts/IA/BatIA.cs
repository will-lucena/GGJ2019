using UnityEngine;

public class BatIA : IA
{
    [Range(1, 3)]
    [SerializeField] private float atk;
    [SerializeField] private Vector3 target;
    [SerializeField] private float flySpeed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        FleeBehaviour.startFlee += flee;
    }

    private void FixedUpdate()
    {
        if (animator.GetBool("isAttacking"))
        {
            transform.Translate(target * Time.deltaTime * flySpeed);
        }

        if (Vector3.Distance(transform.position, target) < 1f && animator.GetBool("isAttacking"))
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("flee", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger enter");
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.transform.position;
            animator.SetBool("isAttacking", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!collision.gameObject.GetComponent<Animator>().GetBool("isAttacking"))
            {
                collision.gameObject.GetComponent<Player>().receiveDamage(atk);
            }
        }
    }
    private void turnOff()
    {
        Destroy(gameObject);
    }

    private void flee()
    {
        rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
        Invoke("turnOff", 3f);
    }
}
