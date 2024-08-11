using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum InteractType
{
    None = 0,
    Click = 1,
    Switch = 2,
}

public class InteractiveObject : Singleton, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int sfxNum = 0;
    public int spriteNum = 0;
    public InteractType type;
    public bool isOn = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        imgMouse.SetImage();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imgMouse.ReleaseImage();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (type)
        {
            case InteractType.None:
                break;
            case InteractType.Click:
                OnClick();
                break;
            case InteractType.Switch:
                OnSwitch();
                break;
        }
    }

    public virtual void OnClick() { }
    public virtual void OnSwitch() { }
}
