using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient.UI
{

	internal class FindBackData
	{

		public int findid = 0;

		public int maxfindback = 0;

		public int findindex = 0;

		public bool isfind = false;

		public int findbacklevel = 0;

		public List<ItemFindBackInfo2Client> findbackinfo = new List<ItemFindBackInfo2Client>();

		public Dictionary<int, List<int>> goldItemCount = new Dictionary<int, List<int>>();

		public Dictionary<int, List<int>> dragonCoinItemCount = new Dictionary<int, List<int>>();
	}
}
