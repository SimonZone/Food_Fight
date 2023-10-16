using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MonsterMovement : MonoBehaviour
{

    public float speed = 1.0f;



    public bool vertiacal = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.position;
        if (vertiacal == false)
        {
            move.x += speed * Time.deltaTime;
            Debug.Log("Hors" + speed);
        } 
        else
        {
            move.y += speed * Time.deltaTime;
            Debug.Log("Vert" + speed);
        }
        transform.position = move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            speed *= -1.0f;
            Debug.Log("Hit collision");
        } 
    }
}
