using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public TMP_InputField textName;
    // Start is called before the first frame update
    public void OnUsernameInputValue()
    {
        PhotonNetwork.NickName = textName.text;
    }
}

