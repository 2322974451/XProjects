using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D7B RID: 3451
	public class XFlowerRankActivityInfo : XBaseRankInfo
	{
		// Token: 0x0600BCAA RID: 48298 RVA: 0x0026E40C File Offset: 0x0026C60C
		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
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

		// Token: 0x04004C8E RID: 19598
		public uint flowerCount;

		// Token: 0x04004C8F RID: 19599
		public uint profession;

		// Token: 0x04004C90 RID: 19600
		public Dictionary<ulong, uint> receivedFlowers = new Dictionary<ulong, uint>();

		// Token: 0x04004C91 RID: 19601
		public string headPicUrl;
	}
}
