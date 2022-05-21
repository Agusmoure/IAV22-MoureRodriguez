using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonChange : MonoBehaviour
{
    [SerializeField] Image background;
    [SerializeField] Image pokemon;
    [SerializeField] Text pokemonName;
    DBComponent db;
    string actualId;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(ChangePokemon);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInfo(PokemonInTeam pIT)
    {
        db = GameManager.instance.GetDB();
        if (pIT.id == "empty")
        {
            pokemon.gameObject.SetActive(false);
            pokemonName.gameObject.SetActive(false);
            background.color = new Color32(0x63, 0x63, 0x63, 0xFF);
            actualId = pIT.id;
        }
        else
        {
            //Sprite
            pokemon.sprite = db.GetPokemons().getPokemons()[pIT.pokemon].frontSprite;
            //Text
            pokemonName.text = pIT.nickName + " " + pIT.lvl;
            //Fondo
            Stat stats = db.GetStats().GetStats()[pIT.id];
            if (stats.currhp > 0)
            {
                actualId = pIT.id;
                background.color = new Color32(0x5D, 0xA4, 0x52, 0xFF);
            }
            else
            {
                actualId = "dead";
                background.color = new Color32(0xA4, 0x51, 0x51, 0xFF);
            }
        }

    }

    public void ChangePokemon()
    {
        if (actualId != "dead" && actualId != "empty")
        {
        transform.parent.transform.GetComponent<TeamManager>().GetPlayer().ChangePokemon(actualId);
        transform.parent.transform.GetComponent<TeamManager>().PokemonChanged();
        }

    }
}
