using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PControllerPH : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    public Text countText;
    private int count;

    Camera cam;

    public LayerMask kiwiMask;
    //public GameObject Menu;

    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        cam = Camera.main;

        count = 0;
        SetCountText();

        pausePanel.SetActive(false);
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

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Menu.SetActive(!Menu.activeInHierarchy);
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }
            else
            {
                if (pausePanel.activeInHierarchy)
                {
                    ContinueGame();
                }
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
