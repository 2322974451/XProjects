using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A74 RID: 2676
	internal class XGuildBasicData : XDataBase
	{
		// Token: 0x17002F77 RID: 12151
		// (get) Token: 0x0600A2C2 RID: 41666 RVA: 0x001BC2AC File Offset: 0x001BA4AC
		// (set) Token: 0x0600A2C1 RID: 41665 RVA: 0x001BC2A2 File Offset: 0x001BA4A2
		public string announcement
		{
			get
			{
				bool flag = this._announcement == null || this._announcement == "";
				string result;
				if (flag)
				{
					result = XStringDefineProxy.GetString("GUILD_DEFAULT_ANNOUNCEMENT");
				}
				else
				{
					result = this._announcement;
				}
				return result;
			}
			set
			{
				this._announcement = value;
			}
		}

		// Token: 0x0600A2C3 RID: 41667 RVA: 0x001BC2F4 File Offset: 0x001BA4F4
		public string GetLiveness()
		{
			string text = string.Empty;
			bool flag = this.liveList.Count > 0;
			if (flag)
			{
				int i = 0;
				int count = this.liveList.Count;
				while (i < count)
				{
					bool flag2 = this.liveness < this.liveList[i];
					if (flag2)
					{
						text = string.Format("GUILD_LIVENESS_{0}", i + 1);
						break;
					}
					i++;
				}
			}
			bool flag3 = string.IsNullOrEmpty(text);
			string result;
			if (flag3)
			{
				result = this.liveness.ToString();
			}
			else
			{
				result = XStringDefineProxy.GetString(text, new object[]
				{
					this.liveness
				});
			}
			return result;
		}

		// Token: 0x0600A2C4 RID: 41668 RVA: 0x001BC3A8 File Offset: 0x001BA5A8
		public string GetLivenessTips()
		{
			bool flag = this.liveList.Count != 3;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				result = string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("GUILD_LIVENESS_TIPS")), new object[]
				{
					this.liveList[0],
					this.liveList[0],
					this.liveList[1],
					this.liveList[1],
					this.liveList[2],
					this.liveList[2]
				});
			}
			return result;
		}

		// Token: 0x17002F78 RID: 12152
		// (get) Token: 0x0600A2C5 RID: 41669 RVA: 0x001BC474 File Offset: 0x001BA674
		public string actualAnnoucement
		{
			get
			{
				return this._announcement;
			}
		}

		// Token: 0x0600A2C6 RID: 41670 RVA: 0x001BC48C File Offset: 0x001BA68C
		public virtual void Init(GuildInfo info)
		{
			this.uid = info.id;
			this.guildName = info.name;
			this.leaderuid = info.leaderID;
			this.leaderName = info.leaderName;
			this.level = (uint)info.level;
			this.memberCount = (uint)info.memberCount;
			this.maxMemberCount = (uint)info.capacity;
			this.portraitIndex = info.icon;
			this.announcement = info.annoucement;
			this.popularity = info.prestige;
		}

		// Token: 0x0600A2C7 RID: 41671 RVA: 0x001BC514 File Offset: 0x001BA714
		public void Init(GuildBriefRes info)
		{
			this.guildName = info.name;
			this.leaderName = info.leaderName;
			this.leaderuid = info.leaderID;
			this.level = (uint)info.level;
			this.memberCount = (uint)info.membercount;
			this.maxMemberCount = (uint)info.capacity;
			this.announcement = info.annoucement;
			this.portraitIndex = info.icon;
			this.exp = info.exp;
			this.rank = info.rank;
			this.liveness = info.activity;
			this.liveList.Clear();
			this.liveList.Add(info.activityOne);
			this.liveList.Add(info.activityTwo);
			this.liveList.Add(info.activityThree);
			this.popularity = info.prestige;
			this.technology = info.schoolpoint;
			this.resource = info.hallpoint;
		}

		// Token: 0x0600A2C8 RID: 41672 RVA: 0x001BC610 File Offset: 0x001BA810
		public virtual string ToGuildNameString()
		{
			return this.guildName;
		}

		// Token: 0x04003AC4 RID: 15044
		public ulong uid;

		// Token: 0x04003AC5 RID: 15045
		public string guildName;

		// Token: 0x04003AC6 RID: 15046
		public string leaderName;

		// Token: 0x04003AC7 RID: 15047
		public ulong leaderuid;

		// Token: 0x04003AC8 RID: 15048
		public uint level;

		// Token: 0x04003AC9 RID: 15049
		public uint memberCount;

		// Token: 0x04003ACA RID: 15050
		public uint maxMemberCount;

		// Token: 0x04003ACB RID: 15051
		private string _announcement;

		// Token: 0x04003ACC RID: 15052
		public int portraitIndex;

		// Token: 0x04003ACD RID: 15053
		public uint exp;

		// Token: 0x04003ACE RID: 15054
		public int rank;

		// Token: 0x04003ACF RID: 15055
		public uint liveness;

		// Token: 0x04003AD0 RID: 15056
		public List<uint> liveList = new List<uint>();

		// Token: 0x04003AD1 RID: 15057
		public uint popularity;

		// Token: 0x04003AD2 RID: 15058
		public uint technology;

		// Token: 0x04003AD3 RID: 15059
		public uint resource;
	}
}
