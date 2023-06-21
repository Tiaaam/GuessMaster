using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;

public class TestScript1
{
    [Test]
    public void CheckQuestionFile()
    {
        TextAsset csvFile = Resources.Load<TextAsset>("DataTables/german_cities_area_questions_12_01_2022");
        Assert.IsTrue(csvFile != null);
    }

    [Test]
    public void CheckQuestionContent()
    {
        TextAsset csvFile = Resources.Load<TextAsset>("DataTables/german_cities_area_questions_12_01_2022");
        Assert.IsFalse(csvFile.text.Length == 0);
    }
}
