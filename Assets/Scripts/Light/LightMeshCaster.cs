using UnityEngine;

namespace Light
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class LightMeshCaster : MonoBehaviour
    {
        [SerializeField] private int _rayCount = 360;
        private LightSource _lightSource;
        private int _wallLayer;
        private MeshFilter _meshFilter;

        private void Awake()
        {
            _lightSource = GetComponentInParent<LightSource>();
            _meshFilter = GetComponent<MeshFilter>();
            _wallLayer = LayerMask.GetMask("Shadow");
        }

        private void Update()
        {
            // Get max distance.
//            var maxDistance = _lightSource.GetMaxLightRadius();
            var maxDistance = 5f;
            // Get the points for the mesh.
            var vertices = new Vector3[_rayCount + 1];
            vertices[0] = Vector3.zero;
            for (var i = 1; i <= _rayCount; i++)
            {
                var angle = (float)i / _rayCount * 360f * Mathf.Deg2Rad;
                var rayDirection = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);
                var hit = Physics2D.Raycast(transform.position, rayDirection, maxDistance, _wallLayer);
                Vector2 targetPoint;
                if (hit.collider)
                {
                    var position = transform.position;
                    targetPoint = hit.point - new Vector2(position.x, position.y);
                }
                else
                {
                    targetPoint = rayDirection * maxDistance;
                }
                vertices[i] = targetPoint;
            }
            // Get the triangles.
            var triangles = new int[_rayCount * 3];
            for (var i = 0; i < _rayCount; i++)
            {
                var index = i * 3;
                triangles[index] = 0;
                triangles[index + 1] = i + 1;
                triangles[index + 2] = i + 1 == _rayCount ? 1 : i + 2;
            }
            // Create the new mesh.
            var mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            _meshFilter.mesh = mesh;
        }
    }
}
