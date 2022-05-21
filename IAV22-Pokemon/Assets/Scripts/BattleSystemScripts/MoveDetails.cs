using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveDetails : MonoBehaviour
{
    [SerializeField] Text pp;
    [SerializeField] Text type;
    public void SetDetails(Attack a)
    {
        pp.text = a.currpp+"/"+a.pp;
        type.text = a.type.ToString();
    }
}
