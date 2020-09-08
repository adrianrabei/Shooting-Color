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
    private Material obj_mat;
    [SerializeField] private string targetColor;
    private int coloredToWin;
    private int sceneIndex;
    private GameObject[] colored;

    void Start()
    {
        obj_mat = GetComponent<Renderer>().material;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        coloredToWin = PlayerPrefs.GetInt("Level index:" + sceneIndex);
        
    }

    
    void Update()
    {
        
    }

    private void ChangeColor(string color_to_change)
    {
        if(color_to_change == "Red")
        {
            obj_mat.color = m_red.color;
        }
        else if(color_to_change == "Blue")
        {
            obj_mat.color = m_blue.color;
        }
        else if(color_to_change == "Green")
        {
            obj_mat.color = m_green.color;
        }
        else if(color_to_change == "Yellow")
        {
            obj_mat.color = m_yellow.color;
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RedBall")
        {
            ChangeColor("Red");
            gameObject.transform.tag = "Red";
            StartCoroutine(CheckCubeColor());


        }
        else if(other.gameObject.transform.tag == "BlueBall")
        {
            ChangeColor("Blue");
            gameObject.transform.tag = "Blue";
            StartCoroutine(CheckCubeColor());

        }
        else if(other.gameObject.transform.tag == "GreenBall")
        {
            ChangeColor("Green");
            gameObject.transform.tag = "Green";
            StartCoroutine(CheckCubeColor());

        }
        else 
        {
            ChangeColor("Yellow");
            gameObject.transform.tag = "Yellow";
            StartCoroutine(CheckCubeColor());

        }
    }

    private IEnumerator CheckCubeColor()
    {
        yield return new WaitForSeconds(1f);

        if(gameObject.transform.tag == targetColor)
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
