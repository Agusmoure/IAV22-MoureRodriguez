using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text name;
    [SerializeField] Text lvl;
    [SerializeField] HPBar hpBar;
    int maxValue = 10000;
    int actualValue = 10000;
    int lv;
    public void SetData(string n,int l,int actualLive,int maxValue)
    {
        name.text=n;
        lvl.text = "Lvl" + l;
        hpBar.SetHealth((float)actualLive / (float)maxValue);
    }
     void Update()
    {
        SetData("", lv++, Mathf.Abs(--actualValue%maxValue), maxValue);
    }
}
