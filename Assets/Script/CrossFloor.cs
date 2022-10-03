using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFloor : MonoBehaviour
{
    public bool CrossInPlace = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("FullCross"))
        {
            CrossInPlace = true;
            Debug.Log("in place");

            RedoChess chessCode = other.GetComponent<RedoChess>();

            if (chessCode != null)
            {
                chessCode.canUndoCross = false;
            }

        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
