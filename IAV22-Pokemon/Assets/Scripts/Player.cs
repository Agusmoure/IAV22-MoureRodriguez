using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject playerHud;
    [SerializeField] BattleHud battleHud;
    [SerializeField] MovesHud movesHud;
    [SerializeField] Image spritePlayer;
    PokemonDB actualPokemon;
    string idActualPokemon;
    Stat actualStats;
    // Start is called before the first frame update
    void Start()
    {
        //ChangePokemon(GameManager.instance.GetFirstRival());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePokemon(string newPokemon)
    {
        DBComponent db = GameManager.instance.GetDB();
        PokemonInTeam pokemon=db.GetRivalTeam().GetPokemons()[newPokemon];
        idActualPokemon=newPokemon;
        actualPokemon = db.GetPokemons().getPokemons()[pokemon.pokemon];
        actualStats = db.GetStats().GetStats()[pokemon.id];
        Debug.Log(pokemon.nickName+"CHP: "+actualStats.currhp);
        battleHud.SetData(pokemon.nickName, pokemon.lvl, actualStats.currhp, actualStats.hp);
        spritePlayer.sprite = actualPokemon.backSprite;
        //Movimientos actuales
        List<Attack> atc = new List<Attack>();
        foreach(Movement m in db.GetMovements().GetMoves()[newPokemon])
        {
            atc.Add(db.GetAttacks().getAttacks()[m.attack]);
        }
        movesHud.SetMoves(atc);
    }
    public void ReceiveDamage(int damage)
    {
        actualStats.currhp -= damage;
        if (actualStats.currhp < 0) actualStats.currhp = 0;
        battleHud.UpdateLive(actualStats.currhp);
        Debug.Log(idActualPokemon + "CHP: " + actualStats.currhp);

    }
    public PokemonDB GetPokemonActual()
    {
        return actualPokemon;
    }
}
