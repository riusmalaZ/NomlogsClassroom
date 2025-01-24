using UnityEngine;

public class BulletLife : MonoBehaviour
{
    public float TimeAfterFirstHitBeforeFreeze;

    private float _timerAfterHit;
    private bool _hasHit;
    private bool _waitToFreeze;
    private bool _isFrozen;

    void Update()
    {
        _timerBeforeFreeze();
    }

    void _timerBeforeFreeze(){
        if(_hasHit && !_isFrozen){
            _timerAfterHit+= Time.deltaTime;
            if(_timerAfterHit >= TimeAfterFirstHitBeforeFreeze){
                _waitToFreeze = true;
            }   
        }
    }

    void _freeze(){
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        GetComponent<SphereCollider>().enabled = false;
        _isFrozen = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        _hasHit = true;
        if(_waitToFreeze && collision.gameObject.CompareTag("Sol"))
            _freeze();

        Debug.Log("Bullet hit gumsssss");

        if (collision.gameObject.tag == "Gum")
        {
            Debug.Log("Bullet hit gum");
            collision.gameObject.GetComponent<BubbleGumGenerator>().ResetScale();
            Destroy(gameObject);
        }
    }
}
