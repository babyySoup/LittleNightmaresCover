using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatFloor : MonoBehaviour
{
    public bool FlatInPlace = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FullFlat"))
        {
            FlatInPlace = true;
            Debug.Log(other);

            RedoChess chessCode = other.GetComponent<RedoChess>();

            if (chessCode != null)
            {
                chessCode.canUndoFlat = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
