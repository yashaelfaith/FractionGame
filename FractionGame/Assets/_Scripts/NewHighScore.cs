using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public Text currentScore;

    private List<string> rankParse;
    private List<User> rankData;
    private bool newHighScore = false;
    private bool doneInput = false;
    private bool hasChecked = false;
    private bool isEmpty = false;
    private int length = 0;
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
        
        // parsing external file by '\n'
        rankParse = content.Split('\n').ToList();
        /*if (rankParse[0] == "")
            isEmpty = true;*/
        // making list of user from rankParse
        length = Int32.Parse(rankParse[0]);
        rankData = new List<User>();
        /*if (!isEmpty)
        {
            length = rankParse.Count;
        }*/
        for (int i = 0; i < length; i++)
        {
            List<string> data = rankParse[i + 1].Split(' ').ToList();
            rankData.Add(new User());
            rankData[i].Username = data[0];
            rankData[i].Score = Int32.Parse(data[1]);
        }
    }
	
	void Update () {
        if (PlayerPrefs.GetInt("mode") == 1)
        {
            // Function check if the user got into the top 5
            // Checking only done once, when it is GameOver or Finished and haven't input username
            if (((GameOver.activeSelf) || (Finish.activeSelf)) && (!doneInput) && (!hasChecked))
            {
                if (isEmpty || length < 5)
                {
                    newHighScore = true;
                }
                for (int i = 0; i < length; i++)
                {
                    if (Int32.Parse(currentScore.text) > rankData[i].Score)
                    {
                        newHighScore = true;
                    }
                }
                // Showing the InsertName Display if current score is a new HighScore
                if (newHighScore)
                {
                    InsertName.SetActive(true);
                }
                hasChecked = true;
            }
        }
    }

    // Function triggered when done giving input
    public void NameInsert () {
        // Make new list component
        rankData.Add(new User());
        rankData[length].Username = usernameInput.text;
        rankData[length].Score = Int32.Parse(currentScore.text);

        // Sorting the list by score
        List<User> sortedList = rankData.OrderByDescending(o => o.Score).ToList();

        // replace highscore.txt with empty highscore.txt
        StreamWriter writer = new StreamWriter(path + "/MatchMe_Data/Data/highscore.txt", false);

        // writing highscore.txt
        // loop until count-1 so that highscore.txt only have 5 data
        int listLength = sortedList.Count;
        if (listLength > 5)
            listLength = 5;

        writer.WriteLine(listLength.ToString());
        for (int i = 0; i < listLength; i++)
        {
            writer.Write(sortedList[i].Username);
            writer.Write(" ");
            writer.WriteLine(sortedList[i].Score.ToString());
        }
        writer.Close();
        
        // Removing InsertName Display
        InsertName.SetActive(false);

        // updating doneInput
        doneInput = true;
    }
}
