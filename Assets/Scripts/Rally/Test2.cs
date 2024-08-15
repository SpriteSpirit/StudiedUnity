using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private Test test;

    private void Start()
    {
        test = GameObject.Find("Test").GetComponent<Test>();
        //Debug.Log(test.apples);
    }
    /* public Test test;
    *


    void Start()
    {
        test.apples = 150;
        Debug.Log(test.apples);
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
