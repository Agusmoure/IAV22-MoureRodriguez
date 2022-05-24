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
        _movement.currpp--;
        return new Decision(attack.damageType,attack.type,CalculateDamage(attack));
    }
    //Calcula el daño sin tener en cuenta el tipo del rival 
    int CalculateDamage( Attack attack)
    {
        //daño ataque*tipo ataque*efectividad
        return attack.damageType == StatsType.Physic ? (int)(attack.damage * GameManager.instance.GetPlayer().GetActualStat().phyDamage) : (int)(attack.damage * GameManager.instance.GetPlayer().GetActualStat().speDamage);
    }
    public void ProcessTurn()
    {
        transform.GetComponentInParent<MovesHud>().DoAttack();
        GameManager.instance.ProcessTurn(DoMovement());
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
