using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D myrigidbody2D;
    public float bulletSpeed = 10f;
    public GameManager myGameManager;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();

        myGameManager = FindFirstObjectByType<GameManager>();

        Destroy(gameObject, 3f);
    }

    void Update()
    {
        myrigidbody2D.linearVelocity = new Vector2(bulletSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood") || collision.CompareTag("ItemBad"))
        {
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
}
