using UnityEngine;
using DG.Tweening;

public class Node : MonoBehaviour, INode
{
    public Board board;
    public SpriteRenderer mainSprite;

    public bool selected;
    public LayerMask holderLayerMask;

    private void Awake()
    {
        board = FindObjectOfType<Board>();
        mainSprite = GetComponent<SpriteRenderer>();
    }

    public void onSelect()
    {
        selected = true;
        transform.SetParent(null);
        transform.DOScale(Vector3.one * 1.2f, 0.2f);
        mainSprite.maskInteraction = SpriteMaskInteraction.None;
    }

    public void onRelease()
    {
        selected = false;
        transform.DOScale(Vector3.one, 0.2f);
        //If there's a holder beneath the node, assign the node piece to the holder
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.forward, 100, holderLayerMask);
        if (hit.collider != null)
        {
            hit.transform.GetComponent<IHolder>().hold(this);
        }
    }
}