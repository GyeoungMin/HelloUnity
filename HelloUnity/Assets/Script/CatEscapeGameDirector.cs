using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatEscapeGameDirector : MonoBehaviour
{
    [SerializeField] private Image hpGauge;

    public void DecreaseHp(float hp)
    {
        //this.hpGauge.fillAmount -= 0.1f;    //
        this.hpGauge.fillAmount = hp;
    }
    public float GetHp()
    {
        return this.hpGauge.fillAmount;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
