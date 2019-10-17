using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ArrowSpawn : MonoBehaviour
{
    public static ArrowSpawn instance;

    Vector3[] positions = new Vector3[6];
    Vector3[] sidepositions = new Vector3[6];

    public GameObject Arrow;
    public GameObject ArrowSide;
    public bool isSpawn = false;
    public float spawnDelay = 1.5f;
    float spawnTimer = 0f;
    float levelTimer = 0f;

    void CreatePositions()
    {
        float viewPosY = 1.2f;
        float gapX = 1f / 6f;
        float viewPosX = 0f;

        for (int i =0; i < positions.Length; i++)
        {
            viewPosX = gapX/2 + gapX * i;
            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            worldPos.z = 0f;
            positions[i] = worldPos;
        }
    }

    void CreateSidePositions()
    {
        float viewPosX = -0.3f;
        float gapY = 1f / 6f;
        float viewPosY = 0f;

        for(int i = 0; i < sidepositions.Length; i++)
        {
            viewPosY = gapY/2 + gapY * i;
            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            worldPos.z = 0f;
            sidepositions[i] = worldPos;

        }
    }

    void SpawnArrow()
    {
        if(isSpawn == true)
        {
            spawnDelay -= levelTimer / 10000000;
            if (spawnTimer > spawnDelay)
            {
                int rand = Random.Range(0, positions.Length);
                int rand2 = Random.Range(0, sidepositions.Length);

                Instantiate(ArrowSide, sidepositions[rand2], Quaternion.identity);
                Instantiate(Arrow, positions[rand], Quaternion.identity);

                spawnTimer = 0f;
            }
            spawnTimer += Time.deltaTime;
            levelTimer += Time.deltaTime;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatePositions();
        CreateSidePositions();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnArrow();
    }

    private void Awake()
    {
        if (ArrowSpawn.instance == null)
            ArrowSpawn.instance = this;
    }

}
