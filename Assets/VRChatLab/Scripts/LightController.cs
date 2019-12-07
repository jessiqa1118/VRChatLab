using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using FaderController;
using System;

public class LightController : MonoBehaviour
{
    List<GameObject> lightShaftObjs = new List<GameObject>();
    List<Color> baseColors = new List<Color>();
    List<Fader> faders = new List<Fader>();
    string midiControllerName;
    int faderNum;

    // Start is called before the first frame update
    void Start()
    {
        faderNum = 8;
        midiControllerName = "nanoKONTROL2";

        // Fader setting
        for (int i = 0; i < faderNum; i++)
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
            baseColors.Add(obj.GetComponent<Renderer>().material.color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < faderNum; i++)
        //{
        //    Debug.Log(MidiMaster.GetKnob(MidiChannel.Ch1, i));
        //}
        //foreach (GameObject obj in lightShaftObjs)
        for (int i=0; i<lightShaftObjs.Count; i++)
        {
            float w = MidiMaster.GetKnob(MidiChannel.Ch1, 0);
            //Debug.Log(obj.name);
            lightShaftObjs[i].GetComponent<Renderer>().material.color = baseColors[i] * w;
        }
    }
}
