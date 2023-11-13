using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Movement : MonoBehaviour
{
    private float speed = 5f;

    private GameObject bob;

    private GameObject gameManager;

    private GameManagement gameManagement;

    // Update is called once per frame
    void Update()
    {
        GameObject myGameObject = gameObject;

        speed = gameManagement.speed;
        
            myGameObject.transform.position = Vector3.MoveTowards(myGameObject.transform.position, bob.transform.position, Time.deltaTime * speed);
            //Debug.Log("Dette er farten " + speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            //Destroy(this.gameObject);
            Debug.Log("Food hit hero");
        }   
    }

    private void Start()
    {

        bob = GameObject.FindGameObjectWithTag("Hero");

        gameManager = GameObject.FindGameObjectWithTag("GameManager");


        if (gameManager.TryGetComponent(out gameManagement))
        {
            //Debug.Log("Found it");
            speed = gameManagement.speed;
        }
    }
}
