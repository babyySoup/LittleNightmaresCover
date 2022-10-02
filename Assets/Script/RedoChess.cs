using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedoChess : MonoBehaviour
{
    public bool canUndoQueen = true;
    public bool canUndoFlat = true;

    public GameObject ChessBottom;
    public GameObject ChessBottom2;

    public GameObject QueenTop;
    public GameObject FlatTop;


    public void UndoQueen()
    {
        if (canUndoQueen == true)
        {
            Debug.Log("redoing the queen chess");
            GameObject NewBottom = Instantiate(ChessBottom, transform.position, Quaternion.identity) as GameObject;
            GameObject NewTop = Instantiate(QueenTop, transform.position, Quaternion.identity) as GameObject;
            canUndoQueen = false;
            Destroy(gameObject);
        }
    }


    public void UndoFlat()
    {
        Debug.Log("1");
        Destroy(gameObject);
        Instantiate(ChessBottom2, transform.position, Quaternion.identity);

        Instantiate(FlatTop, transform.position, Quaternion.identity);

        canUndoFlat = false;
        Debug.Log("redoing the flat chess");
        Destroy(gameObject);



        //if (canUndoFlat)
        //{

        //    Debug.Log("1");
        //    GameObject NewBottom1 = Instantiate(ChessBottom2, transform.position, Quaternion.identity) as GameObject;
        //    GameObject NewTop1 = Instantiate(FlatTop, transform.position, Quaternion.identity) as GameObject;
        //    canUndoFlat = false;
        //}
    }



    void Start()
    {
        canUndoFlat = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
