using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (Rigidbody))]
public class Player_Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 5;

    [HideInInspector] public int _currentPoint;
    [Space(height: 5f)]

    [SerializeField] private Transform[] _waitPoints;

    [HideInInspector] public bool IsMoving = false;

    [Header("UI")]
    [SerializeField] private Button _goNextPointButton;
    [Space (height: 10f)]

    [SerializeField] private Animator _animator;
    private NavMeshAgent _meshAgent;
    private Gun _gun;

    
    private void Start()
    {
        _meshAgent = GetComponent<NavMeshAgent>();
        _gun = GameObject.FindObjectOfType<Gun>();

        _goNextPointButton.onClick.AddListener(() => IsMoving = true);

        _meshAgent.speed = _moveSpeed;

        transform.position = _waitPoints[_currentPoint].position;
    }


    private void Update()
    {
        Movement();
    }


    private void Movement()
    {
        if (IsMoving == true)
        {
            if (_currentPoint < _waitPoints.Length - 2)
            {
                _meshAgent.SetDestination(_waitPoints[_currentPoint + 1].position);

                _animator.SetBool("isWalking", true);

                _gun.IsShooting = false;
                
                _goNextPointButton.gameObject.SetActive(false);

                if (transform.position.z >= _waitPoints[_currentPoint + 1].position.z - 1)
                {
                    _animator.SetBool("isWalking", false);

                    _gun.IsShooting = true;
                    IsMoving = false;

                    _currentPoint++;
                }
            }
            else if (_currentPoint >= _waitPoints.Length - 2)
            {
                _meshAgent.SetDestination(_waitPoints[_currentPoint + 1].position);

                _animator.SetBool("isWalking", true);

                _goNextPointButton.gameObject.SetActive(false);

                if (transform.position.z >= _waitPoints[_currentPoint + 1].position.z - 1)
                {
                    _animator.SetBool("isWalking", false);

                    //==��������� ������==//
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}