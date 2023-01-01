using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextXo : MonoBehaviour
{
    public XOController controller;
    public TextMeshProUGUI uGUI;

    // Start is called before the first frame update
    void Start()
    {

        uGUI = GetComponentInChildren<TextMeshProUGUI>();
        uGUI.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickButton()
    {
        switch (controller.currentStage)
        {
            case XOController.stage.Player_1:

                if (uGUI.text == "")
                {
                    uGUI.text = "X";

                    controller.currentStage = XOController.stage.Player_2;
                }
                else
                {
                    Debug.Log("Can't click this space");

                }
                break;
            case XOController.stage.Player_2:

                if (uGUI.text == "")
                {
                    uGUI.text = "O";

                    controller.currentStage = XOController.stage.Player_1;
                }
                else
                {
                    Debug.Log("Can't click this space");

                }
                break;
        }

    }
}
