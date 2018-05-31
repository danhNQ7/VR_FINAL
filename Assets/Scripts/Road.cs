using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road :BaseClass {

    // Use this for initialization
    private float[] arr4Random = new float[] { -0.5266f, 0f, 0.5266f };
    void Start () {
		
	}

    // Update is called once per frame
    void createObstacle()
    {
        GameObject ob = GetObject.Instance.GetGameObject("Enemy" + Random.Range(1,3).ToString());
        GameObject ob2 = Instantiate(ob) as GameObject;
        ob2.transform.SetParent(this.transform);
        ob2.transform.position = this.transform.position;
        ob2.transform.Translate(Vector3.back * 1.99f / 2);

        int ind = Random.Range(0, 3);
        ob2.transform.Translate(new Vector3(arr4Random[ind], 0, 0));
    }

    void createItem()
    {
        GameObject ob = GetObject.Instance.GetGameObject("Sphere");
        GameObject ob2 = Instantiate(ob) as GameObject;
        ob2.transform.SetParent(this.transform);
        ob2.transform.position = this.transform.position;
        ob2.transform.Translate(Vector3.back * 1.99f / 2);

        int ind = Random.Range(0, 3);
        ob2.transform.Translate(new Vector3(arr4Random[ind], -0.2f, 0));
    }

    void createObsta()
    {
        GameObject ob = GetObject.Instance.GetGameObject("Obsta");
        GameObject ob2 = Instantiate(ob) as GameObject;
        ob2.transform.SetParent(this.transform);
        ob2.transform.position = this.transform.position;
        ob2.transform.Translate(Vector3.back * 1.99f / 2);
        int ind = Random.Range(0, 3);
        ob2.transform.Translate(new Vector3(arr4Random[ind], 0, 0));
    }
    new bool Destroy()
    {
        if (this.transform.position.z <= Variables.minZ)
        {
            Vector3 temp = this.transform.position;
            temp.z = Variables.maxZ;
            this.transform.position = temp;
            int ind = Random.Range(0, 5);
            if (ind <=1)
                createObstacle();
            else
               if (ind == 2 )
                createObsta();
            else
                createItem();
        }
        return false;
    }
    void Update () {
        base.Update_frame();
        Destroy();
	}
}
