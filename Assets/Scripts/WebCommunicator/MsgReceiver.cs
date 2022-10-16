using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgReceiver : MonoBehaviour, IUnityInitialized
{
    public event OnUnityInitialized OnUnityInitializedHandler;

    public void LoadAfter()
    {
        OnUnityInitializedHandler?.Invoke();
    }

}
