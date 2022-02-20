using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPoint : MonoBehaviour
{
    [SerializeField] private int _dialogPointNumber;
    [SerializeField] private DialogWindow _dialogWindow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Player>(out Player player);

        if (player)
        {
            _dialogWindow.Open(_dialogPointNumber);
            gameObject.SetActive(false);
        }
    }
}
