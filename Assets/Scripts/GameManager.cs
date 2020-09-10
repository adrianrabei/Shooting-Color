using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject main, game, settings, win;
    public bool isActive;
    [SerializeField] private ParticleSystem win_partciles;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Win()
    {
        win.SetActive(true);
        win_partciles.Play();
    }

    public void Play()
    {
        isActive = true;
        game.SetActive(true);
    }

    public void Settings()
    {
        game.SetActive(false);
        isActive = false;
    }

    public void Resume()
    {
        game.SetActive(true);
        isActive = true;
    }

    public void Pause()
    {
        game.SetActive(false);
        isActive = false;
    }
}
