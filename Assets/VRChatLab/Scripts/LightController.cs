using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using FaderController;
using System;

public class LightController : MonoBehaviour
{
    List<GameObject> lightShaftObjs = new List<GameObject>();
    List<Fader> faders = new List<Fader>();
    string midiControllerName;

    // Start is called before the first frame update
    void Start()
    {
        int faderNum = 8;
        midiControllerName = "nanoKONTROL2";

        // Fader setting
        for (int i=0; i < faderNum; i++)
        {
            byte statusByte = Convert.ToByte("B0", 16);
            byte firstDataByte = Convert.ToByte("00", 16);
            byte secondDataByte = Convert.ToByte(i);
            faders.Add(new Fader(statusByte, firstDataByte, secondDataByte));
        }

        // Object setting
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
