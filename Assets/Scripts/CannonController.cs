using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject ball_prefab;
    private GameObject ball;
    private Vector3 spawn_position;
    private float t;
    private Transform startPosx;
    private Transform finishPosx;
    private bool can_shoot;
    private Material ball_mat;
    [SerializeField] private Material m_red;
    [SerializeField] private Material m_blue;
    [SerializeField] private Material m_green;
    [SerializeField] private Material m_yellow;
    [SerializeField] private Material cannon;

    void Start()
    {
        t = 0.01f;
        can_shoot = true;
        cannon = GetComponent<Renderer>().material;
    }

    private void SpawnBall()
    {
        spawn_position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
        ball = Instantiate(ball_prefab, spawn_position, transform.rotation) as GameObject;
        ball.transform.tag = gameObject.transform.tag;
        startPosx = ball.transform.Find("start_pos");
        finishPosx = ball.transform.Find("finish_pos");
        ball_mat = ball.GetComponent<Renderer>().material;
        ball_mat.color = cannon.color;
        can_shoot = false;
    }

    private void OnMouseDown()
    {
        if(can_shoot)
        {
            SpawnBall();
            StartCoroutine(DestroyBall());
        }
    }

    private IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(1f);
        Destroy(ball);
        can_shoot = true;
    }

    void FixedUpdate()
    {
        if (ball != null)
        {
            ball.transform.position = Vector3.Lerp(startPosx.transform.transform.position, finishPosx.transform.position, t);
            t += 0.03f;
        }
    }

}
