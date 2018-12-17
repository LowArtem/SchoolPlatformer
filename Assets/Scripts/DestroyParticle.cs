using System.Collections;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {
    
    void Start()
    {
        StartCoroutine(Particle());
    }

    IEnumerator Particle()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
