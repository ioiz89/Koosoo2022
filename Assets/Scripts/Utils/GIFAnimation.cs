using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIFAnimation : MonoBehaviour
{
    [SerializeField] private Texture2D[] frames;
    [SerializeField] private  float fps = 10.0f; // 0.4s
    private Material material;

    void Start () 
    {
        material = GetComponent<Renderer> ().material;
    }

    void Update () 
    {
        int index = (int)(Time.time * fps);
        index = index % frames.Length;
        material.mainTexture = frames[index]; // usar en planeObjects
        //GetComponent<RawImage> ().texture = frames [index];
    }
}