using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    Animator animator;
    Transform Playertransform;
    CharacterController characterController;
    //用于解决手柄等误触造成的不必要的移动，即超过这个阈值再进行移动
    float threshold = 0.1f;
    //玩家输入
    Vector2 playerInput;
    //角色移动
    Vector3 PlayerMovement;

    public float walkSpeed = 2.0f;
    private float RunSpeed = 5.0f;
    private float idleSpeed = 0f;
    private float currentSpeed = 0f;
    private float targetSpeed = 0f;
    bool isrunning;
    bool ismoving;
    bool hand;
    public float rotateSpeed = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Playertransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }
    //这个方法可以取代rootMove来控制角色的移动速度。
    //使用这个方法的目的就是高自由度的控制速度以及适配动作，防止脚底打滑。
    private void OnAnimatorMove()
    {
        Move();
        characterController.SimpleMove(animator.velocity);
    }

    public void getPlayerWalkInput(InputAction.CallbackContext ctx)
    {
        playerInput = ctx.ReadValue<Vector2>();
        if (playerInput.magnitude > threshold || playerInput.magnitude < -threshold)
        {
            ismoving = true;

            animator.SetBool("ismoving?", ismoving);
        }
        else
        {
            ismoving = false;
            isrunning = false;
            targetSpeed = idleSpeed;
            animator.SetBool("ismoving?", ismoving);
        }
        if (ismoving && !isrunning)
        {
            targetSpeed = walkSpeed;
        }
        //Debug.Log(playerInput.magnitude);
    }
    public void getPlayerRunInput(InputAction.CallbackContext ctx)
    {
        isrunning = ctx.ReadValue<float>() > 0;
        targetSpeed = RunSpeed;
        Debug.Log(isrunning);
    }
    void RotatePlayer()
    {
        if (playerInput.Equals(Vector2.zero))
            return;

        PlayerMovement.x = playerInput.x;
        PlayerMovement.z = playerInput.y;
        //在这里传入玩家输入的方向，通过lookrotation将方向转变成旋转角度，用于后面角色的旋转
        Quaternion targetRotation = Quaternion.LookRotation(PlayerMovement, Vector3.up);
        //这里不是之间赋值，而是用一个函数随着时间和速度慢慢转过去
        Playertransform.rotation = Quaternion.RotateTowards(Playertransform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
    private void Move()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, 0.9f);
        //movement=new Vector3(0,0,currentSpeed*Time.deltaTime);
        //transform.position+=movement;
        animator.SetFloat("speed", currentSpeed);
        //由于每次调用OnAnimatorMove都会调用move函数，导致y分量的速度始终为定值，我们需要保留y值，这样才会下落越来越快。
        //Vector3 vector3 = new Vector3(animator.velocity.x, Rigidbodyrb.velocity.y, animator.velocity.z);
        //Rigidbodyrb.velocity = vector3;
    }
    public void PlayerHandMove(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
        {
            hand = !hand;
            animator.SetBool("hello", hand);
        }
    }
}
