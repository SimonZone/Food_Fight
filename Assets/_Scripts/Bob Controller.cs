using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BobController : MonoBehaviour
{
    public int Lives = 3;
    public bool Won = false;
    public bool PowerUp = false;
    [SerializeField]
    public BobAnimations bobAnimations;

    private bool isDefeatPlaying = false;
    private bool isVictoryPlaying = false;

    void FixedUpdate()
    {
        Swing();

        if (Won && !isVictoryPlaying)
        {
            // Play the victory animation only if it's not already playing
            bobAnimations.SetAnimationBool("Victory", true);
            isVictoryPlaying = true;
        }

        OnPowerUp();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("player got hit by something");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("player got hit by " + collision.gameObject.tag);
            Destroy(collision.gameObject);
            Lives--;
            Debug.Log("current lives: " + Lives);

            if (Lives <= 0 && !isDefeatPlaying)
            {
                Debug.Log("Player defeated");
                bobAnimations.SetAnimationBool("Defeat", true);
                isDefeatPlaying = true;
            }
        }
    }

    private void Swing()
    {
        if (Input.GetKey(KeyCode.S))
        {
            bobAnimations.SetAnimationBool("Swing",true);
        } 
        else
        {
            bobAnimations.SetAnimationBool("Swing", false);
        }
    }

    private void OnPowerUp()
    {
        if (PowerUp)
        {
            bobAnimations.SetAnimationBool("PowerUp", true);
            PowerUp = false;
        }
    }
}
