using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject main, game, settings, win;
    public bool isActive;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Win()
    {
        win.SetActive(true);
    }

    public void Play()
    {
        isActive = true;
        game.SetActive(true);
    }

    public void Settings()
    {
        game.SetActive(false);
    }
}
