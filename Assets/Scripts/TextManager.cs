using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text text_light;
    public Text text_dark;
    public void sendText(Text target, string content, Font font = null, bool animated = false, float animationSpeed = 1)
    {
        if (font is null)
        {
            font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        }
        target.text += "\n"  + content;
        target.font = font;
    }

    public void clearText(Text target)
    {
        target.text = "";
    }
}
