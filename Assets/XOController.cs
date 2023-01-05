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
        Player_2,
        EndGame,

    }

    [SerializeField]
    public stage currentStage;
    public List<Button> buttonXO;
    public List<TextMeshProUGUI> textAll;
    public TextMeshProUGUI[] textP;
    [SerializeField] PhotonView view;
    public bool nextPlayer;
    public bool winGame;
    public List<GameObject> gg;
    [SerializeField] private SpawnPlayer spawnPlayer;
       
    void Start()
    {
        view = GetComponent<PhotonView>();
        PhotonNetwork.AutomaticallySyncScene = true;
        winGame = false;
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

        //if (PhotonNetwork.CurrentRoom.PlayerCount < 2)
        //{
        //    currentStage = stage.None;
        //}
        //else
        //{

        //    currentStage = stage.Player_1;

        //}
        for (int i = 0; i < buttonXO.Count; i++)
        {
            if (buttonXO[i].GetComponent<TextXo>().updateTurn)
            {
                if (currentStage == stage.Player_1)
                {
                    currentStage = stage.Player_2;
                    buttonXO[i].GetComponent<TextXo>().updateTurn = false;
                    break;
                }

                if (currentStage == stage.Player_2)
                {
                    currentStage = stage.Player_1;
                    buttonXO[i].GetComponent<TextXo>().updateTurn = false;
                    break;


                }
            }
        }
        switch (currentStage)
        {
            case stage.None:
                Debug.Log("wait..");
                break;

            case stage.Player_1:
                break;

            case stage.Player_2:              

                break;

        }
       // StartCoroutine(waitToReset());
    }
    void RuleWin(string xo)
    {
        if (textAll[0].text.Contains(xo) && textAll[1].text.Contains(xo) && textAll[2].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
            winGame = true;

        }
        if (textAll[0].text.Contains(xo) && textAll[3].text.Contains(xo) && textAll[6].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
            winGame = true;

        }
        if (textAll[1].text.Contains(xo) && textAll[4].text.Contains(xo) && textAll[7].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
            winGame = true;

        }
        if (textAll[2].text.Contains(xo) && textAll[5].text.Contains(xo) && textAll[8].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
            winGame = true;

        }
        if (textAll[3].text.Contains(xo) && textAll[4].text.Contains(xo) && textAll[5].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
            winGame = true;

        }
        if (textAll[6].text.Contains(xo) && textAll[7].text.Contains(xo) && textAll[8].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
            winGame = true;

        }
        if (textAll[0].text.Contains(xo) && textAll[4].text.Contains(xo) && textAll[8].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
            winGame = true;

        }
        if (textAll[2].text.Contains(xo) && textAll[4].text.Contains(xo) && textAll[6].text.Contains(xo))
        {
            Debug.Log("Won");
            currentStage = stage.None;
            winGame = true;

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
    IEnumerator waitToReset()
    {  
        gg[0].SetActive(true);
        gg[1].GetComponent<TextMeshProUGUI>().text = currentStage.ToString();        

        yield return new WaitForSeconds(10f);

        foreach (var item in textAll)
        {
            item.text = "";
        }
        currentStage = stage.Player_1;

    }
}

