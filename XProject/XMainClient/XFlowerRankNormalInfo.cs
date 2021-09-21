using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D79 RID: 3449
	public class XFlowerRankNormalInfo : XBaseRankInfo
	{
		// Token: 0x0600BCA6 RID: 48294 RVA: 0x0026E2A4 File Offset: 0x0026C4A4
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

		// Token: 0x04004C8A RID: 19594
		public uint flowerCount;

		// Token: 0x04004C8B RID: 19595
		public uint profession;

		// Token: 0x04004C8C RID: 19596
		public Dictionary<ulong, uint> receivedFlowers = new Dictionary<ulong, uint>();

		// Token: 0x04004C8D RID: 19597
		public string headPicUrl;
	}
}
