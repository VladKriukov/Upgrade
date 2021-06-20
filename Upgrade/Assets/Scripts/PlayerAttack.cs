using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] Vector3 castOffset;
    [SerializeField] float radius;
    [SerializeField] float damageAmount = -10;
    public LayerMask layerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //castOffset.x += transform.position.x;
            //castOffset.y += transform.position.y;
            //castOffset.z += transform.position.z;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
            if (colliders.Length > 0)
            {
                Debug.Log("hit something");
                foreach (var item in colliders)
                {
                    Debug.Log(item.gameObject.tag);
                    item.gameObject.GetComponent<Enemy>().enemyhealth(damageAmount);
                }
            }
        }
    }
}