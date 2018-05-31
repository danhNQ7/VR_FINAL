using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : BaseClass {

	// Use this for initialization
	void Start () {
		
	}
	new void Destroy()
    {
        //Khi mỗi BackGround chạy hết đoạn đường thì quay lại 
        if (this.transform.position.z <= Variables.minZ)
        {
            Vector3 pos = this.transform.position;
            pos.z = Variables.maxBGZ;
            this.transform.position = pos;
        }
    }
	// Update is called once per frame
	void Update () {
        Update_frame();
        Destroy();
	}
}
