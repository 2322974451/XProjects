using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildBasicInfoDisplay
	{

		public void Init(Transform go, bool bFirstInit)
		{
			this.Root = go;
			Transform transform = this.Root.FindChild("GuildName");
			bool flag = transform != null;
			if (flag)
			{
				this.GuildName = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.GuildName.SetText("");
				}
			}
			else
			{
				this.GuildName = null;
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
			transform = this.Root.FindChild("Announcement");
			bool flag3 = transform != null;
			if (flag3)
			{
				this.Annoucement = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.Annoucement.SetText("");
				}
			}
			else
			{
				this.Annoucement = null;
			}
			transform = this.Root.FindChild("Level");
			bool flag4 = transform != null;
			if (flag4)
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
			transform = this.Root.FindChild("Rank");
			bool flag5 = transform != null;
			if (flag5)
			{
				this.Rank = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.Rank.SetText("");
				}
			}
			else
			{
				this.Rank = null;
			}
			transform = this.Root.FindChild("MemberCount");
			bool flag6 = transform != null;
			if (flag6)
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
			transform = this.Root.FindChild("Exp");
			bool flag7 = transform != null;
			if (flag7)
			{
				this.Exp = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.Exp.SetText("");
				}
			}
			else
			{
				this.Exp = null;
			}
			transform = this.Root.FindChild("Portrait");
			bool flag8 = transform != null;
			if (flag8)
			{
				this.Portrait = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.Portrait = null;
			}
			transform = this.Root.FindChild("Liveness");
			bool flag9 = transform != null;
			if (flag9)
			{
				this.Liveness = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			else
			{
				this.Liveness = null;
			}
			transform = this.Root.FindChild("Popularity");
			bool flag10 = transform != null;
			if (flag10)
			{
				this.Popularity = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			else
			{
				this.Popularity = null;
			}
			transform = this.Root.FindChild("Technology");
			bool flag11 = transform != null;
			if (flag11)
			{
				this.Technology = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			transform = this.Root.FindChild("Resources");
			bool flag12 = transform != null;
			if (flag12)
			{
				this.Resources = (transform.GetComponent("XUILabel") as IXUILabel);
			}
		}

		public void Set(XGuildBasicData data)
		{
			bool flag = this.GuildName != null;
			if (flag)
			{
				this.GuildName.SetText(data.guildName);
			}
			bool flag2 = this.LeaderName != null;
			if (flag2)
			{
				this.LeaderName.SetText(data.leaderName);
			}
			bool flag3 = this.Annoucement != null;
			if (flag3)
			{
				this.Annoucement.SetText(data.announcement);
			}
			bool flag4 = this.Level != null;
			if (flag4)
			{
				this.Level.SetText("Lv." + data.level);
			}
			bool flag5 = this.MemberCount != null;
			if (flag5)
			{
				this.MemberCount.SetText(string.Format("{0}/{1}", data.memberCount, data.maxMemberCount));
			}
			bool flag6 = this.Portrait != null;
			if (flag6)
			{
				this.Portrait.SetSprite(XGuildDocument.GetPortraitName(data.portraitIndex));
			}
			bool flag7 = this.Exp != null;
			if (flag7)
			{
				this.Exp.SetText(string.Format("{0}/{1}", XSingleton<UiUtility>.singleton.NumberFormat((ulong)(XGuildDocument.GuildConfig.GetBaseExp(data.level) + data.exp)), XSingleton<UiUtility>.singleton.NumberFormat((ulong)XGuildDocument.GuildConfig.GetTotalExp(data.level))));
			}
			bool flag8 = this.Rank != null;
			if (flag8)
			{
				this.Rank.SetText("No." + data.rank);
			}
			bool flag9 = this.Liveness != null;
			if (flag9)
			{
				this.Liveness.SetText(data.GetLiveness());
			}
			bool flag10 = this.Popularity != null;
			if (flag10)
			{
				this.Popularity.SetText(data.popularity.ToString());
			}
			bool flag11 = this.Technology != null;
			if (flag11)
			{
				this.Technology.SetText(data.technology.ToString());
			}
			bool flag12 = this.Resources != null;
			if (flag12)
			{
				this.Resources.SetText(data.resource.ToString());
			}
		}

		public Transform Root;

		public IXUILabel GuildName;

		public IXUILabel LeaderName;

		public IXUILabel Annoucement;

		public IXUILabel Level;

		public IXUILabel Rank;

		public IXUILabel MemberCount;

		public IXUILabel Exp;

		public IXUISprite Portrait;

		public IXUILabel Liveness;

		public IXUILabel Popularity;

		public IXUILabel Technology;

		public IXUILabel Resources;
	}
}
