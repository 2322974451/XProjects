using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	public class XFlowerRankNormalInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.formatname = XTitleDocument.GetTitleWithFormat(data.titleID, data.RoleName);
			this.id = data.RoleId;
			this.rank = data.Rank;
			this.guildicon = data.guildicon;
			this.guildname = data.guildname;
			this.flowerCount = data.flowercount;
			this.profession = data.profession;
			this.headPicUrl = data.headpic;
			this.setid = ((data.pre == null) ? new List<uint>() : data.pre.setid);
			this.receivedFlowers.Clear();
			foreach (MapIntItem mapIntItem in data.receiveFlowers)
			{
				bool flag = !this.receivedFlowers.ContainsKey(mapIntItem.key);
				if (flag)
				{
					this.receivedFlowers.Add(mapIntItem.key, mapIntItem.value);
				}
			}
		}

		public uint flowerCount;

		public uint profession;

		public Dictionary<ulong, uint> receivedFlowers = new Dictionary<ulong, uint>();

		public string headPicUrl;
	}
}
