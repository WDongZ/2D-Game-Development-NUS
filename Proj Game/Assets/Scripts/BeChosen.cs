

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage; // 按钮的 Image 组件
    public Sprite normalSprite; // 默认图像
    public Sprite hoverSprite; // 鼠标悬停时的图像
    private Vector3 originalPosition; // 原始位置
    private Vector3 hoverPosition; // 悬停位置

    void Start()
    {
        
        originalPosition = buttonImage.transform.localPosition;
        hoverPosition = originalPosition + new Vector3(0, 1f, 0); 
    }

    // 当鼠标进入按钮区域时触发
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite; // 更换图像
        buttonImage.transform.localPosition = hoverPosition; // 移动位置
    }

    // 当鼠标离开按钮区域时触发
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // 恢复原始图像
        buttonImage.transform.localPosition = originalPosition; // 恢复原始位置
    }
}
