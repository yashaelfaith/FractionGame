using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSelected : MonoBehaviour {

    void Start ()
    {
        PlayerPrefs.SetInt("selected", -1);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D clicked_collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (clicked_collider != null)
            {
                // if has not been disabled
                if (PlayerPrefs.GetInt(clicked_collider.gameObject.tag) == 0)
                {
                    PlayerPrefs.SetInt("selected", Int32.Parse(clicked_collider.gameObject.tag));
                }
            }
        }
    }
}
