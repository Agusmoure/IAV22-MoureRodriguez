using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PokemonType { None, Siniestro, Roca, Psiquico, Fantasma, Normal, Lucha }
public enum StatsType { Fisico, Especial, None }
[System.Serializable]
public struct PokemonDB
{
    int _natDexNumber;
    string _name;
    PokemonType _type1;
    PokemonType _type2;
    public int natDexNumber
    {
        get { return _natDexNumber; }
        set { _natDexNumber = value; }
    }
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public PokemonType type1
    {
        get { return _type1; }
        set { _type1 = value; }
    }
    public PokemonType type2
    {
        get { return _type2; }
        set { _type2 = value; }
    }
    public PokemonDB(int nD, string na, PokemonType t1, PokemonType t2)
    {
        _natDexNumber = nD;
        _name = na;
        _type1 = t1;
        _type2 = t2;
    }
}
[System.Serializable]

public class Pokemons
{
    public Pokemons()
    {
        pokemons = new Dictionary<int, PokemonDB>();
    }
    Dictionary<int, PokemonDB> pokemons;
    public void add(PokemonDB p)
    {
        pokemons[p.natDexNumber] = p;
    }
    public Dictionary<int, PokemonDB> getPokemons() { return pokemons; }
}
[System.Serializable]
public struct Attack
{
    string _id;
    string _name;
    PokemonType _type;
    int _damage;
    StatsType _damageType;
    int _pp;
    int _currPp;
    public string id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public PokemonType type
    {
        get { return _type; }
        set { _type = value; }
    }
    public int damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public StatsType damageType
    {
        get { return _damageType; }
        set { _damageType = value; }
    }
    public int pp
    {
        get { return _pp; }
        set { _pp = value; }
    }
    public int currpp
    {
        get { return _currPp; }
        set { _currPp = value; }
    }

    public Attack(string id_, string na, PokemonType ty, int dam, StatsType st, int ammount)
    {
        _id = id_;
        _name = na;
        _type = ty;
        _damage = dam;
        _damageType = st;
        _pp = ammount;
        _currPp = ammount;
    }
}
[System.Serializable]
public class Attacks
{
    public Attacks()
    {
        attacks = new Dictionary<string, Attack>();
    }

    Dictionary<string, Attack> attacks;
    public void add(Attack a)
    {
        attacks[a.id] = a;
    }
    public Dictionary<string, Attack> getAttacks() { return attacks; }
}
[System.Serializable]
public struct Stat
{
    int _hp;
    int _currHp;
    int _phyDamage;
    int _speDamage;
    int _phyDefense;
    int _speDefense;
    int _speed;
    public int currhp
    {
        get { return _currHp; }
        set { _currHp = value; }
    }
    public void SetCurrHp(int val) { currhp = val; }
    public int hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
    public int phyDamage
    {
        get { return _phyDamage; }
        set { _phyDamage = value; }
    }
    public int speDamage
    {
        get { return _speDamage; }
        set { _speDamage = value; }
    }
    public int phyDefense
    {
        get { return _phyDefense; }
        set { _phyDefense = value; }
    }
    public int speDefense
    {
        get { return _speDefense; }
        set { _speDefense = value; }
    }
    public int speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public Stat(int h,int pDa,int pDe,int sDa,int sDe,int s)
    {
        _hp = h;
        _currHp = h;
        _phyDamage = pDa;
        _phyDefense = pDe;
        _speDamage = sDa;
        _speDefense = sDe;
        _speed = s;
    }
}
[System.Serializable]
public class PokemonsStats
{
    Dictionary<string, Stat> stats;
    public PokemonsStats()
    {
        stats = new Dictionary<string, Stat>();
    }
    public void add(string id,Stat m)
    {
        stats[id]=m;
    }
    public Dictionary<string, Stat> GetStats() { return stats; }
}
[System.Serializable]
public struct PokemonInTeam
{
    string _id;
    string _nickName;
    int _pokemon;
    public string id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string nickName
    {
        get { return _nickName; }
        set { _nickName = value; }
    }
    public int pokemon
    {
        get { return _pokemon; }
        set { _pokemon = value; }
    }
    public PokemonInTeam(string i, PokemonDB poke, string n = "")
    {
        _id = i;
        _pokemon = poke.natDexNumber;
        _nickName = n == "" ? poke.name : n;
    }
}
[System.Serializable]
public class TeamPokemon
{
    Dictionary<string, PokemonInTeam> pokemons;
    public TeamPokemon()
    {
        pokemons = new Dictionary<string, PokemonInTeam>();
    }
    public void add(PokemonInTeam p)
    {
        pokemons[p.id] = p;
    }
    public Dictionary<string, PokemonInTeam> GetPokemons() { return pokemons; }
}
[System.Serializable]
public struct Movement
{
    //string _pokemon;
    string _attack;
    //public string pokemon
    //{
    //    get { return _pokemon; }
    //    set { _pokemon = value; }
    //}
    public string attack
    {
        get { return _attack; }
        set { _attack = value; }
    }
    public Movement(/*string p,*/ string a)
    {
        // _pokemon = p;
        _attack = a;
    }
}
[System.Serializable]
public class MovementSet
{
    Dictionary<string, List<Movement>> moves;
    public MovementSet()
    {
        moves = new Dictionary<string, List<Movement>>();
    }
    public void add(string id, Movement m)
    {
        if (!moves.ContainsKey(id))
        {
            moves[id] = new List<Movement>();
        }
        moves[id].Add(m);
    }
    public Dictionary<string, List<Movement>> GetMoves() { return moves; }
}