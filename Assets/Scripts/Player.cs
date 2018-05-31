using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {
    public Text _score;
    public GameObject canvasResult;
    public GameObject canvas;
    public Text scoreResult;
    public AudioSource source;
    public AudioClip pickup;
    public AudioClip accident;
    public AudioClip jump;
	// Use this for initialization
	void Start () {
		
	}
    //Xử lý va chạm
    void OnTriggerEnter(Collider other)
    {
        //Xử lý va chạm với dốc
        if (other.tag == "obstacle")
        {
            source.PlayOneShot(jump);
            this.GetComponent<Rigidbody>().velocity = new Vector3(0f, 5f, 0f);
        }
        //Xử lý va chạm với Xe 
        else if (other.tag == "enemy")
        {
            source.PlayOneShot(accident);
            Destroy(other.gameObject);
            Variables.speed = 0;
            scoreResult.text = "Your Score: " + Variables.score;
            canvasResult.SetActive(true);
            canvas.SetActive(false);
        }
        else
        {
         //Earn Coin
            if (other.tag == "item")
            {
                
                source.PlayOneShot(pickup);
                Destroy(other.gameObject);
                Variables.score += 100;
                _score.text = "Score: " + Variables.score;
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
