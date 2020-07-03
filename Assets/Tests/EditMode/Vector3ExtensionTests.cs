using NUnit.Framework;
using R4ZE.Extensions;
using R4ZE.ModularBlock.Enums;
using UnityEngine;

namespace R4ZE.Tests
{
    public class Vector3ExtensionTests
    {
        [Test]
        public void TestConvertToVector3_EDirectionUP_UpVector()
        {
            Vector3 testVector = EDirection.UP.ConvertToVector3();
            Assert.AreEqual(new Vector3(0, 1, 0), testVector);
        }

        [Test]
        public void TestConvertToVector3_EDirectionDOWN_DownVector()
        {
            Vector3 testVector = EDirection.DOWN.ConvertToVector3();
            Assert.AreEqual(new Vector3(0, -1, 0), testVector);
        }

        [Test]
        public void TestConvertToVector3_EDirectionLEFT_LeftVector()
        {
            Vector3 testVector = EDirection.LEFT.ConvertToVector3();
            Assert.AreEqual(new Vector3(-1, 0, 0), testVector);
        }

        [Test]
        public void TestConvertToVector3_EDirectionRIGHT_RightVector()
        {
            Vector3 testVector = EDirection.RIGHT.ConvertToVector3();
            Assert.AreEqual(new Vector3(1, 0, 0), testVector);
        }

        [Test]
        public void TestConvertToVector3_EDirectionFORWARD_ForwardVector()
        {
            Vector3 testVector = EDirection.FORWARD.ConvertToVector3();
            Assert.AreEqual(new Vector3(0, 0, 1), testVector);
        }

        [Test]
        public void TestConvertToVector3_EDirectionBACK_BackVector()
        {
            Vector3 testVector = EDirection.BACK.ConvertToVector3();
            Assert.AreEqual(new Vector3(0, 0, -1), testVector);
        }

        [Test]
        public void TestConvertToVector3_EDirectionNONE_ZeroVector()
        {
            Vector3 testVector = EDirection.NONE.ConvertToVector3();
            Assert.AreEqual(new Vector3(0, 0, 0), testVector);
        }
    }
}
