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

    private List<string> _dialogs = new List<string>(5);

    private const string Speak = "Speak";
    private const string StartDialog = "������� �������, �� �������� ������� SOS �������, ����� ��������� � ����.";
    private const string LokingEnemyDialog = "���, ��� ������ ������������� ������� �����, ���� �������� ������ ���, " +
        "������� ����� �������� ����.";
    private const string WeaponPickUpDialog = "� ��� � �������� �������. ��, ��������� ������� � �����, " +
        "����� ������ ���� ������ � �������� ������, �� ��� ���� ����� ��������� ����� ������ ���� ����������";
    private const string LokingGolemDialog = "��� ���, ������ �� �����-�� ��������, ������ �� ��� ���� � ������������ ����������, " +
        "������ ������ �� ��� �� �����, ����� ������� �� �����.";
    private const string EnemyDefeatedDialog = "������� �� ������ ������ ���������, ������� ��� �������� �����, ������ ����� ������� ��������," +
        "���� � ��� ����������, � ��� ��� ��� �������� � ������...";

    private void Start()
    {
        _dialogs.Add(StartDialog);
        _dialogs.Add(LokingEnemyDialog);
        _dialogs.Add(WeaponPickUpDialog);
        _dialogs.Add(LokingGolemDialog);
        _dialogs.Add(EnemyDefeatedDialog);
    }

    public void Open(int dialogNumber)
    {
        _controllerHud.Close();
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _animator.SetTrigger(Speak);
        _dialog.text = _dialogs[dialogNumber];
    }

    public void Close()
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0;
        _controllerHud.Open();
    }
}
