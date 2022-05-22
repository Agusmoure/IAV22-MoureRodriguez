using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovesHud : MonoBehaviour
{
    [SerializeField] GameObject action;
    [SerializeField] GameObject dialogText;
    [SerializeField] MoveDetails details;
    List<Transform> movesHUD;
    List<Movement> moves;
    Movement emptyAttack;
    // Start is called before the first frame update
    private void Awake()
    {
        emptyAttack = new Movement("Demo", 0);
        movesHUD = new List<Transform>();
        moves = new List<Movement>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
            movesHUD.Add(gameObject.transform.GetChild(i));
        transform.parent.gameObject.SetActive(false);
    }
    void Start()
    {

    }
    public void SetMoves(List<Movement> attacks)
    {
        moves.Clear();
        foreach (Movement m in attacks)
        {
            moves.Add(m);
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
    public List<Movement> GetMoves()
    {
        return moves;
    }
    public void DoAttack()
    {
        dialogText.SetActive(true);
        action.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
    public MoveDetails GetMoveDetails()
    {
        return details;
    }
}
