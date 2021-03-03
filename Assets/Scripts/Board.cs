using UnityEngine;
using DG.Tweening;

public class Board : MonoBehaviour
{
    public Node[] nodes;

    public int width = 6;
    public int height = 6;

    public Transform holder;
    public GameObject boardHolderPrefab;

    private void Start()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly).SetCapacity(500, 20);
        generateGrid();
    }

    private void generateGrid()
    {
        int boardHolderId = 0;
        for (int row = height - 1; row >= 0 ; row--)
        {
            for (int column = 0; column < width; column++)
            {
                //Instantiate and center the board position
                GameObject boardHolder = Instantiate(boardHolderPrefab, holder) as GameObject;
                boardHolder.transform.position = new Vector2(column - width / 2, row - height / 2);
                boardHolder.GetComponent<BoardHolder>().assignHolderID(boardHolderId);
                boardHolderId += 1;
            }
        }
    }

}