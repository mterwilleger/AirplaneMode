using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class WinConditions : MonoBehaviourPun
{
    void OnTriggerEnter(Collider collision)
    {
        // Debug.Log("TRIGGER");
        if (!PhotonNetwork.IsMasterClient)
            return;

        PhotonNetwork.Destroy(gameObject);
    }
}