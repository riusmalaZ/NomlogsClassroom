using UnityEngine;

public class BulletLife : MonoBehaviour
{
    public float TimeAfterFirstHitBeforeFreeze;

    public bool IsLethal;
    private float _timerAfterHit;
    private bool _hasHit;
    private bool _waitToFreeze;
    private bool _isFrozen;
    public float DistanceForLethal;

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


        if (collision.gameObject.tag == "Gum" && collision.gameObject.GetComponentInParent<Student>().isBubbling)
        {
            collision.gameObject.GetComponentInParent<Student>().Pop(IsLethal);
            Destroy(gameObject);
        }
        else if (IsLethal)
        {
            foreach (Student student in GameEvents.Students)
            {
                student.CheckIfInArea(transform.position, DistanceForLethal);
            }
        }
    }
}
