using UnityEngine;
using DG.Tweening;

public class BoardHolder : MonoBehaviour, IHolder
{
    public Node node;
    public int boardHolderID;

    private void Update()
    {
        //If the holder doesn't hold the node, derefernce it
        if (node)
        {
            if (node.transform.parent != transform)
                node = null;
        }
    }

    public void assignHolderID(int id)
    {
        boardHolderID = id;
    }

    public void hold(Node node)
    {
        node.transform.SetParent(transform);
        node.transform.DOMove(transform.position, 0.2f);
        this.node = node;
    }
}