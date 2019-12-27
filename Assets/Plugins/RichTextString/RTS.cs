
//************* LICENCE *************
// Made with love by Yann Bouissou.
// Thx to Remy Maetz for the update.
//
// Free for commercial an personnal use. '(O.<)'
// Kiss !

using System.Text;
using UnityEngine;

/// <summary>
/// RTS ==> "Rich Text String"   
/// <para>Add style to your text field with string params</para>
/// </summary>
class RTS
{
    //****** Styles *******//
    #region Styles

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
    /// <summary>
    /// Bold text (no parameters required)
    /// </summary>
    /// <para>example: RTS.Bold()</para>
    /// <returns></returns>
    public static Style.S_Bold Bold()
    {
        return new Style.S_Bold();
    }
    /// <summary>
    /// Italic text to String (no parameters required)
    /// </summary>
    /// <para>example: RTS.Italic()</para>
    /// <returns></returns>
    public static Style.S_Italic Italic()
    {
        return new Style.S_Italic();
    }

    static int MaxFontSize = 35;
    static int MinFontSize = 10;
    /// <summary>
    /// Define the size of the test
    /// </summary>
    /// <param name="size">define the size of the text, it's automatically constrained (10-25)
    /// <para>example: RTS.Size(12)</para>
    /// </param>
    /// <returns></returns>
    public static Style.S_Size Size(int size)
    {
        if (size>20)
        {
            size= MaxFontSize; 
        }
        if (size<10)
        {
            size= MinFontSize;
        }
        return new Style.S_Size() { value = size };
    }
    /// <summary>
    /// Define the text color with hexadecimal value
    /// </summary>
    /// <param name="hexColor">Use hexadecimal value in string without #
    /// <para>example: RTS.Color("E43CFF")</para>
    /// </param>
    /// <returns></returns>
    public static Style.S_Color Color(string hexColor)
    {
        return new Style.S_Color() { value = hexColor };
    }
    /// <summary>
    /// Define the text color with Color value
    /// </summary>
    /// <param name="color">Use a color value in string
    /// <para>example: RTS.Color(Color.blue)</para>
    /// </param>
    /// <returns></returns>
    public static Style.S_Color Color(Color color)
    {
        return new Style.S_Color() { value = ColorUtility.ToHtmlStringRGBA(color) };
    }

    #endregion

    //****** RTS String Construction *******//

    #region RTS String Construction

    /// <summary>
    /// String with multiples sytles params
    /// </summary>
    /// <param name="text">The string you want to format</param>
    /// <param name="styles">A style array including: RTS.Bold RTS.Italic RTS.Size RTS.Color</param>
    /// <returns></returns>
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

    #endregion
}
