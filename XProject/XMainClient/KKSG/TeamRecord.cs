using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamRecord")]
	[Serializable]
	public class TeamRecord : IExtensible
	{

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

		private bool ShouldSerializelastdayuptime()
		{
			return this.lastdayuptimeSpecified;
		}

		private void Resetlastdayuptime()
		{
			this.lastdayuptimeSpecified = false;
		}

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

		private bool ShouldSerializelastweekuptime()
		{
			return this.lastweekuptimeSpecified;
		}

		private void Resetlastweekuptime()
		{
			this.lastweekuptimeSpecified = false;
		}

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

		private bool ShouldSerializegoddessGetRewardToday()
		{
			return this.goddessGetRewardTodaySpecified;
		}

		private void ResetgoddessGetRewardToday()
		{
			this.goddessGetRewardTodaySpecified = false;
		}

		[ProtoMember(4, Name = "teamcountins", DataFormat = DataFormat.Default)]
		public List<TeamCountInfo> teamcountins
		{
			get
			{
				return this._teamcountins;
			}
		}

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

		private bool ShouldSerializeweeknestrewardcount()
		{
			return this.weeknestrewardcountSpecified;
		}

		private void Resetweeknestrewardcount()
		{
			this.weeknestrewardcountSpecified = false;
		}

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

		private bool ShouldSerializediamondcostcount()
		{
			return this.diamondcostcountSpecified;
		}

		private void Resetdiamondcostcount()
		{
			this.diamondcostcountSpecified = false;
		}

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

		private bool ShouldSerializeuseticketcount()
		{
			return this.useticketcountSpecified;
		}

		private void Resetuseticketcount()
		{
			this.useticketcountSpecified = false;
		}

		[ProtoMember(9, Name = "dragonhelpfetchedrew", DataFormat = DataFormat.TwosComplement)]
		public List<int> dragonhelpfetchedrew
		{
			get
			{
				return this._dragonhelpfetchedrew;
			}
		}

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

		private bool ShouldSerializewantdragonhelp()
		{
			return this.wantdragonhelpSpecified;
		}

		private void Resetwantdragonhelp()
		{
			this.wantdragonhelpSpecified = false;
		}

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

		private bool ShouldSerializesetdiamondnum()
		{
			return this.setdiamondnumSpecified;
		}

		private void Resetsetdiamondnum()
		{
			this.setdiamondnumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lastdayuptime;

		private uint? _lastweekuptime;

		private uint? _goddessGetRewardToday;

		private readonly List<TeamCountInfo> _teamcountins = new List<TeamCountInfo>();

		private RoleTeamCostInfo _teamcost = null;

		private uint? _weeknestrewardcount;

		private uint? _diamondcostcount;

		private uint? _useticketcount;

		private readonly List<int> _dragonhelpfetchedrew = new List<int>();

		private bool? _wantdragonhelp;

		private uint? _setdiamondnum;

		private IExtension extensionObject;
	}
}
