using System;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x0200174B RID: 5963
	public class GuildArenaBattleDuelInfo
	{
		// Token: 0x0600F687 RID: 63111 RVA: 0x0037F0DC File Offset: 0x0037D2DC
		public void Init(Transform t)
		{
			this.transfrom = t;
			this.BlueInfo = new GuildArenaBattleDuelTeamInfo();
			this.BlueInfo.Init(this.transfrom.FindChild("Blue"));
			this.RedInfo = new GuildArenaBattleDuelTeamInfo();
			this.RedInfo.Init(this.transfrom.FindChild("Red"));
		}

		// Token: 0x0600F688 RID: 63112 RVA: 0x0037F13F File Offset: 0x0037D33F
		public void SetVisible(bool active)
		{
			this.transfrom.gameObject.SetActive(active);
		}

		// Token: 0x0600F689 RID: 63113 RVA: 0x0037F154 File Offset: 0x0037D354
		public void Reset()
		{
			this.BlueInfo.Reset();
			this.RedInfo.Reset();
		}

		// Token: 0x0600F68A RID: 63114 RVA: 0x0037F16F File Offset: 0x0037D36F
		public void Destroy()
		{
			this.BlueInfo = null;
			this.RedInfo = null;
		}

		// Token: 0x04006B03 RID: 27395
		private Transform transfrom;

		// Token: 0x04006B04 RID: 27396
		public GuildArenaBattleDuelTeamInfo BlueInfo;

		// Token: 0x04006B05 RID: 27397
		public GuildArenaBattleDuelTeamInfo RedInfo;
	}
}
