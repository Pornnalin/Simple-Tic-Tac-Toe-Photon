using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    public void CreateRoom()
    {
        if (CheckInput(createInput.text))
        {
            PhotonNetwork.CreateRoom(createInput.text);
        }
        else
        {
            Debug.LogError("input your room");
        }

        Debug.Log("CreckInput = " + CheckInput(createInput.text));
    }
    public void JoinRoom()
    {

        if (CheckInput(joinInput.text))
        {
            PhotonNetwork.JoinRoom(joinInput.text);
        }
        else
        {
            Debug.LogError("input your room");

        }

    }
    public override void OnJoinedLobby()
    {
        //PhotonNetwork.NickName = "Player" + Random.Range(0, 1000).ToString("0000");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
    public bool CheckInput(string text)
    {
        if (text == "") 
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
