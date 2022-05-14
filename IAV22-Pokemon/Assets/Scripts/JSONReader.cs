using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Esta clase se encarga de leer los JSON y guardarlos en la base de datos.
public class JSONReader : MonoBehaviour
{
    public TextAsset PokemonFile;
    public TextAsset AttackFile;
    public TextAsset GymLeader;
    DBComponent db;
    #region AuxClass
    //Para poder emular una base de datos relacional y poder leer de JSON de manera sencilla se crean una serie de clases auxiliares
    [System.Serializable]
    class PokemonDBAux
    {
        public int natDexNumber;
        public string name;
        public string type1;
        public string type2;
    }
    [System.Serializable]
     class PokemonsAux
    {
        public PokemonDBAux[] pokemons;
    }
    [System.Serializable]
     class AttackAux
    {
      public  string id;
        public string name;
        public string type;
        public int damage;
        public string damageType;
        public int pp;
    }
    [System.Serializable]
    class AttacksAux
    {
        public AttackAux[] attacks;
    }
    [System.Serializable]
    public class StatsAux
    {
        public int hp;
        public int phyDamage;
        public int speDamage;
        public int phyDefense;
        public int speDefense;
        public int speed;
    }
    [System.Serializable]
     class PokemonInTeamAux
    {
        public string id;
        public string nickName;
        public int natDexNumber;
        
    }
    [System.Serializable]
     class TeamPokemonAux
    {
       public PokemonInTeamAux[] pokemons;
    }
    #endregion
    AttacksAux attacksAux;
    PokemonsAux pokemonsAux;
    TeamPokemonAux tPokemonAux;
    // Start is called before the first frame update
    void Start()
    {
        db = transform.GetComponent<DBComponent>();
         pokemonsAux= JsonUtility.FromJson<PokemonsAux>(PokemonFile.text);
         attacksAux= JsonUtility.FromJson<AttacksAux>(AttackFile.text);
        tPokemonAux = JsonUtility.FromJson<TeamPokemonAux>(GymLeader.text);
        foreach (PokemonDBAux pokemon in pokemonsAux.pokemons)
        {
            Debug.Log("Found Pokemon: " + pokemon.natDexNumber + " " + pokemon.name + " " + pokemon.type1 + " " + pokemon.type2);
            db.GetPokemons().add(PokemonAuxtoPokemon(pokemon));
        }
        foreach (AttackAux a in attacksAux.attacks)
        {
            Debug.Log("Found attack: " +a.id );
            db.GetAttacks().add(AttackAuxToAttack(a));
        }
        foreach(PokemonInTeamAux p in tPokemonAux.pokemons)
        {
            Debug.Log("Found Pokemon: " +p.id);
            db.getGymLeader().add(PokemonITAuxToPokemonIT(p));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    PokemonDB PokemonAuxtoPokemon(PokemonDBAux p)
    {
        PokemonType t1=getTypeFromString(p.type1), t2=getTypeFromString(p.type2);
        return new PokemonDB(p.natDexNumber, p.name, t1, t2);

    }
    Attack AttackAuxToAttack(AttackAux a)
    {
        PokemonType t = getTypeFromString(a.type);
        StatsType st = getStatsTypeFromString(a.damageType);
        return new Attack(a.id, a.name, t, a.damage, st, a.pp);
    }
    PokemonType getTypeFromString(string type)
    {
        switch (type.ToLower())
        {
            case "siniestro":
                return PokemonType.Siniestro;
            case "roca":
                return PokemonType.Roca;
            case "lucha":
                return  PokemonType.Lucha;
            case "psiquico":
                return  PokemonType.Psiquico;
            default:
                return  PokemonType.None;
        }
    }
    StatsType getStatsTypeFromString(string type)
    {
        switch (type.ToLower())
        {
            case "fisico":
                return StatsType.Fisico;
            case "especial":
                return StatsType.Especial;
            default:
                return StatsType.None;
        }
    }
    PokemonInTeam PokemonITAuxToPokemonIT(PokemonInTeamAux p)
    {
        return new PokemonInTeam(p.id,db.GetPokemons().getPokemons()[p.natDexNumber],p.nickName);
    }
}
