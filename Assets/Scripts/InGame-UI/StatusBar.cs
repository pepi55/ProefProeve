//Author Jesse Stam
//25-2-2016

using UnityEngine;
using System.Collections;
public class StatusBar : MonoBehaviour
{
    enum Direction
    {
        Vertical_left,
        Vertical_right,
        Horizontal_up,
        Horizontal_down
    }

    [SerializeField]
    Direction ScaleDirection = Direction.Vertical_left;
    Direction _ScaleDirection = Direction.Vertical_left;

    [SerializeField]
    RectTransform Mask = null,Image = null;

    Vector2 orignalSize;

    public float Value
    {
        set
        {
            if (value > 1)
            {
                Debug.Log("Value Exided Bounds. Supply value between 1 and 0");
                ChangeSize(1);
                return;
            }

            if(value < 0)
            {
                Debug.Log("Value Exided Bounds. Supply value between 1 and 0");
                ChangeSize(0);
                return;
            }

            ChangeSize(value);

        }
    }
    // Use this for initialization
    void Start()
    {
        Vector2 v2 = new Vector2(Image.rect.width, Image.rect.height);

        Image.anchorMax = new Vector2(0, 1);
        Image.anchorMin = new Vector2(0, 1);
        Image.pivot = new Vector2(0, 1);

        Image.sizeDelta = v2;
        Image.anchoredPosition = Vector3.zero;

        v2 = new Vector2(Mask.rect.width, Mask.rect.height);

        Mask.anchorMax = new Vector2(0, 1);
        Mask.anchorMin = new Vector2(0, 1);
        Mask.pivot = new Vector2(0, 1);

        Mask.sizeDelta = v2;
        Mask.anchoredPosition = Vector3.zero;

        orignalSize = Mask.sizeDelta;
    }

    void ChangeSize(float f)
    {
        SetupDirection();
        switch (ScaleDirection)
        {
            case Direction.Vertical_left:
                Mask.sizeDelta = new Vector2(orignalSize.x * f, orignalSize.y);
                break;

            case Direction.Vertical_right:
                Mask.sizeDelta = new Vector2(orignalSize.x * f, orignalSize.y);
                break;

            case Direction.Horizontal_up:
                Mask.sizeDelta = new Vector2(orignalSize.x, orignalSize.y * f);
                break;

            case Direction.Horizontal_down:
                Mask.sizeDelta = new Vector2(orignalSize.x, orignalSize.y * f);
                break;
        }
    }

    void SetupDirection()
    {
        if (_ScaleDirection == ScaleDirection)
            return;

        _ScaleDirection = ScaleDirection;

        switch (ScaleDirection)
        {
            case Direction.Vertical_left:
            case Direction.Horizontal_up:
                Image.anchorMax = new Vector2(0, 1);
                Image.anchorMin = new Vector2(0, 1);
                Image.pivot = new Vector2(0, 1);

                Mask.anchorMax = new Vector2(0, 1);
                Mask.anchorMin = new Vector2(0, 1);
                Mask.pivot = new Vector2(0, 1);
                break;

            case Direction.Vertical_right:
            case Direction.Horizontal_down:
                Image.anchorMax = new Vector2(1, 0);
                Image.anchorMin = new Vector2(1, 0);
                Image.pivot = new Vector2(1, 0);

                Mask.anchorMax = new Vector2(1, 0);
                Mask.anchorMin = new Vector2(1, 0);
                Mask.pivot = new Vector2(1, 0);
                break;
        }
    }
}
