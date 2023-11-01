using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordScript : MonoBehaviour
{
    public TextMeshProUGUI wordUnderProjectile;
    public string[] wordBank;
    public string currentWord = "test";
    public string remainingWord;

    // Start is called before the first frame update
    void Start()
    {
        SetCurrentWord();
    }
    public void SetCurrentWord()
    {
        SetRemainingWord(currentWord);
    }

    public void SetRemainingWord(string word)
    {
        remainingWord = word;
        wordUnderProjectile.text = remainingWord;
    }
    void Update()
    {
        CheckInput();
    }
    private void CheckInput()
    {
        if (Input.anyKeyDown) 
        { 
        string keysPressed = Input.inputString.ToLower();
            if (keysPressed.Length == 1) EnterLetter(keysPressed);
        }
    }

    private void EnterLetter(string typedLetter) 
    { 
        if (IsCorrectLetter(typedLetter)) 
        {
            RemoveLetter();

            if (IsWordComplete())
            {
                SetCurrentWord();
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }
}
