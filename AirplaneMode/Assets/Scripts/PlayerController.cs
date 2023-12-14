using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro.Examples;

public class PlayerController : MonoBehaviourPun
{
    [Header("Info")]
    public int id;


    [Header("Components")]
    public Rigidbody rig;
    public Player photonPlayer;


    [PunRPC]
    public void Initialize(Player player)
    {
        id = player.ActorNumber;
        photonPlayer = player;

        GameManager.instance.players[id - 1] = this;

       
        // is this not our local player?
        if (!photonView.IsMine)
        {
            GetComponentInChildren<Camera>().gameObject.SetActive(false);
            rig.isKinematic = true;
        }
        //else
        //{
        //    GameUI.instance.Initialize(this);
        //}
    }

    void Update()
    {
        if (!photonView.IsMine)
            return;

        //Move();

    }

    //void Move()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");

    //    Vector3 dir = (transform.forward * z + transform.right * x) * moveSpeed;
    //    dir.y = rig.velocity.y;

    //    rig.velocity = dir;
    //}
}