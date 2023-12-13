using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    Animator animator;
    Transform Playertransform;
    CharacterController characterController;
    //���ڽ���ֱ�������ɵĲ���Ҫ���ƶ��������������ֵ�ٽ����ƶ�
    float threshold = 0.1f;
    //�������
    Vector2 playerInput;
    //��ɫ�ƶ�
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
    //�����������ȡ��rootMove�����ƽ�ɫ���ƶ��ٶȡ�
    //ʹ�����������Ŀ�ľ��Ǹ����ɶȵĿ����ٶ��Լ����䶯������ֹ�ŵ״򻬡�
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
        //�����ﴫ���������ķ���ͨ��lookrotation������ת�����ת�Ƕȣ����ں����ɫ����ת
        Quaternion targetRotation = Quaternion.LookRotation(PlayerMovement, Vector3.up);
        //���ﲻ��֮�丳ֵ��������һ����������ʱ����ٶ�����ת��ȥ
        Playertransform.rotation = Quaternion.RotateTowards(Playertransform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
    private void Move()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, 0.9f);
        //movement=new Vector3(0,0,currentSpeed*Time.deltaTime);
        //transform.position+=movement;
        animator.SetFloat("speed", currentSpeed);
        //����ÿ�ε���OnAnimatorMove�������move����������y�������ٶ�ʼ��Ϊ��ֵ��������Ҫ����yֵ�������Ż�����Խ��Խ�졣
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
