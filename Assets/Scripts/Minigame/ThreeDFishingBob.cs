using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDFishingBob : MonoBehaviour
{
    [Header("Bobbing")]
    public float bobSpeed = 1.0f;      // Adjust this value to control the bobbing speed
    public float bobHeight = 0.2f;     // Adjust this value to control the height of the bobbing
    public float catchSpeed = 3.0f;

    private Vector3 _initialPosition;
    private bool _isBobbing = false;
    private bool _fishCaught = false;
    private int _waitTime = 0;

    [Header("Fish Hooked")]
    public float trembleSpeed = 1.0f;     // Adjust this value to control the trembling speed
    public float trembleAmount = 0.2f;    // Adjust this value to control the amount of trembling
    public float catchWindow;

    public GameObject[] activateOnFish;

    private bool _isTrembling = false;
    private HookState _currentState = HookState.BOBBING;
    private float _stopCatchTime;

    public enum HookState {
        DEAD,
        BOBBING,
        FISHCATCHING,
        FISHCAUGHT
    }

    private void Start()
    {
        _initialPosition = transform.position;
        _currentState = HookState.DEAD;
        //StartBobbing();
    }

    private void Update()
    {
        StateUpdate();
        //Checks();
    }

    public void StateUpdate(){
        switch (_currentState){
            case HookState.BOBBING:
                // Debug.Log("bobbing");
                Bobbing();
                break;
            case HookState.FISHCATCHING:
                // Debug.Log("Fish catching");
                FishCatching();
                break;
            case HookState.FISHCAUGHT:
                // Debug.Log("Fish caught");
                FishCatched();
                break;
            case HookState.DEAD:
                // Debug.Log("Dead");
                Dead();
                break;
        }
    }

    public void Bobbing(){
        // Calculate the new position based on a sine wave
        float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        Vector3 newPosition = _initialPosition + new Vector3(0f, yOffset, 0f);

        // Apply the new position to the sprite
        transform.position = newPosition;
    }

    public void FishCatching(){
        // Calculate the trembling offset based on Perlin noise
        float xOffset = Mathf.PerlinNoise(0f, Time.time * trembleSpeed) * trembleAmount;
        float yOffset = Mathf.PerlinNoise(Time.time * trembleSpeed, 0f) * trembleAmount;

        // Apply the trembling offset to the sprite's position
        Vector3 newPosition = _initialPosition + new Vector3(xOffset, yOffset, 0f);
        transform.position = newPosition;

        if(Time.time > _stopCatchTime){
            StartBobbing();
        }
    }

    public void FishCatched(){

    }

    public void Dead(){

    }

    public void StartBobbing()
    {
        _waitTime = Random.Range(4,21);
        Invoke("StartCatching", _waitTime);
        _isBobbing = true;
        _currentState = HookState.BOBBING;
    }

    public void StopBobbing()
    {
        _isBobbing = false;
        transform.position = _initialPosition;
        _currentState = HookState.DEAD;
    }

    public void StartCatching(){
        _isBobbing = false;
        _fishCaught = true;
        _isTrembling = true;
        _currentState = HookState.FISHCATCHING;
        _stopCatchTime = Time.time + catchWindow;

        foreach (GameObject i in activateOnFish){
            i.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other) {
        _initialPosition = transform.position;
        GetComponent<SphereCollider>().enabled = false;
        Debug.Log("hit water");
        StartBobbing();
    }

    public HookState GetState(){
        return _currentState;
    }

    //player doing minigame so extend the trembling duration
    public void PlayerCatchingFish(){
        _stopCatchTime += 60f;
    }
}

