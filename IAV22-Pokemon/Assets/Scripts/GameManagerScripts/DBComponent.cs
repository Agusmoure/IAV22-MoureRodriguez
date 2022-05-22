using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Este Script será el encargado de almacenar los datos
public class DBComponent : MonoBehaviour
{
    Pokemons pokemons;
    Attacks attacks;
    TeamPokemon gymLeader;
    TeamPokemon rival;
    MovementSet movements;
    PokemonsStats pokemonStats;
    Relations relations;
    private void Awake()
    {
        pokemons = new Pokemons();
        attacks = new Attacks();
        gymLeader = new TeamPokemon();
        rival = new TeamPokemon();
        movements = new MovementSet();
        pokemonStats = new PokemonsStats();
        relations = new Relations();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(KeyValuePair<PokemonType, Dictionary<PokemonType, float>> aux in relations.GetRelations() )
            {
                foreach (KeyValuePair<PokemonType, float> pair in aux.Value)
                {
                    Debug.Log(aux.Key.ToString() + "-" + pair.Key + "---->" + pair.Value);
                }
            }
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
    public TeamPokemon GetGymLeaderTeam()
    {
        return gymLeader;
    }
    public TeamPokemon GetRivalTeam()
    {
        return rival;
    }
    PokemonDB GetPokemonDBFromTeam(TeamPokemon t, string id)
    {
        return pokemons.getPokemons()[t.GetPokemons()[id].pokemon];
    }
    public MovementSet GetMovements()
    {
        return movements;
    }
    public PokemonsStats GetStats()
    {
        return pokemonStats;
    }
    public Relations GetRelations()
    {
        return relations;
    }
}
