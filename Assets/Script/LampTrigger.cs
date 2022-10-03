using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTrigger : MonoBehaviour
{
    public Animator animator;
    bool isOpen = false;
    private bool completed = false;
    public GameObject FF;
    public GameObject CF;
    public GameObject QF;

    public GameObject Light;

    public GameObject shelfDoor;
    ShelfDoor sdCode;
    FlatFloor flatFloor;
    CrossFloor crossFloor;
    QueenFloor queenFloor;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        sdCode = shelfDoor.GetComponent<ShelfDoor>();
        flatFloor = FF.GetComponent<FlatFloor>();
        crossFloor = CF.GetComponent<CrossFloor>();
        queenFloor = QF.GetComponent<QueenFloor>();
    }

    public void Update()
    {
        if (flatFloor.FlatInPlace == true && crossFloor.CrossInPlace == true && queenFloor.queenInPlace == true)
        {
            completed = true;
            Light.SetActive(true);
            Debug.Log("puzzle complete");
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (isOpen == false && completed == true)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetTrigger("pulling");
                
                Debug.Log("open SD");
                sdCode.OpenShelf();
                isOpen = true;
            }
        }
    }


}
