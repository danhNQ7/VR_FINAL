using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour{
	protected void Update_frame()
    {
        this.transform.Translate(Vector3.back * Variables.speed * Time.deltaTime);
    }
    protected bool Destroy()    
    {
        if(this.transform.position.z <= Variables.minZ)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
