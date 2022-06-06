using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemInstance : MonoBehaviour
{
    public TypeItems typeItems;
    public Sprite catchedItem;
    private SpriteRenderer spriteRenderer;
    private bool isCatched;

    private void Start()
    {
        OnInit();
    }
    protected void OnInit()
    {
        isCatched = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCatched && other.CompareTag(ConstantManager.BALL))
        {
            switch (typeItems)
            {
                case TypeItems.life:
                    GameManager.Instance.SetCountLife(1);
                    break;
                case TypeItems.check_point:
                    PlayerManager.Instance.SaveStatusBall();
                    break;

            }
            if (catchedItem != null)
            {
                spriteRenderer.sprite = catchedItem;
            }
            else
            {
                gameObject.SetActive(false);
            }
            isCatched = true;
        }
    }
}
