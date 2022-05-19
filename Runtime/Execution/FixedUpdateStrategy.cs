using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// An update strategy executed during the fixed update loop.
    /// </summary>
    public sealed class FixedUpdateStrategy : UpdateStrategy
    {
        private void FixedUpdate()
        {
            Execute(Time.fixedDeltaTime);
        }

    }

}
