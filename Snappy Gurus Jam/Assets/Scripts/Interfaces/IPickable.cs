using UnityEngine;

namespace Interfaces
{
    public interface IPickable
    {
        Transform Transform { get; set; }
        void Pick();
    }
}
