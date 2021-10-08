using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Entities {
    public class Mob : MonoBehaviour {

        public float BaseHealth;
    
        private float _health;
        public float Health {
            get => _health;
            set {
                _health = value;
                if (_health <= 0) Destroy(gameObject);
            }
        }

        public static List<Mob> Mobs = new List<Mob>();

        private NavMeshAgent _navMeshAgent;
    
        private void Awake() {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = BaseHealth;
            Mobs.Add(this);
        }

        private void Start() {
            Goal nearestGoal = Goal.Goals.OrderBy(goal => Vector3.Distance(goal.transform.position, transform.position)).FirstOrDefault();
            if (nearestGoal == null) throw new Exception("No Goal found !");
            _navMeshAgent.SetDestination(nearestGoal.transform.position);
        }

        private void OnDestroy() {
            Mobs.Remove(this);
        }
    
    }
}