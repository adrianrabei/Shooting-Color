using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    
    public Material m_red;
    public Material m_blue;
    public Material m_green;
    public Material m_yellow;
    private Material obj_mat;

    void Start()
    {
        obj_mat = GetComponent<Renderer>().material;    
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
        }
        else if(other.gameObject.transform.tag == "BlueBall")
        {
            ChangeColor("Blue");
        }
        else if(other.gameObject.transform.tag == "GreenBall")
        {
            ChangeColor("Green");
        }
        else 
        {
            ChangeColor("Yellow");
        }
    }
}
