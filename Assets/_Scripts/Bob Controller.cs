using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BobController : MonoBehaviour
{
    public int Lives = 3;
    public bool Won = false;
    public bool PowerUp = false;
    public int highscore = 0;

    [SerializeField]
    public BobAnimations bobAnimations;
    private WordScript projectile;

    private bool isDefeatPlaying = false;
    private bool isVictoryPlaying = false;

    private void Start()
    {
        projectile = GetComponent<WordScript>();
    }

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
        if (collision.gameObject.tag == "Enemy")
        {
            
            projectile = collision.gameObject.GetComponentInChildren<WordScript>();
            Debug.Log(projectile.isWordComplete);
            if (!projectile.isWordComplete)
            {
                Lives--;
            } else
            {
                bobAnimations.SetAnimationBool("Swing", true);
                highscore++;
            }
            if (Lives <= 0 && !isDefeatPlaying)
            {
                bobAnimations.SetAnimationBool("Defeat", true);
                isDefeatPlaying = true;
            }
            Destroy(collision.gameObject);
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
