using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class WordScript : MonoBehaviour
{
    public TextMeshProUGUI wordUnderProjectile;
    private List<string> wordBankBackup = new() { 
    "unicorn", "spaceship", "chocolate", "umbrella", "giraffe", "keyboard", "rainbow", "bookshelf", "sunglasses", "waterfall",
    "treasure", "fireworks", "penguin", "telescope", "whale", "mystery", "carousel", "adventure", "trampoline",
    "parachute", "magnifier", "wonderland", "tornado", "candlelight", "riddle", "bubblegum", "galaxy", "zeppelin", "kangaroo",
    "mermaid", "volcano", "moonlight", "quicksand", "harmonica", "coconut", "accordion", "caterpillar", "firefly", "jellyfish",
    "snowflake", "toothbrush", "pajamas", "garden gnome", "rollercoaster", "whirlwind", "dreamcatcher", "chameleon", "robot",
    "wristwatch", "chimney", "mosquito", "sandcastle", "butterfly", "gumball", "trebuchet", "locomotive", "pinwheel", "dragon",
    "stethoscope", "kaleidoscope", "top hat", "umbrella", "astronaut", "marionette", "lighthouse", "glowstick", "plutonium",
    "guitar", "bicycle", "narwhal", "kettle", "toucan", "gazelle", "plasma", "origami", "candelabra", "whisk", "piano",
    "hoverboard", "boomerang", "quokka", "steampunk", "velociraptor", "sorcerer", "sasquatch",
    "sandstorm", "bagpipes", "snowman", "lemur", "toothpaste", "sherbet", "gargoyle", "jackalope", "sunflower", 
    "cat", "dog", "hat", "red", "sun", "moon", "tree", "frog", "pen", "blue",
    "rose", "king", "ball", "fish", "bird", "book", "cake", "door", "rain", "sock",
    "lamp", "star", "ship", "fire", "leaf", "key", "coin", "gold", "rose", "bell",
    "wine", "song", "ring", "baby", "lion", "leaf", "pear", "deer", "hand", "fish",
    "star", "rose", "moon", "blue", "bird", "lamp", "book", "rose", "frog", "door"
    };

    public string currentWord;
    private string remainingWord;
    public bool isWordComplete;
    private int currentIndex = 0;

    public TextAsset jsonFile;
    public List<string> wordBank;

    void Start()
    {
        // lags everytime, need to find another way
        if (jsonFile != null)
        {
            string textData = jsonFile.text;
            string[] lines = textData.Split('\n');

            foreach (string line in lines)
            {
                string CleanedLine = CleanString(line);
                if (!string.IsNullOrEmpty(CleanedLine) && IsAlphabetic(CleanedLine))
                {
                    
                    wordBank.Add(CleanedLine);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Debug.Log(wordBank[i]);
            }
            Debug.Log(wordBank.Count);
        }
        else
        {
            //Debug.Log("JSON file is not assigned.");
            wordBank = wordBankBackup;
        }

        int randomInt = Random.Range(0, wordBank.Count);
        currentWord = wordBank[randomInt];
        wordUnderProjectile.text = currentWord;
        wordUnderProjectile.SetText($"" +
            $"{currentWord.AddColor(Color.red)}");
        SetCurrentWord();
    }
    public void SetCurrentWord()
    {

        SetRemainingWord(currentWord);
    }

    public void SetRemainingWord(string word)
    {
        remainingWord = word;
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
            currentIndex++;
            ColorLetter();
            if (remainingWord.Length == 0)
            {
                isWordComplete = true;
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void ColorLetter()
    {
        string letterToPaint = "";
        string letterNotToPaint = "";

        for (int i = 0; i < currentWord.Length; i++)
        {
            if (i < currentIndex)
            {
                letterToPaint += currentWord[i];
            } else if (i >= currentIndex)
            {
                letterNotToPaint += currentWord[i];
            }
        }
        //Debug.Log("word that is being changed: " + letterToPaint + " - " + letterNotToPaint);

        wordUnderProjectile.SetText($"" +
            $"{letterToPaint.AddColor(Color.green)}" +
            $"{letterNotToPaint.AddColor(Color.red)}");
        //wordUnderProjectile.SetText($"" +
        //    $"{"H".AddColor(Color.red)}" +
        //    $"{"E".AddColor(Color.blue)}" +
        //    $"{"L".AddColor(Color.green)}" +
        //    $"{"L".AddColor(Color.white)}" +
        //    $"{"O".AddColor(Color.yellow)}");
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }
    static bool IsAlphabetic(string text)
    {
        foreach (char c in text)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        return true;
    }
    string CleanString(string text)
    {
        // Use a regular expression to remove non-letter characters
        string cleaned = Regex.Replace(text, "[^a-zA-Z ]", "");
        // Trim spaces from the sides
        return cleaned.Trim();
    }
}

public static class StringExtensions
{
    public static string AddColor(this string text, Color col) => $"<color={ColorHexFromUnityColor(col)}>{text}</color>";
    public static string ColorHexFromUnityColor(this Color unityColor) => $"#{ColorUtility.ToHtmlStringRGBA(unityColor)}";
}