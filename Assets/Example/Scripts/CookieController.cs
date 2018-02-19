using System;
using UnityEngine;
using UnityEngine.UI;

public class CookieController : MonoBehaviour
{
    [Header("Common")]
    [SerializeField]
    private InputField cookieNameInputField;

    [Header("Get value")]
    [SerializeField]
    private Text getCookieValueText;

    [Header("Set value")]
    [SerializeField]
    private InputField setCookieValueInputField;

    [Header("Set value with time")]
    [SerializeField]
    private InputField timeCookieNameInputField;
    [SerializeField]
    private InputField timeValueInputField;

    public void OnGetCookieClick()
    {
        getCookieValueText.text = HttpCookie.GetCookie(cookieNameInputField.text);
    }

    public void OnSetCookieClick()
    {
        HttpCookie.SetCookie(cookieNameInputField.text, setCookieValueInputField.text);
    }

    public void OnTimeSetCookieClick()
    {
        double seconds;
        if (!double.TryParse(timeValueInputField.text, out seconds))
            return;

        HttpCookie.SetCookie(
            cookieNameInputField.text,
            timeCookieNameInputField.text,
            DateTime.Now.AddSeconds(seconds)
        );
    }
}
