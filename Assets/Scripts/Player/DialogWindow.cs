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
    private const string _startDialog = "∆естка€ посадка, но источник сигнала SOS впереди, нужно следовать к нему.";
    private const string _lokingEnemyDialog = "¬оу, это видимо представители местной фауны, пока никакого оружи€ нет, " +
        "пожалуй лучше избегать драк.";
    private const string _weaponPickUpDialig = "ј вот и источник сигнала. ’м, фотоновые бластер и посох, " +
        "такое оружие есть только у научного отдела, на ѕƒј есть точка назначен€ нужно узнать цель экспедиции";
    private const string _lokingGolemDialog = "Ёто что, похоже на какой-то механизм, видимо за ним сюда и направл€лась экспедици€, " +
        "правда никого из них не видно, нужно подойти по ближе.";
    private const string _enemyDefeatedDialog = "Ќикогда не видела ничего подобного, планета без разумной жизни, откуда столь сложный механизм," +
        "есть о чем задуматьм€, а что это там светитс€ в далеке...";

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
