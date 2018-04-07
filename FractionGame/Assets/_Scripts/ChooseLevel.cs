using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour {

    public void SaveLevel(int idx) // 0: easy, 1: medium, 2: hard
    {
        if (idx >= 0 && idx <= 2)
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
