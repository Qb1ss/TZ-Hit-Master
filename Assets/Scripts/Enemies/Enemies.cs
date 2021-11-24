using UnityEngine;
using UnityEngine.EventSystems;

public class Enemies : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform _targetPosition;


    public void OnPointerClick(PointerEventData eventData)
    {
        var gun = GameObject.FindObjectOfType<Gun>();

        gun.OnClickToShoot();

        var bulletProjectile = GameObject.FindObjectOfType<Bullet>();

        bulletProjectile.TargetBulletPosition = _targetPosition.position;
    }
}