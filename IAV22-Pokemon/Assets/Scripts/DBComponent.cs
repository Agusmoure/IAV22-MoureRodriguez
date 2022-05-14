using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Este Script será el encargado de almacenar los datos
public class DBComponent : MonoBehaviour
{
    Pokemons pokemons;
    Attacks attacks;
    TeamPokemon gymLeader;
    private void Awake()
    {
     pokemons = new Pokemons();
     attacks = new Attacks();
        gymLeader = new TeamPokemon();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            foreach (KeyValuePair<int, PokemonDB> p in pokemons.getPokemons())
            {
                Debug.Log(p.Key + " " + p.Value.type1);
            }
            foreach (KeyValuePair<string, Attack> p in attacks.getAttacks())
            {
                Debug.Log(p.Key + " " + p.Value.name);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PokemonDB p = GetPokemonDBFromTeam("LS1");
            Debug.Log("Pokemon con ID LS1: " +gymLeader.GetPokemons()["LS1"].nickName);
            Debug.Log("Pokemon con ID LS1: " + p.name + " " + p.natDexNumber + " " + p.type1);
        }
    }
    public Pokemons GetPokemons()
    {
        return pokemons;
    }
    public Attacks GetAttacks()
    {
        return attacks;
    }
    public TeamPokemon getGymLeader()
    {
        return gymLeader;
    }
    PokemonDB GetPokemonDBFromTeam(string id)
    {
        return pokemons.getPokemons()[gymLeader.GetPokemons()[id].pokemon];
    }
}
