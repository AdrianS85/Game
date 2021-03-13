using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SpawnObjectImageAtCoursor : object
{
    public static GameObject Spawn(Sprite sprite_, GameObject canvas_, Vector3 scale_)
    {
        GameObject objectImage;
        objectImage = new GameObject("image_", typeof(Image));
        objectImage.GetComponent<Image>().sprite = sprite_;
        objectImage.transform.SetParent(canvas_.transform);
        objectImage.GetComponent<RectTransform>().localScale = scale_;
        objectImage.transform.position = Input.mousePosition;

        return objectImage;
    }
}
