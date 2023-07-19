using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fishing gameplay functionality
//All inputs should be processed here in the 3d version of fishing game
//probably should've named this PlayerInput
public class PlayerInput : MonoBehaviour
{
    [Header("Animation")]
    public Animator rodAnimator;

    [Header("Sounds")]
    public AudioClip bobEnterWater;
    public AudioClip bobExitWater;

    [Header("Fishing")]
    public GameObject bob;
    public Rope rope;
    public Transform bobSpawn;
    public MeterManager meterManager;
    public bool isCatching = false;
    public GameObject[] activateOnFishHooked;
    public GameObject[] activateOnMiniGameWon;
    public GameObject[] deactivateOnMiniGameWon;

    private float nextBobTime;
    private GameObject prevBob;
    private BobGameController.HookState bobStatus;

    // Start is called before the first frame update
    void Start()
    {
        nextBobTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(prevBob){
            bobStatus = prevBob.GetComponent<BobGameController>().GetState();
            //check if the bob is "dead" (didn't hit water)
            if (bobStatus == BobGameController.HookState.DEAD){
                rope.gameObject.SetActive(false);
                Destroy(prevBob);
                prevBob = null;
            }
        }
        GetInputs();
        MinigameCheck();
    }

    public void MinigameCheck(){
        if(meterManager.meterVal == meterManager.maxMeterVal){
                //pause game, remember to unpause in next scene
                Time.timeScale = 0;
                foreach(GameObject i in activateOnMiniGameWon){
                    i.SetActive(!i.activeSelf);
                }
                foreach(GameObject c in deactivateOnMiniGameWon){
                    c.SetActive(false);
                }
                isCatching = false;
                meterManager.Reset();
                Destroy(prevBob);
                rope.gameObject.SetActive(false);
        }
    }

#region ANIMATION FUNCTIONS

//all of these functions are called in the fishing rod animations by the RodMethods script
    public void CastLine(){
        rope.gameObject.SetActive(true);
        prevBob = Instantiate(bob, bobSpawn.transform.position, bobSpawn.transform.rotation);
        rope.EndPoint = prevBob.transform;

        SoundManager.Instance.Play(bobEnterWater);
    }

    public void PullBackEmpty(){
        if(prevBob){
                Destroy(prevBob);
        }
        rope.gameObject.SetActive(false);
        //SoundManager.Instance.Play(bobEnterWater);
    }

    public void PullBackFish(){
        Debug.Log("START MINIGAME   " + Time.time);
        foreach (GameObject i in activateOnFishHooked){
            i.SetActive(true);
        }
        prevBob.GetComponent<BobGameController>().PlayerCatchingFish();
        isCatching = true;
        SoundManager.Instance.Play(bobExitWater);
    }

#endregion

    private void GetInputs(){

#region SpaceBar

        if(Time.timeScale == 0){
            return;
        }

        if(!Input.GetKeyDown(KeyCode.Space) && !Input.GetMouseButtonDown(0)){
            return;
        }

        //throw out a new bob
        if(prevBob == null){
            //play animation
            rodAnimator.SetTrigger("TrCast");
            return;
        }

        //pull the bob back
        if(bobStatus != BobGameController.HookState.FISHCATCHING){
            rodAnimator.SetTrigger("TrPullBackEmpty");
            return;
        }

        //fish was hooked and not in minigame
        if(bobStatus == BobGameController.HookState.FISHCATCHING && !isCatching){
            rodAnimator.SetTrigger("TrPullBackFish");
            return;
        }

        //fish hooked and currently in minigame
        if(bobStatus == BobGameController.HookState.FISHCATCHING && isCatching){
            Debug.Log("MINIGAME");
            //caught fish, beat minigame
            if(meterManager.meterVal == meterManager.maxMeterVal){
                // //pause game, remember to unpause in next scene
                // Time.timeScale = 0;
                // foreach(GameObject i in activateOnMiniGameWon){
                //     i.SetActive(!i.activeSelf);
                // }
                // isCatching = false;
                // meterManager.Reset();
                // Destroy(prevBob);
                // rope.gameObject.SetActive(false);
            }else{
                //meterManager.meterVal += 10;
                Debug.Log("+10");
            }
            
            //run this if player fails minigame
            //prevBob.GetComponent<BobGameController>().StartBobbing();
        }

        // GameObject manager = GameObject.Find("3DManager");
        // manager.GetComponent<ThreeDManager>().FishCaught();
        // GameObject.Find("Rope").SetActive(false);
        // Destroy(prevBob);

#endregion

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
