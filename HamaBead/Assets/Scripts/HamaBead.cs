using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HamaBead : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void Paint()
    {
        image.color = HamaBeadManager.Instance.selectedColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Paint();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            Paint();
        }
    }

    public Color GetColor()
    {
        return image.color;
    }
}

