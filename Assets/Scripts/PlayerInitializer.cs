using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    public SpriteRenderer PlayerSprite;
    public BoxCollider2D PlayerCollider;

    public Sprite WalterSprite;
    public Sprite MildredSprite;

    private void Start()
    {
        Setup(Globals.PlayerName);
    }
    public void Setup(string name)
    {
        if (name == "Walter")
        {
            PlayerSprite.sprite = WalterSprite;
            PlayerCollider.size = new Vector2(16, 32);
        }

        else if (name == "Mildred")
        {
            PlayerSprite.sprite = MildredSprite;
            PlayerCollider.size = new Vector2(20, 32);
        }

        else
        {
            Debug.Log("No name yet");
        }
    }
}
