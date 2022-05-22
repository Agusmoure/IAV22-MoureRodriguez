using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    [SerializeField] Player player;
    [SerializeField] GymLeader gymLeader;
    [SerializeField] Battle battle;
    DBComponent db;
    [SerializeField] string firstRivalPokemon = "R1";
    [SerializeField] string firstGymLeaderPokemon = "LS2";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
        db = transform.GetComponent<DBComponent>();
    }
    void Start()
    {
    }

   public  DBComponent GetDB()
    {
        return db;
    }
    public string GetFirstRival()
    {
        return firstRivalPokemon;
    }
    public string GetFirstGymLeader()
    {
        return firstGymLeaderPokemon;
    }
    public Player GetPlayer()
    {
        return player;
    }
    public GymLeader GetGymLeader()
    {
        return gymLeader;
    }
    public void ProcessTurn(Decision d)
    {
        battle.ProcessTurn(d);
    }
}
