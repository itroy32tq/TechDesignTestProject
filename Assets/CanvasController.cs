using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TechDesignTestProject
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private TMP_Text _text;
        [SerializeField]
        private Animator _animator;

        private void Update()
        {
            float value = _gameManager.TrackerBot();
            if (value < 180) _animator.SetTrigger("FontSize");
            else _animator.ResetTrigger("FontSize");
            _text.text = value.ToString();
       
        }
    }
}

