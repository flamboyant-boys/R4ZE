using NUnit.Framework;
using R4ZE.Extensions;
using R4ZE.ModularBlock.Enums;
using UnityEngine;

namespace R4ZE.Tests
{
    public class EnumExtensionTests
    {
        [Test]
        public void TestConvertToVector3_UpVector_EDirectionUP()
        {
            EDirection testDirection = new Vector3(0, 1, 0).ConvertToEDirection();
            Assert.AreEqual(EDirection.UP, testDirection);
        }

        [Test]
        public void TestConvertToVector3_DownVector_EDirectionDOWN()
        {
            EDirection testDirection = new Vector3(0, -1, 0).ConvertToEDirection();
            Assert.AreEqual(EDirection.DOWN, testDirection);
        }

        [Test]
        public void TestConvertToVector3_LeftVector_EDirectionLEFT()
        {
            EDirection testDirection = new Vector3(-1, 0, 0).ConvertToEDirection();
            Assert.AreEqual(EDirection.LEFT, testDirection);
        }

        [Test]
        public void TestConvertToVector3_RightVector_EDirectionRIGHT()
        {
            EDirection testDirection = new Vector3(1, 0, 0).ConvertToEDirection();
            Assert.AreEqual(EDirection.RIGHT, testDirection);
        }

        [Test]
        public void TestConvertToVector3_ForwardVector_EDirectionFORWARD()
        {
            EDirection testDirection = new Vector3(0, 0, 1).ConvertToEDirection();
            Assert.AreEqual(EDirection.FORWARD, testDirection);
        }

        [Test]
        public void TestConvertToVector3_BackVector_EDirectionBACK()
        {
            EDirection testDirection = new Vector3(0, 0, -1).ConvertToEDirection();
            Assert.AreEqual(EDirection.BACK, testDirection);
        }

        [Test]
        public void TestConvertToVector3_ZeroVector_EDirectionNONE()
        {
            EDirection testDirection = new Vector3(0, 0, 0).ConvertToEDirection();
            Assert.AreEqual(EDirection.NONE, testDirection);
        }

        [Test]
        public void TestConvertToVector3_Normalization()
        {
            EDirection testDirection1 = new Vector3(15, 0, 0).ConvertToEDirection();
            EDirection testDirection2 = new Vector3(0, 15, 0).ConvertToEDirection();
            EDirection testDirection3 = new Vector3(0, 0, 15).ConvertToEDirection();
            EDirection testDirection4 = new Vector3(-15, 0, 0).ConvertToEDirection();
            EDirection testDirection5 = new Vector3(0, -15, 0).ConvertToEDirection();
            EDirection testDirection6 = new Vector3(0, 0, -15).ConvertToEDirection();

            Assert.AreEqual(EDirection.RIGHT, testDirection1);
            Assert.AreEqual(EDirection.UP, testDirection2);
            Assert.AreEqual(EDirection.FORWARD, testDirection3);
            Assert.AreEqual(EDirection.LEFT, testDirection4);
            Assert.AreEqual(EDirection.DOWN, testDirection5);
            Assert.AreEqual(EDirection.BACK, testDirection6);
        }
    }
}
