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
    [SerializeField] TeamManager team;
    PokemonDB actualPokemon;
    string idActualPokemon;
    Stat actualStats;
    // Start is called before the first frame update
    void Start()
    {
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
        battleHud.SetData(pokemon.nickName, pokemon.lvl, actualStats.currhp, actualStats.hp);
        spritePlayer.sprite = actualPokemon.backSprite;
        //Movimientos actuales
        List<Movement> atc = new List<Movement>();
        foreach(Movement m in db.GetMovements().GetMoves()[newPokemon])
        {
            atc.Add(m);
        }
        movesHud.SetMoves(atc);
        PokemonChanged();
    }
    public void ReceiveDamage(Damage d)
    {
        //Segun el tipo de daño: daño/defensaTipo
        Debug.Log("PLAYER RECEIVEDAMAGE");
        Relations rels = GameManager.instance.GetDB().GetRelations();
        //Segun el tipo de daño: daño/defensaTipo
        float power = d.damage * rels.GetRelations()[d.ptype][actualPokemon.type1];
        if (actualPokemon.type2 != PokemonType.None)
            power *= rels.GetRelations()[d.ptype][actualPokemon.type2];
        actualStats.currhp -= d.mtype == StatsType.Physic ?(int)(power / actualStats.phyDefense ): (int)(power / actualStats.speDefense);
        if (actualStats.currhp < 0) actualStats.currhp = 0;
        battleHud.UpdateLive(actualStats.currhp);

    }
    public PokemonDB GetPokemonActual()
    {
        return actualPokemon;
    }
    public string GetIDActualPokemon()
    {
        return idActualPokemon;
    }

    public void PokemonChanged()
    {
        team.PokemonChanged();
    }
    public Stat GetActualStat()
    {
        return actualStats;
    }
}
