using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using UnityEditor.Rendering;
using Unity.VisualScripting;

public class BobController : MonoBehaviour
{
    public int Lives = 3;
    public bool PowerUp = false;
    public int Highscore = 0;
    public int scoreToWin = 500;

    [field: SerializeField]
    public UnityEvent OnDefeat { set; get; }
    [field: SerializeField]
    public UnityEvent OnVictory { set; get; }
    [field: SerializeField]
    public UnityEvent OnPowerUp { set; get; }
    [field: SerializeField]
    public UnityEvent Swing { set; get; }

    public TextMeshProUGUI scoreText;

    public BobAnimations bobAnimations;
    private WordScript projectile;
    public Movement foodMovement;

    private void Start()
    {
        scoreText.text = Highscore.ToString();
    }
    void FixedUpdate()
    {

        if (PowerUp)
        {
            OnPowerUp.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        projectile = collision.gameObject.GetComponentInChildren<WordScript>();
        foodMovement = collision.gameObject.GetComponentInChildren<Movement>();
       
        if (projectile != null)
        {
            //Debug.Log("Did find WordScript component, word completeness status: " + projectile.isWordComplete);
            if (!projectile.isWordComplete)
            {
                Lives--;
                Debug.Log("I got hit by something");
            }
            else
            {
                Swing.Invoke();
                Highscore += projectile.currentWord.Count();
                scoreText.text = Highscore.ToString();
                //increaseWordSpeed();
                if (Highscore >= scoreToWin)
                {
                    OnVictory.Invoke();
                }
                
                
            }
        }
        else
        {
            Debug.Log("Did not find WordScript component");
        }

        if (Lives <= 0)
        {
            OnDefeat.Invoke();
        }
        Destroy(collision.gameObject);
    }
    
}
