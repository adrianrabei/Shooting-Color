using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int sceneIndex;
    private GameObject[] cubesCount;
    public static bool levelPassed;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        cubesCount = GameObject.FindGameObjectsWithTag("Cube");
        PlayerPrefs.SetInt("Colored to win lvl" + sceneIndex, cubesCount.Length);
        levelPassed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelPassed)
        {
            Win();
        }
    }

    public void Win()
    {
        Debug.Log("WIN");
    }
}
