using UnityEngine;

public class PlayerTrecker : MonoBehaviour
{
    [SerializeField] private Transform _player;
 
    private void Update()
    {
        transform.position = new Vector3(_player.position.x,
            Mathf.Lerp(transform.position.y, _player.position.y, Time.deltaTime), transform.position.z);
    }
}
