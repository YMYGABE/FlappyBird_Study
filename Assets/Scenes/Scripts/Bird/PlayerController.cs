using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D bird;
    public Animator animator;
    public CircleCollider2D circle;
    public PipleManager pipleManager;
    private Vector3 InitPosition;
    public float force;
    public bool isStart = false;
    public bool isLive = true;
    private void Start()
    {
        this.Idle();
        InitPosition = this.transform.position;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isStart && isLive)
        {
            bird.velocity = Vector2.zero;
            bird.AddForce(new Vector2(0, force), ForceMode2D.Force);
        }
    }
    public void Init()
    {
        this.transform.position = InitPosition;
        Idle();
        isLive = true;
    }
    public void Fly()
    {
        this.bird.simulated = true;
        isStart = true;
        this.animator.SetTrigger("Fly");
    }

    public void Idle()
    {
        this.bird.simulated = false;
        this.animator.SetTrigger("Idle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pase")
        {
            //Debug.Log("pase");
            UIManager.Instance.AddScore();
        }
        else if(collision.gameObject.tag == "Death")
        {
            this.animator.SetTrigger("Death");
            isLive = false;
            pipleManager.StopRun();
            pipleManager.Init();
            UIManager.Instance.GameOver();
        }
    }

}
