using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addChess : MonoBehaviour
{
    public GameObject ChessFlat;
    public GameObject ChessCrossW;
    public GameObject ChessCrossB;
    public GameObject ChessQueen;

    public bool canAdd = true;


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("chessTop"))
        {
            //Debug.Log("touch!");
            if (canAdd == true)
            {
                Debug.Log("making a full chess!");
                GameObject FLatChess = Instantiate(ChessFlat, transform.position, Quaternion.identity) as GameObject;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                canAdd = false;
            }
        }
        else if (collision.gameObject.CompareTag("CrossTop"))
        {
            if (canAdd == true)
            {
                Debug.Log("making a full chess!");
                GameObject WChessCross = Instantiate(ChessCrossW, transform.position, Quaternion.identity) as GameObject;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                canAdd = false;
            }
        }
        else if (collision.gameObject.CompareTag("CrossTopB"))
        {
            if (canAdd == true)
            {
                Debug.Log("making a full chess!");
                GameObject BChessCross = Instantiate(ChessCrossB, transform.position, Quaternion.identity) as GameObject;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                canAdd = false;
            }
        } 
        else if (collision.gameObject.CompareTag("QueenTop"))
        {
            if (canAdd == true)
            {
                Debug.Log("making a full chess!");
                GameObject QueenChess = Instantiate(ChessQueen, transform.position, Quaternion.identity) as GameObject;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                canAdd = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
