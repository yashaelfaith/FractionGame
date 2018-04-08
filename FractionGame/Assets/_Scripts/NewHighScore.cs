using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class User
{
    private string username;
    private int score;

    public string Username
    {
        get
        {
            return username;
        }

        set
        {
            username = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }
}

public class NewHighScore : MonoBehaviour {

    public GameObject InsertName;
    public GameObject GameOver;
    public GameObject Finish;
    public Text usernameInput;
    public TextAsset rankList;
    public Text currentScore;

    private List<string> rankParse;
    private List<User> rankData;
    private bool newHighScore = false;
    private bool doneInput = false;
    private bool hasChecked = false;

    void Start () {
        // parsing external file by '\n'
        rankParse = rankList.text.Split('\n').ToList();
        // making list of user from rankParse
        rankData = new List<User>();
        for (int i = 0; i < 5; i++)
        {
            List<string> data = rankParse[i].Split(' ').ToList();
            rankData.Add(new User());
            rankData[i].Username = data[0];
            rankData[i].Score = Int32.Parse(data[1]);
        }
	}
	
	void Update () {        
        // Function check if the user got into the top 5
        // Checking only done once, when it is GameOver or Finished and haven't input username
        if ( ( (GameOver.activeSelf) || (Finish.activeSelf) ) && (!doneInput) && (!hasChecked) )
        {
            for (int i = 0; i < 5; i++)
            {
                if (Int32.Parse(currentScore.text) > rankData[i].Score)
                {
                    newHighScore = true;
                }
                //Debug.Log(rankData[i].Username);
            }
            // Showing the InsertName Display if current score is a new HighScore
            if (newHighScore)
            {
                InsertName.SetActive(true);
            }
            hasChecked = true;
        }
    }

    // Function triggered when done giving input
    public void NameInsert () {
        // Make new list component
        rankData.Add(new User());
        rankData[5].Username = usernameInput.text;
        rankData[5].Score = Int32.Parse(currentScore.text);

        // Sorting the list by score
        List<User> sortedList = rankData.OrderByDescending(o => o.Score).ToList();

        // replace highscore.txt with empty highscore.txt
        StreamWriter writer = new StreamWriter("Assets/Resources/Data/highscore.txt", false);      

        // writing highscore.txt
        // loop until count-1 so that highscore.txt only have 5 data
        for (int i = 0; i < sortedList.Count-1; i++)
        {
            //Debug.Log(sortedList[i].Rank);
            //Debug.Log(sortedList[i].Username);
            //Debug.Log(sortedList[i].Score);
            writer.Write(sortedList[i].Username);
            writer.Write(" ");
            writer.WriteLine(sortedList[i].Score.ToString());
        }
        writer.Close();
        AssetDatabase.ImportAsset("Assets/Resources/Data/highscore.txt");

        // Removing InsertName Display
        InsertName.SetActive(false);

        // updating doneInput
        doneInput = true;
    }
}
