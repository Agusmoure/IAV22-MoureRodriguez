using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionSelector : MonoBehaviour
{
    [SerializeField] GameObject Dialogue, Action, Moves,Team,DieTeam;
    private void Start()
    {
        Team.SetActive(false);
        DieTeam.SetActive(false);
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
    public void DiePokemon()
    {
        Dialogue.SetActive(false);
        Action.SetActive(false);
        Moves.SetActive(false);
        DieTeam.SetActive(true);
        DieTeam.GetComponent<TeamManager>().ShowTeam();
    }
}
