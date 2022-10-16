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
        dir.Capacity = 2;
        SetLinesDir();
        ChangeDir(PoleLines.MainLine, dir[PoleLines.MainLine]);
        ChangeDir(PoleLines.SubLine,  dir[PoleLines.SubLine]);
    }

    
    private void SetLinesDir()
    {
        var name = this.gameObject.name;
        var verticalLineNum = name.Split('_')[1];
        var horizonLineNum = name.Split('_')[2];
        int verTemp = 0;
        int horizonTemp = 0;
        if(int.TryParse(verticalLineNum, out verTemp) && int.TryParse(horizonLineNum, out horizonTemp))
        {
            verTemp = Mathf.Abs(verTemp - 7);
            
            dir[PoleLines.MainLine] = PoleDirectionInstance.GetDir(verTemp, horizonTemp, PoleLines.MainLine);
            dir[PoleLines.SubLine]  = PoleDirectionInstance.GetDir(verTemp, horizonTemp, PoleLines.SubLine);
        }
    }

    private void ChangeDir(int lineID, ELineDir i)
    {
        if(i == ELineDir.none)
        {
            lines[lineID].gameObject.SetActive(false);
            return;
        }
        Vector3 rot = new Vector3();
        rot.y = rot.y + (float)i;
        lines[lineID].rotation = Quaternion.Euler(rot);
    }
}

