using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities {
    public class Tower : MonoBehaviour {

        public GameObject FireLinePrefab;
        public float DamageValue;
        public float ReloadTime;
        public float FireRange;

        private float _timeSinceLastShot;
        private Mob _currentTarget;

        private List<Mob> InRangeMobs => Mob.Mobs
            .Where(mob => Vector3.Distance(mob.transform.position, transform.position) < FireRange).ToList();

        private void Update() {
            _timeSinceLastShot += Time.deltaTime;
            if (InRangeMobs.Count == 0 || _timeSinceLastShot < ReloadTime) return;
            if (_currentTarget == null || !InRangeMobs.Contains(_currentTarget)) {
                // We need another target
                _currentTarget = InRangeMobs[Random.Range(0, InRangeMobs.Count - 1)];
            }
            FireOn(_currentTarget);

        }

        private void FireOn(Mob mob) {
            LineRenderer lineRenderer = Instantiate(FireLinePrefab).GetComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(new []{transform.position, _currentTarget.transform.position});
            mob.Health -= DamageValue;
            _timeSinceLastShot = 0;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.92f, 0.016f, 0.2f);
            Gizmos.DrawSphere(transform.position, FireRange);
        }
    
    }
}