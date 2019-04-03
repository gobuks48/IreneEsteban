using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamaBeadManager : MonoBehaviour
{
    public static HamaBeadManager Instance { get; private set; }

    [Header("Hama Bead Grid")]
    public GameObject hamaBeadPrefab;
    public RectTransform panelTransform;
    public Vector2Int gridSize = new Vector2Int(32, 32);

    [Header("Color Selection")]
    public Color selectedColor;
    public Image selectedColorImage;
    public Color[] paletteColor;
    public GameObject colorButtonPrefab;
    public RectTransform colorSelectionPanel;

    private HamaBead[,] hamaBeadArray;

    void Awake()
    {
        Instance = this;
        CreateGrid();
        CreatePalette();
    }

    void CreatePalette()
    {
        SelectColor(paletteColor[0]);

        for (int i = 0; i < paletteColor.Length; i++)
        {
            ColorSelector cS = GameObject.Instantiate(colorButtonPrefab, colorSelectionPanel).GetComponent<ColorSelector>();
            cS.SetColor(paletteColor[i]);
        }
    }

    public void SelectColorFromImage(Image image)
    {
        SelectColor(image.color);
    }

    public void SelectColor(Color color)
    {
        selectedColor = color;
        selectedColorImage.color = color;
    }

    public void CrearButton()
    {
        Color previous = selectedColor;
        SelectColor(paletteColor[1]);

        for (int j = 0; j < gridSize.y; j++)
        {
            for (int i = 0; i < gridSize.x; i++)
            {
                hamaBeadArray[i, j].Paint();
            }
        }

        SelectColor(previous);
    }

    public void FillButton()
    {
        Color previous = selectedColor;

        for (int j = 0; j < gridSize.y; j++)
        {
            for (int i = 0; i < gridSize.x; i++)
            {
                hamaBeadArray[i, j].Paint();
            }
        }

        SelectColor(previous);
    }

    void CreateGrid()
    {
        hamaBeadArray = new HamaBead[gridSize.x, gridSize.y];

        float size = panelTransform.rect.height / gridSize.y;

        for (int j = 0; j < gridSize.y; j++)
        {
            for (int i = 0; i < gridSize.x; i++)
            {
                GameObject hamaBeadObject = GameObject.Instantiate(hamaBeadPrefab, panelTransform);

                hamaBeadObject.transform.localPosition = new Vector3(size * i, -size * j, 0);
                hamaBeadObject.transform.localScale = new Vector3(size, size, size) / 100.0f;

                HamaBead hamaBead = hamaBeadObject.GetComponent<HamaBead>();
                hamaBeadArray[i, j] = hamaBead;
            }
        }
    }

    public void SaveButton()
    {
        Texture2D texture = new Texture2D(gridSize.x, gridSize.y);

        for (int j = 0; j < gridSize.y; j++)
        {
            for (int i = 0; i < gridSize.x; i++)
            {
                texture.SetPixel(i, gridSize.y - j - 1, hamaBeadArray[i, j].GetColor());
            }
        }
        texture.Apply();
        System.IO.File.WriteAllBytes("myImages.png", texture.EncodeToPNG());
    }

    void DestroyGrid()
    {
        for (int j = 0; j < gridSize.y; j++)
        {
            for (int i = 0; i < gridSize.x; i++)
            {
                Destroy(hamaBeadArray[i, j].gameObject);
            }
        }
    }

    public void ChangeGrid(int size)
    {
        DestroyGrid();
        gridSize = new Vector2Int(size, size);
        CreateGrid();
    }

    public void GoToPlayScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}

