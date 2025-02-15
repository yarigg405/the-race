using UnityEngine;


namespace TheRaceGame.Game
{
    internal sealed class ScrWheel : MonoBehaviour
    {
        [Header("Suspension")]
        [SerializeField] private float _restLenght;
        [SerializeField] private float _springTravel;
        [SerializeField] private float _springStiffness;
        [SerializeField] private float _damperStiffness;

        private Rigidbody _rb;

        private float _minLenght;
        private float _maxLenght;
        private float _lastLenght;
        private float _springLenght;
        private float _springVelocity;
        private float _springForce;
        private float _damperForce;
        private Vector3 _suspensionForce;

        [Header("Wheel")]
        [SerializeField] private float _wheelRadius;
        

        private void Start()
        {
            _rb = transform.root.GetComponent<Rigidbody>();

            _minLenght = _restLenght - _springTravel;
            _maxLenght = _restLenght + _springTravel;
        }

        private void FixedUpdate()
        {
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, _maxLenght + _wheelRadius))
            {
                _lastLenght = _springLenght;
                _springLenght = hit.distance - _wheelRadius;
                _springLenght = Mathf.Clamp(_springLenght,_minLenght, _maxLenght);
                _springVelocity = (_lastLenght - _springLenght) / Time.fixedDeltaTime;
                _springForce = _springStiffness * (_restLenght - _springLenght);
                _damperForce = _damperStiffness * _springVelocity;

                _suspensionForce = (_springForce +_damperForce) * transform.up;

                _rb.AddForceAtPosition(_suspensionForce, hit.point);
            }
        }

    }
}
