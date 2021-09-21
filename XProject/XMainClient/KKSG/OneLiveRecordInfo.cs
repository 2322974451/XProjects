using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200017A RID: 378
	[ProtoContract(Name = "OneLiveRecordInfo")]
	[Serializable]
	public class OneLiveRecordInfo : IExtensible
	{
		// Token: 0x17000728 RID: 1832
		// (get) Token: 0x0600169E RID: 5790 RVA: 0x0002D430 File Offset: 0x0002B630
		// (set) Token: 0x0600169F RID: 5791 RVA: 0x0002D45C File Offset: 0x0002B65C
		[ProtoMember(1, IsRequired = false, Name = "liveID", DataFormat = DataFormat.TwosComplement)]
		public uint liveID
		{
			get
			{
				return this._liveID ?? 0U;
			}
			set
			{
				this._liveID = new uint?(value);
			}
		}

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x060016A0 RID: 5792 RVA: 0x0002D46C File Offset: 0x0002B66C
		// (set) Token: 0x060016A1 RID: 5793 RVA: 0x0002D48C File Offset: 0x0002B68C
		[XmlIgnore]
		[Browsable(false)]
		public bool liveIDSpecified
		{
			get
			{
				return this._liveID != null;
			}
			set
			{
				bool flag = value == (this._liveID == null);
				if (flag)
				{
					this._liveID = (value ? new uint?(this.liveID) : null);
				}
			}
		}

		// Token: 0x060016A2 RID: 5794 RVA: 0x0002D4D0 File Offset: 0x0002B6D0
		private bool ShouldSerializeliveID()
		{
			return this.liveIDSpecified;
		}

		// Token: 0x060016A3 RID: 5795 RVA: 0x0002D4E8 File Offset: 0x0002B6E8
		private void ResetliveID()
		{
			this.liveIDSpecified = false;
		}

		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x060016A4 RID: 5796 RVA: 0x0002D4F4 File Offset: 0x0002B6F4
		// (set) Token: 0x060016A5 RID: 5797 RVA: 0x0002D520 File Offset: 0x0002B720
		[ProtoMember(2, IsRequired = false, Name = "DNExpID", DataFormat = DataFormat.TwosComplement)]
		public int DNExpID
		{
			get
			{
				return this._DNExpID ?? 0;
			}
			set
			{
				this._DNExpID = new int?(value);
			}
		}

		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x060016A6 RID: 5798 RVA: 0x0002D530 File Offset: 0x0002B730
		// (set) Token: 0x060016A7 RID: 5799 RVA: 0x0002D550 File Offset: 0x0002B750
		[XmlIgnore]
		[Browsable(false)]
		public bool DNExpIDSpecified
		{
			get
			{
				return this._DNExpID != null;
			}
			set
			{
				bool flag = value == (this._DNExpID == null);
				if (flag)
				{
					this._DNExpID = (value ? new int?(this.DNExpID) : null);
				}
			}
		}

		// Token: 0x060016A8 RID: 5800 RVA: 0x0002D594 File Offset: 0x0002B794
		private bool ShouldSerializeDNExpID()
		{
			return this.DNExpIDSpecified;
		}

		// Token: 0x060016A9 RID: 5801 RVA: 0x0002D5AC File Offset: 0x0002B7AC
		private void ResetDNExpID()
		{
			this.DNExpIDSpecified = false;
		}

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x060016AA RID: 5802 RVA: 0x0002D5B8 File Offset: 0x0002B7B8
		// (set) Token: 0x060016AB RID: 5803 RVA: 0x0002D5E4 File Offset: 0x0002B7E4
		[ProtoMember(3, IsRequired = false, Name = "watchNum", DataFormat = DataFormat.TwosComplement)]
		public int watchNum
		{
			get
			{
				return this._watchNum ?? 0;
			}
			set
			{
				this._watchNum = new int?(value);
			}
		}

		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x060016AC RID: 5804 RVA: 0x0002D5F4 File Offset: 0x0002B7F4
		// (set) Token: 0x060016AD RID: 5805 RVA: 0x0002D614 File Offset: 0x0002B814
		[XmlIgnore]
		[Browsable(false)]
		public bool watchNumSpecified
		{
			get
			{
				return this._watchNum != null;
			}
			set
			{
				bool flag = value == (this._watchNum == null);
				if (flag)
				{
					this._watchNum = (value ? new int?(this.watchNum) : null);
				}
			}
		}

		// Token: 0x060016AE RID: 5806 RVA: 0x0002D658 File Offset: 0x0002B858
		private bool ShouldSerializewatchNum()
		{
			return this.watchNumSpecified;
		}

		// Token: 0x060016AF RID: 5807 RVA: 0x0002D670 File Offset: 0x0002B870
		private void ResetwatchNum()
		{
			this.watchNumSpecified = false;
		}

		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x060016B0 RID: 5808 RVA: 0x0002D67C File Offset: 0x0002B87C
		// (set) Token: 0x060016B1 RID: 5809 RVA: 0x0002D6A8 File Offset: 0x0002B8A8
		[ProtoMember(4, IsRequired = false, Name = "commendNum", DataFormat = DataFormat.TwosComplement)]
		public int commendNum
		{
			get
			{
				return this._commendNum ?? 0;
			}
			set
			{
				this._commendNum = new int?(value);
			}
		}

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x060016B2 RID: 5810 RVA: 0x0002D6B8 File Offset: 0x0002B8B8
		// (set) Token: 0x060016B3 RID: 5811 RVA: 0x0002D6D8 File Offset: 0x0002B8D8
		[XmlIgnore]
		[Browsable(false)]
		public bool commendNumSpecified
		{
			get
			{
				return this._commendNum != null;
			}
			set
			{
				bool flag = value == (this._commendNum == null);
				if (flag)
				{
					this._commendNum = (value ? new int?(this.commendNum) : null);
				}
			}
		}

		// Token: 0x060016B4 RID: 5812 RVA: 0x0002D71C File Offset: 0x0002B91C
		private bool ShouldSerializecommendNum()
		{
			return this.commendNumSpecified;
		}

		// Token: 0x060016B5 RID: 5813 RVA: 0x0002D734 File Offset: 0x0002B934
		private void ResetcommendNum()
		{
			this.commendNumSpecified = false;
		}

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x060016B6 RID: 5814 RVA: 0x0002D740 File Offset: 0x0002B940
		// (set) Token: 0x060016B7 RID: 5815 RVA: 0x0002D76C File Offset: 0x0002B96C
		[ProtoMember(5, IsRequired = false, Name = "hasFriend", DataFormat = DataFormat.Default)]
		public bool hasFriend
		{
			get
			{
				return this._hasFriend ?? false;
			}
			set
			{
				this._hasFriend = new bool?(value);
			}
		}

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x060016B8 RID: 5816 RVA: 0x0002D77C File Offset: 0x0002B97C
		// (set) Token: 0x060016B9 RID: 5817 RVA: 0x0002D79C File Offset: 0x0002B99C
		[XmlIgnore]
		[Browsable(false)]
		public bool hasFriendSpecified
		{
			get
			{
				return this._hasFriend != null;
			}
			set
			{
				bool flag = value == (this._hasFriend == null);
				if (flag)
				{
					this._hasFriend = (value ? new bool?(this.hasFriend) : null);
				}
			}
		}

		// Token: 0x060016BA RID: 5818 RVA: 0x0002D7E0 File Offset: 0x0002B9E0
		private bool ShouldSerializehasFriend()
		{
			return this.hasFriendSpecified;
		}

		// Token: 0x060016BB RID: 5819 RVA: 0x0002D7F8 File Offset: 0x0002B9F8
		private void ResethasFriend()
		{
			this.hasFriendSpecified = false;
		}

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x060016BC RID: 5820 RVA: 0x0002D804 File Offset: 0x0002BA04
		// (set) Token: 0x060016BD RID: 5821 RVA: 0x0002D830 File Offset: 0x0002BA30
		[ProtoMember(6, IsRequired = false, Name = "beginTime", DataFormat = DataFormat.TwosComplement)]
		public int beginTime
		{
			get
			{
				return this._beginTime ?? 0;
			}
			set
			{
				this._beginTime = new int?(value);
			}
		}

		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x060016BE RID: 5822 RVA: 0x0002D840 File Offset: 0x0002BA40
		// (set) Token: 0x060016BF RID: 5823 RVA: 0x0002D860 File Offset: 0x0002BA60
		[XmlIgnore]
		[Browsable(false)]
		public bool beginTimeSpecified
		{
			get
			{
				return this._beginTime != null;
			}
			set
			{
				bool flag = value == (this._beginTime == null);
				if (flag)
				{
					this._beginTime = (value ? new int?(this.beginTime) : null);
				}
			}
		}

		// Token: 0x060016C0 RID: 5824 RVA: 0x0002D8A4 File Offset: 0x0002BAA4
		private bool ShouldSerializebeginTime()
		{
			return this.beginTimeSpecified;
		}

		// Token: 0x060016C1 RID: 5825 RVA: 0x0002D8BC File Offset: 0x0002BABC
		private void ResetbeginTime()
		{
			this.beginTimeSpecified = false;
		}

		// Token: 0x17000734 RID: 1844
		// (get) Token: 0x060016C2 RID: 5826 RVA: 0x0002D8C8 File Offset: 0x0002BAC8
		// (set) Token: 0x060016C3 RID: 5827 RVA: 0x0002D8F4 File Offset: 0x0002BAF4
		[ProtoMember(7, IsRequired = false, Name = "tianTiLevel", DataFormat = DataFormat.TwosComplement)]
		public int tianTiLevel
		{
			get
			{
				return this._tianTiLevel ?? 0;
			}
			set
			{
				this._tianTiLevel = new int?(value);
			}
		}

		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x060016C4 RID: 5828 RVA: 0x0002D904 File Offset: 0x0002BB04
		// (set) Token: 0x060016C5 RID: 5829 RVA: 0x0002D924 File Offset: 0x0002BB24
		[XmlIgnore]
		[Browsable(false)]
		public bool tianTiLevelSpecified
		{
			get
			{
				return this._tianTiLevel != null;
			}
			set
			{
				bool flag = value == (this._tianTiLevel == null);
				if (flag)
				{
					this._tianTiLevel = (value ? new int?(this.tianTiLevel) : null);
				}
			}
		}

		// Token: 0x060016C6 RID: 5830 RVA: 0x0002D968 File Offset: 0x0002BB68
		private bool ShouldSerializetianTiLevel()
		{
			return this.tianTiLevelSpecified;
		}

		// Token: 0x060016C7 RID: 5831 RVA: 0x0002D980 File Offset: 0x0002BB80
		private void ResettianTiLevel()
		{
			this.tianTiLevelSpecified = false;
		}

		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x060016C8 RID: 5832 RVA: 0x0002D98C File Offset: 0x0002BB8C
		// (set) Token: 0x060016C9 RID: 5833 RVA: 0x0002D9B8 File Offset: 0x0002BBB8
		[ProtoMember(8, IsRequired = false, Name = "guildBattleLevel", DataFormat = DataFormat.TwosComplement)]
		public int guildBattleLevel
		{
			get
			{
				return this._guildBattleLevel ?? 0;
			}
			set
			{
				this._guildBattleLevel = new int?(value);
			}
		}

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x060016CA RID: 5834 RVA: 0x0002D9C8 File Offset: 0x0002BBC8
		// (set) Token: 0x060016CB RID: 5835 RVA: 0x0002D9E8 File Offset: 0x0002BBE8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildBattleLevelSpecified
		{
			get
			{
				return this._guildBattleLevel != null;
			}
			set
			{
				bool flag = value == (this._guildBattleLevel == null);
				if (flag)
				{
					this._guildBattleLevel = (value ? new int?(this.guildBattleLevel) : null);
				}
			}
		}

		// Token: 0x060016CC RID: 5836 RVA: 0x0002DA2C File Offset: 0x0002BC2C
		private bool ShouldSerializeguildBattleLevel()
		{
			return this.guildBattleLevelSpecified;
		}

		// Token: 0x060016CD RID: 5837 RVA: 0x0002DA44 File Offset: 0x0002BC44
		private void ResetguildBattleLevel()
		{
			this.guildBattleLevelSpecified = false;
		}

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x060016CE RID: 5838 RVA: 0x0002DA50 File Offset: 0x0002BC50
		[ProtoMember(9, Name = "nameInfos", DataFormat = DataFormat.Default)]
		public List<LiveNameInfo> nameInfos
		{
			get
			{
				return this._nameInfos;
			}
		}

		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x060016CF RID: 5839 RVA: 0x0002DA68 File Offset: 0x0002BC68
		// (set) Token: 0x060016D0 RID: 5840 RVA: 0x0002DA94 File Offset: 0x0002BC94
		[ProtoMember(10, IsRequired = false, Name = "liveType", DataFormat = DataFormat.TwosComplement)]
		public LiveType liveType
		{
			get
			{
				return this._liveType ?? LiveType.LIVE_RECOMMEND;
			}
			set
			{
				this._liveType = new LiveType?(value);
			}
		}

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x060016D1 RID: 5841 RVA: 0x0002DAA4 File Offset: 0x0002BCA4
		// (set) Token: 0x060016D2 RID: 5842 RVA: 0x0002DAC4 File Offset: 0x0002BCC4
		[XmlIgnore]
		[Browsable(false)]
		public bool liveTypeSpecified
		{
			get
			{
				return this._liveType != null;
			}
			set
			{
				bool flag = value == (this._liveType == null);
				if (flag)
				{
					this._liveType = (value ? new LiveType?(this.liveType) : null);
				}
			}
		}

		// Token: 0x060016D3 RID: 5843 RVA: 0x0002DB08 File Offset: 0x0002BD08
		private bool ShouldSerializeliveType()
		{
			return this.liveTypeSpecified;
		}

		// Token: 0x060016D4 RID: 5844 RVA: 0x0002DB20 File Offset: 0x0002BD20
		private void ResetliveType()
		{
			this.liveTypeSpecified = false;
		}

		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x060016D5 RID: 5845 RVA: 0x0002DB2C File Offset: 0x0002BD2C
		// (set) Token: 0x060016D6 RID: 5846 RVA: 0x0002DB58 File Offset: 0x0002BD58
		[ProtoMember(11, IsRequired = false, Name = "hasGuild", DataFormat = DataFormat.Default)]
		public bool hasGuild
		{
			get
			{
				return this._hasGuild ?? false;
			}
			set
			{
				this._hasGuild = new bool?(value);
			}
		}

		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x060016D7 RID: 5847 RVA: 0x0002DB68 File Offset: 0x0002BD68
		// (set) Token: 0x060016D8 RID: 5848 RVA: 0x0002DB88 File Offset: 0x0002BD88
		[XmlIgnore]
		[Browsable(false)]
		public bool hasGuildSpecified
		{
			get
			{
				return this._hasGuild != null;
			}
			set
			{
				bool flag = value == (this._hasGuild == null);
				if (flag)
				{
					this._hasGuild = (value ? new bool?(this.hasGuild) : null);
				}
			}
		}

		// Token: 0x060016D9 RID: 5849 RVA: 0x0002DBCC File Offset: 0x0002BDCC
		private bool ShouldSerializehasGuild()
		{
			return this.hasGuildSpecified;
		}

		// Token: 0x060016DA RID: 5850 RVA: 0x0002DBE4 File Offset: 0x0002BDE4
		private void ResethasGuild()
		{
			this.hasGuildSpecified = false;
		}

		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x060016DB RID: 5851 RVA: 0x0002DBF0 File Offset: 0x0002BDF0
		// (set) Token: 0x060016DC RID: 5852 RVA: 0x0002DC1C File Offset: 0x0002BE1C
		[ProtoMember(12, IsRequired = false, Name = "canEnter", DataFormat = DataFormat.Default)]
		public bool canEnter
		{
			get
			{
				return this._canEnter ?? false;
			}
			set
			{
				this._canEnter = new bool?(value);
			}
		}

		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x060016DD RID: 5853 RVA: 0x0002DC2C File Offset: 0x0002BE2C
		// (set) Token: 0x060016DE RID: 5854 RVA: 0x0002DC4C File Offset: 0x0002BE4C
		[XmlIgnore]
		[Browsable(false)]
		public bool canEnterSpecified
		{
			get
			{
				return this._canEnter != null;
			}
			set
			{
				bool flag = value == (this._canEnter == null);
				if (flag)
				{
					this._canEnter = (value ? new bool?(this.canEnter) : null);
				}
			}
		}

		// Token: 0x060016DF RID: 5855 RVA: 0x0002DC90 File Offset: 0x0002BE90
		private bool ShouldSerializecanEnter()
		{
			return this.canEnterSpecified;
		}

		// Token: 0x060016E0 RID: 5856 RVA: 0x0002DCA8 File Offset: 0x0002BEA8
		private void ResetcanEnter()
		{
			this.canEnterSpecified = false;
		}

		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x060016E1 RID: 5857 RVA: 0x0002DCB4 File Offset: 0x0002BEB4
		// (set) Token: 0x060016E2 RID: 5858 RVA: 0x0002DCE0 File Offset: 0x0002BEE0
		[ProtoMember(13, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public uint sceneID
		{
			get
			{
				return this._sceneID ?? 0U;
			}
			set
			{
				this._sceneID = new uint?(value);
			}
		}

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x060016E3 RID: 5859 RVA: 0x0002DCF0 File Offset: 0x0002BEF0
		// (set) Token: 0x060016E4 RID: 5860 RVA: 0x0002DD10 File Offset: 0x0002BF10
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new uint?(this.sceneID) : null);
				}
			}
		}

		// Token: 0x060016E5 RID: 5861 RVA: 0x0002DD54 File Offset: 0x0002BF54
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x060016E6 RID: 5862 RVA: 0x0002DD6C File Offset: 0x0002BF6C
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x060016E7 RID: 5863 RVA: 0x0002DD78 File Offset: 0x0002BF78
		// (set) Token: 0x060016E8 RID: 5864 RVA: 0x0002DDA4 File Offset: 0x0002BFA4
		[ProtoMember(14, IsRequired = false, Name = "curWatchNum", DataFormat = DataFormat.TwosComplement)]
		public uint curWatchNum
		{
			get
			{
				return this._curWatchNum ?? 0U;
			}
			set
			{
				this._curWatchNum = new uint?(value);
			}
		}

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x060016E9 RID: 5865 RVA: 0x0002DDB4 File Offset: 0x0002BFB4
		// (set) Token: 0x060016EA RID: 5866 RVA: 0x0002DDD4 File Offset: 0x0002BFD4
		[XmlIgnore]
		[Browsable(false)]
		public bool curWatchNumSpecified
		{
			get
			{
				return this._curWatchNum != null;
			}
			set
			{
				bool flag = value == (this._curWatchNum == null);
				if (flag)
				{
					this._curWatchNum = (value ? new uint?(this.curWatchNum) : null);
				}
			}
		}

		// Token: 0x060016EB RID: 5867 RVA: 0x0002DE18 File Offset: 0x0002C018
		private bool ShouldSerializecurWatchNum()
		{
			return this.curWatchNumSpecified;
		}

		// Token: 0x060016EC RID: 5868 RVA: 0x0002DE30 File Offset: 0x0002C030
		private void ResetcurWatchNum()
		{
			this.curWatchNumSpecified = false;
		}

		// Token: 0x17000743 RID: 1859
		// (get) Token: 0x060016ED RID: 5869 RVA: 0x0002DE3C File Offset: 0x0002C03C
		// (set) Token: 0x060016EE RID: 5870 RVA: 0x0002DE68 File Offset: 0x0002C068
		[ProtoMember(15, IsRequired = false, Name = "mapID", DataFormat = DataFormat.TwosComplement)]
		public uint mapID
		{
			get
			{
				return this._mapID ?? 0U;
			}
			set
			{
				this._mapID = new uint?(value);
			}
		}

		// Token: 0x17000744 RID: 1860
		// (get) Token: 0x060016EF RID: 5871 RVA: 0x0002DE78 File Offset: 0x0002C078
		// (set) Token: 0x060016F0 RID: 5872 RVA: 0x0002DE98 File Offset: 0x0002C098
		[XmlIgnore]
		[Browsable(false)]
		public bool mapIDSpecified
		{
			get
			{
				return this._mapID != null;
			}
			set
			{
				bool flag = value == (this._mapID == null);
				if (flag)
				{
					this._mapID = (value ? new uint?(this.mapID) : null);
				}
			}
		}

		// Token: 0x060016F1 RID: 5873 RVA: 0x0002DEDC File Offset: 0x0002C0DC
		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		// Token: 0x060016F2 RID: 5874 RVA: 0x0002DEF4 File Offset: 0x0002C0F4
		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		// Token: 0x17000745 RID: 1861
		// (get) Token: 0x060016F3 RID: 5875 RVA: 0x0002DF00 File Offset: 0x0002C100
		// (set) Token: 0x060016F4 RID: 5876 RVA: 0x0002DF2C File Offset: 0x0002C12C
		[ProtoMember(16, IsRequired = false, Name = "isCross", DataFormat = DataFormat.Default)]
		public bool isCross
		{
			get
			{
				return this._isCross ?? false;
			}
			set
			{
				this._isCross = new bool?(value);
			}
		}

		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x060016F5 RID: 5877 RVA: 0x0002DF3C File Offset: 0x0002C13C
		// (set) Token: 0x060016F6 RID: 5878 RVA: 0x0002DF5C File Offset: 0x0002C15C
		[XmlIgnore]
		[Browsable(false)]
		public bool isCrossSpecified
		{
			get
			{
				return this._isCross != null;
			}
			set
			{
				bool flag = value == (this._isCross == null);
				if (flag)
				{
					this._isCross = (value ? new bool?(this.isCross) : null);
				}
			}
		}

		// Token: 0x060016F7 RID: 5879 RVA: 0x0002DFA0 File Offset: 0x0002C1A0
		private bool ShouldSerializeisCross()
		{
			return this.isCrossSpecified;
		}

		// Token: 0x060016F8 RID: 5880 RVA: 0x0002DFB8 File Offset: 0x0002C1B8
		private void ResetisCross()
		{
			this.isCrossSpecified = false;
		}

		// Token: 0x060016F9 RID: 5881 RVA: 0x0002DFC4 File Offset: 0x0002C1C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400059D RID: 1437
		private uint? _liveID;

		// Token: 0x0400059E RID: 1438
		private int? _DNExpID;

		// Token: 0x0400059F RID: 1439
		private int? _watchNum;

		// Token: 0x040005A0 RID: 1440
		private int? _commendNum;

		// Token: 0x040005A1 RID: 1441
		private bool? _hasFriend;

		// Token: 0x040005A2 RID: 1442
		private int? _beginTime;

		// Token: 0x040005A3 RID: 1443
		private int? _tianTiLevel;

		// Token: 0x040005A4 RID: 1444
		private int? _guildBattleLevel;

		// Token: 0x040005A5 RID: 1445
		private readonly List<LiveNameInfo> _nameInfos = new List<LiveNameInfo>();

		// Token: 0x040005A6 RID: 1446
		private LiveType? _liveType;

		// Token: 0x040005A7 RID: 1447
		private bool? _hasGuild;

		// Token: 0x040005A8 RID: 1448
		private bool? _canEnter;

		// Token: 0x040005A9 RID: 1449
		private uint? _sceneID;

		// Token: 0x040005AA RID: 1450
		private uint? _curWatchNum;

		// Token: 0x040005AB RID: 1451
		private uint? _mapID;

		// Token: 0x040005AC RID: 1452
		private bool? _isCross;

		// Token: 0x040005AD RID: 1453
		private IExtension extensionObject;
	}
}
