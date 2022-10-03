using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //undo chess 

    public GameObject QueenTop;
    public GameObject FlatTop;


    public float speed;
    public float rotationSpeed;
    private CharacterController characterController;

    public float jumpSpeed;

    private float fallSpeed;
    private float originalStepOffset;

    public bool handsEmpty = true;

    public Item[] Inventory;
    public int currentItemIndex;

    public GameObject FullQueen;
    public GameObject FullFlat;
    


    public void OnTriggerStay(Collider other)
    {
        //on mouse click 
        //intiate two diff game object - bottom and top 
        //delete full chess gameobject
        //parent the top(item) to the player 

        if (other.gameObject.CompareTag("FullFlat"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(other);
                //Destroy(other.gameObject);
                //FlatUndo.UndoFlat();

                RedoChess chessCode = other.GetComponent<RedoChess>();
                
                if(chessCode != null)
                {
                    chessCode.UndoFlat();
                }

            }
        }




        if (other.gameObject.CompareTag("FullQueen"))
        {

            if (Input.GetMouseButtonDown(0))
            {
                RedoChess chessCode = other.GetComponent<RedoChess>();

                if (chessCode != null)
                {
                    chessCode.UndoQueen();
                }
            }
        }

        if (other.gameObject.CompareTag("FullCross"))
        {

            if (Input.GetMouseButtonDown(0))
            {
                RedoChess chessCode = other.GetComponent<RedoChess>();

                if (chessCode != null)
                {
                    chessCode.UndoCross();
                }
            }
        }

    }



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        handsEmpty = true;

        

    }
    void Update()
    {   
        //movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = fallSpeed;
        characterController.Move(velocity * Time.deltaTime);

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //gravity
        fallSpeed += Physics.gravity.y * Time.deltaTime;


        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            fallSpeed = -0.5f;

            //jump
            if (Input.GetButtonDown("Jump"))
            {
                fallSpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }
        


        //L mouse click
        if (Input.GetMouseButtonDown(0))
        {

            //pick up items 
            //only one at a time
            if (Inventory[currentItemIndex] != null)
            {
                Inventory[currentItemIndex].GetComponent<Rigidbody>().isKinematic = false;
                Inventory[currentItemIndex].GetComponent<Rigidbody>().velocity = Vector3.zero;
                //Debug.Log("hands full");
                if (Inventory[currentItemIndex] != null)
                {
                    //dropping
                    Inventory[currentItemIndex].transform.SetParent(null);
                    Inventory[currentItemIndex] = null;
                    
                }
            }

            else
            {
                Collider[] overlappingItems;
                overlappingItems = Physics.OverlapBox(transform.position + 1 * Vector3.forward, 1.5f * Vector3.one, Quaternion.identity, LayerMask.GetMask("Item"));

                if (overlappingItems.Length == 0)
                    Debug.Log("No item in front of you");
                else
                //pick up
                {
                    if (Inventory[currentItemIndex] != null)
                    {
                        Inventory[currentItemIndex].transform.SetParent(null);
                        Inventory[currentItemIndex] = null;
                    }

                    Inventory[currentItemIndex] = overlappingItems[0].GetComponent<Item>();
                    Inventory[currentItemIndex].transform.SetParent(gameObject.transform);
                    Inventory[currentItemIndex].transform.localPosition = new Vector3(0, -0.2f, 0.6f);
                    Inventory[currentItemIndex].GetComponent<Rigidbody>().isKinematic = true;


                    Debug.Log("u picked up an item");
                }
            }

        }
        
    }

}
