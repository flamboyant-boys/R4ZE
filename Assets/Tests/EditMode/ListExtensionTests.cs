using NUnit.Framework;
using NUnit.Framework.Internal;
using R4ZE.Extensions;
using System;
using System.Collections.Generic;

namespace R4ZE.Tests
{
    public class ListExtensionTests
    {
        [Test]
        public void TestAddIfNotExists_AddNewEntryToList_ListWithNewEntry()
        {
            List<int> testList = new List<int>() { 1, 2, 3 };
            testList.AddIfNotExists(4);

            Assert.AreEqual(4, testList.Count);
            Assert.AreEqual(new List<int>() { 1, 2, 3, 4 }, testList);
        }

        [Test]
        public void TestAddIfNotExists_AddExistingEntryToList_ListWithoutNewEntry()
        {
            List<int> testList = new List<int>() { 1, 2, 3};
            testList.AddIfNotExists(3);

            Assert.AreEqual(3, testList.Count);
            Assert.AreEqual(new List<int>() { 1, 2, 3 }, testList);
        }

        [Test]
        public void TestUpdateValue_UpdateExistingEntry_UpdatedList()
        {
            List<int> testList = new List<int>() { 1, 2, 3 };
            testList.UpdateValue(2, 4);

            Assert.AreEqual(3, testList.Count);
            Assert.AreEqual(new List<int>() { 1, 4, 3 }, testList);
        }

        [Test]
        public void TestDeleteIfExists_DeleteExistingEntry_ShortenedList()
        {
            List<int> testList = new List<int>() { 1, 2, 3 };
            testList.DeleteIfExists(3);

            Assert.AreEqual(2, testList.Count);
            Assert.AreEqual(new List<int>() { 1, 2 }, testList);
        }

        [Test]
        public void TestDeleteIfExists_DeleteNonExistingEntry_OriginalList()
        {
            List<int> testList = new List<int>() { 1, 2, 3 };
            testList.DeleteIfExists(4);

            Assert.AreEqual(3, testList.Count);
            Assert.AreEqual(new List<int>() { 1, 2, 3 }, testList);
        }

        [Test]
        public void TestAreValuesEmpty_CheckEmptyList_True()
        {
            List<string> testList = new List<string>() { null, null, null };
            Assert.IsTrue(testList.AreValuesNull());
        }

        [Test]
        public void TestAreValuesEmpty_CheckListWithNullEntries_False()
        {
            List<string> testList = new List<string>() { null, "b", null };
            Assert.IsFalse(testList.AreValuesNull());
        }

        [Test]
        public void TestAreValuesEmpty_CheckFilledList_False()
        {
            List<string> testList = new List<string>() { "a", "b", "c" };
            Assert.IsFalse(testList.AreValuesNull());
        }

        [Test]
        public void TestIsNullOrEmptz_EmptyList_True()
        {
            List<string> testList = new List<string>();
            Assert.IsTrue(testList.IsNullOrEmpty());
        }

        [Test]
        public void TestIsNullOrEmptz_NullList_True()
        {
            List<string> testList = null;
            Assert.IsTrue(testList.IsNullOrEmpty());
        }

        [Test]
        public void TestIsNullOrEmptz_FilledList_False()
        {
            List<int> testList = new List<int>(){ 1, 2, 3};
            Assert.IsFalse(testList.IsNullOrEmpty());
        }
    }
}
