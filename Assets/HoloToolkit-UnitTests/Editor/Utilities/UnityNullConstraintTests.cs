﻿using NUnit.Framework;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace HoloToolkit.Unity.Tests
{
    public class UnityNullConstraintTests
    {
        [Test]
        public void TestObjectUnityNullConstraint()
        {
            var obj = CreateDestroyedObject();
            var constraint = new UnityNullConstraint();
            Assert.That(constraint.ApplyTo(obj).IsSuccess, Is.True);
        }

        [Test]
        public void TestObjectUsingUnityIsDirect()
        {
            var obj = CreateDestroyedObject();
            Assert.That(obj, Is.UnityNull);
        }

        [Test]
        public void TestNotUnityNull()
        {
            Assert.That(new GameObject(), Is.Not.UnityNull());
        }

        [Test]
        public void TestChainedCompare()
        {
            var obj = CreateDestroyedObject();
            Assert.That(obj, Is.UnityNull.And.Not.Null);
        }

        [Test]
        public void TestCompareAgainstNormalNullConstraint()
        {
            var obj = CreateDestroyedObject();
            var result1 = new UnityNullConstraint().ApplyTo(obj).IsSuccess;
            var result2 = new NullConstraint().ApplyTo(obj).IsSuccess;
            Assert.That(result1, Is.Not.EqualTo(result2));
        }

        [Test]
        public void TestTransformUnityNullConstraint()
        {
            var transform = new GameObject().transform;
            Object.DestroyImmediate(transform.gameObject);
            Assert.That(transform, Is.UnityNull);
        }

        private static GameObject CreateDestroyedObject()
        {
            var gameObject = new GameObject();
            Object.DestroyImmediate(gameObject);
            return gameObject;
        }
    }
}
