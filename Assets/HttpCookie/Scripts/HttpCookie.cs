using System;
using System.Globalization;
using System.Runtime.InteropServices;

public static class HttpCookie
{
    /// <summary>
    /// Get all cookies.
    /// </summary>
    /// <returns></returns>
    [DllImport("__Internal")]
    private static extern string getHttpCookies();
    
    /// <summary>
    /// Get a cookie by name.
    /// </summary>
    /// <param name="name">Cookie name</param>
    /// <returns>Cookie value</returns>
    [DllImport("__Internal")]
    private static extern string getHttpCookie(string name);
    
    /// <summary>
    /// Set a cookie.
    /// </summary>
    /// <param name="name">Cookie name</param>
    /// <param name="value">Cookie value</param>
    /// <param name="expires">Expiration date and time in the format "Day, DD Month YYYY HH:MM:SS GMT" (e.g. Fri, 31 Dec 2010 23:59:59 GMT)</param>
    /// <param name="path">Path where the cookie is accessible</param>
    /// <param name="domain">Domain where the cookie is accessible</param>
    /// <param name="secure">Cookie can only be transmitted over a secure protocol (https)</param>
    [DllImport("__Internal")]
    private static extern void setHttpCookie(string name, string value, string expires, string path, string domain, string secure);

    /// <summary>
    /// Get a cookie.
    /// </summary>
    /// <param name="name">Cookie name</param>
    /// <returns>Cookie value</returns>
    public static string GetCookie(string name)
    {
        return getHttpCookie(name);
    }

    /// <summary>
    /// Remove a cookie.
    /// </summary>
    /// <param name="name">Cookie name</param>
    public static void RemoveCookie(string name)
    {
        setHttpCookie(name, string.Empty, "0", string.Empty, string.Empty, string.Empty);
    }

    /// <summary>
    /// Set a cookie.
    /// </summary>
    /// <param name="name">Cookie name</param>
    /// <param name="value">Cookie value</param>
    public static void SetCookie(string name, string value)
    {
        SetCookie(name, value, string.Empty, string.Empty, string.Empty, string.Empty);
    }

    /// <summary>
    /// Set a cookie.
    /// </summary>
    /// <param name="name">Cookie name</param>
    /// <param name="value">Cookie value</param>
    /// <param name="date">Expiration date and time in the format "Day, DD Month YYYY HH:MM:SS GMT" (e.g. Fri, 31 Dec 2010 23:59:59 GMT)</param>
    public static void SetCookie(string name, string value, DateTime date)
    {
        var dateJS = date.ToUniversalTime().ToString("ddd, dd'-'MMM'-'yyyy HH':'mm':'ss 'GMT'", CultureInfo.CreateSpecificCulture("en-US"));
        SetCookie(name, value, dateJS, string.Empty, string.Empty, string.Empty);
    }

    /// <summary>
    /// Set a cookie.
    /// </summary>
    /// <param name="name">Cookie name</param>
    /// <param name="value">Cookie value</param>
    /// <param name="expires">Expiration date and time in the format "Day, DD Month YYYY HH:MM:SS GMT" (e.g. Fri, 31 Dec 2010 23:59:59 GMT)</param>
    /// <param name="path">Path where the cookie is accessible</param>
    /// <param name="domain">Domain where the cookie is accessible</param>
    /// <param name="secure">Cookie can only be transmitted over a secure protocol (https)</param>
    public static void SetCookie(string name, string value, string expires, string path, string domain, string secure)
    {
        setHttpCookie(name, value, expires, path, domain, secure);
    }
}