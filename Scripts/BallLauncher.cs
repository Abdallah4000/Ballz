using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    public static int ballNo = 3;
    LauncherPreview launcherPreview;
    Vector3 startPostion ;
    Vector3 endPostion;

    void Awake()
    {
        launcherPreview = GetComponent<LauncherPreview>();
    }

    void Update()
    {
        Vector3 WorldPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;

        if(Input.GetMouseButtonDown(0))
        {
            StartDrag(WorldPostion);
        }
        else if (Input.GetMouseButton(0))
        {
            continueDrag(WorldPostion);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            endDrag();

        }       
    }

    public void StartDrag (Vector3 worldPostion)
    {
        startPostion = worldPostion;
        launcherPreview.SetStartPoint(transform.position);   
    }

    public void continueDrag (Vector3 worldPostion) {

        endPostion = worldPostion;
        Vector3 diraction = endPostion-startPostion; 

        launcherPreview.SetEndPoint(transform.position - diraction);
        
    }

    public void endDrag () {
        StartCoroutine(BallLaunch());
    }

    private IEnumerator BallLaunch()
    {
        Vector3 direction = endPostion - startPostion ;
        direction.Normalize();

        for(int i = 0; i < ballNo; i++) {
            var ball = Instantiate(ballPrefab ,transform.position ,Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);

            yield return new WaitForSeconds(.1f);
            
        }


    } 
}
