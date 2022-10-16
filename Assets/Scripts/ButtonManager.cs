using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebViewGeneralName;
public class ButtonManager : MonoBehaviour,IStartBtn
{
    public Button startBtn;
    public Canvas canvas;


    public event OnPlayBtnClicked OnPlayBtnClickedHandler;

    // Start is called before the first frame update
    void Start()
    {
        if(!canvas)
        {
            canvas = GameObject.FindGameObjectWithTag(TAGS.WebCanvas).GetComponent<Canvas>();
        }
        if (!startBtn)
        {
            startBtn = GameObject.FindGameObjectWithTag(TAGS.WebStartBtn).GetComponent<Button>();
        }

        startBtn.onClick.AddListener(() => StartMuseum());
    }

    void StartMuseum()
    {
        OnPlayBtnClickedHandler?.Invoke();
        canvas.enabled = false;

    }
}
