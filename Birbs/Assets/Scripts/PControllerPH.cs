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
    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

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

        if (Input.GetKeyDown("escape"))
        {
            Menu.SetActive(!Menu.activeInHierarchy);
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

    }
}
