using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000589 RID: 1417
	[ProtoContract(Name = "LeagueRankData")]
	[Serializable]
	public class LeagueRankData : IExtensible
	{
		// Token: 0x170016F7 RID: 5879
		// (get) Token: 0x06004AAB RID: 19115 RVA: 0x0008DF6C File Offset: 0x0008C16C
		// (set) Token: 0x06004AAC RID: 19116 RVA: 0x0008DF99 File Offset: 0x0008C199
		[ProtoMember(1, IsRequired = false, Name = "league_teamid", DataFormat = DataFormat.TwosComplement)]
		public ulong league_teamid
		{
			get
			{
				return this._league_teamid ?? 0UL;
			}
			set
			{
				this._league_teamid = new ulong?(value);
			}
		}

		// Token: 0x170016F8 RID: 5880
		// (get) Token: 0x06004AAD RID: 19117 RVA: 0x0008DFA8 File Offset: 0x0008C1A8
		// (set) Token: 0x06004AAE RID: 19118 RVA: 0x0008DFC8 File Offset: 0x0008C1C8
		[XmlIgnore]
		[Browsable(false)]
		public bool league_teamidSpecified
		{
			get
			{
				return this._league_teamid != null;
			}
			set
			{
				bool flag = value == (this._league_teamid == null);
				if (flag)
				{
					this._league_teamid = (value ? new ulong?(this.league_teamid) : null);
				}
			}
		}

		// Token: 0x06004AAF RID: 19119 RVA: 0x0008E00C File Offset: 0x0008C20C
		private bool ShouldSerializeleague_teamid()
		{
			return this.league_teamidSpecified;
		}

		// Token: 0x06004AB0 RID: 19120 RVA: 0x0008E024 File Offset: 0x0008C224
		private void Resetleague_teamid()
		{
			this.league_teamidSpecified = false;
		}

		// Token: 0x170016F9 RID: 5881
		// (get) Token: 0x06004AB1 RID: 19121 RVA: 0x0008E030 File Offset: 0x0008C230
		// (set) Token: 0x06004AB2 RID: 19122 RVA: 0x0008E05C File Offset: 0x0008C25C
		[ProtoMember(2, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		// Token: 0x170016FA RID: 5882
		// (get) Token: 0x06004AB3 RID: 19123 RVA: 0x0008E06C File Offset: 0x0008C26C
		// (set) Token: 0x06004AB4 RID: 19124 RVA: 0x0008E08C File Offset: 0x0008C28C
		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		// Token: 0x06004AB5 RID: 19125 RVA: 0x0008E0D0 File Offset: 0x0008C2D0
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06004AB6 RID: 19126 RVA: 0x0008E0E8 File Offset: 0x0008C2E8
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x170016FB RID: 5883
		// (get) Token: 0x06004AB7 RID: 19127 RVA: 0x0008E0F4 File Offset: 0x0008C2F4
		// (set) Token: 0x06004AB8 RID: 19128 RVA: 0x0008E115 File Offset: 0x0008C315
		[ProtoMember(3, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
		public string servername
		{
			get
			{
				return this._servername ?? "";
			}
			set
			{
				this._servername = value;
			}
		}

		// Token: 0x170016FC RID: 5884
		// (get) Token: 0x06004AB9 RID: 19129 RVA: 0x0008E120 File Offset: 0x0008C320
		// (set) Token: 0x06004ABA RID: 19130 RVA: 0x0008E13C File Offset: 0x0008C33C
		[XmlIgnore]
		[Browsable(false)]
		public bool servernameSpecified
		{
			get
			{
				return this._servername != null;
			}
			set
			{
				bool flag = value == (this._servername == null);
				if (flag)
				{
					this._servername = (value ? this.servername : null);
				}
			}
		}

		// Token: 0x06004ABB RID: 19131 RVA: 0x0008E16C File Offset: 0x0008C36C
		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		// Token: 0x06004ABC RID: 19132 RVA: 0x0008E184 File Offset: 0x0008C384
		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		// Token: 0x170016FD RID: 5885
		// (get) Token: 0x06004ABD RID: 19133 RVA: 0x0008E190 File Offset: 0x0008C390
		// (set) Token: 0x06004ABE RID: 19134 RVA: 0x0008E1B1 File Offset: 0x0008C3B1
		[ProtoMember(4, IsRequired = false, Name = "teamname", DataFormat = DataFormat.Default)]
		public string teamname
		{
			get
			{
				return this._teamname ?? "";
			}
			set
			{
				this._teamname = value;
			}
		}

		// Token: 0x170016FE RID: 5886
		// (get) Token: 0x06004ABF RID: 19135 RVA: 0x0008E1BC File Offset: 0x0008C3BC
		// (set) Token: 0x06004AC0 RID: 19136 RVA: 0x0008E1D8 File Offset: 0x0008C3D8
		[XmlIgnore]
		[Browsable(false)]
		public bool teamnameSpecified
		{
			get
			{
				return this._teamname != null;
			}
			set
			{
				bool flag = value == (this._teamname == null);
				if (flag)
				{
					this._teamname = (value ? this.teamname : null);
				}
			}
		}

		// Token: 0x06004AC1 RID: 19137 RVA: 0x0008E208 File Offset: 0x0008C408
		private bool ShouldSerializeteamname()
		{
			return this.teamnameSpecified;
		}

		// Token: 0x06004AC2 RID: 19138 RVA: 0x0008E220 File Offset: 0x0008C420
		private void Resetteamname()
		{
			this.teamnameSpecified = false;
		}

		// Token: 0x170016FF RID: 5887
		// (get) Token: 0x06004AC3 RID: 19139 RVA: 0x0008E22C File Offset: 0x0008C42C
		// (set) Token: 0x06004AC4 RID: 19140 RVA: 0x0008E258 File Offset: 0x0008C458
		[ProtoMember(5, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x17001700 RID: 5888
		// (get) Token: 0x06004AC5 RID: 19141 RVA: 0x0008E268 File Offset: 0x0008C468
		// (set) Token: 0x06004AC6 RID: 19142 RVA: 0x0008E288 File Offset: 0x0008C488
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06004AC7 RID: 19143 RVA: 0x0008E2CC File Offset: 0x0008C4CC
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06004AC8 RID: 19144 RVA: 0x0008E2E4 File Offset: 0x0008C4E4
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17001701 RID: 5889
		// (get) Token: 0x06004AC9 RID: 19145 RVA: 0x0008E2F0 File Offset: 0x0008C4F0
		// (set) Token: 0x06004ACA RID: 19146 RVA: 0x0008E31C File Offset: 0x0008C51C
		[ProtoMember(6, IsRequired = false, Name = "winnum", DataFormat = DataFormat.TwosComplement)]
		public uint winnum
		{
			get
			{
				return this._winnum ?? 0U;
			}
			set
			{
				this._winnum = new uint?(value);
			}
		}

		// Token: 0x17001702 RID: 5890
		// (get) Token: 0x06004ACB RID: 19147 RVA: 0x0008E32C File Offset: 0x0008C52C
		// (set) Token: 0x06004ACC RID: 19148 RVA: 0x0008E34C File Offset: 0x0008C54C
		[XmlIgnore]
		[Browsable(false)]
		public bool winnumSpecified
		{
			get
			{
				return this._winnum != null;
			}
			set
			{
				bool flag = value == (this._winnum == null);
				if (flag)
				{
					this._winnum = (value ? new uint?(this.winnum) : null);
				}
			}
		}

		// Token: 0x06004ACD RID: 19149 RVA: 0x0008E390 File Offset: 0x0008C590
		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		// Token: 0x06004ACE RID: 19150 RVA: 0x0008E3A8 File Offset: 0x0008C5A8
		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		// Token: 0x17001703 RID: 5891
		// (get) Token: 0x06004ACF RID: 19151 RVA: 0x0008E3B4 File Offset: 0x0008C5B4
		// (set) Token: 0x06004AD0 RID: 19152 RVA: 0x0008E3E4 File Offset: 0x0008C5E4
		[ProtoMember(7, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
		public float winrate
		{
			get
			{
				return this._winrate ?? 0f;
			}
			set
			{
				this._winrate = new float?(value);
			}
		}

		// Token: 0x17001704 RID: 5892
		// (get) Token: 0x06004AD1 RID: 19153 RVA: 0x0008E3F4 File Offset: 0x0008C5F4
		// (set) Token: 0x06004AD2 RID: 19154 RVA: 0x0008E414 File Offset: 0x0008C614
		[XmlIgnore]
		[Browsable(false)]
		public bool winrateSpecified
		{
			get
			{
				return this._winrate != null;
			}
			set
			{
				bool flag = value == (this._winrate == null);
				if (flag)
				{
					this._winrate = (value ? new float?(this.winrate) : null);
				}
			}
		}

		// Token: 0x06004AD3 RID: 19155 RVA: 0x0008E458 File Offset: 0x0008C658
		private bool ShouldSerializewinrate()
		{
			return this.winrateSpecified;
		}

		// Token: 0x06004AD4 RID: 19156 RVA: 0x0008E470 File Offset: 0x0008C670
		private void Resetwinrate()
		{
			this.winrateSpecified = false;
		}

		// Token: 0x17001705 RID: 5893
		// (get) Token: 0x06004AD5 RID: 19157 RVA: 0x0008E47C File Offset: 0x0008C67C
		// (set) Token: 0x06004AD6 RID: 19158 RVA: 0x0008E4A8 File Offset: 0x0008C6A8
		[ProtoMember(8, IsRequired = false, Name = "continuewin", DataFormat = DataFormat.TwosComplement)]
		public uint continuewin
		{
			get
			{
				return this._continuewin ?? 0U;
			}
			set
			{
				this._continuewin = new uint?(value);
			}
		}

		// Token: 0x17001706 RID: 5894
		// (get) Token: 0x06004AD7 RID: 19159 RVA: 0x0008E4B8 File Offset: 0x0008C6B8
		// (set) Token: 0x06004AD8 RID: 19160 RVA: 0x0008E4D8 File Offset: 0x0008C6D8
		[XmlIgnore]
		[Browsable(false)]
		public bool continuewinSpecified
		{
			get
			{
				return this._continuewin != null;
			}
			set
			{
				bool flag = value == (this._continuewin == null);
				if (flag)
				{
					this._continuewin = (value ? new uint?(this.continuewin) : null);
				}
			}
		}

		// Token: 0x06004AD9 RID: 19161 RVA: 0x0008E51C File Offset: 0x0008C71C
		private bool ShouldSerializecontinuewin()
		{
			return this.continuewinSpecified;
		}

		// Token: 0x06004ADA RID: 19162 RVA: 0x0008E534 File Offset: 0x0008C734
		private void Resetcontinuewin()
		{
			this.continuewinSpecified = false;
		}

		// Token: 0x17001707 RID: 5895
		// (get) Token: 0x06004ADB RID: 19163 RVA: 0x0008E540 File Offset: 0x0008C740
		// (set) Token: 0x06004ADC RID: 19164 RVA: 0x0008E56C File Offset: 0x0008C76C
		[ProtoMember(9, IsRequired = false, Name = "joincount", DataFormat = DataFormat.TwosComplement)]
		public uint joincount
		{
			get
			{
				return this._joincount ?? 0U;
			}
			set
			{
				this._joincount = new uint?(value);
			}
		}

		// Token: 0x17001708 RID: 5896
		// (get) Token: 0x06004ADD RID: 19165 RVA: 0x0008E57C File Offset: 0x0008C77C
		// (set) Token: 0x06004ADE RID: 19166 RVA: 0x0008E59C File Offset: 0x0008C79C
		[XmlIgnore]
		[Browsable(false)]
		public bool joincountSpecified
		{
			get
			{
				return this._joincount != null;
			}
			set
			{
				bool flag = value == (this._joincount == null);
				if (flag)
				{
					this._joincount = (value ? new uint?(this.joincount) : null);
				}
			}
		}

		// Token: 0x06004ADF RID: 19167 RVA: 0x0008E5E0 File Offset: 0x0008C7E0
		private bool ShouldSerializejoincount()
		{
			return this.joincountSpecified;
		}

		// Token: 0x06004AE0 RID: 19168 RVA: 0x0008E5F8 File Offset: 0x0008C7F8
		private void Resetjoincount()
		{
			this.joincountSpecified = false;
		}

		// Token: 0x06004AE1 RID: 19169 RVA: 0x0008E604 File Offset: 0x0008C804
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001299 RID: 4761
		private ulong? _league_teamid;

		// Token: 0x0400129A RID: 4762
		private uint? _serverid;

		// Token: 0x0400129B RID: 4763
		private string _servername;

		// Token: 0x0400129C RID: 4764
		private string _teamname;

		// Token: 0x0400129D RID: 4765
		private uint? _point;

		// Token: 0x0400129E RID: 4766
		private uint? _winnum;

		// Token: 0x0400129F RID: 4767
		private float? _winrate;

		// Token: 0x040012A0 RID: 4768
		private uint? _continuewin;

		// Token: 0x040012A1 RID: 4769
		private uint? _joincount;

		// Token: 0x040012A2 RID: 4770
		private IExtension extensionObject;
	}
}
