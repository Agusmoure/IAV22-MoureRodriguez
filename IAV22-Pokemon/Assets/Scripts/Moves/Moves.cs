using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moves : MonoBehaviour
{
    Attack _actualMovement;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(ProcessTurn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAttack(Attack m)
    {
        _actualMovement = m;
        transform.GetComponent<Text>().text = m.name;
    }
    public Attack GetAttack()
    {
        return _actualMovement;
    }
    public Decision DoMovement()
    {
        Debug.Log("Ejecuta " + _actualMovement.name);
        return new Decision(_actualMovement.damageType,CalculateDamage(GameManager.instance.GetGymLeader().GetPokemonActual(),_actualMovement));
    }
    int CalculateDamage(PokemonDB rival, Attack attack)
    {
        DBComponent db = GameManager.instance.GetDB();
        Relations rels = db.GetRelations();
        PokemonType atcType = attack.type;
        float power;
        power = rels.GetRelations()[atcType][rival.type1];
        if (rival.type2 != PokemonType.None)
            power *= rels.GetRelations()[atcType][rival.type2];
        //daño ataque*tipo ataque*efectividad
        return attack.damageType == StatsType.Fisico ? (int)(attack.damage * GameManager.instance.GetPlayer().GetActualStat().phyDamage * power) : (int)(attack.damage * GameManager.instance.GetPlayer().GetActualStat().speDamage * power);
    }
    public void ProcessTurn()
    {
        GameManager.instance.ProcessTurn(DoMovement());
        transform.GetComponentInParent<MovesHud>().DoAttack();
    }
}
