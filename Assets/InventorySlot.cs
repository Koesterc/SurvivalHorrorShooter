using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour {
    public void Scale(int size)
    {
        RectTransform rt = GetComponent(typeof(RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2(size, size);
        foreach (Transform t in transform)
        {
            rt = t.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(size-5, size-5);
        }
    }
}
