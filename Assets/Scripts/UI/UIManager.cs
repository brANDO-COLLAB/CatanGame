using Catan.GameManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Catan.UI
{
    public class UIManager : MonoBehaviour
    {
        public GameManager gameManager;

        public TextMeshProUGUI playerDisplay;
        public TextMeshProUGUI phaseDisplay;
        public TextMeshProUGUI nextDisplay;
        public Button nextButton;

        public TextMeshProUGUI oreDisplay;
        public TextMeshProUGUI brickDisplay;
        public TextMeshProUGUI woodDisplay;
        public TextMeshProUGUI grainDisplay;
        public TextMeshProUGUI sheepDisplay;

        public void AdvanceTurn()
        {
            gameManager.AdvanceTurn();
            UpdateTurnUI();
        }

        public void UpdateTurnUI()
        {
            playerDisplay.text = gameManager.currentPlayer.playerName;
            playerDisplay.color = gameManager.currentPlayer.primaryUIColor;
            phaseDisplay.color = gameManager.currentPlayer.primaryUIColor;
            nextDisplay.color = gameManager.currentPlayer.secondaryUIColor;
            nextButton.GetComponent<Image>().color = gameManager.currentPlayer.primaryUIColor;

            grainDisplay.text = gameManager.currentPlayer.resources[0].amount.ToString();
            sheepDisplay.text = gameManager.currentPlayer.resources[1].amount.ToString();
            woodDisplay.text = gameManager.currentPlayer.resources[2].amount.ToString();
            brickDisplay.text = gameManager.currentPlayer.resources[3].amount.ToString();
            oreDisplay.text = gameManager.currentPlayer.resources[4].amount.ToString();


            switch (gameManager.phase)
            {
                case 0:
                    phaseDisplay.text = "Roll Resources";
                    nextDisplay.text = "Next";
                    break;
                case 1:
                    phaseDisplay.text = "Trade";
                    nextDisplay.text = "End Trading";
                    break;
                case 2:
                    phaseDisplay.text = "Build";
                    nextDisplay.text = "End Building";
                    break;
                default:
                    phaseDisplay.text = "Waiting...";
                    nextDisplay.text = "Waiting...";
                    break;
            }
        }
    }

}
