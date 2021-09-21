using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005BF RID: 1471
	[ProtoContract(Name = "BattleData")]
	[Serializable]
	public class BattleData : IExtensible
	{
		// Token: 0x17001971 RID: 6513
		// (get) Token: 0x0600524A RID: 21066 RVA: 0x0009C868 File Offset: 0x0009AA68
		// (set) Token: 0x0600524B RID: 21067 RVA: 0x0009C894 File Offset: 0x0009AA94
		[ProtoMember(1, IsRequired = false, Name = "timespan", DataFormat = DataFormat.TwosComplement)]
		public int timespan
		{
			get
			{
				return this._timespan ?? 0;
			}
			set
			{
				this._timespan = new int?(value);
			}
		}

		// Token: 0x17001972 RID: 6514
		// (get) Token: 0x0600524C RID: 21068 RVA: 0x0009C8A4 File Offset: 0x0009AAA4
		// (set) Token: 0x0600524D RID: 21069 RVA: 0x0009C8C4 File Offset: 0x0009AAC4
		[XmlIgnore]
		[Browsable(false)]
		public bool timespanSpecified
		{
			get
			{
				return this._timespan != null;
			}
			set
			{
				bool flag = value == (this._timespan == null);
				if (flag)
				{
					this._timespan = (value ? new int?(this.timespan) : null);
				}
			}
		}

		// Token: 0x0600524E RID: 21070 RVA: 0x0009C908 File Offset: 0x0009AB08
		private bool ShouldSerializetimespan()
		{
			return this.timespanSpecified;
		}

		// Token: 0x0600524F RID: 21071 RVA: 0x0009C920 File Offset: 0x0009AB20
		private void Resettimespan()
		{
			this.timespanSpecified = false;
		}

		// Token: 0x17001973 RID: 6515
		// (get) Token: 0x06005250 RID: 21072 RVA: 0x0009C92C File Offset: 0x0009AB2C
		[ProtoMember(2, Name = "pickDoodadWaveID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> pickDoodadWaveID
		{
			get
			{
				return this._pickDoodadWaveID;
			}
		}

		// Token: 0x17001974 RID: 6516
		// (get) Token: 0x06005251 RID: 21073 RVA: 0x0009C944 File Offset: 0x0009AB44
		// (set) Token: 0x06005252 RID: 21074 RVA: 0x0009C970 File Offset: 0x0009AB70
		[ProtoMember(3, IsRequired = false, Name = "Combo", DataFormat = DataFormat.TwosComplement)]
		public int Combo
		{
			get
			{
				return this._Combo ?? 0;
			}
			set
			{
				this._Combo = new int?(value);
			}
		}

		// Token: 0x17001975 RID: 6517
		// (get) Token: 0x06005253 RID: 21075 RVA: 0x0009C980 File Offset: 0x0009AB80
		// (set) Token: 0x06005254 RID: 21076 RVA: 0x0009C9A0 File Offset: 0x0009ABA0
		[XmlIgnore]
		[Browsable(false)]
		public bool ComboSpecified
		{
			get
			{
				return this._Combo != null;
			}
			set
			{
				bool flag = value == (this._Combo == null);
				if (flag)
				{
					this._Combo = (value ? new int?(this.Combo) : null);
				}
			}
		}

		// Token: 0x06005255 RID: 21077 RVA: 0x0009C9E4 File Offset: 0x0009ABE4
		private bool ShouldSerializeCombo()
		{
			return this.ComboSpecified;
		}

		// Token: 0x06005256 RID: 21078 RVA: 0x0009C9FC File Offset: 0x0009ABFC
		private void ResetCombo()
		{
			this.ComboSpecified = false;
		}

		// Token: 0x17001976 RID: 6518
		// (get) Token: 0x06005257 RID: 21079 RVA: 0x0009CA08 File Offset: 0x0009AC08
		// (set) Token: 0x06005258 RID: 21080 RVA: 0x0009CA34 File Offset: 0x0009AC34
		[ProtoMember(4, IsRequired = false, Name = "BeHit", DataFormat = DataFormat.TwosComplement)]
		public int BeHit
		{
			get
			{
				return this._BeHit ?? 0;
			}
			set
			{
				this._BeHit = new int?(value);
			}
		}

		// Token: 0x17001977 RID: 6519
		// (get) Token: 0x06005259 RID: 21081 RVA: 0x0009CA44 File Offset: 0x0009AC44
		// (set) Token: 0x0600525A RID: 21082 RVA: 0x0009CA64 File Offset: 0x0009AC64
		[XmlIgnore]
		[Browsable(false)]
		public bool BeHitSpecified
		{
			get
			{
				return this._BeHit != null;
			}
			set
			{
				bool flag = value == (this._BeHit == null);
				if (flag)
				{
					this._BeHit = (value ? new int?(this.BeHit) : null);
				}
			}
		}

		// Token: 0x0600525B RID: 21083 RVA: 0x0009CAA8 File Offset: 0x0009ACA8
		private bool ShouldSerializeBeHit()
		{
			return this.BeHitSpecified;
		}

		// Token: 0x0600525C RID: 21084 RVA: 0x0009CAC0 File Offset: 0x0009ACC0
		private void ResetBeHit()
		{
			this.BeHitSpecified = false;
		}

		// Token: 0x17001978 RID: 6520
		// (get) Token: 0x0600525D RID: 21085 RVA: 0x0009CACC File Offset: 0x0009ACCC
		// (set) Token: 0x0600525E RID: 21086 RVA: 0x0009CAF8 File Offset: 0x0009ACF8
		[ProtoMember(5, IsRequired = false, Name = "hppercent", DataFormat = DataFormat.TwosComplement)]
		public uint hppercent
		{
			get
			{
				return this._hppercent ?? 0U;
			}
			set
			{
				this._hppercent = new uint?(value);
			}
		}

		// Token: 0x17001979 RID: 6521
		// (get) Token: 0x0600525F RID: 21087 RVA: 0x0009CB08 File Offset: 0x0009AD08
		// (set) Token: 0x06005260 RID: 21088 RVA: 0x0009CB28 File Offset: 0x0009AD28
		[XmlIgnore]
		[Browsable(false)]
		public bool hppercentSpecified
		{
			get
			{
				return this._hppercent != null;
			}
			set
			{
				bool flag = value == (this._hppercent == null);
				if (flag)
				{
					this._hppercent = (value ? new uint?(this.hppercent) : null);
				}
			}
		}

		// Token: 0x06005261 RID: 21089 RVA: 0x0009CB6C File Offset: 0x0009AD6C
		private bool ShouldSerializehppercent()
		{
			return this.hppercentSpecified;
		}

		// Token: 0x06005262 RID: 21090 RVA: 0x0009CB84 File Offset: 0x0009AD84
		private void Resethppercent()
		{
			this.hppercentSpecified = false;
		}

		// Token: 0x1700197A RID: 6522
		// (get) Token: 0x06005263 RID: 21091 RVA: 0x0009CB90 File Offset: 0x0009AD90
		[ProtoMember(6, Name = "smallmonster", DataFormat = DataFormat.TwosComplement)]
		public List<uint> smallmonster
		{
			get
			{
				return this._smallmonster;
			}
		}

		// Token: 0x1700197B RID: 6523
		// (get) Token: 0x06005264 RID: 21092 RVA: 0x0009CBA8 File Offset: 0x0009ADA8
		[ProtoMember(7, Name = "bossrush", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bossrush
		{
			get
			{
				return this._bossrush;
			}
		}

		// Token: 0x1700197C RID: 6524
		// (get) Token: 0x06005265 RID: 21093 RVA: 0x0009CBC0 File Offset: 0x0009ADC0
		// (set) Token: 0x06005266 RID: 21094 RVA: 0x0009CBEC File Offset: 0x0009ADEC
		[ProtoMember(8, IsRequired = false, Name = "OpenChest", DataFormat = DataFormat.TwosComplement)]
		public int OpenChest
		{
			get
			{
				return this._OpenChest ?? 0;
			}
			set
			{
				this._OpenChest = new int?(value);
			}
		}

		// Token: 0x1700197D RID: 6525
		// (get) Token: 0x06005267 RID: 21095 RVA: 0x0009CBFC File Offset: 0x0009ADFC
		// (set) Token: 0x06005268 RID: 21096 RVA: 0x0009CC1C File Offset: 0x0009AE1C
		[XmlIgnore]
		[Browsable(false)]
		public bool OpenChestSpecified
		{
			get
			{
				return this._OpenChest != null;
			}
			set
			{
				bool flag = value == (this._OpenChest == null);
				if (flag)
				{
					this._OpenChest = (value ? new int?(this.OpenChest) : null);
				}
			}
		}

		// Token: 0x06005269 RID: 21097 RVA: 0x0009CC60 File Offset: 0x0009AE60
		private bool ShouldSerializeOpenChest()
		{
			return this.OpenChestSpecified;
		}

		// Token: 0x0600526A RID: 21098 RVA: 0x0009CC78 File Offset: 0x0009AE78
		private void ResetOpenChest()
		{
			this.OpenChestSpecified = false;
		}

		// Token: 0x1700197E RID: 6526
		// (get) Token: 0x0600526B RID: 21099 RVA: 0x0009CC84 File Offset: 0x0009AE84
		// (set) Token: 0x0600526C RID: 21100 RVA: 0x0009CC9C File Offset: 0x0009AE9C
		[ProtoMember(9, IsRequired = false, Name = "anticheatInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CliAntiCheatInfo anticheatInfo
		{
			get
			{
				return this._anticheatInfo;
			}
			set
			{
				this._anticheatInfo = value;
			}
		}

		// Token: 0x1700197F RID: 6527
		// (get) Token: 0x0600526D RID: 21101 RVA: 0x0009CCA8 File Offset: 0x0009AEA8
		// (set) Token: 0x0600526E RID: 21102 RVA: 0x0009CCD4 File Offset: 0x0009AED4
		[ProtoMember(10, IsRequired = false, Name = "isfailed", DataFormat = DataFormat.Default)]
		public bool isfailed
		{
			get
			{
				return this._isfailed ?? false;
			}
			set
			{
				this._isfailed = new bool?(value);
			}
		}

		// Token: 0x17001980 RID: 6528
		// (get) Token: 0x0600526F RID: 21103 RVA: 0x0009CCE4 File Offset: 0x0009AEE4
		// (set) Token: 0x06005270 RID: 21104 RVA: 0x0009CD04 File Offset: 0x0009AF04
		[XmlIgnore]
		[Browsable(false)]
		public bool isfailedSpecified
		{
			get
			{
				return this._isfailed != null;
			}
			set
			{
				bool flag = value == (this._isfailed == null);
				if (flag)
				{
					this._isfailed = (value ? new bool?(this.isfailed) : null);
				}
			}
		}

		// Token: 0x06005271 RID: 21105 RVA: 0x0009CD48 File Offset: 0x0009AF48
		private bool ShouldSerializeisfailed()
		{
			return this.isfailedSpecified;
		}

		// Token: 0x06005272 RID: 21106 RVA: 0x0009CD60 File Offset: 0x0009AF60
		private void Resetisfailed()
		{
			this.isfailedSpecified = false;
		}

		// Token: 0x17001981 RID: 6529
		// (get) Token: 0x06005273 RID: 21107 RVA: 0x0009CD6C File Offset: 0x0009AF6C
		// (set) Token: 0x06005274 RID: 21108 RVA: 0x0009CD84 File Offset: 0x0009AF84
		[ProtoMember(11, IsRequired = false, Name = "failedinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BattleFailedData failedinfo
		{
			get
			{
				return this._failedinfo;
			}
			set
			{
				this._failedinfo = value;
			}
		}

		// Token: 0x17001982 RID: 6530
		// (get) Token: 0x06005275 RID: 21109 RVA: 0x0009CD90 File Offset: 0x0009AF90
		// (set) Token: 0x06005276 RID: 21110 RVA: 0x0009CDBC File Offset: 0x0009AFBC
		[ProtoMember(12, IsRequired = false, Name = "found", DataFormat = DataFormat.TwosComplement)]
		public uint found
		{
			get
			{
				return this._found ?? 0U;
			}
			set
			{
				this._found = new uint?(value);
			}
		}

		// Token: 0x17001983 RID: 6531
		// (get) Token: 0x06005277 RID: 21111 RVA: 0x0009CDCC File Offset: 0x0009AFCC
		// (set) Token: 0x06005278 RID: 21112 RVA: 0x0009CDEC File Offset: 0x0009AFEC
		[XmlIgnore]
		[Browsable(false)]
		public bool foundSpecified
		{
			get
			{
				return this._found != null;
			}
			set
			{
				bool flag = value == (this._found == null);
				if (flag)
				{
					this._found = (value ? new uint?(this.found) : null);
				}
			}
		}

		// Token: 0x06005279 RID: 21113 RVA: 0x0009CE30 File Offset: 0x0009B030
		private bool ShouldSerializefound()
		{
			return this.foundSpecified;
		}

		// Token: 0x0600527A RID: 21114 RVA: 0x0009CE48 File Offset: 0x0009B048
		private void Resetfound()
		{
			this.foundSpecified = false;
		}

		// Token: 0x17001984 RID: 6532
		// (get) Token: 0x0600527B RID: 21115 RVA: 0x0009CE54 File Offset: 0x0009B054
		// (set) Token: 0x0600527C RID: 21116 RVA: 0x0009CE80 File Offset: 0x0009B080
		[ProtoMember(13, IsRequired = false, Name = "npchp", DataFormat = DataFormat.TwosComplement)]
		public uint npchp
		{
			get
			{
				return this._npchp ?? 0U;
			}
			set
			{
				this._npchp = new uint?(value);
			}
		}

		// Token: 0x17001985 RID: 6533
		// (get) Token: 0x0600527D RID: 21117 RVA: 0x0009CE90 File Offset: 0x0009B090
		// (set) Token: 0x0600527E RID: 21118 RVA: 0x0009CEB0 File Offset: 0x0009B0B0
		[XmlIgnore]
		[Browsable(false)]
		public bool npchpSpecified
		{
			get
			{
				return this._npchp != null;
			}
			set
			{
				bool flag = value == (this._npchp == null);
				if (flag)
				{
					this._npchp = (value ? new uint?(this.npchp) : null);
				}
			}
		}

		// Token: 0x0600527F RID: 21119 RVA: 0x0009CEF4 File Offset: 0x0009B0F4
		private bool ShouldSerializenpchp()
		{
			return this.npchpSpecified;
		}

		// Token: 0x06005280 RID: 21120 RVA: 0x0009CF0C File Offset: 0x0009B10C
		private void Resetnpchp()
		{
			this.npchpSpecified = false;
		}

		// Token: 0x17001986 RID: 6534
		// (get) Token: 0x06005281 RID: 21121 RVA: 0x0009CF18 File Offset: 0x0009B118
		[ProtoMember(14, Name = "monster_id", DataFormat = DataFormat.TwosComplement)]
		public List<uint> monster_id
		{
			get
			{
				return this._monster_id;
			}
		}

		// Token: 0x17001987 RID: 6535
		// (get) Token: 0x06005282 RID: 21122 RVA: 0x0009CF30 File Offset: 0x0009B130
		[ProtoMember(15, Name = "monster_num", DataFormat = DataFormat.TwosComplement)]
		public List<uint> monster_num
		{
			get
			{
				return this._monster_num;
			}
		}

		// Token: 0x06005283 RID: 21123 RVA: 0x0009CF48 File Offset: 0x0009B148
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001420 RID: 5152
		private int? _timespan;

		// Token: 0x04001421 RID: 5153
		private readonly List<uint> _pickDoodadWaveID = new List<uint>();

		// Token: 0x04001422 RID: 5154
		private int? _Combo;

		// Token: 0x04001423 RID: 5155
		private int? _BeHit;

		// Token: 0x04001424 RID: 5156
		private uint? _hppercent;

		// Token: 0x04001425 RID: 5157
		private readonly List<uint> _smallmonster = new List<uint>();

		// Token: 0x04001426 RID: 5158
		private readonly List<uint> _bossrush = new List<uint>();

		// Token: 0x04001427 RID: 5159
		private int? _OpenChest;

		// Token: 0x04001428 RID: 5160
		private CliAntiCheatInfo _anticheatInfo = null;

		// Token: 0x04001429 RID: 5161
		private bool? _isfailed;

		// Token: 0x0400142A RID: 5162
		private BattleFailedData _failedinfo = null;

		// Token: 0x0400142B RID: 5163
		private uint? _found;

		// Token: 0x0400142C RID: 5164
		private uint? _npchp;

		// Token: 0x0400142D RID: 5165
		private readonly List<uint> _monster_id = new List<uint>();

		// Token: 0x0400142E RID: 5166
		private readonly List<uint> _monster_num = new List<uint>();

		// Token: 0x0400142F RID: 5167
		private IExtension extensionObject;
	}
}
