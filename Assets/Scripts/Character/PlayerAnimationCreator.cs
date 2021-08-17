using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationCreator : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovementScript;
    [SerializeField]
    PlayerInventory playerInventory;

    [SerializeField]
    SpriteRenderer[] playerSpriteRenderers;

    Sprite[][] playerSpriteSheets = new Sprite[5][];



    int[] idlePosIdMove = { 14, 44, 78, 108, 146 };//idle position in sprite sheet

    private void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
        playerInventory = GetComponent<PlayerInventory>();

        LoadSpriteSheets();
    }

    void LoadSpriteSheets()
    {
        playerSpriteSheets = new Sprite[6][];
        for (int i = 0; i < playerInventory.playerClothes.Length; i++)
        {
            if (playerInventory.playerClothes[i].SpriteSheetPath != null)
            {
                playerSpriteSheets[i] = Resources.LoadAll<Sprite>(playerInventory.playerClothes[i].SpriteSheetPath);
            }
        }        
    }

    public void PlayerIdleAnimation(int Sprite_Id)
    {
        for (int i = 0; i < playerSpriteRenderers.Length; i++)
        {
            if (!(playerSpriteSheets[i] is null))
            {

                playerSpriteRenderers[i].sprite = playerSpriteSheets[i][idlePosIdMove[Sprite_Id]];
            }
        }
    }

    public void PlayerWalkingAnimation(int Sprite_Id)
    {
        int movingDirection = playerMovementScript.movement.y == 1 ? 0 : 
                              playerMovementScript.movement.y == -1 ? 2 : 
                              playerMovementScript.movement.x == 1 ? 3 : 1;


        for (int i = 0; i < playerSpriteRenderers.Length; i++)
        {
            if (!(playerSpriteSheets[i] is null))
            {
                playerSpriteRenderers[i].sprite = playerSpriteSheets[i][Sprite_Id + 60 + 9 * movingDirection];
            }
        }
    }
}
