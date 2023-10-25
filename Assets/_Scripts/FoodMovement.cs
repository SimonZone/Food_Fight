using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        GameObject myGameObject = this.gameObject;

        GameObject targetObject = GameObject.FindGameObjectWithTag("Hero");
        
            myGameObject.transform.position = Vector3.MoveTowards(myGameObject.transform.position, targetObject.transform.position, Time.deltaTime * speed);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit collision");
        if (collision.gameObject.tag == "Hero")
        {
            Debug.Log("Hit hero");
            Destroy(this.gameObject);
        }

    }
}
