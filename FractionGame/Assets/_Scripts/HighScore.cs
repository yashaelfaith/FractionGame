using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    // Top classes for Text UI
    public TopList topList;
    
    // External file asset
    private string path;
    private string content;

    void Start () {
        path = Directory.GetCurrentDirectory();

        if (!File.Exists(path + "/MatchMe_Data/Data/highscore.txt"))
        {
            Directory.CreateDirectory(path + "/MatchMe_Data/Data");
            File.WriteAllText(path + "/MatchMe_Data/Data/highscore.txt", "player 50");
        }
        content = File.ReadAllText(path + "/MatchMe_Data/Data/highscore.txt");
        
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
        List<string> rankData = content.Split('\n').ToList();
        int length = rankData.Count;
        if (rankData[0] == "")
        {
            length = 0;
        }
        for (int i = 0; i < length; i++)
        {
            // parsing external file by ' '
            List<string> data = rankData[i].Split(' ').ToList();

            // changing the text based on external file
            if (data[0] == "")
            {
                topData[i].Username.text = "";
            } else
            {
                topData[i].Username.text = data[0];
            }
            topData[i].Score.text = data[1];
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
