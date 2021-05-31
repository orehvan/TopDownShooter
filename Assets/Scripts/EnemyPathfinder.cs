using Pathfinding;
using UnityEngine;

public class EnemyPathfinder : MonoBehaviour
{
        public Transform target;
        public float moveSpeed = 20;
        public float nextWayPointDistance = 3f;
    
        private Path path;
        private int currentWaypoint;
        private bool reachedTheEnd;
        private Seeker seeker;
        private Rigidbody2D rb;
    
    
        private void Start()
        {
            seeker = GetComponent<Seeker>();
            rb = GetComponent<Rigidbody2D>();
            
            InvokeRepeating(nameof(UpdatePath), 0f, 0.5f);
        }
    
        private void UpdatePath()
        {
            if (seeker.IsDone())
                seeker.StartPath(rb.position, target.position, OnPathEnd);
        }

        private void FixedUpdate()
        {
            if (path == null)
                return;
    
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedTheEnd = true;
                return;
            }
            reachedTheEnd = false;
    
            var direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            var force = direction * moveSpeed * Time.deltaTime;
            rb.AddForce(force);
    
            var distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
            if (distance < nextWayPointDistance)
                currentWaypoint++;
        }
    
        private void OnPathEnd(Path p)
        {
            if (p.error)
                return;
            path = p;
            currentWaypoint = 0;
        }
}