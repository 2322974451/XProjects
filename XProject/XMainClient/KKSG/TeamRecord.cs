using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200065B RID: 1627
	[ProtoContract(Name = "TeamRecord")]
	[Serializable]
	public class TeamRecord : IExtensible
	{
		// Token: 0x17002006 RID: 8198
		// (get) Token: 0x0600657F RID: 25983 RVA: 0x000C1C5C File Offset: 0x000BFE5C
		// (set) Token: 0x06006580 RID: 25984 RVA: 0x000C1C88 File Offset: 0x000BFE88
		[ProtoMember(1, IsRequired = false, Name = "lastdayuptime", DataFormat = DataFormat.TwosComplement)]
		public uint lastdayuptime
		{
			get
			{
				return this._lastdayuptime ?? 0U;
			}
			set
			{
				this._lastdayuptime = new uint?(value);
			}
		}

		// Token: 0x17002007 RID: 8199
		// (get) Token: 0x06006581 RID: 25985 RVA: 0x000C1C98 File Offset: 0x000BFE98
		// (set) Token: 0x06006582 RID: 25986 RVA: 0x000C1CB8 File Offset: 0x000BFEB8
		[XmlIgnore]
		[Browsable(false)]
		public bool lastdayuptimeSpecified
		{
			get
			{
				return this._lastdayuptime != null;
			}
			set
			{
				bool flag = value == (this._lastdayuptime == null);
				if (flag)
				{
					this._lastdayuptime = (value ? new uint?(this.lastdayuptime) : null);
				}
			}
		}

		// Token: 0x06006583 RID: 25987 RVA: 0x000C1CFC File Offset: 0x000BFEFC
		private bool ShouldSerializelastdayuptime()
		{
			return this.lastdayuptimeSpecified;
		}

		// Token: 0x06006584 RID: 25988 RVA: 0x000C1D14 File Offset: 0x000BFF14
		private void Resetlastdayuptime()
		{
			this.lastdayuptimeSpecified = false;
		}

		// Token: 0x17002008 RID: 8200
		// (get) Token: 0x06006585 RID: 25989 RVA: 0x000C1D20 File Offset: 0x000BFF20
		// (set) Token: 0x06006586 RID: 25990 RVA: 0x000C1D4C File Offset: 0x000BFF4C
		[ProtoMember(2, IsRequired = false, Name = "lastweekuptime", DataFormat = DataFormat.TwosComplement)]
		public uint lastweekuptime
		{
			get
			{
				return this._lastweekuptime ?? 0U;
			}
			set
			{
				this._lastweekuptime = new uint?(value);
			}
		}

		// Token: 0x17002009 RID: 8201
		// (get) Token: 0x06006587 RID: 25991 RVA: 0x000C1D5C File Offset: 0x000BFF5C
		// (set) Token: 0x06006588 RID: 25992 RVA: 0x000C1D7C File Offset: 0x000BFF7C
		[XmlIgnore]
		[Browsable(false)]
		public bool lastweekuptimeSpecified
		{
			get
			{
				return this._lastweekuptime != null;
			}
			set
			{
				bool flag = value == (this._lastweekuptime == null);
				if (flag)
				{
					this._lastweekuptime = (value ? new uint?(this.lastweekuptime) : null);
				}
			}
		}

		// Token: 0x06006589 RID: 25993 RVA: 0x000C1DC0 File Offset: 0x000BFFC0
		private bool ShouldSerializelastweekuptime()
		{
			return this.lastweekuptimeSpecified;
		}

		// Token: 0x0600658A RID: 25994 RVA: 0x000C1DD8 File Offset: 0x000BFFD8
		private void Resetlastweekuptime()
		{
			this.lastweekuptimeSpecified = false;
		}

		// Token: 0x1700200A RID: 8202
		// (get) Token: 0x0600658B RID: 25995 RVA: 0x000C1DE4 File Offset: 0x000BFFE4
		// (set) Token: 0x0600658C RID: 25996 RVA: 0x000C1E10 File Offset: 0x000C0010
		[ProtoMember(3, IsRequired = false, Name = "goddessGetRewardToday", DataFormat = DataFormat.TwosComplement)]
		public uint goddessGetRewardToday
		{
			get
			{
				return this._goddessGetRewardToday ?? 0U;
			}
			set
			{
				this._goddessGetRewardToday = new uint?(value);
			}
		}

		// Token: 0x1700200B RID: 8203
		// (get) Token: 0x0600658D RID: 25997 RVA: 0x000C1E20 File Offset: 0x000C0020
		// (set) Token: 0x0600658E RID: 25998 RVA: 0x000C1E40 File Offset: 0x000C0040
		[XmlIgnore]
		[Browsable(false)]
		public bool goddessGetRewardTodaySpecified
		{
			get
			{
				return this._goddessGetRewardToday != null;
			}
			set
			{
				bool flag = value == (this._goddessGetRewardToday == null);
				if (flag)
				{
					this._goddessGetRewardToday = (value ? new uint?(this.goddessGetRewardToday) : null);
				}
			}
		}

		// Token: 0x0600658F RID: 25999 RVA: 0x000C1E84 File Offset: 0x000C0084
		private bool ShouldSerializegoddessGetRewardToday()
		{
			return this.goddessGetRewardTodaySpecified;
		}

		// Token: 0x06006590 RID: 26000 RVA: 0x000C1E9C File Offset: 0x000C009C
		private void ResetgoddessGetRewardToday()
		{
			this.goddessGetRewardTodaySpecified = false;
		}

		// Token: 0x1700200C RID: 8204
		// (get) Token: 0x06006591 RID: 26001 RVA: 0x000C1EA8 File Offset: 0x000C00A8
		[ProtoMember(4, Name = "teamcountins", DataFormat = DataFormat.Default)]
		public List<TeamCountInfo> teamcountins
		{
			get
			{
				return this._teamcountins;
			}
		}

		// Token: 0x1700200D RID: 8205
		// (get) Token: 0x06006592 RID: 26002 RVA: 0x000C1EC0 File Offset: 0x000C00C0
		// (set) Token: 0x06006593 RID: 26003 RVA: 0x000C1ED8 File Offset: 0x000C00D8
		[ProtoMember(5, IsRequired = false, Name = "teamcost", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleTeamCostInfo teamcost
		{
			get
			{
				return this._teamcost;
			}
			set
			{
				this._teamcost = value;
			}
		}

		// Token: 0x1700200E RID: 8206
		// (get) Token: 0x06006594 RID: 26004 RVA: 0x000C1EE4 File Offset: 0x000C00E4
		// (set) Token: 0x06006595 RID: 26005 RVA: 0x000C1F10 File Offset: 0x000C0110
		[ProtoMember(6, IsRequired = false, Name = "weeknestrewardcount", DataFormat = DataFormat.TwosComplement)]
		public uint weeknestrewardcount
		{
			get
			{
				return this._weeknestrewardcount ?? 0U;
			}
			set
			{
				this._weeknestrewardcount = new uint?(value);
			}
		}

		// Token: 0x1700200F RID: 8207
		// (get) Token: 0x06006596 RID: 26006 RVA: 0x000C1F20 File Offset: 0x000C0120
		// (set) Token: 0x06006597 RID: 26007 RVA: 0x000C1F40 File Offset: 0x000C0140
		[XmlIgnore]
		[Browsable(false)]
		public bool weeknestrewardcountSpecified
		{
			get
			{
				return this._weeknestrewardcount != null;
			}
			set
			{
				bool flag = value == (this._weeknestrewardcount == null);
				if (flag)
				{
					this._weeknestrewardcount = (value ? new uint?(this.weeknestrewardcount) : null);
				}
			}
		}

		// Token: 0x06006598 RID: 26008 RVA: 0x000C1F84 File Offset: 0x000C0184
		private bool ShouldSerializeweeknestrewardcount()
		{
			return this.weeknestrewardcountSpecified;
		}

		// Token: 0x06006599 RID: 26009 RVA: 0x000C1F9C File Offset: 0x000C019C
		private void Resetweeknestrewardcount()
		{
			this.weeknestrewardcountSpecified = false;
		}

		// Token: 0x17002010 RID: 8208
		// (get) Token: 0x0600659A RID: 26010 RVA: 0x000C1FA8 File Offset: 0x000C01A8
		// (set) Token: 0x0600659B RID: 26011 RVA: 0x000C1FD4 File Offset: 0x000C01D4
		[ProtoMember(7, IsRequired = false, Name = "diamondcostcount", DataFormat = DataFormat.TwosComplement)]
		public uint diamondcostcount
		{
			get
			{
				return this._diamondcostcount ?? 0U;
			}
			set
			{
				this._diamondcostcount = new uint?(value);
			}
		}

		// Token: 0x17002011 RID: 8209
		// (get) Token: 0x0600659C RID: 26012 RVA: 0x000C1FE4 File Offset: 0x000C01E4
		// (set) Token: 0x0600659D RID: 26013 RVA: 0x000C2004 File Offset: 0x000C0204
		[XmlIgnore]
		[Browsable(false)]
		public bool diamondcostcountSpecified
		{
			get
			{
				return this._diamondcostcount != null;
			}
			set
			{
				bool flag = value == (this._diamondcostcount == null);
				if (flag)
				{
					this._diamondcostcount = (value ? new uint?(this.diamondcostcount) : null);
				}
			}
		}

		// Token: 0x0600659E RID: 26014 RVA: 0x000C2048 File Offset: 0x000C0248
		private bool ShouldSerializediamondcostcount()
		{
			return this.diamondcostcountSpecified;
		}

		// Token: 0x0600659F RID: 26015 RVA: 0x000C2060 File Offset: 0x000C0260
		private void Resetdiamondcostcount()
		{
			this.diamondcostcountSpecified = false;
		}

		// Token: 0x17002012 RID: 8210
		// (get) Token: 0x060065A0 RID: 26016 RVA: 0x000C206C File Offset: 0x000C026C
		// (set) Token: 0x060065A1 RID: 26017 RVA: 0x000C2098 File Offset: 0x000C0298
		[ProtoMember(8, IsRequired = false, Name = "useticketcount", DataFormat = DataFormat.TwosComplement)]
		public uint useticketcount
		{
			get
			{
				return this._useticketcount ?? 0U;
			}
			set
			{
				this._useticketcount = new uint?(value);
			}
		}

		// Token: 0x17002013 RID: 8211
		// (get) Token: 0x060065A2 RID: 26018 RVA: 0x000C20A8 File Offset: 0x000C02A8
		// (set) Token: 0x060065A3 RID: 26019 RVA: 0x000C20C8 File Offset: 0x000C02C8
		[XmlIgnore]
		[Browsable(false)]
		public bool useticketcountSpecified
		{
			get
			{
				return this._useticketcount != null;
			}
			set
			{
				bool flag = value == (this._useticketcount == null);
				if (flag)
				{
					this._useticketcount = (value ? new uint?(this.useticketcount) : null);
				}
			}
		}

		// Token: 0x060065A4 RID: 26020 RVA: 0x000C210C File Offset: 0x000C030C
		private bool ShouldSerializeuseticketcount()
		{
			return this.useticketcountSpecified;
		}

		// Token: 0x060065A5 RID: 26021 RVA: 0x000C2124 File Offset: 0x000C0324
		private void Resetuseticketcount()
		{
			this.useticketcountSpecified = false;
		}

		// Token: 0x17002014 RID: 8212
		// (get) Token: 0x060065A6 RID: 26022 RVA: 0x000C2130 File Offset: 0x000C0330
		[ProtoMember(9, Name = "dragonhelpfetchedrew", DataFormat = DataFormat.TwosComplement)]
		public List<int> dragonhelpfetchedrew
		{
			get
			{
				return this._dragonhelpfetchedrew;
			}
		}

		// Token: 0x17002015 RID: 8213
		// (get) Token: 0x060065A7 RID: 26023 RVA: 0x000C2148 File Offset: 0x000C0348
		// (set) Token: 0x060065A8 RID: 26024 RVA: 0x000C2174 File Offset: 0x000C0374
		[ProtoMember(10, IsRequired = false, Name = "wantdragonhelp", DataFormat = DataFormat.Default)]
		public bool wantdragonhelp
		{
			get
			{
				return this._wantdragonhelp ?? false;
			}
			set
			{
				this._wantdragonhelp = new bool?(value);
			}
		}

		// Token: 0x17002016 RID: 8214
		// (get) Token: 0x060065A9 RID: 26025 RVA: 0x000C2184 File Offset: 0x000C0384
		// (set) Token: 0x060065AA RID: 26026 RVA: 0x000C21A4 File Offset: 0x000C03A4
		[XmlIgnore]
		[Browsable(false)]
		public bool wantdragonhelpSpecified
		{
			get
			{
				return this._wantdragonhelp != null;
			}
			set
			{
				bool flag = value == (this._wantdragonhelp == null);
				if (flag)
				{
					this._wantdragonhelp = (value ? new bool?(this.wantdragonhelp) : null);
				}
			}
		}

		// Token: 0x060065AB RID: 26027 RVA: 0x000C21E8 File Offset: 0x000C03E8
		private bool ShouldSerializewantdragonhelp()
		{
			return this.wantdragonhelpSpecified;
		}

		// Token: 0x060065AC RID: 26028 RVA: 0x000C2200 File Offset: 0x000C0400
		private void Resetwantdragonhelp()
		{
			this.wantdragonhelpSpecified = false;
		}

		// Token: 0x17002017 RID: 8215
		// (get) Token: 0x060065AD RID: 26029 RVA: 0x000C220C File Offset: 0x000C040C
		// (set) Token: 0x060065AE RID: 26030 RVA: 0x000C2238 File Offset: 0x000C0438
		[ProtoMember(11, IsRequired = false, Name = "setdiamondnum", DataFormat = DataFormat.TwosComplement)]
		public uint setdiamondnum
		{
			get
			{
				return this._setdiamondnum ?? 0U;
			}
			set
			{
				this._setdiamondnum = new uint?(value);
			}
		}

		// Token: 0x17002018 RID: 8216
		// (get) Token: 0x060065AF RID: 26031 RVA: 0x000C2248 File Offset: 0x000C0448
		// (set) Token: 0x060065B0 RID: 26032 RVA: 0x000C2268 File Offset: 0x000C0468
		[XmlIgnore]
		[Browsable(false)]
		public bool setdiamondnumSpecified
		{
			get
			{
				return this._setdiamondnum != null;
			}
			set
			{
				bool flag = value == (this._setdiamondnum == null);
				if (flag)
				{
					this._setdiamondnum = (value ? new uint?(this.setdiamondnum) : null);
				}
			}
		}

		// Token: 0x060065B1 RID: 26033 RVA: 0x000C22AC File Offset: 0x000C04AC
		private bool ShouldSerializesetdiamondnum()
		{
			return this.setdiamondnumSpecified;
		}

		// Token: 0x060065B2 RID: 26034 RVA: 0x000C22C4 File Offset: 0x000C04C4
		private void Resetsetdiamondnum()
		{
			this.setdiamondnumSpecified = false;
		}

		// Token: 0x060065B3 RID: 26035 RVA: 0x000C22D0 File Offset: 0x000C04D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001897 RID: 6295
		private uint? _lastdayuptime;

		// Token: 0x04001898 RID: 6296
		private uint? _lastweekuptime;

		// Token: 0x04001899 RID: 6297
		private uint? _goddessGetRewardToday;

		// Token: 0x0400189A RID: 6298
		private readonly List<TeamCountInfo> _teamcountins = new List<TeamCountInfo>();

		// Token: 0x0400189B RID: 6299
		private RoleTeamCostInfo _teamcost = null;

		// Token: 0x0400189C RID: 6300
		private uint? _weeknestrewardcount;

		// Token: 0x0400189D RID: 6301
		private uint? _diamondcostcount;

		// Token: 0x0400189E RID: 6302
		private uint? _useticketcount;

		// Token: 0x0400189F RID: 6303
		private readonly List<int> _dragonhelpfetchedrew = new List<int>();

		// Token: 0x040018A0 RID: 6304
		private bool? _wantdragonhelp;

		// Token: 0x040018A1 RID: 6305
		private uint? _setdiamondnum;

		// Token: 0x040018A2 RID: 6306
		private IExtension extensionObject;
	}
}
