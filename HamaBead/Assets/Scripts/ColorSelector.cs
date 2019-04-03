using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour, IPointerClickHandler
{
    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetColor (Color color)
    {
        image.color = color;
    }

    public Color GetColor()
    {
        return image.color;
    }

    public void SelectColor()
    {
        HamaBeadManager.Instance.SelectColor(GetColor());
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        SelectColor();
    }
}
