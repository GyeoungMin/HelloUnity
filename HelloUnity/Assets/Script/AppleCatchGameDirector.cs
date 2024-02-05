using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AppleCatchGameDirector : MonoBehaviour
{
    [SerializeField] private GameObject basketGo;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timerText;

    private BasketController basketController;
    private float score;
    private float timer = 60f;
    private Coroutine scoreCoroutine;
    private Coroutine timerCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        basketController = basketGo.GetComponent<BasketController>();
        scoreCoroutine = StartCoroutine(CoScore());
        timerCoroutine = StartCoroutine(CoTimer(() =>
        {
            StopCoroutine(scoreCoroutine);
            StopCoroutine(timerCoroutine);
        }));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CoScore()
    {
        while (true)
        {
            score = basketController.Score;
            scoreText.text = "Score : " + score.ToString("0");
            yield return null;
        }
    }

    IEnumerator CoTimer(System.Action callback)
    {
        while (true)
        {
            if (timer <= 0)
            {
                break;
            }
            timer -= Time.deltaTime;
            timerText.text = "남은시간 : " + TimeSpan.FromSeconds(timer).ToString("ss\\:ff");
            yield return null;
        }
        callback();
    }
}
