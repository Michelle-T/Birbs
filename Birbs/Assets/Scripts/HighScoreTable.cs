using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;

    private void Awake()
    {
        //entryContainer = transform.Find("EntryContainer");
        //entryTemplate = entryContainer.Find("EntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 25f;
        int i;
        for (i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
