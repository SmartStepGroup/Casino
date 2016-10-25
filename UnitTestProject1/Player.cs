using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace UnitTests
{
	[TestClass]
	public class PlayerTest
	{
		[TestMethod]
		public void ByDefault_HasNoChips()
		{
			var player = new Player();
		}

		[TestMethod]
		public void Buy1Chip_ChipsSetTo1()
		{
			var player = new Player();
			player.BuyChips(1);
			Assert.AreEqual(1, player.Chips);
		}
	}
}
