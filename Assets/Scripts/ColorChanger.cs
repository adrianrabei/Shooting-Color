using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChanger : MonoBehaviour
{

    [SerializeField] private GameManager game_manager;
    [SerializeField]private Material m_red;
    [SerializeField] private Material m_blue;
    [SerializeField] private Material m_green;
    [SerializeField] private Material m_yellow;
    private Material cube_mat;
    [SerializeField] private Material target;
    private int sceneIndex;
    private GameObject[] colored;
    private GameObject[] cubesCount;

    void Start()
    {
        cube_mat = GetComponent<Renderer>().material;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        cubesCount = GameObject.FindGameObjectsWithTag("Cube");
        PlayerPrefs.SetInt("Colored to win lvl:" + sceneIndex, cubesCount.Length);
        //Debug.Log(PlayerPrefs.GetInt("Colored to win lvl:" + sceneIndex, cubesCount.Length));
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        cube_mat.color = other.gameObject.GetComponent<Renderer>().material.color;
        CheckCubeColor();
        StartCoroutine(Counter());

    }

    private void CheckCubeColor()
    {
        if(cube_mat.color == target.color)
        {
            gameObject.transform.tag = "Colored";
        }
        else
        {
            gameObject.transform.tag = "Cube";
        }

    }

    private IEnumerator Counter()
    {
        yield return new WaitForSeconds(1f);

        colored = GameObject.FindGameObjectsWithTag("Colored");
        Debug.Log("Colored: " + colored.Length);
        if (colored.Length == PlayerPrefs.GetInt("Colored to win lvl:" + sceneIndex))
        {
            game_manager.Win();
        }
    }
}
