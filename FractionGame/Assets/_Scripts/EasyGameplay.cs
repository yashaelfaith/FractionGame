using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EasyGameplay : MonoBehaviour {
    public GameObject time;
    public Text score;

    private int level; // 0: easy, 1: medium, 2: hard
    private bool relax = false; // relax false means challenge
    private List<GameObject> questions = new List<GameObject>();
    private List<float> numbers = new List<float>();
    private List<GameObject> img = new List<GameObject>();
    private List<GameObject> imgDisabled = new List<GameObject>();
    private List<GameObject> imgChosen = new List<GameObject>();

    private int selected = -1;

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("selected", -1);

        level = PlayerPrefs.GetInt("level");

        if (PlayerPrefs.GetInt("mode") == 0)
        {
            relax = true;
        }

        // if relax then hide time
        if (relax)
        {
            time.SetActive(false);
        } else
        {
            time.SetActive(true);
        }

        // if easy then show 3 pairs problems
        if (level == 0 || level == 1)
        {
            transform.gameObject.SetActive(true);
            foreach (RectTransform t in transform)
            {
                questions.Add(t.gameObject);
            }
            if (level == 0) // easy
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    List<GameObject> items = new List<GameObject>();
                    foreach (RectTransform t in questions[i].transform)
                    {
                        items.Add(t.gameObject);
                    }
                    items[0].SetActive(false);
                    imgDisabled.Add(items[0]); // add ImgDisabled to list

                    items[1].SetActive(false); 
                    imgChosen.Add(items[1]); // add ImgChosen to list

                    img.Add(items[2]); // add Img to list

                    List<GameObject> subitems = new List<GameObject>();
                    foreach (RectTransform t in items[3].transform)
                    {
                        subitems.Add(t.gameObject);
                    }
                    
                    // initialize fraction value and images
                    if (i == 0)
                    {
                        subitems[0].GetComponent<TextMesh>().text = 3.ToString();
                        subitems[2].GetComponent<TextMesh>().text = 9.ToString();
                        numbers.Add((float)3 / (float)9);
                    } else if (i == 1)
                    {
                        subitems[0].GetComponent<TextMesh>().text = 1.ToString();
                        subitems[2].GetComponent<TextMesh>().text = 3.ToString();
                        numbers.Add((float)1 / (float)3);
                    } else if (i == 2)
                    {
                        subitems[0].GetComponent<TextMesh>().text = 1.ToString();
                        subitems[2].GetComponent<TextMesh>().text = 2.ToString();
                        numbers.Add((float)1 / (float)2);
                    } else if (i == 3)
                    {
                        subitems[0].GetComponent<TextMesh>().text = 2.ToString();
                        subitems[2].GetComponent<TextMesh>().text = 4.ToString();
                        numbers.Add((float)2 / (float)4);
                    } else if (i == 4)
                    {
                        subitems[0].GetComponent<TextMesh>().text = 6.ToString();
                        subitems[2].GetComponent<TextMesh>().text = 8.ToString();
                        numbers.Add((float)6 / (float)8);
                    } else // (i == 5)
                    {
                        subitems[0].GetComponent<TextMesh>().text = 3.ToString();
                        subitems[2].GetComponent<TextMesh>().text = 4.ToString();
                        numbers.Add((float)3 / (float)4);
                    } 
                }
            
            } else // medium
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    List<GameObject> items = new List<GameObject>();
                    foreach (RectTransform t in questions[i].transform)
                    {
                        items.Add(t.gameObject);
                    }
                    items[0].SetActive(false);
                    imgDisabled.Add(items[0]); // add ImgDisabled to list

                    items[1].SetActive(false);
                    imgChosen.Add(items[1]); // add ImgChosen to list

                    img.Add(items[2]); // add Img to list

                    List<GameObject> subitems = new List<GameObject>();
                    foreach (RectTransform t in items[3].transform)
                    {
                        subitems.Add(t.gameObject);
                    }

                    // initialize fraction value and images
                    if (i == 0)
                    {
                        subitems[0].GetComponent<TextMesh>().text = "".ToString();
                        subitems[2].GetComponent<TextMesh>().text = 5.ToString();
                        //numbers.Add((float)3 / (float)9);
                    }
                    else if (i == 1)
                    {
                        subitems[0].GetComponent<TextMesh>().text = 2.ToString();
                        subitems[2].GetComponent<TextMesh>().text = "".ToString();
                        //numbers.Add((float)1 / (float)3);
                    }
                    else if (i == 2)
                    {
                        subitems[0].GetComponent<TextMesh>().text = "".ToString();
                        subitems[2].GetComponent<TextMesh>().text = 3.ToString();
                        //numbers.Add((float)1 / (float)2);
                    }
                    else if (i == 3)
                    {
                        subitems[0].GetComponent<TextMesh>().text = 1.ToString();
                        subitems[2].GetComponent<TextMesh>().text = "".ToString();
                        //numbers.Add((float)2 / (float)4);
                    }
                    else if (i == 4)
                    {
                        subitems[0].GetComponent<TextMesh>().text = "".ToString();
                        subitems[2].GetComponent<TextMesh>().text = 9.ToString();
                        //numbers.Add((float)6 / (float)8);
                    }
                    else // (i == 5)
                    {
                        subitems[0].GetComponent<TextMesh>().text = 2.ToString();
                        subitems[2].GetComponent<TextMesh>().text = "".ToString();
                        //numbers.Add((float)3 / (float)4);
                    }
                }
            }

            // initialize selected question
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt(i.ToString(), 0);
            }
        } else
        {
            transform.gameObject.SetActive(false);
        }
    }

	// Update is called once per frame
	void Update () {
        if (relax)
        {
            RelaxMode();
        } else
        {

        }
    }

    void RelaxMode()
    {
        if (level == 0)
        {
            EasyGameplayRelaxMode();
        } else if (level == 1)
        {
            MediumGameplayRelaxMode();
        }
    }

    void MediumGameplayRelaxMode()
    {

    }

    void EasyGameplayRelaxMode()
    {
        CheckInputMouse();

        int prefs = PlayerPrefs.GetInt("selected");

        if (prefs > -1 && prefs == selected) // unselect an image
        {
            img[selected].SetActive(true);
            imgChosen[selected].SetActive(false);
            imgDisabled[selected].SetActive(false);

            // reset selected
            selected = -1;

            // reset shared preference
            PlayerPrefs.SetInt("selected", -1);
        }
        else if (prefs > -1 && prefs != selected)
        {
            if (selected == -1)
            {
                selected = prefs;
            }
            else
            {
                int score_value;
                if (numbers[selected] == numbers[prefs])
                {
                    score_value = (Int32.Parse(score.text) + 10);
                    PlayerPrefs.SetInt(selected.ToString(), 1); // 1 means has been select and cannot be select anymore
                    PlayerPrefs.SetInt(prefs.ToString(), 1); // 1 means has been select and cannot be select anymore

                    // turn on disable mode for images
                    img[selected].SetActive(false);
                    imgChosen[selected].SetActive(false);
                    imgDisabled[selected].SetActive(true);

                    img[prefs].SetActive(false);
                    imgChosen[prefs].SetActive(false);
                    imgDisabled[prefs].SetActive(true);

                    // check if all has been disabled
                    bool allDisabled = true;
                    for (int i = 0; i < 6 && allDisabled; i++)
                    {
                        if (PlayerPrefs.GetInt(i.ToString()) == 0)
                        {
                            allDisabled = false;
                        }
                    }

                    // go to next level
                    if (allDisabled)
                    {
                        level++;
                        PlayerPrefs.SetInt("level", level);
                        SceneManager.LoadScene(3 + level);
                    }
                }
                else
                {
                    score_value = (Int32.Parse(score.text) - 10);

                    // turn on normal mode for image
                    img[selected].SetActive(true);
                    imgChosen[selected].SetActive(false);
                    imgDisabled[selected].SetActive(false);

                    img[prefs].SetActive(true);
                    imgChosen[prefs].SetActive(false);
                    imgDisabled[prefs].SetActive(false);
                }

                // print the score to UI
                score.text = score_value.ToString();

                // reset selected
                selected = -1;
            }

            // reset shared preference
            PlayerPrefs.SetInt("selected", -1);
        }
    }

    void CheckInputMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D clicked_collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (clicked_collider != null)
            {
                // if has not been disabled
                if (PlayerPrefs.GetInt(clicked_collider.gameObject.tag) == 0)
                {
                    int imageTag = Int32.Parse(clicked_collider.gameObject.tag);

                    // set image to choose mode
                    img[imageTag].SetActive(false);
                    imgDisabled[imageTag].SetActive(false);
                    imgChosen[imageTag].SetActive(true);

                    // set index of chosen image to shared preference
                    PlayerPrefs.SetInt("selected", Int32.Parse(clicked_collider.gameObject.tag));
                }
            }
        }
    }
}