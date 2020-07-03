using R4ZE.ModularBlock.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace R4ZE.Extensions
{
    public static class EnumExtensions
    {
        public static Vector3 ConvertToVector3(this EDirection direction)
        {
            switch(direction)
            {
                case EDirection.UP:         return Vector3.up;
                case EDirection.DOWN:       return Vector3.down;
                case EDirection.LEFT:       return Vector3.left;
                case EDirection.RIGHT:      return Vector3.right;
                case EDirection.FORWARD:    return Vector3.forward;
                case EDirection.BACK:       return Vector3.back;
                default:                    return Vector3.zero;
            }
        }
    }
}
