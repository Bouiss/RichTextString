using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RTS;

public class ExampleRTS : MonoBehaviour
{

    // this is only for test the RTString ! 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(RTString("The Sky is Blue !!!! ", Color.blue, true, false));
            Debug.Log(RTString("The Sky is Blue ! ", Color.blue, true, false)+" "+ RTS.RTString("And Love Is Pink !!!! ", "#E43CFF", false, true));
        }
    }

}
