using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
	Rigidbody rb;
    //HP
    public int hp;
    public Text hpt;
	//Пуля
	public GameObject bullet;
    GameObject bulletClone;
    Rigidbody rbBullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        hp = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.AddForce(transform.forward * moveVertical * 40f);
        transform.Rotate(0, moveHorizontal*5f, 0);
        rb.AddForce(moveHorizontal * transform.right * 40f);

        if(Input.GetButtonDown("Fire1")){
            bulletClone = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Quaternion.identity);
            rbBullet = bulletClone.GetComponent<Rigidbody>();
            rbBullet.AddForce(transform.forward * 500f);
    }

        
}
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {   
            hp = hp - 1;
            hpt.text = "HP: " + hp;
            Debug.Log(hp);

            if(hp<=0)
            {
                SceneManager.LoadScene(1);
                hp=100;
            }
        }  
    }

    }
