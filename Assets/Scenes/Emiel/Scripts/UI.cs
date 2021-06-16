using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    private Player player;
    private Text keyFragmentsCount;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        keyFragmentsCount = GetComponent<Text>();
    }

    private void Update()
    {
        keyFragmentsCount.text = "Picked up Key Fragments: " + player.keyFragments;
    }
}
