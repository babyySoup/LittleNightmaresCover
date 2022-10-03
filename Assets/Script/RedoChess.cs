using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedoChess : MonoBehaviour
{
    public bool canUndoQueen = true;
    public bool canUndoFlat = true;
    public bool canUndoCross = true;

    public GameObject ChessBottom;

    public GameObject QueenTop;
    public GameObject FlatTop;
    public GameObject CrossTop;


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
        if (canUndoFlat == true)
        {
            Debug.Log("1");

            //DestroyImmediate(gameObject, true);

            Instantiate(ChessBottom, transform.position, Quaternion.identity);

            Instantiate(FlatTop, transform.position, Quaternion.identity);

            canUndoFlat = false;
            Debug.Log("redoing the flat chess");
            Destroy(gameObject);
        }

    }

    public void UndoCross()
    {
        if (canUndoCross == true)
        {
            Debug.Log("1");

            //DestroyImmediate(gameObject, true);

            Instantiate(ChessBottom, transform.position, Quaternion.identity);

            Instantiate(CrossTop, transform.position, Quaternion.identity);

            canUndoCross = false;
            Debug.Log("redoing the cross chess");
            Destroy(gameObject);
        }
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