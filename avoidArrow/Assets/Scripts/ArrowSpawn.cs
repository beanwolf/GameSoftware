using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ArrowSpawn : MonoBehaviour
{
    public static ArrowSpawn instance;

    Vector3[] positions = new Vector3[6];

    public GameObject Arrow;
    public bool isSpawn = false;
    public float spawnDelay = 1.5f;
    float spawnTimer = 0f;

    void CreatePositions()
    {
        float viewPosY = 1.2f;
        float gapX = 1f / 6f;
        float viewPosX = 0f;

        for (int i =0; i < positions.Length; i++)
        {
            viewPosX = gapX + gapX * i;
            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            worldPos.z = 0f;
            positions[i] = worldPos;
        }
    }

    void SpawnArrow()
    {
        if(isSpawn == true)
        {
            if (spawnTimer > spawnDelay)
            {
                int rand = Random.Range(0, positions.Length);

                Instantiate(Arrow, positions[rand], Quaternion.identity);
                Arrow.transform.rotation = Quaternion.Euler(0, 0, -90);

                spawnTimer = 0f;
            }
            spawnTimer += Time.deltaTime;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatePositions();
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
