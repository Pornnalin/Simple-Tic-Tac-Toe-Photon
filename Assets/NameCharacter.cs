using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class NameCharacter : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textName;
    [SerializeField]
    public PhotonView photonView;
    [SerializeField] private SpawnPlayer spawnPlayer;

    private void Start()
    {
        textName.text = photonView.Owner.NickName;
        spawnPlayer = FindObjectOfType<SpawnPlayer>();
        spawnPlayer.players.Add(this.gameObject.GetComponent<NameCharacter>());

    }
}