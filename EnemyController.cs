using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{  
    //AI
	public Transform Player;
	public NavMeshAgent Agent;
    //Score
    static int score;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Agent.SetDestination(Player.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {   
            score = score + 1;
            scoretext.text = "Score:  " + score;
            Destroy(gameObject);
            Debug.Log(score);
            if(score>=4)
            {
                SceneManager.LoadScene(0);
                score=0;
            }

        }

    }
}
