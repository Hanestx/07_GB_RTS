using UnityEngine;


namespace RTS
{
    public class OutlineSelectorPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;

        private ISelectable _currentSelectable;
        private OutlineX[] _outlineSelectors;


        private void Start()
        {
            _selectable.OnSelected += onSelected;
            onSelected(_selectable.CurrentValue);
        }

        private void onSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
                return;

            _currentSelectable = selectable;
            SetSelected(_outlineSelectors, false);
            _outlineSelectors = null;

            if (selectable != null)
                _outlineSelectors = (selectable as Component).GetComponentsInParent<OutlineX>();

            SetSelected(_outlineSelectors, true);
        }

        private void SetSelected(OutlineX[] selectors, bool value)
        {
            if (selectors != null)
            {
                for (int i = 0; i < selectors.Length; i++)
                    selectors[i].enabled = value;
            }
        }
    }
}