using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject main, game, settings, win;
    public bool isActive;
    [SerializeField] private ParticleSystem win_partciles;
    private int sceneIndex;

    void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.GetInt("level", 0) == sceneIndex)
        {

        }
        else SceneManager.LoadScene(PlayerPrefs.GetInt("level", 0));
    }

    void Start()
    {
        game.SetActive(false);
        main.SetActive(true);

        if (DontDestroy.wasPlayed)
        {
            Play();
            main.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    public void Win()
    {
        win.SetActive(true);
        win_partciles.Play();
        PlayerPrefs.SetInt("level", sceneIndex + 1);
    }

    public void Play()
    {
        isActive = true;
        game.SetActive(true);
        DontDestroy.wasPlayed = true;
    }

    public void Settings()
    {
        game.SetActive(false);
        isActive = false;
    }

    public void Vibration()
    {
        if (PlayerPrefs.GetInt("vibration", 1) == 0)
        {
            return;
        }
        Handheld.Vibrate();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
