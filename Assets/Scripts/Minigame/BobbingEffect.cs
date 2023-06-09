using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code that goes on the fishing bob, currently keeps track of the current state of the fishing minigame
public class BobbingEffect : MonoBehaviour
{
    [Header("Bobbing")]
    public float bobSpeed = 2.0f;      // Adjust this value to control the bobbing speed
    public float bobHeight = 0.2f;     // Adjust this value to control the height of the bobbing
    public float catchSpeed = 10.0f;

    private Vector3 _initialPosition;
    private bool _isBobbing = false;
    private bool _fishCaught = false;
    private int _waitTime = 0;

    [Header("Fish Hooked")]
    public float trembleSpeed = 11.0f;     // Adjust this value to control the trembling speed
    public float trembleAmount = 0.15f;    // Adjust this value to control the amount of trembling
    public float catchWindow= 0.5f;

    public GameObject[] activateOnFish;

    private bool _isTrembling = false;
    private HookState _currentState = HookState.BOBBING;
    private float _stopCatchTime;

    private enum HookState {
        DEAD,
        BOBBING,
        FISHCATCHING,
        FISHCAUGHT
    }

    private void Start()
    {
        _initialPosition = transform.position;
        StartBobbing();

        _waitTime = Random.Range(4,21);
        Debug.Log(_waitTime);
        Invoke("StartCatching", _waitTime);
    }

    private void Update()
    {
        StateUpdate();
        //Checks();
    }

    public void StateUpdate(){
        switch (_currentState){
            case HookState.BOBBING:
                Debug.Log("bobbing");
                Bobbing();
                break;
            case HookState.FISHCATCHING:
                Debug.Log("Fish catching");
                FishCatching();
                break;
            case HookState.FISHCAUGHT:
                Debug.Log("Fish caught");
                FishCatched();
                break;
            case HookState.DEAD:
                Debug.Log("Dead");
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

        if(Input.GetKeyDown(KeyCode.Space)){

        }
    }

    public void FishCatched(){

    }

    public void Dead(){

    }

    public void StartBobbing()
    {
        _isBobbing = true;
        _currentState = HookState.BOBBING;
    }

    public void StopBobbing()
    {
        _isBobbing = false;
        transform.position = _initialPosition;
        _currentState = HookState.DEAD;
    }

    public void StartTrembling()
    {
        _isTrembling = true;
        _currentState = HookState.FISHCATCHING;
    }

    public void StopTrembling()
    {
        _isTrembling = false;
        transform.position = _initialPosition;
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

    // public void Checks(){
    //     if (_isBobbing)
    //     {
    //         // Calculate the new position based on a sine wave
    //         float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
    //         Vector3 newPosition = _initialPosition + new Vector3(0f, yOffset, 0f);

    //         // Apply the new position to the sprite
    //         transform.position = newPosition;
    //         return;
    //     }

    //     // if (_fishCaught){
    //     //     if(transform.position.y < -6){
    //     //         return;
    //     //     }

    //     //     Vector3 newPosition = transform.position - new Vector3(0f, (catchSpeed * Time.deltaTime), 0f);

    //     //     // Apply the new position to the sprite
    //     //     transform.position = newPosition;
    //     // }

    //     if (_isTrembling)
    //     {
    //         // Calculate the trembling offset based on Perlin noise
    //         float xOffset = Mathf.PerlinNoise(0f, Time.time * trembleSpeed) * trembleAmount;
    //         float yOffset = Mathf.PerlinNoise(Time.time * trembleSpeed, 0f) * trembleAmount;

    //         // Apply the trembling offset to the sprite's position
    //         Vector3 newPosition = _initialPosition + new Vector3(xOffset, yOffset, 0f);
    //         transform.position = newPosition;
    //     }
    // }
}

