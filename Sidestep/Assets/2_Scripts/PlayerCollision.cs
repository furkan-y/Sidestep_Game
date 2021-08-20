using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

    Level level;
    UI ui;

    public GameObject h_wall_1;

    public TMPro.TextMeshProUGUI stageTMP;
    private int stage = 0;

    public GameObject DiamondSprite;
    private Image DiamondImg;

    ParticleSystem PlayerExpPar;
    SpriteRenderer spriteRenderer;
    TrailRenderer trailRenderer;
    CircleCollider2D circleCollider2D;

    public AudioSource diamondCollectedSound;
    public AudioSource playerCrashSound;
    public AudioClip playerCrashClip;

    void Start()
    {
        level = FindObjectOfType<Level>();
        ui = FindObjectOfType<UI>();
        DiamondImg = DiamondSprite.GetComponent<Image>();
        StartCoroutine(ShowFirstStage());

        PlayerExpPar = gameObject.GetComponent<ParticleSystem>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        trailRenderer = gameObject.GetComponent<TrailRenderer>();
        circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            playerCrashSound.PlayOneShot(playerCrashClip, 0.3f);
            Debug.Log("Kaybettin");
            stageTMP.text = "";
            StartCoroutine(GameOver());

        }
        else if(collision.gameObject.tag == "Diamond")
        {
            diamondCollectedSound.Play();

            if(level.score == 9 || level.score == 19 || level.score == 29 || level.score == 39 || level.score == 49 ||
                level.score == 59 || level.score == 69 || level.score == 79 || level.score == 89 || level.score == 99 ||
                level.score == 109 || level.score == 119 || level.score == 129 || level.score == 139 || level.score == 149 ||
                level.score == 159 || level.score == 169 || level.score == 179 || level.score == 189 || level.score == 199)
            {
                level.IncreaseScore();
                level.IncreaseLevel();
                if(level.score <= 91)
                {
                    StartCoroutine(ShowStage());
                }
            }
            else
            {
                level.IncreaseScore();
                level.TranslateDiamond();
            }
        }
    }

    IEnumerator GameOver()
    {
        PlayerExpPar.Play();
        spriteRenderer.enabled = false;
        trailRenderer.enabled = false;
        circleCollider2D.enabled = false;
        yield return new WaitForSeconds(0.7f);
        ui.GameOver();
    }

    IEnumerator ShowFirstStage()
    {
        stage++;
        ColorChange();
        yield return new WaitForSeconds(3f);
        stageTMP.text = "Stage " + stage.ToString();
        yield return new WaitForSeconds(1.8f);
        stageTMP.text = "";
    }

    IEnumerator ShowStage()
    {
        stage++;
        ColorChange();
        stageTMP.text = "Stage " + stage.ToString();
        yield return new WaitForSeconds(1.8f);
        stageTMP.text = "";
    }

    private void ColorChange()
    {
        if (stage == 1)
        {
            UnityEngine.Color sourceColor1 = new UnityEngine.Color(1, 0.49f, 0, 1);
            UnityEngine.Color32 convertedColor1;
            convertedColor1 = sourceColor1;

            stageTMP.color = convertedColor1;
            DiamondImg.color = convertedColor1;
        }
        else if (stage == 2)
        {
            stageTMP.color = Color.green;
            DiamondImg.color = Color.green;
        }
        else if (stage == 3)
        {
            UnityEngine.Color sourceColor1 = new UnityEngine.Color(1, 0, 0.83f, 1);
            UnityEngine.Color32 convertedColor1;
            convertedColor1 = sourceColor1;

            stageTMP.color = convertedColor1;
            DiamondImg.color = convertedColor1;
        }
        else if (stage == 4)
        {
            UnityEngine.Color sourceColor1 = new UnityEngine.Color(0.39f, 0, 1, 1);
            UnityEngine.Color32 convertedColor1;
            convertedColor1 = sourceColor1;

            stageTMP.color = convertedColor1;
            DiamondImg.color = convertedColor1;
        }
        else if (stage == 5)
        {
            UnityEngine.Color sourceColor1 = new UnityEngine.Color(0, 0.66f, 1, 1);
            UnityEngine.Color32 convertedColor1;
            convertedColor1 = sourceColor1;

            stageTMP.color = convertedColor1;
            DiamondImg.color = convertedColor1;
        }
        else if(stage == 6)
        {
            stageTMP.color = Color.yellow;
            DiamondImg.color = Color.yellow;

        }
        else if (stage == 7)
        {
            stageTMP.color = Color.cyan;
            DiamondImg.color = Color.cyan;
        }
        else if (stage == 8)
        {
            stageTMP.color = Color.blue;
            DiamondImg.color = Color.blue;
        }
        else if (stage == 9)
        {
            UnityEngine.Color sourceColor1 = new UnityEngine.Color(0, 1, 0.57f, 1);
            UnityEngine.Color32 convertedColor1;
            convertedColor1 = sourceColor1;

            stageTMP.color = convertedColor1;
            DiamondImg.color = convertedColor1;
        }
        else if (stage >= 10)
        {
            stageTMP.color = Color.red;
            DiamondImg.color = Color.red;
        }


    }


}
