using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public string sceneToLoad;
    public void Load()
    {
        Debug.Log("Going to level " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
