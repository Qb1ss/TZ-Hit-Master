using UnityEngine;
using System.Collections.Generic;

public class Player_SpawnGuns : MonoBehaviour
{
    [Header ("Guns")]
    [SerializeField] private List<Gun> _guns;

    [Header("Parameters")]
    [SerializeField] private Transform _gunSpawnPoint;


    private void Start()
    {
        GameObject newClonedObject = Instantiate(_guns[0].gameObject, _gunSpawnPoint.transform.position, Quaternion.identity);
        newClonedObject.transform.parent = _gunSpawnPoint;
    }
}