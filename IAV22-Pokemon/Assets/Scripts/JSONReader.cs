using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JSONReader : MonoBehaviour
{
    public TextAsset PokemonFile;
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
        public PokemonDBAux[] pokemonsAux;
    }
    [System.Serializable]
     class AttackAux
    {
        string id;
        string name;
        string type;
        int damage;
        string damageType;
        int pp;
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

    #endregion
    PokemonsAux pokemonsAux;
    Pokemons pokemons=new Pokemons();
    // Start is called before the first frame update
    void Start()
    {
         pokemonsAux= JsonUtility.FromJson<PokemonsAux>(PokemonFile.text);
        Debug.Log(pokemonsAux.pokemonsAux);
        foreach (PokemonDBAux pokemon in pokemonsAux.pokemonsAux)
        {
            Debug.Log("Found Pokemon: " + pokemon.natDexNumber + " " + pokemon.name + " " + pokemon.type1 + " " + pokemon.type2);
            pokemons.add(PokemonAuxtoPokemon(pokemon));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            foreach(KeyValuePair<int, PokemonDB>  p in pokemons.getPokemons())
            {
                Debug.Log(p.Key + " " + p.Value.type1);
            }
        }
    }

    PokemonDB PokemonAuxtoPokemon(PokemonDBAux p)
    {
        PokemonType t1=getTypeFromString(p.type1), t2=getTypeFromString(p.type2);
        return new PokemonDB(p.natDexNumber, p.name, t1, t2);

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
}
