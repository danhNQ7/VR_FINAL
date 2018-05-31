using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}

    new void Destroy()
    {
        if (transform.parent.position.z < -2f)
        {
            Destroy(this.gameObject);
        }

    }
    void Update()
    {
        if (this.tag == "item")
            this.transform.Rotate(Vector3.up * Variables.speed * 5f);
        Destroy();
    }
}
