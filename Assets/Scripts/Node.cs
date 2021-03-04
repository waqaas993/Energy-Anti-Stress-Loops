using UnityEngine;
using DG.Tweening;

public enum NodeType
{
    none,

    biConnectorLeftDown,
    biConnectorRightDown,
    biConnectorUpLeft,
    biConnectorUpRight,

    boltDown,
    boltLeft,
    boltRight,
    boltUp,

    bulbDown,
    bulbLeft,
    bulbRight,
    bulbUp,

    lineHorizontol,
    lineVertical,

    triConnectorRightLeftDown,
    triConnectorUpLeftDown,
    triConnectorUpRightDown,
    triConnectorUpRightLeft,

    quadConnector
}

public class Node : MonoBehaviour, INode
{
    public NodeType nodeType;
    public IHolder currentHolder;


    public Board board;
    public SpriteRenderer[] nodeSprites;

    public bool selected;
    public LayerMask holderLayerMask;

    private void Awake()
    {
        board = FindObjectOfType<Board>();
    }

    public void onSelect()
    {
        selected = true;
        transform.SetParent(null);
        transform.DOScale(Vector3.one * 1.2f, 0.2f);
        setMaskInteraction(SpriteMaskInteraction.None);
    }

    public void onRelease()
    {
        selected = false;
        transform.DOScale(Vector3.one, 0.2f);
        //If there's a holder beneath the node, assign the node piece to the holder
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.forward, 100, holderLayerMask);
        if (hit.collider != null)
        {
            currentHolder = hit.transform.GetComponent<IHolder>();
        }
        currentHolder.hold(this);
    }

    public void setMaskInteraction(SpriteMaskInteraction spriteMaskInteraction)
    {
        for (int i = 0 ; i < nodeSprites.Length ; i++)
        {
            nodeSprites[i].maskInteraction = spriteMaskInteraction;
        }
    }
}