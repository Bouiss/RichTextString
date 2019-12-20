
//************* LICENCE *************
// Made with love by Yann Bouissou.
//
// Free for commercial an personnal use. '(O.<)'
// Kiss !

using System.Text;
using UnityEngine;

class RTS
{
    public class Style
    {
        public class S_Bold : Style { }
        public class S_Italic : Style { }
        public class S_Size : Style
        {
            public int value;
        }
        public class S_Color : Style
        {
            public string value;
        }
    }

    public static Style.S_Bold Bold()
    {
        return new Style.S_Bold();
    }
    public static Style.S_Italic Italic()
    {
        return new Style.S_Italic();
    }
    public static Style.S_Size Size(int size)
    {
        return new Style.S_Size() { value = size };
    }

    public static Style.S_Color Color(string hexColor)
    {
        return new Style.S_Color() { value = hexColor };
    }

    public static Style.S_Color Color(Color color)
    {
        return new Style.S_Color() { value = ColorUtility.ToHtmlStringRGBA(color) };
    }

    /**********************************/
    /*   RTS ==> "Rich Text String"   */
    /**********************************/
    public static string String( string text, params Style[] styles )
    {
        StringBuilder sb = new StringBuilder(text);

        foreach( var style in styles)
        {
            var t = style.GetType();

            if (t == typeof(Style.S_Bold))
            {
                sb.Insert(0, "<b>");
                sb.Append("</b>");
            }
            if (t == typeof(Style.S_Italic))
            {
                sb.Insert(0, "<i>");
                sb.Append("</i>");
            }
            if (t == typeof(Style.S_Size))
            {
                sb.Insert(0, $"<size={((Style.S_Size)style).value}>");
                sb.Append("</size>");
            }
            if (t == typeof(Style.S_Color))
            {
                sb.Insert(0, $"<color=#{((Style.S_Color)style).value}>");
                sb.Append("</color>");
            }
        }

        return sb.ToString();
    }

    public static string String(string text, string hexColorWithSharp, bool isBold = false, bool isItalic = false)
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
    public static string String(string text, Color textColor, bool isBold = false, bool isItalic = false)
    {
        return String(text, ColorUtility.ToHtmlStringRGBA(textColor), isBold, isItalic);

    }

    //  Exemple of usage : 

    // Add : using static RTS;

    //  Debug.Log(RTString("The Sky is Blue !!!! ", Color.blue, true, false));
    //  Debug.Log(RTString("The Sky is Blue ! ", Color.blue, true, false)+" "+ RTS.RTString("And Love Is Pink !!!! ", "#E43CFF", false, true));
}
