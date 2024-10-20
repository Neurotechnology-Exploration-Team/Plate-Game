using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject[,] blocks;
    [SerializeField] private GameObject blockTemplate;
    [SerializeField] private int width = 9;
    [SerializeField] private int height = 9;
    #endregion

    #region Internal Methods
    // Start is called before the first frame update
    void Start()
    {
        blocks = new GameObject[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                blocks[i, j] = Instantiate(blockTemplate, new Vector3(-10.40f + (i * 2.6f), 5.85f - (j * 0.8f)), Quaternion.identity); 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region External Methods

    #endregion
}
