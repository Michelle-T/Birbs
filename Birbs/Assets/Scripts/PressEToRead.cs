using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEToRead : MonoBehaviour
{
    public GameObject Player;
    public float minDist = 5;
    public string text = "Hello";
    float dist;
    bool reading = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Player.gameObject.transform.position, gameObject.transform.position);
        
        if(dist <= minDist)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(reading)
                {
                    reading = false;
                }
                else
                {
                    reading = true;
                }
            }
        }
        else
        {
            reading = false;
        }
    }

    private void OnGUI()
    {
        if(reading)
        {
            GUI.TextArea(new Rect(Screen.height / 2, Screen.width / 2, 500, 500), text);
        }
        else if(dist <= minDist)
        {
            GUI.TextArea(new Rect(Screen.height/2, Screen.width/2, 500, 500), "Press 'E' to read.");
        }
    }
}
