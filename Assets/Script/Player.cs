using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    float _score = 0f;
    private Animator anim;
    float lenghtinZaxis = 7.6f;
    float gaplength = 9f;
    Vector3 LastPosition;
    [SerializeField]
    GameObject platform;
    [SerializeField]
    Transform firstobject;
    int score = 0;
    [SerializeField]
    Text scoreUI;
	void Start () 
	{
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f,0f,speed);
        LastPosition = firstobject.transform.position;
        InvokeRepeating("Spawning",0f,0.3f);
	}

    private void ScoreUpdate()
    {
        
        _score += 5f * Time.deltaTime;
        score = Mathf.RoundToInt(_score);
        scoreUI.text = score.ToString();
    }
     
    private void Spawning()
    {
        GameObject _Object = Instantiate(platform) as GameObject;
        _Object.transform.position = LastPosition + new Vector3(0f,0f,9f);
        LastPosition = _Object.transform.position;
    }

	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(0f,5f,0f, ForceMode.Impulse);
            anim.SetBool("isrunning", false);
            anim.Play("Jumping");
        }
        ScoreUpdate();
	}
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Water")
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        Debug.Log("Game Over");
    }
}
