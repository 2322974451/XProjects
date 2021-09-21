using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200065D RID: 1629
	[ProtoContract(Name = "RoleTeamCostInfo")]
	[Serializable]
	public class RoleTeamCostInfo : IExtensible
	{
		// Token: 0x17002023 RID: 8227
		// (get) Token: 0x060065D5 RID: 26069 RVA: 0x000C26E4 File Offset: 0x000C08E4
		// (set) Token: 0x060065D6 RID: 26070 RVA: 0x000C2710 File Offset: 0x000C0910
		[ProtoMember(1, IsRequired = false, Name = "expid", DataFormat = DataFormat.TwosComplement)]
		public uint expid
		{
			get
			{
				return this._expid ?? 0U;
			}
			set
			{
				this._expid = new uint?(value);
			}
		}

		// Token: 0x17002024 RID: 8228
		// (get) Token: 0x060065D7 RID: 26071 RVA: 0x000C2720 File Offset: 0x000C0920
		// (set) Token: 0x060065D8 RID: 26072 RVA: 0x000C2740 File Offset: 0x000C0940
		[XmlIgnore]
		[Browsable(false)]
		public bool expidSpecified
		{
			get
			{
				return this._expid != null;
			}
			set
			{
				bool flag = value == (this._expid == null);
				if (flag)
				{
					this._expid = (value ? new uint?(this.expid) : null);
				}
			}
		}

		// Token: 0x060065D9 RID: 26073 RVA: 0x000C2784 File Offset: 0x000C0984
		private bool ShouldSerializeexpid()
		{
			return this.expidSpecified;
		}

		// Token: 0x060065DA RID: 26074 RVA: 0x000C279C File Offset: 0x000C099C
		private void Resetexpid()
		{
			this.expidSpecified = false;
		}

		// Token: 0x17002025 RID: 8229
		// (get) Token: 0x060065DB RID: 26075 RVA: 0x000C27A8 File Offset: 0x000C09A8
		// (set) Token: 0x060065DC RID: 26076 RVA: 0x000C27D4 File Offset: 0x000C09D4
		[ProtoMember(2, IsRequired = false, Name = "costindex", DataFormat = DataFormat.TwosComplement)]
		public uint costindex
		{
			get
			{
				return this._costindex ?? 0U;
			}
			set
			{
				this._costindex = new uint?(value);
			}
		}

		// Token: 0x17002026 RID: 8230
		// (get) Token: 0x060065DD RID: 26077 RVA: 0x000C27E4 File Offset: 0x000C09E4
		// (set) Token: 0x060065DE RID: 26078 RVA: 0x000C2804 File Offset: 0x000C0A04
		[XmlIgnore]
		[Browsable(false)]
		public bool costindexSpecified
		{
			get
			{
				return this._costindex != null;
			}
			set
			{
				bool flag = value == (this._costindex == null);
				if (flag)
				{
					this._costindex = (value ? new uint?(this.costindex) : null);
				}
			}
		}

		// Token: 0x060065DF RID: 26079 RVA: 0x000C2848 File Offset: 0x000C0A48
		private bool ShouldSerializecostindex()
		{
			return this.costindexSpecified;
		}

		// Token: 0x060065E0 RID: 26080 RVA: 0x000C2860 File Offset: 0x000C0A60
		private void Resetcostindex()
		{
			this.costindexSpecified = false;
		}

		// Token: 0x17002027 RID: 8231
		// (get) Token: 0x060065E1 RID: 26081 RVA: 0x000C286C File Offset: 0x000C0A6C
		// (set) Token: 0x060065E2 RID: 26082 RVA: 0x000C2898 File Offset: 0x000C0A98
		[ProtoMember(3, IsRequired = false, Name = "dragoncount", DataFormat = DataFormat.TwosComplement)]
		public uint dragoncount
		{
			get
			{
				return this._dragoncount ?? 0U;
			}
			set
			{
				this._dragoncount = new uint?(value);
			}
		}

		// Token: 0x17002028 RID: 8232
		// (get) Token: 0x060065E3 RID: 26083 RVA: 0x000C28A8 File Offset: 0x000C0AA8
		// (set) Token: 0x060065E4 RID: 26084 RVA: 0x000C28C8 File Offset: 0x000C0AC8
		[XmlIgnore]
		[Browsable(false)]
		public bool dragoncountSpecified
		{
			get
			{
				return this._dragoncount != null;
			}
			set
			{
				bool flag = value == (this._dragoncount == null);
				if (flag)
				{
					this._dragoncount = (value ? new uint?(this.dragoncount) : null);
				}
			}
		}

		// Token: 0x060065E5 RID: 26085 RVA: 0x000C290C File Offset: 0x000C0B0C
		private bool ShouldSerializedragoncount()
		{
			return this.dragoncountSpecified;
		}

		// Token: 0x060065E6 RID: 26086 RVA: 0x000C2924 File Offset: 0x000C0B24
		private void Resetdragoncount()
		{
			this.dragoncountSpecified = false;
		}

		// Token: 0x17002029 RID: 8233
		// (get) Token: 0x060065E7 RID: 26087 RVA: 0x000C2930 File Offset: 0x000C0B30
		// (set) Token: 0x060065E8 RID: 26088 RVA: 0x000C295C File Offset: 0x000C0B5C
		[ProtoMember(4, IsRequired = false, Name = "updateday", DataFormat = DataFormat.TwosComplement)]
		public uint updateday
		{
			get
			{
				return this._updateday ?? 0U;
			}
			set
			{
				this._updateday = new uint?(value);
			}
		}

		// Token: 0x1700202A RID: 8234
		// (get) Token: 0x060065E9 RID: 26089 RVA: 0x000C296C File Offset: 0x000C0B6C
		// (set) Token: 0x060065EA RID: 26090 RVA: 0x000C298C File Offset: 0x000C0B8C
		[XmlIgnore]
		[Browsable(false)]
		public bool updatedaySpecified
		{
			get
			{
				return this._updateday != null;
			}
			set
			{
				bool flag = value == (this._updateday == null);
				if (flag)
				{
					this._updateday = (value ? new uint?(this.updateday) : null);
				}
			}
		}

		// Token: 0x060065EB RID: 26091 RVA: 0x000C29D0 File Offset: 0x000C0BD0
		private bool ShouldSerializeupdateday()
		{
			return this.updatedaySpecified;
		}

		// Token: 0x060065EC RID: 26092 RVA: 0x000C29E8 File Offset: 0x000C0BE8
		private void Resetupdateday()
		{
			this.updatedaySpecified = false;
		}

		// Token: 0x1700202B RID: 8235
		// (get) Token: 0x060065ED RID: 26093 RVA: 0x000C29F4 File Offset: 0x000C0BF4
		// (set) Token: 0x060065EE RID: 26094 RVA: 0x000C2A20 File Offset: 0x000C0C20
		[ProtoMember(5, IsRequired = false, Name = "getgiftvalue", DataFormat = DataFormat.TwosComplement)]
		public uint getgiftvalue
		{
			get
			{
				return this._getgiftvalue ?? 0U;
			}
			set
			{
				this._getgiftvalue = new uint?(value);
			}
		}

		// Token: 0x1700202C RID: 8236
		// (get) Token: 0x060065EF RID: 26095 RVA: 0x000C2A30 File Offset: 0x000C0C30
		// (set) Token: 0x060065F0 RID: 26096 RVA: 0x000C2A50 File Offset: 0x000C0C50
		[XmlIgnore]
		[Browsable(false)]
		public bool getgiftvalueSpecified
		{
			get
			{
				return this._getgiftvalue != null;
			}
			set
			{
				bool flag = value == (this._getgiftvalue == null);
				if (flag)
				{
					this._getgiftvalue = (value ? new uint?(this.getgiftvalue) : null);
				}
			}
		}

		// Token: 0x060065F1 RID: 26097 RVA: 0x000C2A94 File Offset: 0x000C0C94
		private bool ShouldSerializegetgiftvalue()
		{
			return this.getgiftvalueSpecified;
		}

		// Token: 0x060065F2 RID: 26098 RVA: 0x000C2AAC File Offset: 0x000C0CAC
		private void Resetgetgiftvalue()
		{
			this.getgiftvalueSpecified = false;
		}

		// Token: 0x060065F3 RID: 26099 RVA: 0x000C2AB8 File Offset: 0x000C0CB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018A9 RID: 6313
		private uint? _expid;

		// Token: 0x040018AA RID: 6314
		private uint? _costindex;

		// Token: 0x040018AB RID: 6315
		private uint? _dragoncount;

		// Token: 0x040018AC RID: 6316
		private uint? _updateday;

		// Token: 0x040018AD RID: 6317
		private uint? _getgiftvalue;

		// Token: 0x040018AE RID: 6318
		private IExtension extensionObject;
	}
}
