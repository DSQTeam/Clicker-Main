using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ParticleSystems;

    public void ActivateParticleSystem(int location) {
        for (int i = 0; i < ParticleSystems.Length; i++) {
            if (location == i) {
                ParticleSystems[i].SetActive(true);
            } else {
                ParticleSystems[i].SetActive(false);
            }
        }
    }
}
