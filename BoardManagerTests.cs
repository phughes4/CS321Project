using UnityEngine;
using UnityEditor;
using Nunit.Framework;

[TestFixture]
public class BoardManagerTests
{
	[Test]
	public void setGoalRedAssertions()
	{
		bool x = true;
		setGoalRed(x);
		Assert.IsTrue(goalRed);
		x = false;
		setGoalRed(x);
		Assert.IsFalse(goalRed);
	}
	
	[Test]
	public void setGoalGreenAssertions()
	{
		bool x = true;
		setGoalGreen(x);
		Assert.IsTrue(goalGreen);
		x = false;
		setGoalGreen(x);
		Assert.IsFalse(goalGreen);
	}
	
}