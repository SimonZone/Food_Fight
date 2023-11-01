using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WordScript : MonoBehaviour
{
    public TextMeshProUGUI wordUnderProjectile;
    private List<string> wordBank = new() { 
    "unicorn", "spaceship", "chocolate", "umbrella", "giraffe", "keyboard", "rainbow", "bookshelf", "sunglasses", "waterfall",
    "treasure", "fireworks", "penguin", "telescope", "whale", "mystery", "carousel", "adventure", "trampoline", "ferris wheel",
    "parachute", "magnifier", "wonderland", "tornado", "candlelight", "riddle", "bubblegum", "galaxy", "zeppelin", "kangaroo",
    "mermaid", "volcano", "moonlight", "quicksand", "harmonica", "coconut", "accordion", "caterpillar", "firefly", "jellyfish",
    "snowflake", "toothbrush", "pajamas", "garden gnome", "rollercoaster", "whirlwind", "dreamcatcher", "chameleon", "robot",
    "wristwatch", "chimney", "mosquito", "sandcastle", "butterfly", "gumball", "trebuchet", "locomotive", "pinwheel", "dragon",
    "stethoscope", "kaleidoscope", "top hat", "umbrella", "astronaut", "marionette", "lighthouse", "glowstick", "plutonium",
    "guitar", "bicycle", "narwhal", "kettle", "toucan", "gazelle", "plasma", "origami", "candelabra", "whisk", "piano",
    "hoverboard", "tardis", "wishing well", "boomerang", "quokka", "steampunk", "velociraptor", "sorcerer", "sasquatch",
    "sandstorm", "bagpipes", "snowman", "lemur", "toothpaste", "sherbet", "gargoyle", "jackalope", "sunflower", "black hole", 
    "cat", "dog", "hat", "red", "sun", "moon", "tree", "frog", "pen", "blue",
    "rose", "king", "ball", "fish", "bird", "book", "cake", "door", "rain", "sock",
    "lamp", "star", "ship", "fire", "leaf", "key", "coin", "gold", "rose", "bell",
    "wine", "song", "ring", "baby", "lion", "leaf", "pear", "deer", "hand", "fish",
    "star", "rose", "moon", "blue", "bird", "lamp", "book", "rose", "frog", "door"
    };
    public string currentWord;
    public string remainingWord;
    private bool isWordComplete;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        int randomInt = Random.Range(0, wordBank.Count);
        currentWord = wordBank[randomInt];
        wordUnderProjectile.text = currentWord;
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
            ColorLetter();

            if (IsWordComplete())
            {
                isWordComplete = true;
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        currentIndex++;
        return remainingWord.IndexOf(letter) == 0;
    }

    private void ColorLetter()
    {
        TextMeshProUGUI currentText = wordUnderProjectile;

        string letterToPaint = "";
        string letterNotToPaint = "";

        for (int i = 0; i < currentText.text.Length; i++)
        {
            if (i < currentIndex)
            {
                letterToPaint.Append( currentText.text[i]);
            } else if (i >= currentIndex)
            {
                letterNotToPaint.Append(currentText.text[i]);
            }
        }


        wordUnderProjectile.SetText($"" +
            $"{letterToPaint.AddColor(Color.green)}" +
            $"{letterNotToPaint.AddColor(Color.red)}");

        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }
}

public static class StringExtensions
{
    public static string AddColor(this string text, Color col) => $"<color={ColorHexFromUnityColor(col)}>{text}</color>";
    public static string ColorHexFromUnityColor(this Color unityColor) => $"#{ColorUtility.ToHtmlStringRGBA(unityColor)}";
}