using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header ("Camera Parameters")]
    [SerializeField] private float _cameraSmooth = 5f;
    
    [SerializeField] private Vector3 _cameraOffset = new Vector3(0, 2, -5);

    private Player_Movement _player_Movement;


    private void Start()
    {
        _player_Movement = GameObject.FindObjectOfType<Player_Movement>();
    }


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player_Movement.transform.position + _cameraOffset, Time.deltaTime * _cameraSmooth);
    }
}