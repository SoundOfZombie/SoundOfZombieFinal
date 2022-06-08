using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class Target : MonoBehaviour
{
    public float health = 5.0f;
    public int pointValue;
    public float speed; //움직일때 기본 속도 
    public float returnspeeds;
    private Animator anim;
    public ParticleSystem DestroyedEffect;
    public NavMeshAgent navMeshAgent; // 이동제어
    public Transform target; // Player

    [Header("Audio")]
    public RandomPlayer HitPlayer;
    public AudioSource IdleSource;
    Rigidbody rigidbody;
    public bool Destroyed => m_Destroyed;

    bool m_Destroyed = false;
    float m_CurrentHealth;
    public bool StopGetHited = false;
    public bool SlowGetHited = false;


    public void Setup(Transform target)
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //this.target = target;

        navMeshAgent.updateRotation = false;
    }

    void Awake()
    {
        Helpers.RecursiveLayerChange(transform, LayerMask.NameToLayer("Target"));
    }

    void Start()
    {
        //target = GameObject.Find("Player");
        // returnspeeds = speed;

        if (DestroyedEffect)
            PoolSystem.Instance.InitPool(DestroyedEffect, 16);

        m_CurrentHealth = health;
        if (IdleSource != null)
            IdleSource.time = Random.Range(0.0f, IdleSource.clip.length);

        navMeshAgent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();

    }
    void Update()
    {



        navMeshAgent.SetDestination(target.position);
        //navMeshAgent.speed = 3;
        //10이하일때 한번만 체크해서 속도 지정해주고, 계속 총맞았는지 체크해야함
        //거리 계속 체크하는데 한번만 속도 지정해주는거 
        CalculateDistanceToTargetAndSElectState();
        ChangeSpeed();

    }

    //거리가 10일때 한번만 속도를 3으로 지정해줌 
    public void SetSpeedUnderTen()
    {
        if (!StopGetHited && !SlowGetHited) navMeshAgent.speed = 3;
    }



    public void ChangeSpeed()
    {
        //navmeshagent.speed가 0이상일때만 




        if (navMeshAgent.speed > 0)
        {
            if (StopGetHited)
            {

                navMeshAgent.speed = 0;
                // StopGetHited = false;
                Debug.Log("Stopped");

            }
            else if (SlowGetHited)
            {

                Debug.Log("Slowed");
                navMeshAgent.speed = 1.5f;
                // SlowGetHited = false;

            }
            //10초 뒤에 원래 속도로 옴
            Invoke("returnSpeed", 10);

        }



    }
    private void CalculateDistanceToTargetAndSElectState()
    {
        if (target == null) return;

        float distance = Vector3.Distance(target.position, transform.position);

        //가까울때 총 맞으면 속도 느려짐+ 속도 갱신하기가 충돌해서 잘 안먹힘 
        //거리가 10이하일때 한번만 속도 3를 갱신해주어야 함 
        //거리가 매우 가까울때  쫓아올때 총이 잘안됨 
        if (distance == 10) SetSpeedUnderTen();

        if (distance < 10)
        {
            //계속 10이하 - 가까워지면 계속 갱신됨....
            SetSpeedUnderTen();
            ChangeSpeed();

        }
        else
        {
            navMeshAgent.speed = 0;

        }





    }
    //returnSpeed와 총효과와 충돌하는 경우 
    //계속 총을 맞는지 체크해주어야 함 
    //true인것만 바꾸어 주어야함 
    void returnSpeed()
    {
        navMeshAgent.speed = 3;


        ChangeSpeed();
        if (StopGetHited) StopGetHited = false;
        if (SlowGetHited) SlowGetHited = false;
    }



    public void Got(float damage)
    {
        m_CurrentHealth -= damage;

        if (HitPlayer != null)
            HitPlayer.PlayRandom();

        if (m_CurrentHealth > 0)
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
        // Invoke("returnSpeed", 5);


        // gameObject.SetActive(false);

        //GameSystem.Instance.TargetDestroyed(pointValue);
    }
}

