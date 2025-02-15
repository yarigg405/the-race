using UnityEngine;


namespace TheRaceGame.Game
{
    internal sealed class ScrWheel : MonoBehaviour
    {
        public bool FrontLeft;
        public bool FrontRight;
        public bool RearLeft;
        public bool RearRight;

        [Header("Suspension")]
        [SerializeField] private float _restLenght;
        [SerializeField] private float _springTravel;
        [SerializeField] private float _springStiffness;
        [SerializeField] private float _damperStiffness;

        private float _minLenght;
        private float _maxLenght;
        private float _lastLenght;
        private float _springLenght;
        private float _springVelocity;
        private float _springForce;
        private float _damperForce;


        [Header("Wheel")]
        [SerializeField] private float _wheelRadius;
        [SerializeField] private float _steerTime;

        private Rigidbody _rb;
        private Vector3 _suspensionForce;
        private float _wheelAngle;

        public float SteerAngle { get; set; }

        private void Start()
        {
            _rb = transform.root.GetComponent<Rigidbody>();

            _minLenght = _restLenght - _springTravel;
            _maxLenght = _restLenght + _springTravel;
        }

        private void Update()
        {
            _wheelAngle = Mathf.Lerp(_wheelAngle, SteerAngle, _steerTime * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(Vector3.up * _wheelAngle);
        }

        private void FixedUpdate()
        {
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, _maxLenght + _wheelRadius))
            {
                _lastLenght = _springLenght;
                _springLenght = hit.distance - _wheelRadius;
                _springLenght = Mathf.Clamp(_springLenght, _minLenght, _maxLenght);
                _springVelocity = (_lastLenght - _springLenght) / Time.fixedDeltaTime;
                _springForce = _springStiffness * (_restLenght - _springLenght);
                _damperForce = _damperStiffness * _springVelocity;

                _suspensionForce = (_springForce + _damperForce) * transform.up;

                _rb.AddForceAtPosition(_suspensionForce, hit.point);
            }
        }

    }
}
