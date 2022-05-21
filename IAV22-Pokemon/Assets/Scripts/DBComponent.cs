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
    private void Awake()
    {
        pokemons = new Pokemons();
        attacks = new Attacks();
        gymLeader = new TeamPokemon();
        rival = new TeamPokemon();
        movements = new MovementSet();
        pokemonStats = new PokemonsStats();
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
            PokemonDB p = GetPokemonDBFromTeam(gymLeader, "LS1");
            Debug.Log("Pokemon con ID LS1: " + gymLeader.GetPokemons()["LS1"].nickName);
            Debug.Log("Pokemon con ID LS1: " + p.name + " " + p.natDexNumber + " " + p.type1);
            Debug.Log("Pokemon con ID LS1: " + attacks.getAttacks()[movements.GetMoves()["LS1"][0].attack].name);
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
}
