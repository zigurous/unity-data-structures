﻿using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// An update strategy executed during the late update loop.
    /// </summary>
    public sealed class LateUpdateStrategy : UpdateStrategy
    {
        private void LateUpdate()
        {
            Execute(Time.deltaTime);
        }

    }

}
