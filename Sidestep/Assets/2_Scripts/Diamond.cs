using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    Level level;

    ParticleSystem DiaExpPar;
    SpriteRenderer DiaSpriteRenderer;
    public AudioSource diamondCrushSource;

    void Start()
    {
        level = FindObjectOfType<Level>();

        DiaExpPar = gameObject.GetComponent<ParticleSystem>();
        DiaSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {

            if(DiaExpPar.isPlaying == false)
            {
                diamondCrushSource.Play();
                DiaExpPar.Play();
                level.TranslateDiamond();
            }
        }
    }

}
