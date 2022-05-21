using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovesHud : MonoBehaviour
{
    List<Transform> movesHUD;
    List<Attack> moves;
    // Start is called before the first frame update
    void Start()
    {
        movesHUD = new List<Transform>();
        moves = new List<Attack>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
            movesHUD.Add(gameObject.transform.GetChild(i));
        string[] s = { "Psíquico", "Psicocorte", "Placaje" };
        SetMovesNames(s);
    }
    void SetMovesNames(string[] namesStart)
    {
        string[] names = new string[4];
        if (namesStart.Length < 4)
        {
            namesStart.CopyTo(names, 0);
            for (int j = namesStart.Length; j < 4; j++)
            {
                names[j] = "";
            }
        }
        else
            names = namesStart;
        int i = 0;
        foreach (Transform t in movesHUD)
        {
            t.GetComponent<Text>().text = names[i++];
        }
    }
    public void SetMoves(List<Attack> attacks)
    {
        string[] names = new string[4];
        int i = 0;
        foreach (Attack a in attacks)
        {
            names[i] = a.name;
            i++;
        }
        SetMovesNames(names);
    }
    public List<Attack> GetMoves()
    {
        return moves;
    }

}
