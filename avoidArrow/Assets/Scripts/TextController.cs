using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public static TextController instance;
    public GameObject readyText;
    public GameObject gameOverText;

    private void Awake()
    {
        if (TextController.instance == null)
            TextController.instance = this;
    }

    IEnumerator ShowReady()
    {
        int cnt = 0;
        while (cnt < 3)
        {
            readyText.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            readyText.SetActive(false);

            yield return new WaitForSeconds(0.5f);
            cnt++;
        }
    }

    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        readyText.SetActive(false);
        gameOverText.SetActive(false);

        StartCoroutine(ShowReady());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
