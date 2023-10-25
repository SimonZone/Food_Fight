using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent OnHitEnemy { get; set; }
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    int AntalLiv = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision: " + collision.gameObject.tag);

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("the enemy has the tag: " + collision.gameObject.tag);
            this.AntalLiv--;
            if (AntalLiv > 1)
            {
                OnHitEnemy.Invoke();
                Debug.Log(this.AntalLiv);
            }
            else if (AntalLiv <= 0)
            {
                Debug.Log("Player died");
                OnDie.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
