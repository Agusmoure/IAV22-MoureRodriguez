using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionSelector : MonoBehaviour
{
    [SerializeField] GameObject Dialogue, Action, Moves;
    public void ActivateMoves()
    {
        Dialogue.SetActive(false);
        Action.SetActive(false);
        Moves.SetActive(true);
    }
    public void ChangePokemon()
    {
        Debug.Log("Change Pokemon");
    }
}
