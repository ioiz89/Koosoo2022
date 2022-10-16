using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WebViewGeneralName;

public class UIManager : MonoBehaviour, IStartBtn
{
    public Canvas UICanvas;
    public Camera UICamera;
    public Camera MainCamera;
    public Button enterBtn;
    bool isShowroomOpen = false;
    public Button resetBtn;

    public Image waitingImage;
    public Image mainBG;

    IVideoPlayManager videoMgr;


    public event OnPlayBtnClicked OnPlayBtnClickedHandler;
    private void Start()
    {
        enterBtn.onClick.AddListener(() => StartMuseum());
        
        videoMgr = GameObject.FindGameObjectWithTag(TAGS.WebVideoMgr).GetComponent<VideoPreparation>() as IVideoPlayManager;
        //videoMgr.OnVideoStartHandler += HideEndMessage;
        videoMgr.OnVideoEndHandler += ShowEndMessage;
        resetBtn.onClick.AddListener(() => SceneManager.LoadScene(0));

    }

    

    private void StartMuseum()
    {
        OnPlayBtnClickedHandler?.Invoke();
        needPlayIcon = true;
    }
    public void SetActiveShowroom(bool isOpen)
    {
        isShowroomOpen = isOpen;
        enterBtn.interactable = isShowroomOpen;
        // if(isOpen)
        //     Debug.Log("OPEN");
    }
    public void ChangeMode(bool isGameStart = true)
    {
        if(isGameStart)
        {
            ShowWaitIcon();
            MainCamera.enabled = true;
            UICamera.depth = -1;
            //UICanvas.enabled = false;
        }
        else
        {
            MainCamera.enabled = false;
            UICamera.depth = 0;
            UICanvas.enabled = true;
        }

    }

    public bool needPlayIcon = false;
    void ShowWaitIcon()
    {
        needPlayIcon = true;

        GameObject.FindGameObjectWithTag(TAGS.WebPlayer).GetComponent<PlayerController>().isInMainBG = false;

        UICanvas.worldCamera = MainCamera;
        waitingImage.gameObject.SetActive(true);

        mainBG.gameObject.SetActive(false);
        enterBtn.gameObject.SetActive(false);
    }

    public void HideWaitIcon()
    {
        needPlayIcon = false;
        waitingImage.gameObject.SetActive(false);
    }


    public List<Sprite> waitingIcon;
    public float spawnTime = 0f;
    public float glowSpeed = 1f;
    public bool pm;
    void Update()
    {
        PlayWaitingIcon();
        //if(Input.GetMouseButton(1))
        //{
        //    ChangeMode(false);
        //}

        if(isShowroomOpen)
        {
            var tempAlpha= (Time.time - spawnTime) * glowSpeed % 1;
            pm = Mathf.FloorToInt((Time.time - spawnTime) * glowSpeed) % 2 == 0 ? true : false;
            EmissiveButton(tempAlpha);
        }
        if(resetBtn.IsActive())
        {
            var tempAlpha = (Time.time - spawnTime) * glowSpeed % 1;
            EmissiveResetBtn(resetBtn.GetComponent<Image>(), tempAlpha);
        }

    }

    void EmissiveButton(float newAlpha)
    {
        Image enterImg = enterBtn.GetComponent<Image>();
        if(pm)
        {
            enterImg.color = new Color(1, 1, 1, newAlpha);
        }
        else
        {
            enterImg.color = new Color(1, 1, 1, 1-newAlpha);
        }
    }

    void EmissiveResetBtn(Image img, float newAlpha)
    {

        img.color = new Color(1, 1, 1, 1 - newAlpha);
    }

    void ShowEndMessage()
    {
        resetBtn.gameObject.SetActive(true);
    }

    private void HideEndMessage()
    {
        resetBtn.gameObject.SetActive(false);
    }



    int frameCnt = 0;
    int ratio = 0;
    //millisecond
    public int ratioGapInMillisecond = 500;
    void PlayWaitingIcon()
    {
        if (!needPlayIcon)
            return;
        ratio += 1;
        if(ratio != ratioGapInMillisecond)
            return; 
        frameCnt = (frameCnt + 1) % waitingIcon.Count;
        ratio = 0;
        waitingImage.sprite = waitingIcon[frameCnt];
    }

}
