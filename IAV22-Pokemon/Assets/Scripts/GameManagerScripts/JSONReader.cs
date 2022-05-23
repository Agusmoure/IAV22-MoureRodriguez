using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Esta clase se encarga de leer los JSON y guardarlos en la base de datos.
public class JSONReader : MonoBehaviour
{
    public TextAsset PokemonFile;
    public TextAsset AttackFile;
    public TextAsset GymLeader;
    public TextAsset rival;
    public TextAsset relations;
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
        public string frontSprite;
        public string backSprite;
    }
    [System.Serializable]
    class PokemonsAux
    {
        public PokemonDBAux[] pokemons;
    }
    [System.Serializable]
    class AttackAux
    {
        public string id;
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
        public int level;

    }
    [System.Serializable]
    class TeamPokemonAux
    {
        public PokemonInTeamAux[] pokemons;
    }
    [System.Serializable]
     class MovementAux
    {
        public string pokemon;
        public string attack;
    }
    [System.Serializable]
     class MovementSetAux
    {
        public MovementAux[] moves;
    }

    [System.Serializable]
     class StatAux
    {
        public int hp;
        public int phyDamage;
        public int speDamage;
        public int phyDefense;
        public int speDefense;
        public int speed;
        public string id;
    }
    [System.Serializable]
     class PokemonsStatsAux
    {
        public StatAux[] stats;
    }
    [System.Serializable]
    class RelationAux
    {
        public string type;
        public float power;
    }
    [System.Serializable]
    class RelationsAux
    {
        public string type;
        public RelationAux[]relation;
    }
    class RelationsAuxArray
    {
       public RelationsAux[] relations;
    }
    #endregion
    AttacksAux attacksAux;
    PokemonsAux pokemonsAux;
    TeamPokemonAux gymTPokemonAux;
    TeamPokemonAux rivalPokemonAux;
    MovementSetAux gymMSetAux;
    MovementSetAux rivalMSetAux;
    PokemonsStatsAux gymLeaderStatsAux;
    PokemonsStatsAux rivalStatsAux;
    RelationsAuxArray relationsAux;
    // Start is called before the first frame update
    void Start()
    {
        db = transform.GetComponent<DBComponent>();
        pokemonsAux = JsonUtility.FromJson<PokemonsAux>(PokemonFile.text);
        attacksAux = JsonUtility.FromJson<AttacksAux>(AttackFile.text);
        //gymleader
        gymTPokemonAux = JsonUtility.FromJson<TeamPokemonAux>(GymLeader.text);
        gymMSetAux = JsonUtility.FromJson<MovementSetAux>(GymLeader.text);
        gymLeaderStatsAux = JsonUtility.FromJson<PokemonsStatsAux>(GymLeader.text);
        //rival
        rivalPokemonAux = JsonUtility.FromJson<TeamPokemonAux>(rival.text);
        rivalMSetAux = JsonUtility.FromJson<MovementSetAux>(rival.text);
        rivalStatsAux = JsonUtility.FromJson<PokemonsStatsAux>(rival.text);
        relationsAux = JsonUtility.FromJson<RelationsAuxArray>(relations.text);
        foreach (PokemonDBAux pokemon in pokemonsAux.pokemons)
        {
            db.GetPokemons().add(PokemonAuxtoPokemon(pokemon));
        }
        foreach (AttackAux a in attacksAux.attacks)
        {
            db.GetAttacks().add(AttackAuxToAttack(a));
        }
        //GymLeader
        foreach (PokemonInTeamAux p in gymTPokemonAux.pokemons)
        {
            db.GetGymLeaderTeam().add(PokemonITAuxToPokemonIT(p));
        }
        foreach (MovementAux m in gymMSetAux.moves)
        {
            db.GetMovements().add(m.pokemon,MovementAuxToMovement(m,db.GetAttacks().getAttacks()[m.attack].pp));
        }
        foreach (StatAux s in gymLeaderStatsAux.stats)
        {
            db.GetStats().add(s.id,StatAuxToStat(s));
        }
        //rival
        foreach (PokemonInTeamAux p in rivalPokemonAux.pokemons)
        {
            db.GetRivalTeam().add(PokemonITAuxToPokemonIT(p));
        }
        foreach (MovementAux m in rivalMSetAux.moves)
        {
            db.GetMovements().add(m.pokemon, MovementAuxToMovement(m, db.GetAttacks().getAttacks()[m.attack].pp));
        }
        foreach (StatAux s in rivalStatsAux.stats)
        {
            db.GetStats().add(s.id, StatAuxToStat(s));
        }
        //cargar relaciones

        foreach(RelationsAux rlsAux in relationsAux.relations)
        {
            PokemonType typeKey = getTypeFromString(rlsAux.type);
            foreach(RelationAux r in rlsAux.relation)
            {
                db.GetRelations().add(typeKey,RelationAuxToRelation(r));
            }
        }
        GameManager.instance.GetPlayer().ChangePokemon(GameManager.instance.GetFirstRival());
        GameManager.instance.GetGymLeader().ChangePokemon(GameManager.instance.GetFirstGymLeader());
    }
    // Update is called once per frame
    void Update()
    {

    }
    PokemonDB PokemonAuxtoPokemon(PokemonDBAux p)
    {
        PokemonType t1 = getTypeFromString(p.type1), t2 = getTypeFromString(p.type2);
        return new PokemonDB(p.natDexNumber, p.name, t1, t2,p.frontSprite,p.backSprite);

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
//

            case "siniestro":
                return PokemonType.Siniestro;
            case "roca":
                return PokemonType.Roca;
            case "lucha":
                return PokemonType.Lucha;
            case "psiquico":
                return PokemonType.Psiquico;
            case "fantasma":
                return PokemonType.Fantasma;
            case "normal":
                return PokemonType.Normal;
            case "acero":
                return PokemonType.Acero;
            case "bicho":
                return PokemonType.Bicho;
            case "electrico":
                return PokemonType.Electrico;
            case "volador":
                return PokemonType.Volador;
            case "veneno":
                return PokemonType.Veneno;
            case "fuego":
                return PokemonType.Fuego;
            case "planta":
                return PokemonType.Planta;
            case "agua":
                return PokemonType.Agua;
            case "tierra":
                return PokemonType.Tierra;
            case "hada":
                return PokemonType.Hada;
            case "dragon":
                return PokemonType.Dragon;
            case "hielo":
                return PokemonType.Hielo;
            default:
                return PokemonType.None;
        }
    }
    StatsType getStatsTypeFromString(string type)
    {
        switch (type.ToLower())
        {
            case "fisico":
                return StatsType.Physic;
            case "especial":
                return StatsType.Special;
            default:
                return StatsType.None;
        }
    }
    PokemonInTeam PokemonITAuxToPokemonIT(PokemonInTeamAux p)
    {
        return new PokemonInTeam(p.id, db.GetPokemons().getPokemons()[p.natDexNumber],p.level ,p.nickName);
    }
    Movement MovementAuxToMovement(MovementAux m,int pp)
    {
        return new Movement(m.attack,pp);
    }
    Stat StatAuxToStat(StatAux s)
    {
        return new Stat(s.hp, s.phyDamage, s.phyDefense, s.speDamage, s.speDefense, s.speed);
    }
    Relation RelationAuxToRelation(RelationAux r)
    {
        return new Relation(getTypeFromString(r.type), r.power);
    }
}
