using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    List<GameObject> lightShaftObjs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).transform.Find("LightIcos").transform.Find("LightShaft45").gameObject;
            lightShaftObjs.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in lightShaftObjs)
        {
            Debug.Log(obj.name);
            obj.GetComponent<Renderer>().material.color *= new Color(0.9f, 0.9f, 0.9f);
        }
    }
}
