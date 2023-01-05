using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class TextXo : MonoBehaviourPunCallbacks
{
    public XOController controller;
    public TextMeshProUGUI uGUI;
    public PhotonView view;
    public bool updateTurn;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        uGUI = GetComponentInChildren<TextMeshProUGUI>();
        uGUI.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // view.RPC("updateBool", RpcTarget.All);
        
    }

   

    public void OnClickButton()
    {
        switch (controller.currentStage)
        {
            case XOController.stage.Player_1:

                if (uGUI.text == "")
                {
                    view.RPC("UpdateText", RpcTarget.All, "X");
                
                }
                else
                {
                    Debug.Log("Can't click this space");

                }
                break;
            case XOController.stage.Player_2:

                if (uGUI.text == "")
                {
                    view.RPC("UpdateText", RpcTarget.All, "O");
                   

                }
                else
                {
                    Debug.Log("Can't click this space");

                }
                break;
        }

    }
    [PunRPC]
    public void UpdateText(string text)
    {
        uGUI.text = text;
        updateTurn = true;
    }
}
