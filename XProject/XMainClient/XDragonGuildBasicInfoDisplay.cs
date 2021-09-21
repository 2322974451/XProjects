using System;
using UILib;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000A48 RID: 2632
	internal class XDragonGuildBasicInfoDisplay
	{
		// Token: 0x06009FD2 RID: 40914 RVA: 0x001A864C File Offset: 0x001A684C
		public void Init(Transform go, bool bFirstInit)
		{
			this.Root = go;
			Transform transform = this.Root.FindChild("GuildName");
			bool flag = transform != null;
			if (flag)
			{
				this.DragonGuildName = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.DragonGuildName.SetText("");
				}
			}
			else
			{
				this.DragonGuildName = null;
			}
			transform = this.Root.FindChild("LeaderName");
			bool flag2 = transform != null;
			if (flag2)
			{
				this.LeaderName = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.LeaderName.SetText("");
				}
			}
			else
			{
				this.LeaderName = null;
			}
			transform = this.Root.FindChild("Level");
			bool flag3 = transform != null;
			if (flag3)
			{
				this.Level = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.Level.SetText("");
				}
			}
			else
			{
				this.Level = null;
			}
			transform = this.Root.FindChild("MemberCount");
			bool flag4 = transform != null;
			if (flag4)
			{
				this.MemberCount = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.MemberCount.SetText("");
				}
			}
			else
			{
				this.MemberCount = null;
			}
			transform = this.Root.FindChild("PPT");
			bool flag5 = transform != null;
			if (flag5)
			{
				this.PPT = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.PPT.SetText("");
				}
			}
			else
			{
				this.PPT = null;
			}
		}

		// Token: 0x06009FD3 RID: 40915 RVA: 0x001A8810 File Offset: 0x001A6A10
		public void Set(XDragonGuildBaseData data)
		{
			bool flag = this.DragonGuildName != null;
			if (flag)
			{
				this.DragonGuildName.SetText(data.dragonGuildName);
			}
			bool flag2 = this.LeaderName != null;
			if (flag2)
			{
				this.LeaderName.SetText(data.leaderName);
			}
			bool flag3 = this.Level != null;
			if (flag3)
			{
				this.Level.SetText("Lv." + data.level);
			}
			bool flag4 = this.PPT != null;
			if (flag4)
			{
				this.PPT.SetText(data.totalPPT.ToString());
			}
			bool flag5 = this.MemberCount != null;
			if (flag5)
			{
				this.MemberCount.SetText(string.Format("{0}/{1}", data.memberCount, data.maxMemberCount));
			}
		}

		// Token: 0x0400390F RID: 14607
		public Transform Root;

		// Token: 0x04003910 RID: 14608
		public IXUILabel DragonGuildName;

		// Token: 0x04003911 RID: 14609
		public IXUILabel LeaderName;

		// Token: 0x04003912 RID: 14610
		public IXUILabel Level;

		// Token: 0x04003913 RID: 14611
		public IXUILabel MemberCount;

		// Token: 0x04003914 RID: 14612
		public IXUILabel PPT;
	}
}
