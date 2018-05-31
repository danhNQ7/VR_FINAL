using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject
{
    //Use Singleton to get object
    private static GetObject _instance = null;
    public static GetObject Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GetObject();
            }
            return _instance;
        }
    }
    private GetObject() { }
 
    private Dictionary<string, GameObject> _dict = new Dictionary<string, GameObject>();
    public GameObject GetGameObject(string path)
    {
        if (_dict.ContainsKey(path) == false)
            _dict.Add(path, Resources.Load<GameObject>(path));
        return _dict[path];
    }

}
