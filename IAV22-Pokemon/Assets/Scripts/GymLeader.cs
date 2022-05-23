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
        foreach (Movement m in db.GetMovements().GetMoves()[idActualPokemon])
        {
            if (i < 4)
                moves[i] = m;
            i++;
        }
        for (int j = db.GetMovements().GetMoves()[idActualPokemon].Count; j < 4; j++)
            moves[j] = new Movement("", 0);
    }
    public void ReceiveDamage(Damage d)
    {
        Relations rels = GameManager.instance.GetDB().GetRelations();
        //Segun el tipo de daño: daño/defensaTipo
        float power = d.damage* rels.GetRelations()[d.ptype][actualPokemon.type1];
        if (actualPokemon.type2 != PokemonType.None)
            power *= rels.GetRelations()[d.ptype][actualPokemon.type2];
        actualStats.currhp -= d.mtype == StatsType.Physic ?(int)(power / actualStats.phyDefense ): (int)(power / actualStats.speDefense);
        if (actualStats.currhp < 0) actualStats.currhp = 0;
        battleHud.UpdateLive(actualStats.currhp);
        Debug.Log("GYM RECEIVA DAMAGE");

    }
    public PokemonDB GetPokemonActual()
    {
        return actualPokemon;
    }

    public Decision Think()
    {
        Decision d;
        //Determina cual es el pokemon menos débil frente al rival actual
        string bestPokemon = BestPokemon(GameManager.instance.GetPlayer().GetPokemonActual(), GameManager.instance.GetDB().GetGymLeaderTeam().GetPokemons());
        //Si es el mejor pokemon para enfrentarse al rival ataca, sino cambia de pokemon
        if (idActualPokemon == bestPokemon)
        {
            Movement bM = BestMovement(GameManager.instance.GetPlayer().GetPokemonActual());
            bM.currpp--;
            Attack attack = GameManager.instance.GetDB().GetAttacks().getAttacks()[bM.attack];
            d = new Decision(attack.damageType, attack.type,attack.damageType == StatsType.Physic ? (int)(attack.damage * actualStats.phyDamage) : (int)(attack.damage * actualStats.speDamage));
        }
        else
        {
            ChangePokemon(bestPokemon);
            d = new Decision(bestPokemon);
        }
        return d;
    }
    string BestPokemon(PokemonDB rival, Dictionary<string, PokemonInTeam> pokemons)
    {
        float best = 99, actual = 99;
        Relations rels = GameManager.instance.GetDB().GetRelations();
        string idBetter = idActualPokemon;
        //Comprobamos entre todos los pokemons del equipo cual es el menos débil
        foreach (PokemonInTeam pok in pokemons.Values)
        {
            if (GameManager.instance.GetDB().GetStats().GetStats()[pok.id].currhp > 0)
            {
                PokemonDB pokemon = GameManager.instance.GetDB().GetPokemons().getPokemons()[pok.pokemon];
                actual = rels.GetRelations()[rival.type1][pokemon.type1];
                if (rival.type2 != PokemonType.None)
                    actual *= rels.GetRelations()[rival.type2][pokemon.type1];
                if (pokemon.type2 != PokemonType.None)
                {
                    actual *= rels.GetRelations()[rival.type1][pokemon.type2];
                    if (rival.type2 != PokemonType.None)
                    actual *= rels.GetRelations()[rival.type2][pokemon.type2];
                }
                if (actual < best || (actual == best && pok.id == idActualPokemon))
                {

                    idBetter = pok.id;
                    best = actual;
                }

            }
        }
        return idBetter;
    }
    Movement BestMovement(PokemonDB rival)
    {
        float maxDamage = 0;
        int bestAttack = 0;
        DBComponent db = GameManager.instance.GetDB();
        float actualDamage = 0;
        for (int i = 0; i < 4; i++)
        {
            if (moves[i].currpp > 0)
            {
                actualDamage = CalculateDamage(rival, moves[i]);
                if (maxDamage < actualDamage)
                {
                    bestAttack = i;
                    maxDamage = actualDamage;
                }
            }
        }
        //Hay un 18.75% de que no use el mejor ataque
        if (Random.Range(0, 101) > 25)

            return moves[bestAttack];

        else
            return moves[Random.Range(0, db.GetMovements().GetMoves()[idActualPokemon].Count)];

    }
    int CalculateDamage(PokemonDB rival, Movement m)
    {
        DBComponent db = GameManager.instance.GetDB();
        Relations rels = db.GetRelations();
        Attack attack = db.GetAttacks().getAttacks()[m.attack];
        PokemonType atcType = attack.type;
        float power;
        power = rels.GetRelations()[atcType][rival.type1];
        if (rival.type2 != PokemonType.None)
            power *= rels.GetRelations()[atcType][rival.type2];
        //daño ataque*tipo ataque*efectividad
        return attack.damageType == StatsType.Physic ? (int)(attack.damage * actualStats.phyDamage * power) : (int)(attack.damage * actualStats.speDamage * power);
    }
    public string GetIDActualPokemon()
    {
        return idActualPokemon;
    }
    public void DieCurrentPokemon()
    {
        string aux = BestPokemon(GameManager.instance.GetPlayer().GetPokemonActual(), GameManager.instance.GetDB().GetGymLeaderTeam().GetPokemons());
        if (aux == idActualPokemon)
        {
            Application.Quit();
        }
        else
            ChangePokemon(aux);
    }
}
