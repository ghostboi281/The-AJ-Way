using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float Speed = 2f;
    public float ChaseSpeed = 3.5f;
    public float DetectionRange = 5f;
    public float PatrolRange = 8f;
    public Transform[] PatrolPoints;
    
    private int _currentPatrolIndex = 0;
    private Transform _player;
    private enum State { PATROLLING, CHASING, RETURNING }
    private State _currentState = State.PATROLLING;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        switch (_currentState)
        {
            case State.PATROLLING:
                Patrol();
                break;
            case State.CHASING:
                Chase();
                break;
            case State.RETURNING:
                ReturnToPatrol();
                break;
        }
    }
    
    private void Patrol()
    {
        if (PatrolPoints.Length == 0) return;
        
        Transform target = PatrolPoints[_currentPatrolIndex];
        MoveTowards(target.position, Speed);
        
        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % PatrolPoints.Length;
        }
        
        if (Vector2.Distance(transform.position, _player.position) < DetectionRange)
        {
            _currentState = State.CHASING;
        }
    }
    
    private void Chase()
    {
        MoveTowards(_player.position, ChaseSpeed);
        
        if (Vector2.Distance(transform.position, _player.position) > PatrolRange)
        {
            _currentState = State.RETURNING;
        }
    }
    
    private void ReturnToPatrol()
    {
        Transform target = PatrolPoints[_currentPatrolIndex];
        MoveTowards(target.position, Speed);
        
        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            _currentState = State.PATROLLING;
        }
    }
    
    private void MoveTowards(Vector2 target, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}