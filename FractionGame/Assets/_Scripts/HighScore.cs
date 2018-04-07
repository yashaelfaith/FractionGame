using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Top
{
    public Text Username;
    public Text Score;
}

[Serializable]
public class TopList
{
    public Top Top1;
    public Top Top2;
    public Top Top3;
    public Top Top4;
    public Top Top5;
}

public class HighScore : MonoBehaviour {
    
    // External file asset
    public TextAsset rankList;
    // Top classes for Text UI
    public TopList topList;

    void Start () {
        // initialize topData list
        List<Top> topData = new List<Top>()
        {
            topList.Top1,
            topList.Top2,
            topList.Top3,
            topList.Top4,
            topList.Top5
        };

        // parsing external file by '\n'
        List<string> rankData = rankList.text.Split('\n').ToList();
        for (int i = 0; i < rankData.Count; i++)
        {
            // parsing external file by ' '
            List<string> data = rankData[i].Split(' ').ToList();

            // changing the text based on external file
            topData[i].Username.text = data[0];
            topData[i].Score.text = data[1];
            //Debug.Log(data[0]);
            //Debug.Log(data[1]);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
