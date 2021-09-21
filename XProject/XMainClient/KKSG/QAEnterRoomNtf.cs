using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000187 RID: 391
	[ProtoContract(Name = "QAEnterRoomNtf")]
	[Serializable]
	public class QAEnterRoomNtf : IExtensible
	{
		// Token: 0x17000773 RID: 1907
		// (get) Token: 0x06001790 RID: 6032 RVA: 0x0002F108 File Offset: 0x0002D308
		// (set) Token: 0x06001791 RID: 6033 RVA: 0x0002F135 File Offset: 0x0002D335
		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x06001792 RID: 6034 RVA: 0x0002F144 File Offset: 0x0002D344
		// (set) Token: 0x06001793 RID: 6035 RVA: 0x0002F164 File Offset: 0x0002D364
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x06001794 RID: 6036 RVA: 0x0002F1A8 File Offset: 0x0002D3A8
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06001795 RID: 6037 RVA: 0x0002F1C0 File Offset: 0x0002D3C0
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x06001796 RID: 6038 RVA: 0x0002F1CC File Offset: 0x0002D3CC
		// (set) Token: 0x06001797 RID: 6039 RVA: 0x0002F1ED File Offset: 0x0002D3ED
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

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x06001798 RID: 6040 RVA: 0x0002F1F8 File Offset: 0x0002D3F8
		// (set) Token: 0x06001799 RID: 6041 RVA: 0x0002F214 File Offset: 0x0002D414
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

		// Token: 0x0600179A RID: 6042 RVA: 0x0002F244 File Offset: 0x0002D444
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600179B RID: 6043 RVA: 0x0002F25C File Offset: 0x0002D45C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x0600179C RID: 6044 RVA: 0x0002F268 File Offset: 0x0002D468
		// (set) Token: 0x0600179D RID: 6045 RVA: 0x0002F294 File Offset: 0x0002D494
		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x0600179E RID: 6046 RVA: 0x0002F2A4 File Offset: 0x0002D4A4
		// (set) Token: 0x0600179F RID: 6047 RVA: 0x0002F2C4 File Offset: 0x0002D4C4
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

		// Token: 0x060017A0 RID: 6048 RVA: 0x0002F308 File Offset: 0x0002D508
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x060017A1 RID: 6049 RVA: 0x0002F320 File Offset: 0x0002D520
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x060017A2 RID: 6050 RVA: 0x0002F32C File Offset: 0x0002D52C
		// (set) Token: 0x060017A3 RID: 6051 RVA: 0x0002F358 File Offset: 0x0002D558
		[ProtoMember(4, IsRequired = false, Name = "vip", DataFormat = DataFormat.TwosComplement)]
		public uint vip
		{
			get
			{
				return this._vip ?? 0U;
			}
			set
			{
				this._vip = new uint?(value);
			}
		}

		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x060017A4 RID: 6052 RVA: 0x0002F368 File Offset: 0x0002D568
		// (set) Token: 0x060017A5 RID: 6053 RVA: 0x0002F388 File Offset: 0x0002D588
		[XmlIgnore]
		[Browsable(false)]
		public bool vipSpecified
		{
			get
			{
				return this._vip != null;
			}
			set
			{
				bool flag = value == (this._vip == null);
				if (flag)
				{
					this._vip = (value ? new uint?(this.vip) : null);
				}
			}
		}

		// Token: 0x060017A6 RID: 6054 RVA: 0x0002F3CC File Offset: 0x0002D5CC
		private bool ShouldSerializevip()
		{
			return this.vipSpecified;
		}

		// Token: 0x060017A7 RID: 6055 RVA: 0x0002F3E4 File Offset: 0x0002D5E4
		private void Resetvip()
		{
			this.vipSpecified = false;
		}

		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x060017A8 RID: 6056 RVA: 0x0002F3F0 File Offset: 0x0002D5F0
		// (set) Token: 0x060017A9 RID: 6057 RVA: 0x0002F41C File Offset: 0x0002D61C
		[ProtoMember(5, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x060017AA RID: 6058 RVA: 0x0002F42C File Offset: 0x0002D62C
		// (set) Token: 0x060017AB RID: 6059 RVA: 0x0002F44C File Offset: 0x0002D64C
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x060017AC RID: 6060 RVA: 0x0002F490 File Offset: 0x0002D690
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060017AD RID: 6061 RVA: 0x0002F4A8 File Offset: 0x0002D6A8
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x060017AE RID: 6062 RVA: 0x0002F4B4 File Offset: 0x0002D6B4
		// (set) Token: 0x060017AF RID: 6063 RVA: 0x0002F4E0 File Offset: 0x0002D6E0
		[ProtoMember(6, IsRequired = false, Name = "coverDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint coverDesignationID
		{
			get
			{
				return this._coverDesignationID ?? 0U;
			}
			set
			{
				this._coverDesignationID = new uint?(value);
			}
		}

		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x060017B0 RID: 6064 RVA: 0x0002F4F0 File Offset: 0x0002D6F0
		// (set) Token: 0x060017B1 RID: 6065 RVA: 0x0002F510 File Offset: 0x0002D710
		[XmlIgnore]
		[Browsable(false)]
		public bool coverDesignationIDSpecified
		{
			get
			{
				return this._coverDesignationID != null;
			}
			set
			{
				bool flag = value == (this._coverDesignationID == null);
				if (flag)
				{
					this._coverDesignationID = (value ? new uint?(this.coverDesignationID) : null);
				}
			}
		}

		// Token: 0x060017B2 RID: 6066 RVA: 0x0002F554 File Offset: 0x0002D754
		private bool ShouldSerializecoverDesignationID()
		{
			return this.coverDesignationIDSpecified;
		}

		// Token: 0x060017B3 RID: 6067 RVA: 0x0002F56C File Offset: 0x0002D76C
		private void ResetcoverDesignationID()
		{
			this.coverDesignationIDSpecified = false;
		}

		// Token: 0x060017B4 RID: 6068 RVA: 0x0002F578 File Offset: 0x0002D778
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005D3 RID: 1491
		private ulong? _roleID;

		// Token: 0x040005D4 RID: 1492
		private string _name;

		// Token: 0x040005D5 RID: 1493
		private uint? _profession;

		// Token: 0x040005D6 RID: 1494
		private uint? _vip;

		// Token: 0x040005D7 RID: 1495
		private uint? _time;

		// Token: 0x040005D8 RID: 1496
		private uint? _coverDesignationID;

		// Token: 0x040005D9 RID: 1497
		private IExtension extensionObject;
	}
}
