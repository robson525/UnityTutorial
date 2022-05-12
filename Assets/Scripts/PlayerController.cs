using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public float speed = 2.5f;
    float inputX = 0;
    float inputY = 0;
    bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        this.isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.inputX = Input.GetAxisRaw(Orientation.Horizontal.ToString());
        this.inputY = Input.GetAxisRaw(Orientation.Vertical.ToString());
        this.isWalking = this.inputX != 0 || this.inputY != 0;

        if (this.isWalking)
        {
            var move = new Vector3(inputX, inputY, 0).normalized;
            base.transform.position += this.speed * Time.deltaTime * move;
            this.playerAnimator.SetFloat("inputX", this.inputX);
            this.playerAnimator.SetFloat("inputY", this.inputY);
        }

        this.playerAnimator.SetBool("isWalking", this.isWalking);


        if (Input.GetButtonDown("Fire1"))        
            this.playerAnimator.SetTrigger("attack");
        
    }
}
