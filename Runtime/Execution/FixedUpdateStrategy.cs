using UnityEngine;

namespace Zigurous.DataStructures.Execution
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
