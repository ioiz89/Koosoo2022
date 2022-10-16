using UnityEngine;
using System;
using System.Collections.Generic;
using WebViewGeneralName;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour//, IGameManager
{
    Vector3 playerStartPosition = new Vector3(9f, 1f, -3.5f);
    public AudioClip[] audioClips;  // 0: collision, 1: finish
    public AudioSource audioSource;
    public int CollisionCount = 0;
    private int LifeCount = 3;
    public bool isInMainBG = true;
    public bool hasFirstTouch = false;
    public bool isInShowroom = false;
    public bool isVideoEnd = false;
    bool isFinish = false;
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;
    public GameObject camera;

    IGameManager gameManager;
    //public event OnGameStart OnGameStartHandler;
    //public event OnGameFinish OnGameFinishHandler;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Mgr").GetComponent<VideoPreparation>() as IGameManager;
        //gameManager.OnGameFinishHandler += SetPlayerPosition;
        
        
        //videoMgr = GameObject.FindGameObjectWithTag(TAGS.WebVideoMgr).GetComponent<VideoPreparation>() as IVideoPlayManager;
        //videoMgr.OnVideoEndHandler += SetIsVideoEnd;
        SetCurrentTransform();
    }

    void InitGame()
    {
        this.gameObject.transform.position = playerStartPosition;
        this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        isFinish = false;
    }

    private void SetIsVideoEnd()
    {
        isVideoEnd = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Box"))
        {
            if(!isFinish)
            {
            // image not found -> animation
                audioSource.clip = audioClips[1];
                audioSource.Play();
                isFinish = true;
                return;
            }
        }

        if(other.gameObject.CompareTag("Pole"))
        {
            CollisionCount ++;
            audioSource.clip = audioClips[0];
            audioSource.Play();

            if(CollisionCount == LifeCount)
            {
                CollisionCount = 0;
                InitGame();
                // die
            }
        }
    }

    void Update ()
    {
        if (isInMainBG)
            return;

        if(isFinish && !audioSource.isPlaying)
        {
            gameManager.FinishGame();
            //OnGameFinishHandler.Invoke();
        }
        
        if(!isFinish)
        {
            MouseRotation();
            KeyboardMove();
            DetectHasFirstTouch();
            SetCurrentTransform();
        }

        //ResetByESC();
    }
    public Vector2 turn;

    void MouseRotation()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;
        
        transform.eulerAngles = new Vector3(0, yRotate, 0);

        if(hasFirstTouch)
        {
            float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
            float xRotate = camera.transform.eulerAngles.x + xRotateSize;
            // Debug.Log(xRotate);
            if(xRotate < 20 && xRotate > -10 || xRotate > 325 && xRotate < 360)
                camera.transform.localRotation = Quaternion.Euler(xRotate, -90, 0);
        }
    }

    void KeyboardMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;

        dir = Camera.main.transform.TransformDirection(dir);

        dir.Normalize();

        transform.position += dir * moveSpeed * Time.deltaTime;

        // if(Input.GetKeyDown(KeyCode.J))
        // {
        //     this.gameObject.transform.position = new Vector3(2.1f, 0.8f, 1.7f);
        // }
    }

    float prevYRot = 0.0f;
    Vector3 prevPos = new Vector3();

    void DetectHasFirstTouch()
    {
        if (hasFirstTouch)
            return;

        if (prevYRot != GetYRot() || Input.anyKey)//prevPos != this.transform.position)
        {
            hasFirstTouch = true;
            GameObject.FindGameObjectWithTag(TAGS.WebCanvas).GetComponent<UIManager>().HideWaitIcon();
        }
    }

    void SetCurrentTransform()
    {
        prevYRot = this.transform.rotation.eulerAngles.y;
        prevPos = this.transform.position;
    }

    float GetYRot()
    {
        return this.transform.rotation.eulerAngles.y;
    }

    void ResetByESC()
    {
        if (!isVideoEnd)
            return;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        }
        //if(Input.GetKeyDown(KeyCode.R))
        //{
        //    isVideoEnd = false;
        //    videoMgr.StartMovie();
        //}
    }
}