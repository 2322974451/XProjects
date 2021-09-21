using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005C9 RID: 1481
	[ProtoContract(Name = "PetInviteInfo")]
	[Serializable]
	public class PetInviteInfo : IExtensible
	{
		// Token: 0x170019CF RID: 6607
		// (get) Token: 0x06005362 RID: 21346 RVA: 0x0009E9B0 File Offset: 0x0009CBB0
		// (set) Token: 0x06005363 RID: 21347 RVA: 0x0009E9DD File Offset: 0x0009CBDD
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

		// Token: 0x170019D0 RID: 6608
		// (get) Token: 0x06005364 RID: 21348 RVA: 0x0009E9EC File Offset: 0x0009CBEC
		// (set) Token: 0x06005365 RID: 21349 RVA: 0x0009EA0C File Offset: 0x0009CC0C
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

		// Token: 0x06005366 RID: 21350 RVA: 0x0009EA50 File Offset: 0x0009CC50
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06005367 RID: 21351 RVA: 0x0009EA68 File Offset: 0x0009CC68
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170019D1 RID: 6609
		// (get) Token: 0x06005368 RID: 21352 RVA: 0x0009EA74 File Offset: 0x0009CC74
		// (set) Token: 0x06005369 RID: 21353 RVA: 0x0009EAA1 File Offset: 0x0009CCA1
		[ProtoMember(2, IsRequired = false, Name = "petuid", DataFormat = DataFormat.TwosComplement)]
		public ulong petuid
		{
			get
			{
				return this._petuid ?? 0UL;
			}
			set
			{
				this._petuid = new ulong?(value);
			}
		}

		// Token: 0x170019D2 RID: 6610
		// (get) Token: 0x0600536A RID: 21354 RVA: 0x0009EAB0 File Offset: 0x0009CCB0
		// (set) Token: 0x0600536B RID: 21355 RVA: 0x0009EAD0 File Offset: 0x0009CCD0
		[XmlIgnore]
		[Browsable(false)]
		public bool petuidSpecified
		{
			get
			{
				return this._petuid != null;
			}
			set
			{
				bool flag = value == (this._petuid == null);
				if (flag)
				{
					this._petuid = (value ? new ulong?(this.petuid) : null);
				}
			}
		}

		// Token: 0x0600536C RID: 21356 RVA: 0x0009EB14 File Offset: 0x0009CD14
		private bool ShouldSerializepetuid()
		{
			return this.petuidSpecified;
		}

		// Token: 0x0600536D RID: 21357 RVA: 0x0009EB2C File Offset: 0x0009CD2C
		private void Resetpetuid()
		{
			this.petuidSpecified = false;
		}

		// Token: 0x170019D3 RID: 6611
		// (get) Token: 0x0600536E RID: 21358 RVA: 0x0009EB38 File Offset: 0x0009CD38
		// (set) Token: 0x0600536F RID: 21359 RVA: 0x0009EB64 File Offset: 0x0009CD64
		[ProtoMember(3, IsRequired = false, Name = "petconfigid", DataFormat = DataFormat.TwosComplement)]
		public uint petconfigid
		{
			get
			{
				return this._petconfigid ?? 0U;
			}
			set
			{
				this._petconfigid = new uint?(value);
			}
		}

		// Token: 0x170019D4 RID: 6612
		// (get) Token: 0x06005370 RID: 21360 RVA: 0x0009EB74 File Offset: 0x0009CD74
		// (set) Token: 0x06005371 RID: 21361 RVA: 0x0009EB94 File Offset: 0x0009CD94
		[XmlIgnore]
		[Browsable(false)]
		public bool petconfigidSpecified
		{
			get
			{
				return this._petconfigid != null;
			}
			set
			{
				bool flag = value == (this._petconfigid == null);
				if (flag)
				{
					this._petconfigid = (value ? new uint?(this.petconfigid) : null);
				}
			}
		}

		// Token: 0x06005372 RID: 21362 RVA: 0x0009EBD8 File Offset: 0x0009CDD8
		private bool ShouldSerializepetconfigid()
		{
			return this.petconfigidSpecified;
		}

		// Token: 0x06005373 RID: 21363 RVA: 0x0009EBF0 File Offset: 0x0009CDF0
		private void Resetpetconfigid()
		{
			this.petconfigidSpecified = false;
		}

		// Token: 0x170019D5 RID: 6613
		// (get) Token: 0x06005374 RID: 21364 RVA: 0x0009EBFC File Offset: 0x0009CDFC
		// (set) Token: 0x06005375 RID: 21365 RVA: 0x0009EC1D File Offset: 0x0009CE1D
		[ProtoMember(4, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x170019D6 RID: 6614
		// (get) Token: 0x06005376 RID: 21366 RVA: 0x0009EC28 File Offset: 0x0009CE28
		// (set) Token: 0x06005377 RID: 21367 RVA: 0x0009EC44 File Offset: 0x0009CE44
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x06005378 RID: 21368 RVA: 0x0009EC74 File Offset: 0x0009CE74
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06005379 RID: 21369 RVA: 0x0009EC8C File Offset: 0x0009CE8C
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x170019D7 RID: 6615
		// (get) Token: 0x0600537A RID: 21370 RVA: 0x0009EC98 File Offset: 0x0009CE98
		// (set) Token: 0x0600537B RID: 21371 RVA: 0x0009ECC4 File Offset: 0x0009CEC4
		[ProtoMember(5, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170019D8 RID: 6616
		// (get) Token: 0x0600537C RID: 21372 RVA: 0x0009ECD4 File Offset: 0x0009CED4
		// (set) Token: 0x0600537D RID: 21373 RVA: 0x0009ECF4 File Offset: 0x0009CEF4
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

		// Token: 0x0600537E RID: 21374 RVA: 0x0009ED38 File Offset: 0x0009CF38
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x0600537F RID: 21375 RVA: 0x0009ED50 File Offset: 0x0009CF50
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x170019D9 RID: 6617
		// (get) Token: 0x06005380 RID: 21376 RVA: 0x0009ED5C File Offset: 0x0009CF5C
		// (set) Token: 0x06005381 RID: 21377 RVA: 0x0009ED88 File Offset: 0x0009CF88
		[ProtoMember(6, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		// Token: 0x170019DA RID: 6618
		// (get) Token: 0x06005382 RID: 21378 RVA: 0x0009ED98 File Offset: 0x0009CF98
		// (set) Token: 0x06005383 RID: 21379 RVA: 0x0009EDB8 File Offset: 0x0009CFB8
		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		// Token: 0x06005384 RID: 21380 RVA: 0x0009EDFC File Offset: 0x0009CFFC
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x06005385 RID: 21381 RVA: 0x0009EE14 File Offset: 0x0009D014
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x170019DB RID: 6619
		// (get) Token: 0x06005386 RID: 21382 RVA: 0x0009EE20 File Offset: 0x0009D020
		// (set) Token: 0x06005387 RID: 21383 RVA: 0x0009EE4C File Offset: 0x0009D04C
		[ProtoMember(7, IsRequired = false, Name = "petppt", DataFormat = DataFormat.TwosComplement)]
		public uint petppt
		{
			get
			{
				return this._petppt ?? 0U;
			}
			set
			{
				this._petppt = new uint?(value);
			}
		}

		// Token: 0x170019DC RID: 6620
		// (get) Token: 0x06005388 RID: 21384 RVA: 0x0009EE5C File Offset: 0x0009D05C
		// (set) Token: 0x06005389 RID: 21385 RVA: 0x0009EE7C File Offset: 0x0009D07C
		[XmlIgnore]
		[Browsable(false)]
		public bool petpptSpecified
		{
			get
			{
				return this._petppt != null;
			}
			set
			{
				bool flag = value == (this._petppt == null);
				if (flag)
				{
					this._petppt = (value ? new uint?(this.petppt) : null);
				}
			}
		}

		// Token: 0x0600538A RID: 21386 RVA: 0x0009EEC0 File Offset: 0x0009D0C0
		private bool ShouldSerializepetppt()
		{
			return this.petpptSpecified;
		}

		// Token: 0x0600538B RID: 21387 RVA: 0x0009EED8 File Offset: 0x0009D0D8
		private void Resetpetppt()
		{
			this.petpptSpecified = false;
		}

		// Token: 0x0600538C RID: 21388 RVA: 0x0009EEE4 File Offset: 0x0009D0E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001460 RID: 5216
		private ulong? _roleid;

		// Token: 0x04001461 RID: 5217
		private ulong? _petuid;

		// Token: 0x04001462 RID: 5218
		private uint? _petconfigid;

		// Token: 0x04001463 RID: 5219
		private string _rolename;

		// Token: 0x04001464 RID: 5220
		private uint? _profession;

		// Token: 0x04001465 RID: 5221
		private uint? _ppt;

		// Token: 0x04001466 RID: 5222
		private uint? _petppt;

		// Token: 0x04001467 RID: 5223
		private IExtension extensionObject;
	}
}
