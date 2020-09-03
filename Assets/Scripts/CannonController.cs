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
    private bool can_shoot;

    void Start()
    {
        t = 0.01f;
        can_shoot = true;
    }

    private void Shoot()
    {
        spawn_position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ball = Instantiate(ball_prefab, spawn_position, transform.rotation) as GameObject;
        ball.transform.tag = gameObject.transform.tag;
        startPosx = ball.transform.Find("start_pos");
        finishPosx = ball.transform.Find("finish_pos");
        can_shoot = false;
    }

    private void OnMouseDown()
    {
        if(can_shoot)
        {
            Shoot();
            StartCoroutine(DestroyBall());
        }
    }

    private IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(ball);
        can_shoot = true;
    }

    void FixedUpdate()
    {
        if(ball != null)
        {
            ball.transform.position = Vector3.Lerp(startPosx.transform.transform.position, finishPosx.transform.position, t);
            t += 0.05f;
        }
    }


}
