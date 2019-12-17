
//************* LICENCE *************
// Made with love by Yann Bouissou.
//
// Free for commercial an personnal use. '(O.<)'
// Kiss !

using System.Text;
using UnityEngine;

static class RTS
{
    /**********************************/
    /*   RTS ==> "Rich Text String"   */
    /**********************************/

    public static string RTString(string text, Color textColor,bool isBold = false, bool isItalic = false )
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=#{0}>{1}</color>", ColorUtility.ToHtmlStringRGBA(textColor), text);
        
        if (isBold)
        {
            sb.Insert(0, "<b>");
            sb.Append("</b>");
        }

        if (isItalic)
        {
            sb.Insert(0, "<i>");
            sb.Append("</i>");
        }


        return sb.ToString();

    }
    public static string RTString(string text, string hexColorWithSharp, bool isBold = false, bool isItalic = false)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color={0}>{1}</color>", hexColorWithSharp, text);

        if (isBold)
        {
            sb.Insert(0, "<b>");
            sb.Append("</b>");
        }

        if (isItalic)
        {
            sb.Insert(0, "<i>");
            sb.Append("</i>");
        }


        return sb.ToString();
    }

    //  Exemple of usage : 

    // Add : using static RTS;

    //  Debug.Log(RTString("The Sky is Blue !!!! ", Color.blue, true, false));
    //  Debug.Log(RTString("The Sky is Blue ! ", Color.blue, true, false)+" "+ RTS.RTString("And Love Is Pink !!!! ", "#E43CFF", false, true));
}
