 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Animator))]
public class BobAnimations : MonoBehaviour
{
    protected Animator bobAnimator;
    private void Awake()
    {
        bobAnimator = GetComponent<Animator>();
    }

    public void PlayDefeat()
    {
        bobAnimator.SetTrigger("Defeat");
    }

    public void PlayVictory()
    {
        bobAnimator.SetTrigger("Victory");
    }
    public void PlaySwing()
    {
        bobAnimator.SetTrigger("Swing");
    }
    public void PlayPowerUp()
    {
        bobAnimator.SetTrigger("PowerUp");
    }
}
