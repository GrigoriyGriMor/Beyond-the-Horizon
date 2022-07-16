using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using UnityEngine.Events;
using UnityEngine.Networking;

public static class WebData
{
    [Header("Заголовки")]
    private static string headerName = "X-Requested-With";
    public static string HeaderName => headerName;

    private static string headerValue = "XMLHttpRequest";
    public static string HeaderValue => headerValue;

    [Header("Пути")]
    private static string domain = "http://regserver.cloudsgoods.com";
    public static string Domain => domain;

    private static string loginPath = ":80/api/auth";
    public static string LoginPath => domain + loginPath;

    private static string registerPath = ":80/api/register";
    public static string RegisterPath => domain + registerPath;

    private static string serverCharInfoPath = ":80/api/info";
    public static string ServerCharInfoPath => domain + serverCharInfoPath;

    private static string addCharacter = ":80/api/charadd";
    public static string AddCharacter => domain + addCharacter;
}