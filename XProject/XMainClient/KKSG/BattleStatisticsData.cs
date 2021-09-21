using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000698 RID: 1688
	[ProtoContract(Name = "BattleStatisticsData")]
	[Serializable]
	public class BattleStatisticsData : IExtensible
	{
		// Token: 0x170022AD RID: 8877
		// (get) Token: 0x06006D8F RID: 28047 RVA: 0x000D19F8 File Offset: 0x000CFBF8
		// (set) Token: 0x06006D90 RID: 28048 RVA: 0x000D1A25 File Offset: 0x000CFC25
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x170022AE RID: 8878
		// (get) Token: 0x06006D91 RID: 28049 RVA: 0x000D1A34 File Offset: 0x000CFC34
		// (set) Token: 0x06006D92 RID: 28050 RVA: 0x000D1A54 File Offset: 0x000CFC54
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06006D93 RID: 28051 RVA: 0x000D1A98 File Offset: 0x000CFC98
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06006D94 RID: 28052 RVA: 0x000D1AB0 File Offset: 0x000CFCB0
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170022AF RID: 8879
		// (get) Token: 0x06006D95 RID: 28053 RVA: 0x000D1ABC File Offset: 0x000CFCBC
		// (set) Token: 0x06006D96 RID: 28054 RVA: 0x000D1ADD File Offset: 0x000CFCDD
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x170022B0 RID: 8880
		// (get) Token: 0x06006D97 RID: 28055 RVA: 0x000D1AE8 File Offset: 0x000CFCE8
		// (set) Token: 0x06006D98 RID: 28056 RVA: 0x000D1B04 File Offset: 0x000CFD04
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06006D99 RID: 28057 RVA: 0x000D1B34 File Offset: 0x000CFD34
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06006D9A RID: 28058 RVA: 0x000D1B4C File Offset: 0x000CFD4C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170022B1 RID: 8881
		// (get) Token: 0x06006D9B RID: 28059 RVA: 0x000D1B58 File Offset: 0x000CFD58
		// (set) Token: 0x06006D9C RID: 28060 RVA: 0x000D1B84 File Offset: 0x000CFD84
		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x170022B2 RID: 8882
		// (get) Token: 0x06006D9D RID: 28061 RVA: 0x000D1B94 File Offset: 0x000CFD94
		// (set) Token: 0x06006D9E RID: 28062 RVA: 0x000D1BB4 File Offset: 0x000CFDB4
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06006D9F RID: 28063 RVA: 0x000D1BF8 File Offset: 0x000CFDF8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06006DA0 RID: 28064 RVA: 0x000D1C10 File Offset: 0x000CFE10
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170022B3 RID: 8883
		// (get) Token: 0x06006DA1 RID: 28065 RVA: 0x000D1C1C File Offset: 0x000CFE1C
		// (set) Token: 0x06006DA2 RID: 28066 RVA: 0x000D1C48 File Offset: 0x000CFE48
		[ProtoMember(4, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x170022B4 RID: 8884
		// (get) Token: 0x06006DA3 RID: 28067 RVA: 0x000D1C58 File Offset: 0x000CFE58
		// (set) Token: 0x06006DA4 RID: 28068 RVA: 0x000D1C78 File Offset: 0x000CFE78
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x06006DA5 RID: 28069 RVA: 0x000D1CBC File Offset: 0x000CFEBC
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06006DA6 RID: 28070 RVA: 0x000D1CD4 File Offset: 0x000CFED4
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x170022B5 RID: 8885
		// (get) Token: 0x06006DA7 RID: 28071 RVA: 0x000D1CE0 File Offset: 0x000CFEE0
		// (set) Token: 0x06006DA8 RID: 28072 RVA: 0x000D1D14 File Offset: 0x000CFF14
		[ProtoMember(5, IsRequired = false, Name = "damageall", DataFormat = DataFormat.TwosComplement)]
		public double damageall
		{
			get
			{
				return this._damageall ?? 0.0;
			}
			set
			{
				this._damageall = new double?(value);
			}
		}

		// Token: 0x170022B6 RID: 8886
		// (get) Token: 0x06006DA9 RID: 28073 RVA: 0x000D1D24 File Offset: 0x000CFF24
		// (set) Token: 0x06006DAA RID: 28074 RVA: 0x000D1D44 File Offset: 0x000CFF44
		[XmlIgnore]
		[Browsable(false)]
		public bool damageallSpecified
		{
			get
			{
				return this._damageall != null;
			}
			set
			{
				bool flag = value == (this._damageall == null);
				if (flag)
				{
					this._damageall = (value ? new double?(this.damageall) : null);
				}
			}
		}

		// Token: 0x06006DAB RID: 28075 RVA: 0x000D1D88 File Offset: 0x000CFF88
		private bool ShouldSerializedamageall()
		{
			return this.damageallSpecified;
		}

		// Token: 0x06006DAC RID: 28076 RVA: 0x000D1DA0 File Offset: 0x000CFFA0
		private void Resetdamageall()
		{
			this.damageallSpecified = false;
		}

		// Token: 0x170022B7 RID: 8887
		// (get) Token: 0x06006DAD RID: 28077 RVA: 0x000D1DAC File Offset: 0x000CFFAC
		// (set) Token: 0x06006DAE RID: 28078 RVA: 0x000D1DD8 File Offset: 0x000CFFD8
		[ProtoMember(6, IsRequired = false, Name = "deadcount", DataFormat = DataFormat.TwosComplement)]
		public uint deadcount
		{
			get
			{
				return this._deadcount ?? 0U;
			}
			set
			{
				this._deadcount = new uint?(value);
			}
		}

		// Token: 0x170022B8 RID: 8888
		// (get) Token: 0x06006DAF RID: 28079 RVA: 0x000D1DE8 File Offset: 0x000CFFE8
		// (set) Token: 0x06006DB0 RID: 28080 RVA: 0x000D1E08 File Offset: 0x000D0008
		[XmlIgnore]
		[Browsable(false)]
		public bool deadcountSpecified
		{
			get
			{
				return this._deadcount != null;
			}
			set
			{
				bool flag = value == (this._deadcount == null);
				if (flag)
				{
					this._deadcount = (value ? new uint?(this.deadcount) : null);
				}
			}
		}

		// Token: 0x06006DB1 RID: 28081 RVA: 0x000D1E4C File Offset: 0x000D004C
		private bool ShouldSerializedeadcount()
		{
			return this.deadcountSpecified;
		}

		// Token: 0x06006DB2 RID: 28082 RVA: 0x000D1E64 File Offset: 0x000D0064
		private void Resetdeadcount()
		{
			this.deadcountSpecified = false;
		}

		// Token: 0x170022B9 RID: 8889
		// (get) Token: 0x06006DB3 RID: 28083 RVA: 0x000D1E70 File Offset: 0x000D0070
		// (set) Token: 0x06006DB4 RID: 28084 RVA: 0x000D1E9C File Offset: 0x000D009C
		[ProtoMember(7, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public uint killcount
		{
			get
			{
				return this._killcount ?? 0U;
			}
			set
			{
				this._killcount = new uint?(value);
			}
		}

		// Token: 0x170022BA RID: 8890
		// (get) Token: 0x06006DB5 RID: 28085 RVA: 0x000D1EAC File Offset: 0x000D00AC
		// (set) Token: 0x06006DB6 RID: 28086 RVA: 0x000D1ECC File Offset: 0x000D00CC
		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new uint?(this.killcount) : null);
				}
			}
		}

		// Token: 0x06006DB7 RID: 28087 RVA: 0x000D1F10 File Offset: 0x000D0110
		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		// Token: 0x06006DB8 RID: 28088 RVA: 0x000D1F28 File Offset: 0x000D0128
		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		// Token: 0x170022BB RID: 8891
		// (get) Token: 0x06006DB9 RID: 28089 RVA: 0x000D1F34 File Offset: 0x000D0134
		// (set) Token: 0x06006DBA RID: 28090 RVA: 0x000D1F60 File Offset: 0x000D0160
		[ProtoMember(8, IsRequired = false, Name = "killcontinue", DataFormat = DataFormat.TwosComplement)]
		public uint killcontinue
		{
			get
			{
				return this._killcontinue ?? 0U;
			}
			set
			{
				this._killcontinue = new uint?(value);
			}
		}

		// Token: 0x170022BC RID: 8892
		// (get) Token: 0x06006DBB RID: 28091 RVA: 0x000D1F70 File Offset: 0x000D0170
		// (set) Token: 0x06006DBC RID: 28092 RVA: 0x000D1F90 File Offset: 0x000D0190
		[XmlIgnore]
		[Browsable(false)]
		public bool killcontinueSpecified
		{
			get
			{
				return this._killcontinue != null;
			}
			set
			{
				bool flag = value == (this._killcontinue == null);
				if (flag)
				{
					this._killcontinue = (value ? new uint?(this.killcontinue) : null);
				}
			}
		}

		// Token: 0x06006DBD RID: 28093 RVA: 0x000D1FD4 File Offset: 0x000D01D4
		private bool ShouldSerializekillcontinue()
		{
			return this.killcontinueSpecified;
		}

		// Token: 0x06006DBE RID: 28094 RVA: 0x000D1FEC File Offset: 0x000D01EC
		private void Resetkillcontinue()
		{
			this.killcontinueSpecified = false;
		}

		// Token: 0x170022BD RID: 8893
		// (get) Token: 0x06006DBF RID: 28095 RVA: 0x000D1FF8 File Offset: 0x000D01F8
		// (set) Token: 0x06006DC0 RID: 28096 RVA: 0x000D2024 File Offset: 0x000D0224
		[ProtoMember(9, IsRequired = false, Name = "treatcount", DataFormat = DataFormat.TwosComplement)]
		public uint treatcount
		{
			get
			{
				return this._treatcount ?? 0U;
			}
			set
			{
				this._treatcount = new uint?(value);
			}
		}

		// Token: 0x170022BE RID: 8894
		// (get) Token: 0x06006DC1 RID: 28097 RVA: 0x000D2034 File Offset: 0x000D0234
		// (set) Token: 0x06006DC2 RID: 28098 RVA: 0x000D2054 File Offset: 0x000D0254
		[XmlIgnore]
		[Browsable(false)]
		public bool treatcountSpecified
		{
			get
			{
				return this._treatcount != null;
			}
			set
			{
				bool flag = value == (this._treatcount == null);
				if (flag)
				{
					this._treatcount = (value ? new uint?(this.treatcount) : null);
				}
			}
		}

		// Token: 0x06006DC3 RID: 28099 RVA: 0x000D2098 File Offset: 0x000D0298
		private bool ShouldSerializetreatcount()
		{
			return this.treatcountSpecified;
		}

		// Token: 0x06006DC4 RID: 28100 RVA: 0x000D20B0 File Offset: 0x000D02B0
		private void Resettreatcount()
		{
			this.treatcountSpecified = false;
		}

		// Token: 0x170022BF RID: 8895
		// (get) Token: 0x06006DC5 RID: 28101 RVA: 0x000D20BC File Offset: 0x000D02BC
		// (set) Token: 0x06006DC6 RID: 28102 RVA: 0x000D20E8 File Offset: 0x000D02E8
		[ProtoMember(10, IsRequired = false, Name = "combomax", DataFormat = DataFormat.TwosComplement)]
		public uint combomax
		{
			get
			{
				return this._combomax ?? 0U;
			}
			set
			{
				this._combomax = new uint?(value);
			}
		}

		// Token: 0x170022C0 RID: 8896
		// (get) Token: 0x06006DC7 RID: 28103 RVA: 0x000D20F8 File Offset: 0x000D02F8
		// (set) Token: 0x06006DC8 RID: 28104 RVA: 0x000D2118 File Offset: 0x000D0318
		[XmlIgnore]
		[Browsable(false)]
		public bool combomaxSpecified
		{
			get
			{
				return this._combomax != null;
			}
			set
			{
				bool flag = value == (this._combomax == null);
				if (flag)
				{
					this._combomax = (value ? new uint?(this.combomax) : null);
				}
			}
		}

		// Token: 0x06006DC9 RID: 28105 RVA: 0x000D215C File Offset: 0x000D035C
		private bool ShouldSerializecombomax()
		{
			return this.combomaxSpecified;
		}

		// Token: 0x06006DCA RID: 28106 RVA: 0x000D2174 File Offset: 0x000D0374
		private void Resetcombomax()
		{
			this.combomaxSpecified = false;
		}

		// Token: 0x170022C1 RID: 8897
		// (get) Token: 0x06006DCB RID: 28107 RVA: 0x000D2180 File Offset: 0x000D0380
		// (set) Token: 0x06006DCC RID: 28108 RVA: 0x000D21AC File Offset: 0x000D03AC
		[ProtoMember(11, IsRequired = false, Name = "assitnum", DataFormat = DataFormat.TwosComplement)]
		public uint assitnum
		{
			get
			{
				return this._assitnum ?? 0U;
			}
			set
			{
				this._assitnum = new uint?(value);
			}
		}

		// Token: 0x170022C2 RID: 8898
		// (get) Token: 0x06006DCD RID: 28109 RVA: 0x000D21BC File Offset: 0x000D03BC
		// (set) Token: 0x06006DCE RID: 28110 RVA: 0x000D21DC File Offset: 0x000D03DC
		[XmlIgnore]
		[Browsable(false)]
		public bool assitnumSpecified
		{
			get
			{
				return this._assitnum != null;
			}
			set
			{
				bool flag = value == (this._assitnum == null);
				if (flag)
				{
					this._assitnum = (value ? new uint?(this.assitnum) : null);
				}
			}
		}

		// Token: 0x06006DCF RID: 28111 RVA: 0x000D2220 File Offset: 0x000D0420
		private bool ShouldSerializeassitnum()
		{
			return this.assitnumSpecified;
		}

		// Token: 0x06006DD0 RID: 28112 RVA: 0x000D2238 File Offset: 0x000D0438
		private void Resetassitnum()
		{
			this.assitnumSpecified = false;
		}

		// Token: 0x06006DD1 RID: 28113 RVA: 0x000D2244 File Offset: 0x000D0444
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A42 RID: 6722
		private ulong? _roleid;

		// Token: 0x04001A43 RID: 6723
		private string _name;

		// Token: 0x04001A44 RID: 6724
		private uint? _type;

		// Token: 0x04001A45 RID: 6725
		private uint? _profession;

		// Token: 0x04001A46 RID: 6726
		private double? _damageall;

		// Token: 0x04001A47 RID: 6727
		private uint? _deadcount;

		// Token: 0x04001A48 RID: 6728
		private uint? _killcount;

		// Token: 0x04001A49 RID: 6729
		private uint? _killcontinue;

		// Token: 0x04001A4A RID: 6730
		private uint? _treatcount;

		// Token: 0x04001A4B RID: 6731
		private uint? _combomax;

		// Token: 0x04001A4C RID: 6732
		private uint? _assitnum;

		// Token: 0x04001A4D RID: 6733
		private IExtension extensionObject;
	}
}
