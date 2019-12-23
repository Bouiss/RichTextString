using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleRTS : MonoBehaviour
{

    // this is only for test the RTString ! 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(RTS.String("The Sky is Blue !!!! ", RTS.Color(Color.blue), RTS.Bold()));
            Debug.Log(string.Format("{0} {1}",
                RTS.String("The Sky is Blue ! ", RTS.Color(Color.blue), RTS.Bold()),
                RTS.String("And Love Is Pink !!!! ", RTS.Size(20), RTS.Color("E43CFF"), RTS.Italic())
                ));
        }
    }

}
