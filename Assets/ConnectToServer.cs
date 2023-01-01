
using UnityEngine.SceneManagement;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    
    // Start is called before the first frame update
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        
    }
    void Start()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.AutomaticallySyncScene = true;      
        PhotonNetwork.JoinLobby();
        

    }
    public override void OnJoinedLobby()
    {       
        Debug.Log("SomeOne Join lobby");
        PhotonNetwork.LoadLevel(1);
       
    }
    
   
}
