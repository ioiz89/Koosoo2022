using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DCTL;

public class PoleDirectionSetter : MonoBehaviour
{
    public List<Transform> lines;
    public List<ELineDir> dir = new List<ELineDir>();


    // Start is called before the first frame update
    void Start()
    {
        //lines = new List<Transform>();
        //lines.Add(this.transform.GetChild(PoleLines.MainLine));
        //lines.Add(this.transform.GetChild(PoleLines.SubLine));

        ChangeDir(PoleLines.MainLine, dir[PoleLines.MainLine]);
        ChangeDir(PoleLines.SubLine, dir[PoleLines.SubLine]);
    }

    private void ChangeDir(int lineID, ELineDir i)
    {
        if(i == ELineDir.none)
        {
            lines[lineID].gameObject.SetActive(false);
            return;
        }
        Vector3 rot = new Vector3();
        rot.y = rot.y + (90.0f * (int)i);
        lines[lineID].rotation = Quaternion.Euler(rot);
    }
}

