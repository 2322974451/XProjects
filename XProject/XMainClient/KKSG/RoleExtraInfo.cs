using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000611 RID: 1553
	[ProtoContract(Name = "RoleExtraInfo")]
	[Serializable]
	public class RoleExtraInfo : IExtensible
	{
		// Token: 0x17001D72 RID: 7538
		// (get) Token: 0x06005DE0 RID: 24032 RVA: 0x000B2EE4 File Offset: 0x000B10E4
		// (set) Token: 0x06005DE1 RID: 24033 RVA: 0x000B2F10 File Offset: 0x000B1110
		[ProtoMember(1, IsRequired = false, Name = "lastLevelUpTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastLevelUpTime
		{
			get
			{
				return this._lastLevelUpTime ?? 0U;
			}
			set
			{
				this._lastLevelUpTime = new uint?(value);
			}
		}

		// Token: 0x17001D73 RID: 7539
		// (get) Token: 0x06005DE2 RID: 24034 RVA: 0x000B2F20 File Offset: 0x000B1120
		// (set) Token: 0x06005DE3 RID: 24035 RVA: 0x000B2F40 File Offset: 0x000B1140
		[XmlIgnore]
		[Browsable(false)]
		public bool lastLevelUpTimeSpecified
		{
			get
			{
				return this._lastLevelUpTime != null;
			}
			set
			{
				bool flag = value == (this._lastLevelUpTime == null);
				if (flag)
				{
					this._lastLevelUpTime = (value ? new uint?(this.lastLevelUpTime) : null);
				}
			}
		}

		// Token: 0x06005DE4 RID: 24036 RVA: 0x000B2F84 File Offset: 0x000B1184
		private bool ShouldSerializelastLevelUpTime()
		{
			return this.lastLevelUpTimeSpecified;
		}

		// Token: 0x06005DE5 RID: 24037 RVA: 0x000B2F9C File Offset: 0x000B119C
		private void ResetlastLevelUpTime()
		{
			this.lastLevelUpTimeSpecified = false;
		}

		// Token: 0x17001D74 RID: 7540
		// (get) Token: 0x06005DE6 RID: 24038 RVA: 0x000B2FA8 File Offset: 0x000B11A8
		// (set) Token: 0x06005DE7 RID: 24039 RVA: 0x000B2FD4 File Offset: 0x000B11D4
		[ProtoMember(2, IsRequired = false, Name = "lastLoginTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastLoginTime
		{
			get
			{
				return this._lastLoginTime ?? 0U;
			}
			set
			{
				this._lastLoginTime = new uint?(value);
			}
		}

		// Token: 0x17001D75 RID: 7541
		// (get) Token: 0x06005DE8 RID: 24040 RVA: 0x000B2FE4 File Offset: 0x000B11E4
		// (set) Token: 0x06005DE9 RID: 24041 RVA: 0x000B3004 File Offset: 0x000B1204
		[XmlIgnore]
		[Browsable(false)]
		public bool lastLoginTimeSpecified
		{
			get
			{
				return this._lastLoginTime != null;
			}
			set
			{
				bool flag = value == (this._lastLoginTime == null);
				if (flag)
				{
					this._lastLoginTime = (value ? new uint?(this.lastLoginTime) : null);
				}
			}
		}

		// Token: 0x06005DEA RID: 24042 RVA: 0x000B3048 File Offset: 0x000B1248
		private bool ShouldSerializelastLoginTime()
		{
			return this.lastLoginTimeSpecified;
		}

		// Token: 0x06005DEB RID: 24043 RVA: 0x000B3060 File Offset: 0x000B1260
		private void ResetlastLoginTime()
		{
			this.lastLoginTimeSpecified = false;
		}

		// Token: 0x17001D76 RID: 7542
		// (get) Token: 0x06005DEC RID: 24044 RVA: 0x000B306C File Offset: 0x000B126C
		// (set) Token: 0x06005DED RID: 24045 RVA: 0x000B3098 File Offset: 0x000B1298
		[ProtoMember(3, IsRequired = false, Name = "lastLogoutTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastLogoutTime
		{
			get
			{
				return this._lastLogoutTime ?? 0U;
			}
			set
			{
				this._lastLogoutTime = new uint?(value);
			}
		}

		// Token: 0x17001D77 RID: 7543
		// (get) Token: 0x06005DEE RID: 24046 RVA: 0x000B30A8 File Offset: 0x000B12A8
		// (set) Token: 0x06005DEF RID: 24047 RVA: 0x000B30C8 File Offset: 0x000B12C8
		[XmlIgnore]
		[Browsable(false)]
		public bool lastLogoutTimeSpecified
		{
			get
			{
				return this._lastLogoutTime != null;
			}
			set
			{
				bool flag = value == (this._lastLogoutTime == null);
				if (flag)
				{
					this._lastLogoutTime = (value ? new uint?(this.lastLogoutTime) : null);
				}
			}
		}

		// Token: 0x06005DF0 RID: 24048 RVA: 0x000B310C File Offset: 0x000B130C
		private bool ShouldSerializelastLogoutTime()
		{
			return this.lastLogoutTimeSpecified;
		}

		// Token: 0x06005DF1 RID: 24049 RVA: 0x000B3124 File Offset: 0x000B1324
		private void ResetlastLogoutTime()
		{
			this.lastLogoutTimeSpecified = false;
		}

		// Token: 0x17001D78 RID: 7544
		// (get) Token: 0x06005DF2 RID: 24050 RVA: 0x000B3130 File Offset: 0x000B1330
		// (set) Token: 0x06005DF3 RID: 24051 RVA: 0x000B315C File Offset: 0x000B135C
		[ProtoMember(4, IsRequired = false, Name = "loginTimes", DataFormat = DataFormat.TwosComplement)]
		public uint loginTimes
		{
			get
			{
				return this._loginTimes ?? 0U;
			}
			set
			{
				this._loginTimes = new uint?(value);
			}
		}

		// Token: 0x17001D79 RID: 7545
		// (get) Token: 0x06005DF4 RID: 24052 RVA: 0x000B316C File Offset: 0x000B136C
		// (set) Token: 0x06005DF5 RID: 24053 RVA: 0x000B318C File Offset: 0x000B138C
		[XmlIgnore]
		[Browsable(false)]
		public bool loginTimesSpecified
		{
			get
			{
				return this._loginTimes != null;
			}
			set
			{
				bool flag = value == (this._loginTimes == null);
				if (flag)
				{
					this._loginTimes = (value ? new uint?(this.loginTimes) : null);
				}
			}
		}

		// Token: 0x06005DF6 RID: 24054 RVA: 0x000B31D0 File Offset: 0x000B13D0
		private bool ShouldSerializeloginTimes()
		{
			return this.loginTimesSpecified;
		}

		// Token: 0x06005DF7 RID: 24055 RVA: 0x000B31E8 File Offset: 0x000B13E8
		private void ResetloginTimes()
		{
			this.loginTimesSpecified = false;
		}

		// Token: 0x17001D7A RID: 7546
		// (get) Token: 0x06005DF8 RID: 24056 RVA: 0x000B31F4 File Offset: 0x000B13F4
		// (set) Token: 0x06005DF9 RID: 24057 RVA: 0x000B3220 File Offset: 0x000B1420
		[ProtoMember(5, IsRequired = false, Name = "lastFatigueRecoverTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastFatigueRecoverTime
		{
			get
			{
				return this._lastFatigueRecoverTime ?? 0U;
			}
			set
			{
				this._lastFatigueRecoverTime = new uint?(value);
			}
		}

		// Token: 0x17001D7B RID: 7547
		// (get) Token: 0x06005DFA RID: 24058 RVA: 0x000B3230 File Offset: 0x000B1430
		// (set) Token: 0x06005DFB RID: 24059 RVA: 0x000B3250 File Offset: 0x000B1450
		[XmlIgnore]
		[Browsable(false)]
		public bool lastFatigueRecoverTimeSpecified
		{
			get
			{
				return this._lastFatigueRecoverTime != null;
			}
			set
			{
				bool flag = value == (this._lastFatigueRecoverTime == null);
				if (flag)
				{
					this._lastFatigueRecoverTime = (value ? new uint?(this.lastFatigueRecoverTime) : null);
				}
			}
		}

		// Token: 0x06005DFC RID: 24060 RVA: 0x000B3294 File Offset: 0x000B1494
		private bool ShouldSerializelastFatigueRecoverTime()
		{
			return this.lastFatigueRecoverTimeSpecified;
		}

		// Token: 0x06005DFD RID: 24061 RVA: 0x000B32AC File Offset: 0x000B14AC
		private void ResetlastFatigueRecoverTime()
		{
			this.lastFatigueRecoverTimeSpecified = false;
		}

		// Token: 0x17001D7C RID: 7548
		// (get) Token: 0x06005DFE RID: 24062 RVA: 0x000B32B8 File Offset: 0x000B14B8
		// (set) Token: 0x06005DFF RID: 24063 RVA: 0x000B32D9 File Offset: 0x000B14D9
		[ProtoMember(6, IsRequired = false, Name = "fristchannel", DataFormat = DataFormat.Default)]
		public string fristchannel
		{
			get
			{
				return this._fristchannel ?? "";
			}
			set
			{
				this._fristchannel = value;
			}
		}

		// Token: 0x17001D7D RID: 7549
		// (get) Token: 0x06005E00 RID: 24064 RVA: 0x000B32E4 File Offset: 0x000B14E4
		// (set) Token: 0x06005E01 RID: 24065 RVA: 0x000B3300 File Offset: 0x000B1500
		[XmlIgnore]
		[Browsable(false)]
		public bool fristchannelSpecified
		{
			get
			{
				return this._fristchannel != null;
			}
			set
			{
				bool flag = value == (this._fristchannel == null);
				if (flag)
				{
					this._fristchannel = (value ? this.fristchannel : null);
				}
			}
		}

		// Token: 0x06005E02 RID: 24066 RVA: 0x000B3330 File Offset: 0x000B1530
		private bool ShouldSerializefristchannel()
		{
			return this.fristchannelSpecified;
		}

		// Token: 0x06005E03 RID: 24067 RVA: 0x000B3348 File Offset: 0x000B1548
		private void Resetfristchannel()
		{
			this.fristchannelSpecified = false;
		}

		// Token: 0x17001D7E RID: 7550
		// (get) Token: 0x06005E04 RID: 24068 RVA: 0x000B3354 File Offset: 0x000B1554
		// (set) Token: 0x06005E05 RID: 24069 RVA: 0x000B3380 File Offset: 0x000B1580
		[ProtoMember(7, IsRequired = false, Name = "channelmask", DataFormat = DataFormat.Default)]
		public bool channelmask
		{
			get
			{
				return this._channelmask ?? false;
			}
			set
			{
				this._channelmask = new bool?(value);
			}
		}

		// Token: 0x17001D7F RID: 7551
		// (get) Token: 0x06005E06 RID: 24070 RVA: 0x000B3390 File Offset: 0x000B1590
		// (set) Token: 0x06005E07 RID: 24071 RVA: 0x000B33B0 File Offset: 0x000B15B0
		[XmlIgnore]
		[Browsable(false)]
		public bool channelmaskSpecified
		{
			get
			{
				return this._channelmask != null;
			}
			set
			{
				bool flag = value == (this._channelmask == null);
				if (flag)
				{
					this._channelmask = (value ? new bool?(this.channelmask) : null);
				}
			}
		}

		// Token: 0x06005E08 RID: 24072 RVA: 0x000B33F4 File Offset: 0x000B15F4
		private bool ShouldSerializechannelmask()
		{
			return this.channelmaskSpecified;
		}

		// Token: 0x06005E09 RID: 24073 RVA: 0x000B340C File Offset: 0x000B160C
		private void Resetchannelmask()
		{
			this.channelmaskSpecified = false;
		}

		// Token: 0x06005E0A RID: 24074 RVA: 0x000B3418 File Offset: 0x000B1618
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016CF RID: 5839
		private uint? _lastLevelUpTime;

		// Token: 0x040016D0 RID: 5840
		private uint? _lastLoginTime;

		// Token: 0x040016D1 RID: 5841
		private uint? _lastLogoutTime;

		// Token: 0x040016D2 RID: 5842
		private uint? _loginTimes;

		// Token: 0x040016D3 RID: 5843
		private uint? _lastFatigueRecoverTime;

		// Token: 0x040016D4 RID: 5844
		private string _fristchannel;

		// Token: 0x040016D5 RID: 5845
		private bool? _channelmask;

		// Token: 0x040016D6 RID: 5846
		private IExtension extensionObject;
	}
}
