using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveDetails : MonoBehaviour
{
    [SerializeField] Text pp;
    [SerializeField] Text type;
    public void SetDetails(Movement m)
    {
        Attack a = GameManager.instance.GetDB().GetAttacks().getAttacks()[m.attack];
        pp.text ="PP "+ m.currpp+"/"+a.pp;
        type.text = a.type.ToString();
    }
    public void Clear()
    {
        pp.text = "PP /";
        type.text = "None";
    }
}
