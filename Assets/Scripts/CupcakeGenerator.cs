using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class CupcakeGenerator : MonoBehaviour
{
    // Arrays for storing the possible sprites for each layer
    [Header("Layer Sprites")]
    public Sprite[] wrappingSprites;
    public Sprite[] baseSprites;
    public Sprite[] frostingSprites;

    // References to the UI Image components where the sprite will be displayed
    [Header("UI Image References")]
    public Image wrappingImage;
    public Image baseImage;
    public Image frostingImage;

    // Variables to store the randomly selected indices (for later comparison)
    [HideInInspector] public int wrappingIndex;
    [HideInInspector] public int baseIndex;
    [HideInInspector] public int frostingIndex;

    // Call this function to generate a random cupcake
    public void GenerateRandomCupcake()
    {
        // Check if arrays are not empty to avoid errors
        if(wrappingSprites.Length > 0)
        {
            wrappingIndex = Random.Range(0, wrappingSprites.Length);
            wrappingImage.sprite = wrappingSprites[wrappingIndex];
            wrappingImage.enabled = true;
        }

        if(baseSprites.Length > 0)
        {
            baseIndex = Random.Range(0, baseSprites.Length);
            baseImage.sprite = baseSprites[baseIndex];
            baseImage.enabled = true;
        }

        if(frostingSprites.Length > 0)
        {
            frostingIndex = Random.Range(0, frostingSprites.Length);
            frostingImage.sprite = frostingSprites[frostingIndex];
            frostingImage.enabled = true;
        }
        
    }
        void Start()
        {
            GenerateRandomCupcake();
        }
}

