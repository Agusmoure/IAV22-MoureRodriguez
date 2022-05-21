using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moves : MonoBehaviour
{
    Attack _actualMovement;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAttack(Attack m)
    {
        _actualMovement = m;
        transform.GetComponent<Text>().text = m.name;
    }
    public Attack GetAttack()
    {
        return _actualMovement;
    }

}
