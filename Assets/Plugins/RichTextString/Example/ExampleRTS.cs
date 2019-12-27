using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExampleRTS : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // One string with blue and bold text
            Debug.Log(RTS.String("The Sky is Blue !!!! ", RTS.Color(Color.green), RTS.Bold()));

            // Two strings with differents params
            Debug.Log(string.Format("{0} {1}",
                RTS.String("The Sky is Blue ! ", RTS.Color(Color.blue), RTS.Bold()),
                RTS.String("And Love Is Pink !!!! ", RTS.Size(20), RTS.Color("E43CFF"), RTS.Italic())
                ));

            // one string with with an Oversizer text (it will be reduce to 35 automaticly)
            Debug.Log(RTS.String("test", RTS.Italic(), RTS.Color(Color.red),RTS.Size(65)));
        }
    }
}
