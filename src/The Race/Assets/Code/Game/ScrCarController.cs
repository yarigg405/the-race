using TheRaceGame.Game;
using UnityEngine;
using Yrr.Utils;


namespace TheRaceGame
{
    internal sealed class ScrCarController : MonoBehaviour
    {
        [SerializeField] private ScrWheel[] _wheels;

        [Header("Car Specs")]
        [SerializeField] private float _wheelBase;
        [SerializeField] private float _rearTrack;
        [SerializeField] private float _turnRadius;

        [Header("Inputs")]
        [ReadOnly]
        [SerializeField] private float _steerInput;

        private float _ackermanAngleLeft;
        private float _ackermanAngleRight;


        private void Update()
        {
            _steerInput = Input.GetAxis("Horizontal");

            if (_steerInput > 0)
            {
                _ackermanAngleLeft = Mathf.Rad2Deg * Mathf.Atan(_wheelBase / (_turnRadius + (_rearTrack / 2))) * _steerInput;
                _ackermanAngleRight = Mathf.Rad2Deg * Mathf.Atan(_wheelBase / (_turnRadius - (_rearTrack / 2))) * _steerInput;
            }

            else if (_steerInput < 0)
            {
                _ackermanAngleLeft = Mathf.Rad2Deg * Mathf.Atan(_wheelBase / (_turnRadius - (_rearTrack / 2))) * _steerInput;
                _ackermanAngleRight = Mathf.Rad2Deg * Mathf.Atan(_wheelBase / (_turnRadius + (_rearTrack / 2))) * _steerInput;
            }

            else
            {
                _ackermanAngleLeft = 0;
                _ackermanAngleRight = 0;
            }

            foreach (var w in _wheels)
            {
                if (w.FrontLeft)
                    w.SteerAngle = _ackermanAngleLeft;

                if (w.FrontRight)
                    w.SteerAngle = _ackermanAngleRight;
            }
        }
    }
}
