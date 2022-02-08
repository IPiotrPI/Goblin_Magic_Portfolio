using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletDecal;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _timeToDestroy;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private ParticleSystem _trail;
    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private void OnEnable()
    {
        Debug.Log("I Was enabled!");
        Destroy(gameObject, _timeToDestroy);
    }


    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.position = Vector3.MoveTowards(transform.position, target,_speed * Time.deltaTime);
        if(!hit && Vector3.Distance(transform.position, target) <0.01)
        {
            Debug.Log("I Hit something!");
            Destroy(gameObject, _timeToDestroy);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ContactPoint contact = collision.GetContact(0);
        // GameObject.Instantiate(_explosion, contact.point + contact.normal * 0.0001f, Quaternion.LookRotation(contact.normal));
        Debug.Log("I Collided!");
        Destroy(this.gameObject);
    }
}
