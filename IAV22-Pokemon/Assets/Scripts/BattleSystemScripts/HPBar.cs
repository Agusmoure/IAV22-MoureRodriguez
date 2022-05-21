using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;
    public void SetHealth(float w)
    {
        health.transform.localScale = new Vector3(w,1.0f);
        if (health.transform.localScale.x < 0.2 && !(health.transform.localScale.x > 0.5))
            health.GetComponent<Image>().color = new Color32(0xD2, 0x35, 0x42, 0xFF);
        else
        {
            if (health.transform.localScale.x < 0.5)
                health.GetComponent<Image>().color = new Color32(0xD6, 0xCE, 0x00, 0xFF);
            else
                health.GetComponent<Image>().color = new Color32(0x25, 0xDD, 0x6D, 0xFF);
        }
    }
}
