using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaulUIPosition : MonoBehaviour {
    public DraggableUI[] standardPos;
    void Start() {
        standardPos[0].GetComponent<Transform>().transform.localPosition = new Vector3(607, -217, 0);      //Joystick
        standardPos[1].GetComponent<Transform>().transform.localPosition = new Vector3(-518, -242, 0);     //Fire Button
        standardPos[2].GetComponent<Transform>().transform.localPosition = new Vector3(-559, 56, 0);       //Switch Button
        standardPos[3].GetComponent<Transform>().transform.localPosition = new Vector3(855, 220, 0);       //Retry Button
        standardPos[4].GetComponent<Transform>().transform.localPosition = new Vector3(-785, -283.7f, 33); //Throttle Slider
        standardPos[5].GetComponent<Transform>().transform.localPosition = new Vector3(-540, 364.7f, 0);   //Info 
        standardPos[6].GetComponent<Transform>().transform.localPosition = new Vector3(436, -53, 0);       //Speed Boost Button
        standardPos[7].GetComponent<Transform>().transform.localPosition = new Vector3(577, -11, 0);       //Shield Button
        standardPos[8].GetComponent<Transform>().transform.localPosition = new Vector3(712, -11, 0);       //Flare Button
    }
    public DraggableUI[] getStandardPos() { return standardPos; }
}
