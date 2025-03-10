/// AUTHOR: Matthew Moffitt
/// FILENAME: InteractionManager.cs
/// SPECIFICATION: File that manages player interaction
/// FOR: CS 3368 Introduction to Artificial Intelligence Section 001

using Catan.BuildPhase;
using Catan.GameBoard;
using Catan.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Catan.GameManagement
{
    public class InteractionManager : MonoBehaviour
    {
        public GameManager gameManager;
        public Board board;

        public (int, int) tempVertex;
        public void BoardTokenClicked(BoardTokenGameObject obj, int i, int j)
        {
            // Build phase
            if (gameManager.phase == 2 && !gameManager.starting)
            {
                if (obj is TileVertexGameObject)
                {
                    board.BuildVertex(gameManager.currentPlayer, (i, j), (TileVertexGameObject)obj);
                    gameManager.UpdateScores();
                }
                if (obj is RoadGameObject)
                {
                    board.BuildRoad(gameManager.currentPlayer, (i, j), (RoadGameObject)obj);
                    gameManager.UpdateScores();
                }
            }

            // Starting phase
            if (gameManager.phase == 0 && gameManager.starting && obj is TileVertexGameObject)
            {
                if (!board.BuildVertex(gameManager.currentPlayer, (i, j), (TileVertexGameObject)obj, true))
                {
                    return;
                }
                tempVertex = (i, j);

                if (!gameManager.reverseTurnOrder)
                {
                    board.DistributeResourcesFromVertex(tempVertex);
                }

                gameManager.UIManager.AdvanceTurn();
            }
            if (gameManager.phase == 1 && gameManager.starting && obj is RoadGameObject && board.vertices.AdjacentRoadsToVertex(board.roads, tempVertex).Contains((i, j)))
            {
                if (board.BuildRoad(gameManager.currentPlayer, (i, j), (RoadGameObject)obj, true))
                {
                    gameManager.UIManager.AdvanceTurn();
                }
            }
        }

        public void TileClicked(TileGameObject obj, int i, int j)
        {
            if (gameManager.movingRobber)
            {
                board.tiles[gameManager.robberLocation.Item1][gameManager.robberLocation.Item2].robber = false;
                board.tiles[i][j].robber = true;

                GameObject.Find("Tile(" + gameManager.robberLocation.Item1 + "," + gameManager.robberLocation.Item2 + ")").transform.GetChild(0).GetComponent<TileGameObject>().SetRobber(false);
                GameObject.Find("Tile(" + i + "," + j + ")").transform.GetChild(0).GetComponent<TileGameObject>().SetRobber(true);
                
                gameManager.UIManager.EndMoveRobber((i, j));
            }
        }

        public void DumpVertexInfo(int i, int j)
        {
            Debug.Log("Vertex ( " + board.vertices[i][j].xCoord + " " + board.vertices[i][j].yCoord + " ): "
                + "\nData Index: " + board.vertices[i][j].xDataIndex + " " + board.vertices[i][j].yDataIndex
                + "\nAbove: " + board.vertices.TileAboveVertex(board.tiles, i, j)
                + "\nBelow: " + board.vertices.TileBelowVertex(board.tiles, i, j)
                + "\nTo Right: " + board.vertices.TileRightOfVertex(board.tiles, i, j)
                + "\nTo Left: " + board.vertices.TileLeftOfVertex(board.tiles, i, j)
                );
        }
    }
}
