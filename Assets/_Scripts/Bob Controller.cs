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

    void Update()
    {
        Swing();

        if (Lives <= 0 && !isDefeatPlaying)
        {
            // Play the defeat animation only if it's not already playing
            bobAnimations.SetAnimationBool("Defeat", true);
            isDefeatPlaying = true;
        }

        if (Won && !isVictoryPlaying)
        {
            // Play the victory animation only if it's not already playing
            bobAnimations.SetAnimationBool("Victory", true);
            isVictoryPlaying = true;
        }

        OnPowerUp();
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
        else
        {
            bobAnimations.SetAnimationBool("PowerUp", false);
        }
    }
}
