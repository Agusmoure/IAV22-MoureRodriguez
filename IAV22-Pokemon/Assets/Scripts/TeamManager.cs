using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    List<PokemonChange> pokemonsUI;
    [SerializeField] Player player;
    [SerializeField] GameObject action;
    [SerializeField] GameObject dialogText;
    private void Awake()
    {
        pokemonsUI = new List<PokemonChange>();
        for (int i = 0; i < transform.childCount; i++)
            pokemonsUI.Add(transform.GetChild(i).transform.GetComponent<PokemonChange>());        
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void ShowTeam()
    {
        PokemonInTeam pEmpty = new PokemonInTeam("empty",new PokemonDB(),0);
        List<PokemonInTeam> teamPokemon = new List<PokemonInTeam>();
        foreach(KeyValuePair<string,PokemonInTeam> pIT in GameManager.instance.GetDB().GetRivalTeam().GetPokemons())
        {
            teamPokemon.Add(pIT.Value);
        }
        for(int i = teamPokemon.Count; i < 6; i++)
        {
            teamPokemon.Add(pEmpty);
        }
        int j = 0;
        foreach(PokemonChange pC in pokemonsUI)
        {
            pC.SetInfo(teamPokemon[j++]);
        }
    }

    public Player GetPlayer()
    {
        return player;
    }
    public void PokemonChanged()
    {
        action.SetActive(true);
        dialogText.SetActive(true);
        gameObject.SetActive(false);
    }
}
