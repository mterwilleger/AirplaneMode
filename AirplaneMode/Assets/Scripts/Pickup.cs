using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public enum PickupType
{
    Score
}

public class Pickup : MonoBehaviourPun
{
    public PickupType type;
    public int value;

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision");
        if (!PhotonNetwork.IsMasterClient)
            return;

        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            

            if (type == PickupType.Score)
                player.photonView.RPC("GiveTreasure", player.photonPlayer, value);
            
            PhotonNetwork.Destroy(gameObject);
        }
    }
}