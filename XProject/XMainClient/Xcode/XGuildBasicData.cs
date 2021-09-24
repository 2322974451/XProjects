using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildBasicData : XDataBase
	{

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

		public string actualAnnoucement
		{
			get
			{
				return this._announcement;
			}
		}

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

		public virtual string ToGuildNameString()
		{
			return this.guildName;
		}

		public ulong uid;

		public string guildName;

		public string leaderName;

		public ulong leaderuid;

		public uint level;

		public uint memberCount;

		public uint maxMemberCount;

		private string _announcement;

		public int portraitIndex;

		public uint exp;

		public int rank;

		public uint liveness;

		public List<uint> liveList = new List<uint>();

		public uint popularity;

		public uint technology;

		public uint resource;
	}
}
