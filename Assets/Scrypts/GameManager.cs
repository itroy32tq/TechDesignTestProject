using System.Collections;
using UnityEngine;

namespace TechDesignTestProject
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        BotComponent _bot;
        [SerializeField]
        Transform _startPoint;
        [SerializeField]
        Transform _endPoint;
        [SerializeField]
        float _speedBot;

        private bool _moveflag = true;
        public bool Moveflag { get => _moveflag; set => _moveflag = value; }


        private void Start()
        {
            StartCoroutine(MoveCorotine());       
        }

        private IEnumerator MoveCorotine()
        {
            while (true)
            {
                Vector3 desVelocity = _endPoint.position - _bot.transform.position;
                
                float sqrMagnitude = desVelocity.sqrMagnitude;

                if (sqrMagnitude <= 1) 
                {
                    (_endPoint, _startPoint) = (_startPoint, _endPoint);
                    _bot.transform.LookAt(_endPoint);
                    yield return null;
                    continue;
                }

                desVelocity = desVelocity.normalized;

                _bot.SetVelocity(desVelocity*_speedBot, BotComponent.IgnoreAxisType.None);

                yield return null;
            }
        }

        public float TrackerBot()
        {
            return Mathf.Round((_endPoint.position - _bot.transform.position).sqrMagnitude);    
        }


    }

}

