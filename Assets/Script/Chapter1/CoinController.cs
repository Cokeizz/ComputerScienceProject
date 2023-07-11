using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
   
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField]private BoxCollider2D boxCollider;
    [SerializeField]private LayerMask objectLayer;
    private Animator anim;
 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayer();
    }

     private bool PlayerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center+transform.right*range*transform.localScale.x*colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left,0,objectLayer);

        if(hit.collider != null){
            //Debug.Log("IN DOOR");
        }
            //objectHealth = hit.transform.GetComponent<Health>();
        return hit.collider != null;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center+transform.right*range*transform.localScale.x*colliderDistance, 
       new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * range, boxCollider.bounds.size.z));
    }

    private void CheckPlayer()
    {
            if(PlayerInsight())
            {
                gameObject.SetActive(false);
                Debug.Log("+1 coin"); 
                CoinCounter.instance.IncreaseCoins();
            }
    }

}
