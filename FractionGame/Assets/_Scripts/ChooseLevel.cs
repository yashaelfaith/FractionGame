using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour {

    public void SaveLevel(int idx) // 0: lv1, 1: lv2, 2: lv3, 3: lv4, 4: lv5
    {
        if (idx >= 0 && idx <= 4)
        {
            PlayerPrefs.SetInt("level", idx);
        }
    }

    public void SaveMode(int idx) // 0: relax, 1: challenge
    {
        if (idx >= 0 && idx <= 1)
        {
            PlayerPrefs.SetInt("mode", idx);
        }
    }
}
