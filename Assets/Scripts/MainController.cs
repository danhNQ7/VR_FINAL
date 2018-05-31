using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainController : MonoBehaviour {

    // Use this for initialization
    public GameObject road;
    //public GameObject obstacle;
    public GameObject background;
    private float lenRoad = 1.98f;
    //private float wRoad = 1.58f;
    public Transform VRcamera;
    private float toogle = 13f;
    private int currentX = 1;
    private float currentChange = 0.5266f;
    private int flagMove = 0;//1 move left ,2 move right
    private bool flagCheck = true;
   // private bool flagCurrentLane = true;
    private float lenBG = 14f;
    private float currentPos = 0f;
// public GameObject roads;
    void Start () {
        Variables.score = 0;
        Variables.speed = 1.5f;
        //Khoi tao duong
        for (int i =0;i < 17; i++)
        {
            CreateObject(road, Vector3.forward * lenRoad * i);
        }
        //Khởi tạo ground
        for (int i = 0; i < 3; i++)
        {
            CreateObject(background, Vector3.forward * lenBG * i);
        }
	}
	void CreateObject(GameObject _go, Vector3 pos)
    {
        GameObject go = Instantiate(_go) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = pos;
    }

    int Controll()
    {
        
        if (VRcamera.eulerAngles.z > toogle && VRcamera.eulerAngles.z < 85.0f)
        {
            return 1;       
        }
        else if (VRcamera.eulerAngles.z < 360 - toogle && VRcamera.eulerAngles.z > 275.0f)
        {
            return 2;
        }
        else
        {

            //test.OnPointerUp(null);
            return 0;
        }
    }
    // Update is called once per frame
    void Update () {
        //Xử lý di chuyển
        if (flagCheck) flagMove = Controll();
        if (flagMove==1)//Queo trai 
        {
            if (flagCheck)
            {
                currentPos = this.transform.position.x;
            }
            
            if (currentX <= 1 && currentChange>=0)
            {
                flagCheck = false;
                //if (flagCurrentLane)
                //{
                //    currentX += 1;
                //    flagCurrentLane = false;
                //}
                Vector3 trans = Vector3.right * Variables.speed * Time.deltaTime;
                this.transform.Translate(trans);
                currentChange -= Mathf.Abs(trans.x);
            }
            else if (currentX < 2)
            {
                //currentX = this.transform.position.x;
                currentChange = 0.5266f;
                Vector3 temp = this.transform.position;
                temp.x= currentPos + currentChange;
                 this.transform.position = temp;

                flagCheck = true;
                if (currentX<2) currentX += 1;
            }
        }
        else if (flagMove == 2) //Queo phai
        {
            if (flagCheck)
            {
                currentPos = this.transform.position.x;
            }
            
            if (currentX >= 1 && currentChange >= 0)
            {
                flagCheck = false;
                Vector3 trans = Vector3.left * Variables.speed * Time.deltaTime;
                this.transform.Translate(trans);
                currentChange -= Mathf.Abs(trans.x);
            }
            else if (currentX>0)
            {
                if (currentX>0) currentX -= 1;
                currentChange = 0.5266f;
                Vector3 temp = this.transform.position;
                temp.x = currentPos - currentChange;
                 this.transform.position = temp;

                flagCheck = true;
            }
        }
	}
}
