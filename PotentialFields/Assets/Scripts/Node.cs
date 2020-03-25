using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Sprite walkableSprite, notWalkableSprite;
    [SerializeField] private Gradient valueColor;
    public Vector2Int position;
    public float value = int.MaxValue;
    public bool IsWalkable
    {
        get
        {
            return isWalkable;
        }

        set
        {
            isWalkable = value;
            rend.sprite = (isWalkable) ? walkableSprite : notWalkableSprite;
        }
    }
    private bool isWalkable = true;

    private SpriteRenderer rend;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public void ResetNode()
    {
        rend.color = Color.white;
        value = int.MaxValue;
    }

    public void ChangeValue(float value)
    {
        if (IsWalkable)
        {
            this.value = value;
            Color newColor = valueColor.Evaluate(value / 15);
            rend.color = newColor;
        } else
        {
            this.value = int.MaxValue;
        }
    }

    private void OnMouseEnter()
    {
        MouseInput.Instance.focusedNode = this;
    }

    private void OnMouseExit()
    {
        if (MouseInput.Instance.focusedNode == this)
        {
            MouseInput.Instance.focusedNode = null;
        }
    }
}
