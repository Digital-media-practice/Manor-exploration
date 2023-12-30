using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region 参数相关
    Animator animator;
    Transform playerTransform;
    CharacterController controller;
    Transform cameraTransform;
    float walkSpeed=2;
    float runSpeed=5;
    bool isRunning;
    Vector2 moveInput;
    int speedHash;
    Vector3 playerMovement = Vector3.zero;
    float rad;
    float angle;
    public int keys;

    private playerSpawn SpawnControl;
    #endregion
    // Start is called before the first frame update
    private void Awake()
    {
        SpawnControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<playerSpawn>();
        

    }
    void Start()
    {
         
        
        controller = GetComponent<CharacterController>();
        controller.enabled = false;
        animator = GetComponent<Animator>();
        playerTransform = transform;
        speedHash = Animator.StringToHash("speed");
        cameraTransform=Camera.main.transform;
        //Cursor.lockState = CursorLockMode.Locked;
        SpawnPlayer();
        
 
    }
    public void getKey()
    {
        keys++;
        Debug.Log("当前收取了" + keys + "钥匙");
    }
    void SpawnPlayer()
    {
        
        playerTransform.position = SpawnControl.getSpawn(0).transform.position;
        controller.enabled= true;
    }
    // Update is called once per frame
    void Update()
    {
        keys = GameObject.Find("GameData").GetComponent<GameData>().param;
        playerMove();
        CaculateInputDirection();
    }
    private void OnAnimatorMove()
    {
        
        controller.SimpleMove(animator.velocity);
        playerTransform.Rotate(0, rad * 300 * Time.deltaTime, 0f);
    }
    #region 输入相关
    public void GetMoveInput(InputAction.CallbackContext ctx)
    {
        moveInput=ctx.ReadValue<Vector2>();
        
        
    }
    public void GetRunInput(InputAction.CallbackContext ctx)
    {
        isRunning=ctx.ReadValueAsButton();
    }
    #endregion

    void playerMove()
    {
        if (moveInput.magnitude == 0f)
        {
            animator.SetFloat(speedHash,0,0.1f,Time.deltaTime);
        }else if (!isRunning)
        {
            animator.SetFloat(speedHash, walkSpeed, 0.1f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat(speedHash, runSpeed, 0.1f, Time.deltaTime);
        }
        rad = Mathf.Atan2(playerMovement.x, playerMovement.z);
        angle = getAngel(rad);
        forward();
        rad = getRad(angle);
    }

    void CaculateInputDirection()//实时获得相机方向
    {

        Vector3 camForwardProjection = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;
        playerMovement = camForwardProjection * moveInput.y + cameraTransform.right * moveInput.x;
        playerMovement = playerTransform.InverseTransformVector(playerMovement);
    }
    float getRad(float Angel)
    {
        float Rad = Angel * Mathf.PI / 180;
        return Rad;
    }
    float getAngel(float Rad)
    {
        float Angle = Rad * (180 / Mathf.PI);
        return Angle;
    }

    void forward()
    {
        if (moveInput.x == 0 && moveInput.y == -1)
        {
            rad = rad + 90;
        }
        else if(moveInput.x == 1 && moveInput.y == 0)
        {
            rad = rad + 45;
        }
        else if (moveInput.x == -1 && moveInput.y == 0)
        {
            rad = rad - 45;
        }
    }



}