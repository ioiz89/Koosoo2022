using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnUnityInitialized();
public delegate void OnPlayBtnClicked();
public delegate void OnVideoStart();
public delegate void OnVideoEnd();
public delegate void OnGameStart();
public delegate void OnGameReward();
public delegate void OnGameFinish();
//public delegate void OnBackroundChanged(bool didChanged);
//public delegate void OnReceivedBG(string bgName);

public interface IUnityInitialized
{
    event OnUnityInitialized OnUnityInitializedHandler;
}

public interface IStartBtn
{
    event OnPlayBtnClicked OnPlayBtnClickedHandler;
}

public interface IVideoPlayManager
{
    event OnVideoStart OnVideoStartHandler;
    event OnVideoEnd OnVideoEndHandler;
    void StartMovie();
}

public interface IGameManager
{
    event OnGameStart OnGameStartHandler;
    event OnGameReward OnGameRewardHandler;
    event OnGameFinish OnGameFinishHandler;
    public void ShowReward();
    public void FinishGame();
    //void StartMovie();
}


namespace WebViewGeneralName
{
    public static class TAGS
    {
        public static string WebCanvas = "StartCanvas";
        public static string WebPlayer = "Player";
        public static string WebReceiver = "WebReceiver";
        public static string WebStartBtn = "StartBtn";
        public static string WebVideoMgr = "VideoManager";
    }
}
