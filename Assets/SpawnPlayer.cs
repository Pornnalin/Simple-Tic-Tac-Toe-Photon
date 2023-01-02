using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.IO;

public class SpawnPlayer : MonoBehaviour
{

    [SerializeField] Transform canva;
    [SerializeField] private Transform[] pos;
    [SerializeField] public List<Transform> playerTra;
    [SerializeField] PhotonView view;
    // Start is called before the first frame update
    void Start()
    {

        spawnPlayers();       

    }

    // Update is called once per frame
    void Update()
    {

        view.RPC(nameof(Updatelist), RpcTarget.All);

    }
    [PunRPC]
     void Updatelist()
    {
        foreach (var item in playerTra)
        {
            item.SetParent(canva, true);
        }
    }

    void spawnPlayers()
    {
        int i = Array.IndexOf(PhotonNetwork.PlayerList, PhotonNetwork.LocalPlayer);
        PhotonNetwork.Instantiate("Player", pos[i].position, Quaternion.identity);
        
    }
}

