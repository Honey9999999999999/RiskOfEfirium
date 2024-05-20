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
                //if (hit.collider.gameObject.TryGetComponent<Enemy>(out _))
                //{
                //    worldPosition = hit.collider.transform.position + new Vector3(0, 1, 0);
                //}
                //else
                //{
                //    worldPosition = hit.point + new Vector3(0, 1, 0);
                //}

                return true;
            }

            //worldPosition = Vector3.zero;            
            return false;
        }
    }
}
