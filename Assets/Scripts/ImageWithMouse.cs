using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageWithMouse : Singleton
{
    readonly Vector3 gap = new Vector3(30, 20, 0);
    RectTransform rt;
    Image img;
    

    private void Awake()
    {
        rt = this.transform as RectTransform;
        img = GetComponent<Image>();
        ReleaseImage();
        imgMouse = this;
    }

    private void Update()
    {
        rt.localPosition = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2) + gap;
    }

    public void SetImage()
    {
        img.color = new Color(1, 1, 1, 1);
    }

    public void ReleaseImage()
    {
        img.color = new Color(1, 1, 1, 0);
    }
}
