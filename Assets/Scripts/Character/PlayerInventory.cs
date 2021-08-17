using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObjectStruct[] playerClothes;
    public List<GameObjectStruct> playerInventoryList; 
    // Start is called before the first frame update
    void Start()
    {
        playerClothes = new GameObjectStruct[5];
        playerClothes[0] = new GameObjectStruct {
            name = "Player_Body_01",
            weight = 50,
            IsVisible = false,
            SpriteSheetPath = "SpriteSheets/Body",
            clothesType = ClothesType.Body,
        };
    }

    public void ChangeClothes(GameObjectStruct NewCloth)
    {
        playerClothes[((int)NewCloth.clothesType)] = NewCloth;
    }
}

public struct GameObjectStruct
{
    public string name;

    public string SpriteSheetPath;

    public float weight;

    public bool IsVisible;

    public ClothesType clothesType;
}

public struct NPCName
{
    string firstName;
    string lastName;
    string surName;

    public string GetFullName()
    {
        return firstName + " " + lastName;
    }

    public string GetReverseFullName()
    {
        return lastName + " " + firstName;
    }
}


public enum ClothesType
{
    Body,//Mascular, normal, diferrent races and etc
    Hat,
    Shirt,
    Pants,
    Shoes
}
