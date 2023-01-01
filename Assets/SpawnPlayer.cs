using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{

    [SerializeField] Transform canva;
    [SerializeField] private Transform[] pos;
    public List<NameCharacter> players;
    public XOController xO;
    // Start is called before the first frame update
    void Start()
    {

        PhotonNetwork.Instantiate("Player", canva.position, Quaternion.identity);


    }

    // Update is called once per frame
    void Update()
    {

       
        foreach (var player1 in PhotonNetwork.PlayerList)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (player1.IsMasterClient)
                {
                    xO.textP[0].text = players[i].textName.text;
                }
                else
                {
                    xO.textP[1].text = players[i].textName.text;

                }
            }
        }
    }
}
