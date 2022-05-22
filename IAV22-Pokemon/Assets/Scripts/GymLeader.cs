using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GymLeader : MonoBehaviour
{
    [SerializeField] BattleHud battleHud;
    [SerializeField] Image spritePlayer;
    PokemonDB actualPokemon;
    string idActualPokemon;
    Stat actualStats;
    Movement[] moves;

    public void ChangePokemon(string newPokemon)
    {
        DBComponent db = GameManager.instance.GetDB();
        PokemonInTeam pokemon = db.GetGymLeaderTeam().GetPokemons()[newPokemon];
        idActualPokemon = newPokemon;
        actualPokemon = db.GetPokemons().getPokemons()[pokemon.pokemon];
        actualStats = db.GetStats().GetStats()[pokemon.id];
        battleHud.SetData(pokemon.nickName, pokemon.lvl, actualStats.currhp, actualStats.hp);
        spritePlayer.sprite = actualPokemon.frontSprite;
        moves = new Movement[4];
        int i = 0;
        foreach(Movement m in db.GetMovements().GetMoves()[idActualPokemon]){
            if(i<4)
                moves[i] =m;
            i++;
        }
        for (int j = db.GetMovements().GetMoves()[idActualPokemon].Count; j < 4; j++)
            moves[j] = new Movement("", 0);
    }
    public void ReceiveDamage(int damage,StatsType type)
    {
        //Segun el tipo de daño: daño/defensaTipo
        actualStats.currhp -= damage;
        if (actualStats.currhp < 0) actualStats.currhp = 0;
        battleHud.UpdateLive(actualStats.currhp);
        Debug.Log(idActualPokemon + "CHP: " + actualStats.currhp);

    }
    public PokemonDB GetPokemonActual()
    {
        return actualPokemon;
    } 

    public void Think()
    {
        //Determina cual es el pokemon menos débil frente al rival actual
        string bestPokemon = BestPokemon(GameManager.instance.GetPlayer().GetPokemonActual(), 99, 0, GameManager.instance.GetDB().GetGymLeaderTeam().GetPokemons());
        //Si es el mejor pokemon para enfrentarse al rival ataca, sino cambia de pokemon
       if (idActualPokemon==bestPokemon )
        {
            Debug.Log(BestMovement(GameManager.instance.GetPlayer().GetPokemonActual()).attack);
        }
        else
        {
            ChangePokemon(bestPokemon);
        }
        
    }
    string BestPokemon(PokemonDB rival, float better, float actual, Dictionary<string, PokemonInTeam> pokemons)
    {
        Relations rels = GameManager.instance.GetDB().GetRelations();
        string idBetter=idActualPokemon;
        foreach ( PokemonInTeam pok in pokemons.Values)
        {
            PokemonDB pokemon = GameManager.instance.GetDB().GetPokemons().getPokemons()[pok.pokemon];
            actual = rels.GetRelations()[rival.type1][pokemon.type1];
            if (pokemon.type2 != PokemonType.None)
                actual *= rels.GetRelations()[rival.type1][pokemon.type2];
            if (actual < better&&rival.type2!=PokemonType.None)
            {
                actual+= rels.GetRelations()[rival.type2][pokemon.type1] * rels.GetRelations()[rival.type2][pokemon.type2];
            }
                if (actual < better)
                {

                    idBetter = pok.id;
                    better = actual;
                }

        }
        return idBetter;
    }
    Movement BestMovement(PokemonDB rival)
    {
        float maxDamage = 0;
        int bestAttack=0;
        DBComponent db = GameManager.instance.GetDB();
        Relations rels = db.GetRelations();

        for (int i = 0; i < 4; i++)
        {
            if (moves[i].currpp > 0)
            {

            Attack attack = db.GetAttacks().getAttacks()[moves[i].attack];
            PokemonType atcType = attack.type;
            float power;
            power = rels.GetRelations()[atcType][rival.type1];
            if (rival.type2 != PokemonType.None)
                power *= rels.GetRelations()[atcType][rival.type1];
            //daño ataque*tipo ataque*efectividad
            float actualDamage =attack.damageType==StatsType.Fisico? attack.damage*actualStats.phyDamage *power: attack.damage * actualStats.speDamage * power;
            Debug.Log("Comprobando: " + moves[i].attack+" poder "+actualDamage);
            if (maxDamage < actualDamage)
            {
                bestAttack = i;
                    maxDamage=actualDamage;
            }
            }
        }
        //Hay un 18.75% de que no use el mejor ataque
        if (Random.Range(0, 101) > 25)
            return moves[bestAttack];
        else
        {
            return moves[Random.Range(0, db.GetMovements().GetMoves()[idActualPokemon].Count)];
        }
    }
}
