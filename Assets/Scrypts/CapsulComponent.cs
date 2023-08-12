using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TechDesignTestProject 
{
    public class CapsulComponent : MonoBehaviour, IPointerClickHandler
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.SetTrigger("start_trigger");
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            _animator.SetTrigger("start_trigger");
        }
    }
}

