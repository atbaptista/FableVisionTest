using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Camera _cam;
    private CharacterController _controller;
    private float _camRotation = 0f;
    private Vector3 _velocity;
    private bool _isGrounded;

    [Header("Player Movement")]
    public float lookSensitivity = 50f;
    public float moveSpeed = 3f;
    public float gravity;

    [Header("Ground Checking")]
    public float groundDistance = 0.09f; 
    public Transform groundCheck; 
    public LayerMask groundMask;

    [Header("Fishing")]
    public GameObject bob;
    public Rope rope;
    public Transform bobSpawn;
    private float nextBobTime;
    private GameObject prevBob;
    private ThreeDFishingBob.HookState bobStatus;
    public TDFishing fishGame;
    public bool isCatching = false;
    public GameObject[] activateOnFishHooked;
    public GameObject[] activateOnMiniGameWon;



    // Start is called before the first frame update
    void Start()
    {
        nextBobTime = 0;
        //_controller = GetComponent<CharacterController>();
        _cam = GetComponentInChildren<Camera>();

        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(prevBob){
            bobStatus = prevBob.GetComponent<ThreeDFishingBob>().GetState();
        }
        GetInputs();
    }

    private void GetInputs(){
        //################################################## Camera Movement ########################################################
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(Vector3.up * lookSensitivity * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(-Vector3.up * lookSensitivity * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.UpArrow)){
            _camRotation -= lookSensitivity * Time.deltaTime;
            _camRotation = Mathf.Clamp(_camRotation, -90f, 90f);
            _cam.transform.localRotation = Quaternion.Euler(_camRotation, 0f, 0f);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            _camRotation += lookSensitivity * Time.deltaTime;
            _camRotation = Mathf.Clamp(_camRotation, -90f, 90f);
            _cam.transform.localRotation = Quaternion.Euler(_camRotation, 0f, 0f);
        }

        if(Time.timeScale == 0){
            return;
        }

        if(!Input.GetKeyDown(KeyCode.Space)){
            return;
        }

        //throw out a new bob
        if(prevBob == null){
            rope.gameObject.SetActive(true);
            prevBob = Instantiate(bob, bobSpawn.transform.position, bobSpawn.transform.rotation);
            rope.EndPoint = prevBob.transform;
            return;
        }

        //pull the bob back
        if(bobStatus != ThreeDFishingBob.HookState.FISHCATCHING){
            if(prevBob){
                Destroy(prevBob);
            }
            rope.gameObject.SetActive(false);
            return;
        }

        //fish was hooked and not in minigame
        if(bobStatus == ThreeDFishingBob.HookState.FISHCATCHING && !isCatching){
            Debug.Log("START MINIGAME   " + Time.time);
            foreach (GameObject i in activateOnFishHooked){
                i.SetActive(true);
            }
            prevBob.GetComponent<ThreeDFishingBob>().PlayerCatchingFish();
            isCatching = true;
            return;
        }

        //fish hooked and currently in minigame
        if(bobStatus == ThreeDFishingBob.HookState.FISHCATCHING && isCatching){
            Debug.Log("MINIGAME");
            //caught fish
            if(fishGame.meterVal == fishGame.maxMeterVal){
                //pause game
                Time.timeScale = 0;
                foreach(GameObject i in activateOnMiniGameWon){
                    i.SetActive(!i.activeSelf);
                }
                isCatching = false;
                fishGame.Reset();
                Destroy(prevBob);
                rope.gameObject.SetActive(false);
            }
            fishGame.meterVal += 10;
            //run this if player fails minigame
            //prevBob.GetComponent<ThreeDFishingBob>().StartBobbing();
        }

        // GameObject manager = GameObject.Find("3DManager");
        // manager.GetComponent<ThreeDManager>().FishCaught();
        // GameObject.Find("Rope").SetActive(false);
        // Destroy(prevBob);

        //################################################## Player Movement ########################################################
        // _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // if(_isGrounded && _velocity.y < 0){
        //     _velocity.y = -2f;
        // }

        // float x = Input.GetAxis("Horizontal");
        // float z = Input.GetAxis("Vertical");

        // Vector3 move = transform.right * x + transform.forward * z;
        // _controller.Move(move * moveSpeed * Time.deltaTime);

        // _velocity.y += gravity * Time.deltaTime;
        // _controller.Move(_velocity * Time.deltaTime);
    }

    public void TurnRopeOff(){
        rope.gameObject.SetActive(false);
    }
}
