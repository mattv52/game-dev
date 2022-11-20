using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private bool blocks = true; 
    public SpriteRenderer[] spriteRenderes;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderes = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && Time.timeScale == 1)
        {
            toggleBlocks();
        }
    }

    // Turn blocks on/off
    void toggleBlocks()
    {
        blocks = !blocks;
        for (int i = 0; i < spriteRenderes.Length; i++)
        {
            spriteRenderes[i].enabled = blocks;
        }
    }
}
