using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class MsgSendToWebPage
{
    [DllImport("__Internal")]
    public static extern void SendMessageToPage(string text);
}
