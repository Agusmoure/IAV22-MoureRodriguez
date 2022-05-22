using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Moves : MonoBehaviour
{
    Movement _movement;
    Attack attack;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(ProcessTurn);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeAttack(Movement m)
    {
        _movement = m;
        attack = GameManager.instance.GetDB().GetAttacks().getAttacks()[m.attack];
        transform.GetComponent<Text>().text = attack.name;
    }
    public Attack GetAttack()
    {
        return attack;
    }
    public Decision DoMovement()
    {
        return new Decision(attack.damageType,CalculateDamage(GameManager.instance.GetGymLeader().GetPokemonActual(),attack));
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
    private void OnMouseOver()
    {
        transform.parent.GetComponent<MovesHud>().GetMoveDetails().SetDetails(_movement);
    }
    private void OnMouseExit()
    {
        transform.parent.GetComponent<MovesHud>().GetMoveDetails().Clear();

    }
}
