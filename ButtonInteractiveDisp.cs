using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractiveDisp : MonoBehaviour
{
    //Button���I�u�W�F�N�g
    [SerializeField] protected Button btnSet = null;
    [SerializeField] Image imgSet = null;
    [SerializeField] TextMeshProUGUI txtSet = null;
    //�萔�F�{�^���w�i�摜�@���摜��Inspector�Őݒ�
    [SerializeField] Sprite sprBackOn = default;
    [SerializeField] Sprite sprBackOff = default;
    //�萔�F�{�^���e�L�X�g�F
    Color clrTextOn = new Color32(0, 0, 0, 255);
    Color clrTextOff = new Color32(255, 255, 255, 255);

    /// <summary>
    /// �I�u�W�F�N�g����Button�R���|�[�l���g���������Đݒ�
    /// </summary>
    protected void FindTransform() => btnSet = btnSet == null ? GetComponent<Button>() : btnSet;
    /// <summary>
    /// Reset�C�x���g��Inspector�̐ݒ肩������s�ł���
    /// </summary>
    private void Reset()
    {
        FindTransform();
        InitDisp();
    }
    /// <summary>
    /// �N�����ɕ\���̏������ƃC�x���g�ݒ���s��
    /// </summary>
    void Start()
    {
        InitDisp();
        //�{�^����interactable�v���p�e�B�̐؂�ւ��C�x���g�ݒ�
        btnSet.ObserveEveryValueChanged(btn => btn.interactable)
        .Subscribe(isOn =>
        {
            UpdateDisp(isOn);
        })
        .AddTo(this);
    }
    /// <summary>
    /// �{�^���\������������
    /// </summary>
    private void InitDisp()
    {
        //Button�R���|�[�l���g�擾�ςݔ���
        if (btnSet == null) { return; }
        //�{�^������Image,Text������΃R���|�[�l���g�擾
        imgSet = (Image)btnSet.targetGraphic;
        txtSet = GetComponentInChildren<TextMeshProUGUI>();
        //�{�^���̊e��Ԃł̐F�����ׂĔ��ɐݒ肷��
        Color defColor = new Color32(255, 255, 255, 255);
        ColorBlock cb = btnSet.colors;
        cb.selectedColor = defColor;
        cb.highlightedColor = defColor;
        cb.disabledColor = defColor;
        cb.selectedColor = defColor;
        cb.pressedColor = defColor;
        btnSet.colors = cb;
        //���݂�interactable�ɍ��킹�ĕ\���ݒ�
        UpdateDisp(btnSet.interactable);
    }
    /// <summary>
    /// �{�^���\���X�V
    /// </summary>
    /// <param name="isOn">interactable�ݒ�</param>
    private void UpdateDisp(bool isOn)
    {
        Sprite sprBack;
        Color clrText;
        string textValue = "";
        //�w�i���e�擾
        if (isOn)
        {
            sprBack = sprBackOn;
            clrText=clrTextOn;
            textValue = "�{�^���F�L��";
        }
        else
        {
            sprBack = sprBackOff;
            clrText = clrTextOff;
            textValue = "�{�^���F����";
        }
        //�w�i�ύX
        if (imgSet != null)
        {
            imgSet.sprite = sprBack;
        }
        //�����ύX
        if (txtSet != null)
        {
            txtSet.color = clrText;
            txtSet.text = textValue;
        }
    }
}