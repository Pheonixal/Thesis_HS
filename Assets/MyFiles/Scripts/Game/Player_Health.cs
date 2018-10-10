using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{

    public int health;
    public bool hasDied;

    // Use this for initialization
    void Start()
    {
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -147)
        {
            hasDied = true;
        }
        if (hasDied == true)
        {
            StartCoroutine("Die");
        }

        if (gameObject.transform.position.x > 3786){
        	StartCoroutine("Win");
        }
    }

    IEnumerator Die()
    {
        SceneManager.LoadScene(4);
        yield return null;
    }
	IEnumerator Win()
    {
        SceneManager.LoadScene(6);
        yield return null;
    }
}﻿