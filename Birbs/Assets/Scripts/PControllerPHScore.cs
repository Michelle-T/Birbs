using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PControllerPHScore : MonoBehaviour
{
    public Text countText;
    private int count;

    public float radius;
    public float depth;
    public float angle;
    //private Physics physics;

    Camera cam;

    //public LayerMask kiwiMask;
    //public GameObject Menu;

    public GameObject pausePanel;
    bool pause = false;

    bool scoring = true;

    public int film;
    public Text filmText;

    public GameObject WinScreen;
    public GameObject LoseScreen;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        count = 0;
        //SetCountText();
        countText.text = "Count: " + count.ToString();
        filmText.text = "Film: " + film.ToString();
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if ((Physics.Raycast(ray, out hit, 100)) && scoring == true)
            {
                //Debug.Log("We hit " + hit.collider.name + " " + hit.point);

                if (hit.collider.gameObject.tag == "Kiwi")
                {
                    Debug.Log("Kiwi!");
                    count = count + 5;
                    SetCountText();
                }
                if (hit.collider.gameObject.tag == "Banana")
                {
                    Debug.Log("Banana!");
                    count = count + 10;
                    SetCountText();
                }
                if (hit.collider.gameObject.tag == "Grape")
                {
                    Debug.Log("Grape");
                    count = count + 20;
                    SetCountText();
                }
            }
        }

        /*RaycastHit[] coneHits = physics.ConeCastAll(transform.position, radius, transform.forward, depth, angle);

        if (coneHits.Length > 0)
        {
            for (int i = 0; i < coneHits.Length; i++)
            {
                coneHits[i].collider.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1f);
            }
        }*/

        if (Input.GetKeyDown("escape"))
        {
            if (pause == true)
            {
                Time.timeScale = 0.0f;
                pausePanel.SetActive(true);
                count = count + 0;
                pause = false;
            }
            else
            {
                Time.timeScale = 1.0f;
                pausePanel.SetActive(false);
                scoring = true;
                pause = true;
            }
        }
    }

    void FixedUpdate()
    {

    }

    void SetCountText()
    {
        //If the film doesn't reach 0, take points. Film size can be adjusted in Inspector of Unity
        if (film != 0)
        {
            countText.text = "Count: " + count.ToString();
            film = film - 1;
            filmText.text = "Film: " + film.ToString();

            if (count >= 100)
            {
                WinScreen.SetActive(true);
            }
        }
        //If the film does reach 0, stop taking points
        else if (film == 0)
        {
            count = count + 0;
        }
    }
}
