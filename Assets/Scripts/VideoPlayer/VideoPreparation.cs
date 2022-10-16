using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using WebViewGeneralName;

public class VideoPreparation : MonoBehaviour, IGameManager
{
    //public VideoPlayer video;
    string url = "http://www.wfs-game.art/files/movies/encoding_test.mp4";
    string test = "https://samplelib.com/lib/preview/mp4/sample-5s.mp4";
    IStartBtn startHandler;

    public event OnVideoStart OnVideoStartHandler;
    public event OnVideoEnd OnVideoEndHandler;

    public event OnGameStart OnGameStartHandler;
    public event OnGameFinish OnGameFinishHandler;

    public void FinishGame()
    {
        this.OnGameFinishHandler?.Invoke();
    }


    /*
        private void Awake()
        {
            if (!video)
                video = GetComponent<VideoPlayer>();
            video.playOnAwake = false;
            startHandler = GameObject.FindGameObjectWithTag(TAGS.WebCanvas).GetComponent<UIManager>() as IStartBtn;
            startHandler.OnPlayBtnClickedHandler += StartMovie;
        }


        public void StartMovie()
        {
            StartCoroutine(PlayVideo());
        }

        IEnumerator PlayVideo()
        {
            video.source = VideoSource.Url;
            video.url = url;
    #if UNITY_EDITOR
            video.url = test;
    #endif

            video.isLooping = false;
            video.Prepare();
            while(video.isPrepared)
                yield return new WaitForSeconds(0.5f);
            video.Play();
            StartCoroutine(DisplayVideoEnd());
        }

        IEnumerator DisplayVideoEnd()
        {
            yield return new WaitUntil(() => video.isPlaying);
            //OnVideoStartHandler?.Invoke();
            yield return new WaitUntil(() => !video.isPlaying);
            OnVideoEndHandler?.Invoke();
            StartMovie();
        }
    */
}
