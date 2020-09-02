using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject ball_prefab;
    private GameObject ball;
    public Vector3 spawn_position;
    private float t;
    private Transform startPosx;
    private Transform finishPosx;
    private bool clicked;

    void Start()
    {
        t = 0.01f;
        clicked = false;
    }

    private void Shoot()
    {
        spawn_position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
        ball = Instantiate(ball_prefab, spawn_position, Quaternion.identity) as GameObject;
        ball.transform.tag = gameObject.transform.tag;
        startPosx = ball.transform.Find("start_pos");
        finishPosx = ball.transform.Find("finish_pos");
    }

    private void OnMouseDown()
    {
        clicked = true;
        Shoot();
    }

    void FixedUpdate()
    {
        if(clicked)
        {
            ball.transform.position = Vector3.Lerp(startPosx.transform.transform.position, finishPosx.transform.position, t);
            t += 0.05f;
        }
    }


}
