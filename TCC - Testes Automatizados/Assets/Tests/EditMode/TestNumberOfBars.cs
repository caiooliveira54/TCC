using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

public class TestNumberOfBars
{
    private GameObject[] bars;

    [SetUp]
    public void setUp()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Level1.unity");

        bars = GameObject.FindGameObjectsWithTag("Destructable");
    }

    [Test]
    public void testNumberBarsSceneLevel1()
    {
        Assert.AreEqual(49, bars.Length);
    }
}
