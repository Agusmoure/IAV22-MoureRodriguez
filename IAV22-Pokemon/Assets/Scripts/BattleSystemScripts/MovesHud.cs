using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovesHud : MonoBehaviour
{
    [SerializeField] GameObject action;
    [SerializeField] GameObject dialogText;
    List<Transform> movesHUD;
    List<Attack> moves;
    Attack emptyAttack;
    // Start is called before the first frame update
    private void Awake()
    {
        emptyAttack = new Attack("Demo", "", PokemonType.None, 0, StatsType.None, 0);
        movesHUD = new List<Transform>();
        moves = new List<Attack>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
            movesHUD.Add(gameObject.transform.GetChild(i));
        transform.parent.gameObject.SetActive(false);
    }
    void Start()
    {

    }
    public void SetMoves(List<Attack> attacks)
    {
        moves.Clear();
        foreach (Attack a in attacks)
        {
            moves.Add(a);
        }
        for (int j = moves.Count; j < 4; j++)
            moves.Add(emptyAttack);
        int i = 0;
        foreach (Transform t in movesHUD)
        {
            t.GetComponent<Moves>().ChangeAttack(moves[i]);
            i++;
        }
    }
    public List<Attack> GetMoves()
    {
        return moves;
    }
    public void DoAttack()
    {
        dialogText.SetActive(true);
        action.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
