using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text pName;
    [SerializeField] Text lvl;
    [SerializeField] HPBar hpBar;
    int maxLife;
    public void SetData(string n,int l,int actualLive,int maxValue)
    {
        pName.text=n;
        lvl.text = "Lvl" + l;
        hpBar.SetHealth((float)actualLive / (float)maxValue);
        maxLife = maxValue;
    }
    public void UpdateLive(float actualLive)
    {
        hpBar.SetHealth(actualLive / (float)maxLife);
    }
}
