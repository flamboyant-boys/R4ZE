using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace R4ZE.Tests
{
    public class PlayModeTest
    {
        [UnityTest]
        public IEnumerator TestPlayMode_MoveUpBy2()
        {
            var gameObject = new GameObject();
            var playMode = gameObject.AddComponent<PlayMode>();

            playMode.MoveSpeed = 2;
            playMode.Move("UP");

            yield return null;

            Assert.AreEqual(new Vector3(0, 2, 0), gameObject.transform.position);
        }
    }
}
