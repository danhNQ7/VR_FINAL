using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : BaseClass {
    public float speed_local;
	// Use this for initialization
	void Start () {
		
	}
    
    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("nununu");
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("Trung cmnr");
    //    }
    //}
    // Update is called once per frame
    new void Destroy()
    {
        if (transform.parent.position.z < -2f)
        {
           Destroy(this.gameObject);
        }

    } 
    void Update () {
        //Debug.Log(transform.parent.position.z);
        this.transform.Translate(Vector3.back * speed_local*Variables.speed * Time.deltaTime);
        Destroy();
    }
}
