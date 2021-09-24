using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient.UI
{

	internal class BattleRecordGameInfo
	{

		public List<BattleRecordPlayerInfo> left = new List<BattleRecordPlayerInfo>();

		public List<BattleRecordPlayerInfo> right = new List<BattleRecordPlayerInfo>();

		public HeroBattleOver result;

		public int point2V2;

		public uint militaryExploit;
	}
}
