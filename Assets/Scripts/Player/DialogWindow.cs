using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogWindow : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] TMP_Text _dialog;
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] ControllerHud _controllerHud;

    private const string _speak = "Speak";
    private const string _startDialog = "������� �������, �� �������� ������� SOS �������, ����� ��������� � ����.";
    private const string _lokingEnemyDialog = "���, ��� ������ ������������� ������� �����, ���� �������� ������ ���, " +
        "������� ����� �������� ����.";
    private const string _weaponPickUpDialig = "� ��� � �������� �������. ��, ��������� ������� � �����, " +
        "����� ������ ���� ������ � �������� ������, �� ��� ���� ����� ��������� ����� ������ ���� ����������";
    private const string _lokingGolemDialog = "��� ���, ������ �� �����-�� ��������, ������ �� ��� ���� � ������������ ����������, " +
        "������ ������ �� ��� �� �����, ����� ������� �� �����.";
    private const string _enemyDefeatedDialog = "������� �� ������ ������ ���������, ������� ��� �������� �����, ������ ����� ������� ��������," +
        "���� � ��� ����������, � ��� ��� ��� �������� � ������...";

    private List<string> _dialogs = new List<string>(5);

    private void Start()
    {
        _dialogs.Add(_startDialog);
        _dialogs.Add(_lokingEnemyDialog);
        _dialogs.Add(_weaponPickUpDialig);
        _dialogs.Add(_lokingGolemDialog);
        _dialogs.Add(_enemyDefeatedDialog);
    }

    public void Open(int dialogNumber)
    {
        _controllerHud.Close();
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _animator.SetTrigger(_speak);
        _dialog.text = _dialogs[dialogNumber];
    }

    public void Close()
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0;
        _controllerHud.Open();
    }
}
