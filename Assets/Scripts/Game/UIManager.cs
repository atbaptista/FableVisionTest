using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //UI Text GameObjects
    public GameObject UIPlayerHP; 

    //Game Variables
    [HideInInspector]public float PlayerHP;

    //Text Components
    [HideInInspector]TextMeshProUGUI TMPPlayerHP; 

    // Start is called before the first frame update
    void Start()
    {
        TMPPlayerHP = UIPlayerHP.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        TMPPlayerHP.text = PlayerManager.Instance.PlayerHP.ToString();
    }
}
