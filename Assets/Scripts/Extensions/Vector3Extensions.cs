using R4ZE.ModularBlock.Enums;
using UnityEngine;

namespace R4ZE.Extensions
{
    public static class Vector3Extensions
    {
        public static EDirection ConvertToEDirection(this Vector3 vector3)
        {
            switch (vector3.normalized)
            {
                case Vector3 v when v == Vector3.up:        return EDirection.UP;
                case Vector3 v when v == Vector3.down:      return EDirection.DOWN;
                case Vector3 v when v == Vector3.left:      return EDirection.LEFT;
                case Vector3 v when v == Vector3.right:     return EDirection.RIGHT;
                case Vector3 v when v == Vector3.forward:   return EDirection.FORWARD;
                case Vector3 v when v == Vector3.back:      return EDirection.BACK;
                default:                                    return EDirection.NONE;
            }
        }
    }
}
