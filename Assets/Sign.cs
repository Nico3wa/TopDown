using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
   // [Header("UI")]
   // [SerializeField] Transform _canva;
     [SerializeField] TextMeshProUGUI _RenderTEXT;
    [SerializeField] InputActionReference _interaction;
    // [SerializeField] Text _text;
    [SerializeField] GameObject dialogueBox;
       public  bool _playerHere;
    [SerializeField, Multiline] string dialoguehere;

    private void Start()
    {
        _interaction.action.started += StarAction;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _playerHere = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _playerHere = false;
            dialogueBox.SetActive(false);
            _RenderTEXT.text = "";
        }

    }

    private void StarAction(InputAction.CallbackContext obj)
    {
        if (_playerHere == true)
        {
            dialogueBox.SetActive(true);
            _RenderTEXT.text = dialoguehere;
        }
    }
}


