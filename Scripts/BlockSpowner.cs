using System.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpowner : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    List<GameObject> blocksSpowned = new List<GameObject>();

    private int playWidth = 8;
    private float gameSpeed =3f;
    float gameCount;
    [SerializeField] private float distanceBetweenBlocks = .2f;
    private int rowsSpownd;


    void Awake()
    {
        Invoke("SpownRowOfBlocks",gameSpeed);
    }

    private void SpownRowOfBlocks()
    {
        if(rowsSpownd % 10 == 0 )
        {
            GameManager.gm.level ++;
            BallLauncher.ballNo++;
        }

        foreach(var block in blocksSpowned) {
            if(block != null)
            {
                block.transform.position += Vector3.down * distanceBetweenBlocks;
            }

            
        }



        for(int i = 0; i < playWidth; i++) {
            if(UnityEngine.Random.Range(0,100) <= 30)
            {
                GameObject block = Instantiate(blockPrefab,GetPosition(i),Quaternion.identity);
                int hits = UnityEngine.Random.Range(1,3) + rowsSpownd;

                block.GetComponent<Points>().SetHits(hits);
                blocksSpowned.Add(block);

            }
        }

        rowsSpownd++;
        Invoke("SpownRowOfBlocks",gameSpeed);
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * distanceBetweenBlocks;
        return position;
    }
}
