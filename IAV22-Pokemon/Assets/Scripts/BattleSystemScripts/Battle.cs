using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{

    public void ProcessTurn(Decision playerDecision)
    {
        Decision gymLeaderDecision = GameManager.instance.GetGymLeader().Think();
        Player player = GameManager.instance.GetPlayer();
        GymLeader gymLeader = GameManager.instance.GetGymLeader();
        if (playerDecision.change)
        {
            if (playerDecision.newPokemonID == "")
            {
                player.PokemonChanged();
                return;
            }
            player.ChangePokemon(playerDecision.newPokemonID);
            if (gymLeaderDecision.change)
            {
            Debug.Log("PLAYER Y GYM CAMBIAN");
                gymLeader.ChangePokemon(gymLeaderDecision.newPokemonID);
            }
            else
            {
            Debug.Log("PLAYER CAMBIA GYM ATACA");
               player.ReceiveDamage(gymLeaderDecision.damage);
                if (GameManager.instance.GetDB().GetStats().GetStats()[player.GetIDActualPokemon()].currhp <= 0)
                    player.DieCurrentPokemon();
            }
        }
        else
        {
            if (gymLeaderDecision.change)
            {
                Debug.Log("GYM CAMBIA PLAYER ATACA");
                gymLeader.ChangePokemon(gymLeaderDecision.newPokemonID);
                gymLeader.ReceiveDamage(playerDecision.damage);
                if (GameManager.instance.GetDB().GetStats().GetStats()[gymLeader.GetIDActualPokemon()].currhp <= 0)
                    gymLeader.DieCurrentPokemon();
            }
            else
            {
                if (GameManager.instance.GetDB().GetStats().GetStats()[player.GetIDActualPokemon()].speed < GameManager.instance.GetDB().GetStats().GetStats()[gymLeader.GetIDActualPokemon()].speed)
                {
                     Debug.Log("GYM ATACA PLAYER ATACA");
                    player.ReceiveDamage(gymLeaderDecision.damage);
                    //Gestionar la muerte del pokemon del jugador
                    if (GameManager.instance.GetDB().GetStats().GetStats()[player.GetIDActualPokemon()].currhp <= 0)
                        player.DieCurrentPokemon();
                    else
                    {
                        gymLeader.ReceiveDamage(playerDecision.damage);
                        if (GameManager.instance.GetDB().GetStats().GetStats()[gymLeader.GetIDActualPokemon()].currhp <= 0)
                            gymLeader.DieCurrentPokemon();
                    }
                }
                else
                {
                     Debug.Log("PLAYER ATACA GYM ATACA");
                    gymLeader.ReceiveDamage(playerDecision.damage);
                    if (GameManager.instance.GetDB().GetStats().GetStats()[gymLeader.GetIDActualPokemon()].currhp <= 0)
                        gymLeader.DieCurrentPokemon();
                    else
                    {
                        player.ReceiveDamage(gymLeaderDecision.damage);
                        if (GameManager.instance.GetDB().GetStats().GetStats()[player.GetIDActualPokemon()].currhp <= 0)
                            player.DieCurrentPokemon();
                    }
                    }
            }
        }
    }
}
