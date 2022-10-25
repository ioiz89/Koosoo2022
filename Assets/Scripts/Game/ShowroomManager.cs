using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShowroomManager : MonoBehaviour
{

    public int openningHour = 10;
    public int closingHour = 19;

    private string url = "http://www.google.com";
    private bool isOpenTime = false;

    public bool isTest = false;


    private bool isPlaying = false;

    public UIManager UIManager;


    public delegate void OpenShowroom(bool val);


    void Start()
    {
        StartCoroutine(CheckIsShowroomOpenTime());
    }


    // void OpenMethod(bool v)
    // {
    //     // Debug.Log(v);
    //     UIManager.SetActiveShowroom(v);
    // }
    public DayOfWeek testDayOfWeek;
    IEnumerator CheckIsShowroomOpenTime()
    {
        // OpenShowroom handler = OpenMethod;
        OpenShowroom handler = UIManager.SetActiveShowroom;
        yield return null;
        var dateTime = DateTime.Now;
        var dayOfWeek = dateTime.DayOfWeek;
        if (isTest)
            //isOpenTime = GetMuseumAvailable_Test();
            handler(GetMuseumAvailable_Test());
        else
            //isOpenTime = GetMuseumAvailable();
            handler(GetMuseumAvailable());

        //handler(isOpenTime);

        //if (isTest)
        //{
        //    isOpenTime = true;
        //    if (testDayOfWeek == DayOfWeek.Monday)
        //        isOpenTime = false;
        //}


        //else
        //{
        //    if (dateTime.Hour >= openningHour && dateTime.Hour < closingHour)
        //        isOpenTime = true;
        //    if (dayOfWeek != DayOfWeek.Monday)
        //        isOpenTime = true;
        //}



        //UnityWebRequest request = new UnityWebRequest();
        //using (request = UnityWebRequest.Get(url))
        //{
        //    yield return request.SendWebRequest();

        //    if (request.isNetworkError)
        //    {
        //        // Debug.Log(request.error);
        //    }
        //    else {
        //        string date = request.GetResponseHeader("date"); 
        //        // Debug.Log("GMT : " +date);
        //        DateTime dateTime = DateTime.Parse(date).ToLocalTime();
        //        // Debug.Log("KOR : " + dateTime);
        //        // Debug.Log("H : " + dateTime.Hour);

        //        if (isTest)
        //            isOpenTime = true;
        //        else
        //        {
        //            if(dateTime.Hour >= openningHour && dateTime.Hour < closingHour)
        //                isOpenTime = true;
        //        }

        //        handler(isOpenTime);

        //    }
        //}
    }

    bool GetMuseumAvailable()
    {
        var dateTime = DateTime.Now;
        var dayOfWeek = dateTime.DayOfWeek;
        
        if (dayOfWeek != DayOfWeek.Monday)
        {
            if (dateTime.Hour >= openningHour && dateTime.Hour < closingHour)
                return true;
        }
        return false;
    }
    bool GetMuseumAvailable_Test()
    {
        if (testDayOfWeek == DayOfWeek.Monday)
            return false;
        return true;
    }
}
