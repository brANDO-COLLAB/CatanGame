/// AUTHOR: Matthew Moffitt
/// FILENAME: TileGameObject.cs
/// SPECIFICATION: File containing board info
/// FOR: CS 3368 Introduction to Artificial Intelligence Section 001

using Catan.GameManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Catan.GameBoard
{
    public class TileGameObject : MonoBehaviour
    {
        public TextMeshProUGUI text;
        public GameObject mesh;
        public MeshRenderer tokenRenderer;
        public MeshRenderer robberRenderer;

        public int diceValue;
        public bool robber;

        public int xIndex;
        public int yIndex;
        public int xCoord;
        public int yCoord;

        public void OnMouseDown()
        {
            GameObject.Find("Game Manager").GetComponent<InteractionManager>().TileClicked(this, xIndex, yIndex);
        }

        public void SetDiceValue(int value)
        {
            diceValue = value;
            UpdateDiceValueText();
        }

        public void UpdateDiceValueText()
        {
            text.text = diceValue > 0 ? diceValue.ToString() : "";
            tokenRenderer.enabled = diceValue > 0;
        }

        public void SetRobber(bool hasRobber)
        {
            robber = hasRobber;
            UpdateRobberMesh();
        }

        public void UpdateRobberMesh()
        {
            robberRenderer.enabled = robber;
        }

        public void SetAppearance(Tile.TileType type)
        {
            mesh = Instantiate(GameObject.Find("Tile Asset Holder").transform.GetChild((int)type)).gameObject;
            mesh.transform.position = transform.position;
            mesh.transform.rotation = Quaternion.Euler(0, 30 + 60 * UnityEngine.Random.Range(0, 6), 0);
            mesh.transform.parent = transform;
        }
    }
}