using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PokemonType { None,Siniestro,Roca,Psiquico,Fantasma,Normal,Lucha}
public enum StatsType { Physical, Special }
[System.Serializable]
public class PokemonDB
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
    public PokemonDB(int nD,string na,PokemonType t1,PokemonType t2) {
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
    public void add(PokemonDB p) {
        pokemons[p.natDexNumber] = p;
    }
    public Dictionary<int,PokemonDB> getPokemons() { return pokemons; }
}
[System.Serializable]
public class Attack
{
    string _id;
    string _name;
    PokemonType _type;
    int _damage;
    StatsType _damageType;
    int _pp;
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
}

[System.Serializable]
public class Stats
{
    int _hp;
    int _phyDamage;
    int _speDamage;
    int _phyDefense;
    int _speDefense;

    int _speed;
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
}

struct PokemonInGame
{
    public Stats stats;
    public PokemonDB pokemon;
    public string nickName;
    //public PokemonInGame(PokemonDB p,Stats stats, string nick="")
    //{
    //    _pokemon = p;
    //    _stats = stats;
    //    _nickName = nick!=""?nick:p.name;
    //}
}