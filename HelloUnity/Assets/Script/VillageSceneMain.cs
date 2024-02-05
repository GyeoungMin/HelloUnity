using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillegeSceneMain : MonoBehaviour
{
    private HeroDataManager heroDataManager;
    void Start()
    {
        this.heroDataManager = GameObject.FindAnyObjectByType<HeroDataManager>();

        Debug.LogFormat("{0}/{1}", this.heroDataManager.GetHeroHp(), heroDataManager.GetHeroMaxHp());
    }
}