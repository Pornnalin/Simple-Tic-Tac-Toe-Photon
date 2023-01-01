using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class XOController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public enum stage
    {
        None,
        Player_1,
        Player_2
    }

    [SerializeField]
    public stage currentStage;
    public List<Button> buttonXO;
    public List<TextMeshProUGUI> textAll;
    public TextMeshProUGUI[] textP;    
    [SerializeField] PhotonView view;
   
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        foreach (var item in buttonXO)
        {
            textAll.Add(item.GetComponentInChildren<TextMeshProUGUI>());
        }
       
       
    }

    // Update is called once per frame
    void Update()
    {
       

        RuleWin("X");
        RuleWin("O");

        if (PhotonNetwork.CurrentRoom.PlayerCount < 2)
        {
            currentStage = stage.None;
        }
        else
        {

            currentStage = stage.Player_1;

        }

        switch (currentStage)
        {
            case stage.None:
                Debug.Log("wait..");
                break;
            case stage.Player_1:

                break;
            case stage.Player_2:

                // BotTurn();
                break;

        }
    }
    void RuleWin(string xo)
    {
        if (textAll[0].text.Contains(xo) && textAll[1].text.Contains(xo) && textAll[2].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
        }
        if (textAll[0].text.Contains(xo) && textAll[3].text.Contains(xo) && textAll[6].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
        }
        if (textAll[1].text.Contains(xo) && textAll[4].text.Contains(xo) && textAll[7].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
        }
        if (textAll[2].text.Contains(xo) && textAll[5].text.Contains(xo) && textAll[8].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
        }
        if (textAll[3].text.Contains(xo) && textAll[4].text.Contains(xo) && textAll[5].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
        }
        if (textAll[6].text.Contains(xo) && textAll[7].text.Contains(xo) && textAll[8].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
        }
        if (textAll[0].text.Contains(xo) && textAll[4].text.Contains(xo) && textAll[8].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
        }
        if (textAll[2].text.Contains(xo) && textAll[4].text.Contains(xo) && textAll[6].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
        }
    }
    void BotTurn()
    {
        // int index = Random.Range(0, textAll.Count);
        int index = Random.Range(0, textAll.Count);
        if (textAll[index].text == "")
        {
            textAll[index].text = "O";
            currentStage = stage.Player_1;
            Debug.Log("PlayerTurn");
        }

    }
}
