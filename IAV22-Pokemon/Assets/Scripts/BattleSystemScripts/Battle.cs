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
            //El pokemon elegido no es válido
            if (playerDecision.newPokemonID == "")
            {
                player.PokemonChanged();
                return;
            }
            player.ChangePokemon(playerDecision.newPokemonID);

            if (gymLeaderDecision.change)//Los dos cambian
            {
                gymLeader.ChangePokemon(gymLeaderDecision.newPokemonID);
            }
            else//El lider no cambia
            {
                player.ReceiveDamage(gymLeaderDecision.damage);
                Debug.Log("GYMLEADER EJECUTA ATAQUE");
                if (GameManager.instance.GetDB().GetStats().GetStats()[player.GetIDActualPokemon()].currhp <= 0)
                {
                    Debug.Log("MUERE POKEMON DE PLAYER");
                    player.DieCurrentPokemon();
                }
            }
        }
        else//el jugador ataca
        {
            if (gymLeaderDecision.change)//Lider cambia pokemon
            {
                gymLeader.ChangePokemon(gymLeaderDecision.newPokemonID);
                gymLeader.ReceiveDamage(playerDecision.damage);
                if (GameManager.instance.GetDB().GetStats().GetStats()[gymLeader.GetIDActualPokemon()].currhp <= 0)
                {
                    gymLeader.DieCurrentPokemon();
                    Debug.Log("MUERE POKEMON DE GYMLEADER");
                }
            }
            else//Los dos atacan
            {
                if (GameManager.instance.GetDB().GetStats().GetStats()[player.GetIDActualPokemon()].speed < GameManager.instance.GetDB().GetStats().GetStats()[gymLeader.GetIDActualPokemon()].speed)
                {
                    player.ReceiveDamage(gymLeaderDecision.damage);
                    //Gestionar la muerte del pokemon del jugador
                    if (GameManager.instance.GetDB().GetStats().GetStats()[player.GetIDActualPokemon()].currhp <= 0)
                    {
                        player.DieCurrentPokemon();
                    }
                    else
                    {
                        gymLeader.ReceiveDamage(playerDecision.damage);
                        Debug.Log("GYMLEADER EJECUTA ATAQUE");
                        if (GameManager.instance.GetDB().GetStats().GetStats()[gymLeader.GetIDActualPokemon()].currhp <= 0)
                        {
                            gymLeader.DieCurrentPokemon();
                            Debug.Log("MUERE POKEMON DE GYMLEADER");
                        }
                    }
                }
                else
                {
                    Debug.Log("PLAYER ATACA GYM ATACA");
                    gymLeader.ReceiveDamage(playerDecision.damage);
                    if (GameManager.instance.GetDB().GetStats().GetStats()[gymLeader.GetIDActualPokemon()].currhp <= 0)
                    {
                        gymLeader.DieCurrentPokemon();
                        Debug.Log("MUERE POKEMON DE GYMLEADER");

                    }
                    else
                    {
                        player.ReceiveDamage(gymLeaderDecision.damage);
                        if (GameManager.instance.GetDB().GetStats().GetStats()[player.GetIDActualPokemon()].currhp <= 0)
                        {
                            player.DieCurrentPokemon();

                        }
                    }
                }
            }
        }
    }
}
