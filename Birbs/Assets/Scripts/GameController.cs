using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text countText;
    private int count;
    bool scoring = true;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);

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
    }

    void SetCountText()
    {
        if (scoring == true)
        {
            countText.text = "Count: " + count.ToString();
        }
        else
        {

        }
    }
}
