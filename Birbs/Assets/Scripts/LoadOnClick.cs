using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour
{
    public GameObject loadingImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int level)
    {
        loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}
