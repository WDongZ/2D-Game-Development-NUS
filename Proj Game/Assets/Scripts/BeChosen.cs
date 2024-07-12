

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage; // ��ť�� Image ���
    public Sprite normalSprite; // Ĭ��ͼ��
    public Sprite hoverSprite; // �����ͣʱ��ͼ��
    private Vector3 originalPosition; // ԭʼλ��
    private Vector3 hoverPosition; // ��ͣλ��

    void Start()
    {
        
        originalPosition = buttonImage.transform.localPosition;
        hoverPosition = originalPosition + new Vector3(0, 1f, 0); 
    }

    // �������밴ť����ʱ����
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite; // ����ͼ��
        buttonImage.transform.localPosition = hoverPosition; // �ƶ�λ��
    }

    // ������뿪��ť����ʱ����
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // �ָ�ԭʼͼ��
        buttonImage.transform.localPosition = originalPosition; // �ָ�ԭʼλ��
    }
}
