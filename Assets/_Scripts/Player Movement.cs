using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1.0f;
    public int powerUps = 0;
    public int Lives = 3;

    [field:SerializeField]
    public UnityEvent OnCollect { set; get; }
    [field: SerializeField]
    public UnityEvent OnHitEnemy { set; get; }
    [field: SerializeField]
    public UnityEvent OnDie { set; get; }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            move.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.y -= speed * Time.deltaTime;
        }

        transform.position = move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision tag: " + collision.gameObject);

        if (collision.gameObject.CompareTag("PowerUp")) 
        {
            this.Lives++;
            Debug.Log("Current Lives: " + Lives);
            OnCollect.Invoke();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Monster"))
        {
            this.Lives--;
            Debug.Log("Current Lives: " + Lives);
            OnHitEnemy.Invoke();
            if (this.Lives <= 0) { OnDie.Invoke(); gameObject.SetActive(false); }
        }

    }
}
