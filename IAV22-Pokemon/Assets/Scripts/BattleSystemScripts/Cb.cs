using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cb : MonoBehaviour
{
    [SerializeField] DBComponent db;
    [SerializeField] BattleHud bh;
    [SerializeField] MovesHud mh;
    [SerializeField] MoveDetails md;
    private void Start()
    {
        //transform.GetComponent<Button>().onClick.AddListener(SetUmbreonData);
    }
    public void SetEspeonData()
    {
       PokemonInTeam p= db.GetRivalTeam().GetPokemons()["R1"];
     //   bh.SetData(p.nickName,10);
    }
    void ReduceLife() {
        PokemonInTeam p = db.GetRivalTeam().GetPokemons()["LS1"];
        db.GetStats().GetStats()["LS1"].SetCurrHp(db.GetStats().GetStats()["LS1"].currhp-50);
        bh.SetData(p.nickName, 10, db.GetStats().GetStats()["LS1"].currhp, db.GetStats().GetStats()["LS1"].hp);
    }
    void SetPsiquico() { }

    void SetPsicocorte() { }

    public void SetUmbreonData()
    {
        Debug.Log("Entra");
        PokemonInTeam p = db.GetGymLeaderTeam().GetPokemons()["LS1"];

         bh.SetData(p.nickName,10,db.GetStats().GetStats()["LS1"].currhp, db.GetStats().GetStats()["LS1"].hp);
    }
}
