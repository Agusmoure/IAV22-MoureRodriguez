using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionSelector : MonoBehaviour
{
    [SerializeField] GameObject Dialogue, Action, Moves,Team;
    private void Start()
    {
        Team.SetActive(false);
    }
    public void ActivateMoves()
    {
        Dialogue.SetActive(false);
        Action.SetActive(false);
        Team.SetActive(false);
        Moves.SetActive(true);
    }
    public void ChangePokemon()
    {
        Dialogue.SetActive(false);
        Action.SetActive(false);
        Moves.SetActive(false);
        Team.SetActive(true);
        Team.GetComponent<TeamManager>().ShowTeam();
    }
}
