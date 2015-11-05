using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// <copyright file="StringExtensionsTest.Repeat.g.cs">Copyright �  2014</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace dotNetTips.Utility.Portable.Extensions
{
    public partial class StringExtensionsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(StringExtensionsTest))]
public void Repeat2101()
{
    string s;
    s = this.Repeat((string)null, 2);
    Assert.AreEqual<string>("", s);
}
[TestMethod]
[PexGeneratedBy(typeof(StringExtensionsTest))]
public void Repeat11301()
{
    string s;
    s = this.Repeat("\0", 3);
    Assert.AreEqual<string>("\0\0\0", s);
}
[TestMethod]
[PexGeneratedBy(typeof(StringExtensionsTest))]
public void Repeat29401()
{
    string s;
    s = this.Repeat((string)null, 0);
    Assert.AreEqual<string>("", s);
}
[TestMethod]
[PexGeneratedBy(typeof(StringExtensionsTest))]
public void Repeat46501()
{
    string s;
    s = this.Repeat("\0", -1);
    Assert.AreEqual<string>("", s);
}
[TestMethod]
[PexGeneratedBy(typeof(StringExtensionsTest))]
[PexRaisedException(typeof(OverflowException))]
public void RepeatThrowsOverflowException13901()
{
    string s;
    s = this.Repeat("\0", int.MaxValue);
}
    }
}