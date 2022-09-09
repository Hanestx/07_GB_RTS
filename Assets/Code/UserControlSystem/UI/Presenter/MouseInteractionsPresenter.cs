using System.Linq;
using UnityEngine;


namespace RTS
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;

        private bool _isSelect;
        private OutlineX _outline;


        private void Update()
        {
            if (!Input.GetMouseButtonUp(0))
                return;

            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));

            if (hits.Length == 0)
                return;

            var selectable = hits
                .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                .FirstOrDefault(c => c != null);

            _selectedObject.SetValue(selectable);
            
            if (_outline != null)
                _outline.enabled = false;
            
            if (selectable != null)
            {
                _outline = hits
                    .Select(hit => hit.collider.GetComponentInParent<OutlineX>())
                    .FirstOrDefault(c => c != null);

                _outline.enabled = true;
            }
        }
    }
}