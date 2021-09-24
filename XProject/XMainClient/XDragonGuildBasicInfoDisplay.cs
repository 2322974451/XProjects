using System;
using UILib;
using UnityEngine;

namespace XMainClient
{

	internal class XDragonGuildBasicInfoDisplay
	{

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

		public Transform Root;

		public IXUILabel DragonGuildName;

		public IXUILabel LeaderName;

		public IXUILabel Level;

		public IXUILabel MemberCount;

		public IXUILabel PPT;
	}
}
