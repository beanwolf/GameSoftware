using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    GameObject player;
    int heart = 3;
    public Text heartScore;
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("startGame", 1f);
    }

    void startGame()
    {
        ArrowSpawn.instance.isSpawn = true;
    }

    public void deleteHeart()
    {
        heart = heart - 1 ;
        heartScore.text = "남은 목숨 : " + heart;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
