using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float MaxHealth = 5f;

    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
        currentHealth = MaxHealth;
        agent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        AudioManager.instance.PlayOneShot(AudioManager.instance.zombieDamage);
        if (currentHealth <= 0)
        {
            UIManager.zombieDeath?.Invoke(10);
            Destroy(gameObject);
        }
    }
}
