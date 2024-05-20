using UnityEngine;

namespace Assets.Scripts.Tools
{
    public static class CursorHitHandler
    {
        public static bool Raycast(out RaycastHit hit)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                return true;
            }
        
            return false;
        }

        public static bool RaycastNoTriggers(out RaycastHit hit)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] raycastHits = new RaycastHit[5];
            Physics.RaycastNonAlloc(ray, raycastHits);

            hit = new();
            float distance = 9999f;
            Vector3 cameraPosition = Camera.current.transform.position;

            foreach (var _hit in raycastHits)
            {
                if (_hit.collider != null && !_hit.collider.isTrigger)
                {
                    Vector3 ab = _hit.point - cameraPosition;
                    float length = ab.x * ab.x + ab.y * ab.y;

                    if(length < distance)
                    {
                        hit = _hit;
                        distance = length;
                    }
                }
            }

            if(hit.collider == null)
            {
                return false;
            }

            return true;
        }
    }
}
