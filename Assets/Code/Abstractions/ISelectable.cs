using UnityEngine;


namespace RTS
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
    }
}