using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006EE RID: 1774
	[ProtoContract(Name = "RoleOutLookBrief")]
	[Serializable]
	public class RoleOutLookBrief : IExtensible
	{
		// Token: 0x17002599 RID: 9625
		// (get) Token: 0x060076C3 RID: 30403 RVA: 0x000E3364 File Offset: 0x000E1564
		// (set) Token: 0x060076C4 RID: 30404 RVA: 0x000E3391 File Offset: 0x000E1591
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

		// Token: 0x1700259A RID: 9626
		// (get) Token: 0x060076C5 RID: 30405 RVA: 0x000E33A0 File Offset: 0x000E15A0
		// (set) Token: 0x060076C6 RID: 30406 RVA: 0x000E33C0 File Offset: 0x000E15C0
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

		// Token: 0x060076C7 RID: 30407 RVA: 0x000E3404 File Offset: 0x000E1604
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060076C8 RID: 30408 RVA: 0x000E341C File Offset: 0x000E161C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700259B RID: 9627
		// (get) Token: 0x060076C9 RID: 30409 RVA: 0x000E3428 File Offset: 0x000E1628
		// (set) Token: 0x060076CA RID: 30410 RVA: 0x000E3454 File Offset: 0x000E1654
		[ProtoMember(2, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public RoleType profession
		{
			get
			{
				return this._profession ?? RoleType.Role_INVALID;
			}
			set
			{
				this._profession = new RoleType?(value);
			}
		}

		// Token: 0x1700259C RID: 9628
		// (get) Token: 0x060076CB RID: 30411 RVA: 0x000E3464 File Offset: 0x000E1664
		// (set) Token: 0x060076CC RID: 30412 RVA: 0x000E3484 File Offset: 0x000E1684
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
					this._profession = (value ? new RoleType?(this.profession) : null);
				}
			}
		}

		// Token: 0x060076CD RID: 30413 RVA: 0x000E34C8 File Offset: 0x000E16C8
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x060076CE RID: 30414 RVA: 0x000E34E0 File Offset: 0x000E16E0
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x1700259D RID: 9629
		// (get) Token: 0x060076CF RID: 30415 RVA: 0x000E34EC File Offset: 0x000E16EC
		// (set) Token: 0x060076D0 RID: 30416 RVA: 0x000E350D File Offset: 0x000E170D
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700259E RID: 9630
		// (get) Token: 0x060076D1 RID: 30417 RVA: 0x000E3518 File Offset: 0x000E1718
		// (set) Token: 0x060076D2 RID: 30418 RVA: 0x000E3534 File Offset: 0x000E1734
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

		// Token: 0x060076D3 RID: 30419 RVA: 0x000E3564 File Offset: 0x000E1764
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060076D4 RID: 30420 RVA: 0x000E357C File Offset: 0x000E177C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700259F RID: 9631
		// (get) Token: 0x060076D5 RID: 30421 RVA: 0x000E3588 File Offset: 0x000E1788
		// (set) Token: 0x060076D6 RID: 30422 RVA: 0x000E35B4 File Offset: 0x000E17B4
		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x170025A0 RID: 9632
		// (get) Token: 0x060076D7 RID: 30423 RVA: 0x000E35C4 File Offset: 0x000E17C4
		// (set) Token: 0x060076D8 RID: 30424 RVA: 0x000E35E4 File Offset: 0x000E17E4
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x060076D9 RID: 30425 RVA: 0x000E3628 File Offset: 0x000E1828
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x060076DA RID: 30426 RVA: 0x000E3640 File Offset: 0x000E1840
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170025A1 RID: 9633
		// (get) Token: 0x060076DB RID: 30427 RVA: 0x000E364C File Offset: 0x000E184C
		// (set) Token: 0x060076DC RID: 30428 RVA: 0x000E3678 File Offset: 0x000E1878
		[ProtoMember(5, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170025A2 RID: 9634
		// (get) Token: 0x060076DD RID: 30429 RVA: 0x000E3688 File Offset: 0x000E1888
		// (set) Token: 0x060076DE RID: 30430 RVA: 0x000E36A8 File Offset: 0x000E18A8
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

		// Token: 0x060076DF RID: 30431 RVA: 0x000E36EC File Offset: 0x000E18EC
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x060076E0 RID: 30432 RVA: 0x000E3704 File Offset: 0x000E1904
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x170025A3 RID: 9635
		// (get) Token: 0x060076E1 RID: 30433 RVA: 0x000E3710 File Offset: 0x000E1910
		[ProtoMember(6, Name = "fashion", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fashion
		{
			get
			{
				return this._fashion;
			}
		}

		// Token: 0x170025A4 RID: 9636
		// (get) Token: 0x060076E2 RID: 30434 RVA: 0x000E3728 File Offset: 0x000E1928
		// (set) Token: 0x060076E3 RID: 30435 RVA: 0x000E3740 File Offset: 0x000E1940
		[ProtoMember(7, IsRequired = false, Name = "outlook", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLook outlook
		{
			get
			{
				return this._outlook;
			}
			set
			{
				this._outlook = value;
			}
		}

		// Token: 0x170025A5 RID: 9637
		// (get) Token: 0x060076E4 RID: 30436 RVA: 0x000E374C File Offset: 0x000E194C
		// (set) Token: 0x060076E5 RID: 30437 RVA: 0x000E3778 File Offset: 0x000E1978
		[ProtoMember(8, IsRequired = false, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
		public uint viplevel
		{
			get
			{
				return this._viplevel ?? 0U;
			}
			set
			{
				this._viplevel = new uint?(value);
			}
		}

		// Token: 0x170025A6 RID: 9638
		// (get) Token: 0x060076E6 RID: 30438 RVA: 0x000E3788 File Offset: 0x000E1988
		// (set) Token: 0x060076E7 RID: 30439 RVA: 0x000E37A8 File Offset: 0x000E19A8
		[XmlIgnore]
		[Browsable(false)]
		public bool viplevelSpecified
		{
			get
			{
				return this._viplevel != null;
			}
			set
			{
				bool flag = value == (this._viplevel == null);
				if (flag)
				{
					this._viplevel = (value ? new uint?(this.viplevel) : null);
				}
			}
		}

		// Token: 0x060076E8 RID: 30440 RVA: 0x000E37EC File Offset: 0x000E19EC
		private bool ShouldSerializeviplevel()
		{
			return this.viplevelSpecified;
		}

		// Token: 0x060076E9 RID: 30441 RVA: 0x000E3804 File Offset: 0x000E1A04
		private void Resetviplevel()
		{
			this.viplevelSpecified = false;
		}

		// Token: 0x170025A7 RID: 9639
		// (get) Token: 0x060076EA RID: 30442 RVA: 0x000E3810 File Offset: 0x000E1A10
		// (set) Token: 0x060076EB RID: 30443 RVA: 0x000E383C File Offset: 0x000E1A3C
		[ProtoMember(9, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
		public uint paymemberid
		{
			get
			{
				return this._paymemberid ?? 0U;
			}
			set
			{
				this._paymemberid = new uint?(value);
			}
		}

		// Token: 0x170025A8 RID: 9640
		// (get) Token: 0x060076EC RID: 30444 RVA: 0x000E384C File Offset: 0x000E1A4C
		// (set) Token: 0x060076ED RID: 30445 RVA: 0x000E386C File Offset: 0x000E1A6C
		[XmlIgnore]
		[Browsable(false)]
		public bool paymemberidSpecified
		{
			get
			{
				return this._paymemberid != null;
			}
			set
			{
				bool flag = value == (this._paymemberid == null);
				if (flag)
				{
					this._paymemberid = (value ? new uint?(this.paymemberid) : null);
				}
			}
		}

		// Token: 0x060076EE RID: 30446 RVA: 0x000E38B0 File Offset: 0x000E1AB0
		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		// Token: 0x060076EF RID: 30447 RVA: 0x000E38C8 File Offset: 0x000E1AC8
		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		// Token: 0x060076F0 RID: 30448 RVA: 0x000E38D4 File Offset: 0x000E1AD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C22 RID: 7202
		private ulong? _roleid;

		// Token: 0x04001C23 RID: 7203
		private RoleType? _profession;

		// Token: 0x04001C24 RID: 7204
		private string _name;

		// Token: 0x04001C25 RID: 7205
		private uint? _level;

		// Token: 0x04001C26 RID: 7206
		private uint? _ppt;

		// Token: 0x04001C27 RID: 7207
		private readonly List<uint> _fashion = new List<uint>();

		// Token: 0x04001C28 RID: 7208
		private OutLook _outlook = null;

		// Token: 0x04001C29 RID: 7209
		private uint? _viplevel;

		// Token: 0x04001C2A RID: 7210
		private uint? _paymemberid;

		// Token: 0x04001C2B RID: 7211
		private IExtension extensionObject;
	}
}
