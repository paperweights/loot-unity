using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Generation
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Direction _requiredDirection;
        private MapGenerator _mapGenerator;
        private bool _hasSpawned;

        private void Awake()
        {
            _mapGenerator = transform.GetComponentInParent<MapGenerator>();
        }

        private void Start()
        {
            var results = new List<Collider2D>();
            Physics2D.OverlapCollider(_collider, new ContactFilter2D(), results);
            if (results.Count > 0) return;
            Invoke(nameof(SpawnRoom), 1f);
        }

        private void SpawnRoom()
        {
            if (_hasSpawned) return;
            // Spawn a room based on the direction.
            GameObject[] roomsPrefabs;
            switch (_requiredDirection)
            {
                case Direction.Up:
                    roomsPrefabs = _mapGenerator.GetTemplate().GetTopRooms();
                    break;
                case Direction.Down:
                    roomsPrefabs = _mapGenerator.GetTemplate().GetBottomRooms();
                    break;
                case Direction.Left:
                    roomsPrefabs = _mapGenerator.GetTemplate().GetLeftRooms();
                    break;
                case Direction.Right:
                    roomsPrefabs = _mapGenerator.GetTemplate().GetRightRooms();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var randomRoomIndex = Random.Range(0, roomsPrefabs.Length);
            var randomRoom = roomsPrefabs[randomRoomIndex];
            var t = transform;
            Instantiate(randomRoom, t.position, Quaternion.identity, t);
            _hasSpawned = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Spawn Point") && other.GetComponent<SpawnPoint>().HasSpawned())
            {
                Destroy(gameObject);
            }
        }

        public bool HasSpawned()
        {
            return _hasSpawned;
        }
    }
}