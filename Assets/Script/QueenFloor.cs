using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenFloor : MonoBehaviour
{
    public bool queenInPlace = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("FullQueen"))
        {
            queenInPlace = true;
            Debug.Log("in place");

            RedoChess chessCode = other.GetComponent<RedoChess>();

            if (chessCode != null)
            {
                chessCode.canUndoQueen = false;
            }

        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
