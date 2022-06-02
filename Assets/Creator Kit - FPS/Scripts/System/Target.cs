using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Target : MonoBehaviour
{
    public float health = 5.0f;
    public int pointValue;
    public float speed; //움직일때 기본 속도 
    public float returnspeeds;
    private Animator anim;
    public ParticleSystem DestroyedEffect;

    [Header("Audio")]
    public RandomPlayer HitPlayer;
    public AudioSource IdleSource;
    
    public bool Destroyed => m_Destroyed;

    bool m_Destroyed = false;
    float m_CurrentHealth;

    void Awake()
    {
        Helpers.RecursiveLayerChange(transform, LayerMask.NameToLayer("Target"));
    }

    void Start()
    {
        
        returnspeeds = speed;

        if(DestroyedEffect)
            PoolSystem.Instance.InitPool(DestroyedEffect, 16);
        
        m_CurrentHealth = health;
        if(IdleSource != null)
            IdleSource.time = Random.Range(0.0f, IdleSource.clip.length);

     


    }
    void Update()
    {

        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        //피아노 좀비의 경우 움직이면 에니메이션을 바꿔줌 
        if (speed>0 && transform.GetChild(0).gameObject.name == "piano_zombies")
        {
            anim = transform.GetChild(0).gameObject.GetComponent<Animator>();

            anim.SetBool("isWalking", true);
        }

    }

    void returnSpeed()
    {
        speed = returnspeeds;
    }



    public void Got(float damage)
    {
        m_CurrentHealth -= damage;
        
        if(HitPlayer != null)
            HitPlayer.PlayRandom();
        
        if(m_CurrentHealth > 0)
            return;

        Vector3 position = transform.position;
        
        //the audiosource of the target will get destroyed, so we need to grab a world one and play the clip through it
        if (HitPlayer != null)
        {
            var source = WorldAudioPool.GetWorldSFXSource();
            source.transform.position = position;
            source.pitch = HitPlayer.source.pitch;
            source.PlayOneShot(HitPlayer.GetRandomClip());
        }

        if (DestroyedEffect != null)
        {
            var effect = PoolSystem.Instance.GetInstance<ParticleSystem>(DestroyedEffect);
            effect.time = 0.0f;
            effect.Play();
            effect.transform.position = position;
        }

        m_Destroyed = true;

        //3초 뒤에 본래 속도로 돌아가기 
        Invoke("returnSpeed", 3);


       // gameObject.SetActive(false);
       
        //GameSystem.Instance.TargetDestroyed(pointValue);
    }
}
