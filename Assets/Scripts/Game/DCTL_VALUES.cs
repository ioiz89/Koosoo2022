using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DCTL
{
    public class PoleLines
    {
        public static int MainLine = 0;
        public static int SubLine = 1;
    }

    public enum ELineDir
    {
        r = 270, 
        f = 0, 
        l = 90, 
        b = 180, 
        none = 1
    }
}
