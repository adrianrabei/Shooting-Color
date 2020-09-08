using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChanger : MonoBehaviour
{
    
    public Material m_red;
    public Material m_blue;
    public Material m_green;
    public Material m_yellow;
    private Material cube_mat;
    [SerializeField] private Material target;
    private int coloredToWin;
    private int sceneIndex;
    private GameObject[] colored;

    void Start()
    {
        cube_mat = GetComponent<Renderer>().material;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        coloredToWin = PlayerPrefs.GetInt("Colored to win lvl:" + sceneIndex);
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        cube_mat.color = other.gameObject.GetComponent<Renderer>().material.color;
        StartCoroutine(CheckCubeColor());
    }

    private IEnumerator CheckCubeColor()
    {
        yield return new WaitForSeconds(1f);

        if(cube_mat.color == target.color)
        {
            gameObject.transform.tag = "Colored";
            colored = GameObject.FindGameObjectsWithTag("Colored");
            if (colored.Length == coloredToWin)
            {
                GameManager.levelPassed = true;
            }
        }
        
    }
}
