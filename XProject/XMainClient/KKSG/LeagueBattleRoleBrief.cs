using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006F1 RID: 1777
	[ProtoContract(Name = "LeagueBattleRoleBrief")]
	[Serializable]
	public class LeagueBattleRoleBrief : IExtensible
	{
		// Token: 0x170025C7 RID: 9671
		// (get) Token: 0x0600774C RID: 30540 RVA: 0x000E437C File Offset: 0x000E257C
		// (set) Token: 0x0600774D RID: 30541 RVA: 0x000E43A9 File Offset: 0x000E25A9
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

		// Token: 0x170025C8 RID: 9672
		// (get) Token: 0x0600774E RID: 30542 RVA: 0x000E43B8 File Offset: 0x000E25B8
		// (set) Token: 0x0600774F RID: 30543 RVA: 0x000E43D8 File Offset: 0x000E25D8
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

		// Token: 0x06007750 RID: 30544 RVA: 0x000E441C File Offset: 0x000E261C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007751 RID: 30545 RVA: 0x000E4434 File Offset: 0x000E2634
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170025C9 RID: 9673
		// (get) Token: 0x06007752 RID: 30546 RVA: 0x000E4440 File Offset: 0x000E2640
		// (set) Token: 0x06007753 RID: 30547 RVA: 0x000E4461 File Offset: 0x000E2661
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

		// Token: 0x170025CA RID: 9674
		// (get) Token: 0x06007754 RID: 30548 RVA: 0x000E446C File Offset: 0x000E266C
		// (set) Token: 0x06007755 RID: 30549 RVA: 0x000E4488 File Offset: 0x000E2688
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

		// Token: 0x06007756 RID: 30550 RVA: 0x000E44B8 File Offset: 0x000E26B8
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007757 RID: 30551 RVA: 0x000E44D0 File Offset: 0x000E26D0
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170025CB RID: 9675
		// (get) Token: 0x06007758 RID: 30552 RVA: 0x000E44DC File Offset: 0x000E26DC
		// (set) Token: 0x06007759 RID: 30553 RVA: 0x000E4508 File Offset: 0x000E2708
		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170025CC RID: 9676
		// (get) Token: 0x0600775A RID: 30554 RVA: 0x000E4518 File Offset: 0x000E2718
		// (set) Token: 0x0600775B RID: 30555 RVA: 0x000E4538 File Offset: 0x000E2738
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

		// Token: 0x0600775C RID: 30556 RVA: 0x000E457C File Offset: 0x000E277C
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x0600775D RID: 30557 RVA: 0x000E4594 File Offset: 0x000E2794
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170025CD RID: 9677
		// (get) Token: 0x0600775E RID: 30558 RVA: 0x000E45A0 File Offset: 0x000E27A0
		// (set) Token: 0x0600775F RID: 30559 RVA: 0x000E45CC File Offset: 0x000E27CC
		[ProtoMember(4, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170025CE RID: 9678
		// (get) Token: 0x06007760 RID: 30560 RVA: 0x000E45DC File Offset: 0x000E27DC
		// (set) Token: 0x06007761 RID: 30561 RVA: 0x000E45FC File Offset: 0x000E27FC
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

		// Token: 0x06007762 RID: 30562 RVA: 0x000E4640 File Offset: 0x000E2840
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06007763 RID: 30563 RVA: 0x000E4658 File Offset: 0x000E2858
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x170025CF RID: 9679
		// (get) Token: 0x06007764 RID: 30564 RVA: 0x000E4664 File Offset: 0x000E2864
		// (set) Token: 0x06007765 RID: 30565 RVA: 0x000E4690 File Offset: 0x000E2890
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

		// Token: 0x170025D0 RID: 9680
		// (get) Token: 0x06007766 RID: 30566 RVA: 0x000E46A0 File Offset: 0x000E28A0
		// (set) Token: 0x06007767 RID: 30567 RVA: 0x000E46C0 File Offset: 0x000E28C0
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

		// Token: 0x06007768 RID: 30568 RVA: 0x000E4704 File Offset: 0x000E2904
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06007769 RID: 30569 RVA: 0x000E471C File Offset: 0x000E291C
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x170025D1 RID: 9681
		// (get) Token: 0x0600776A RID: 30570 RVA: 0x000E4728 File Offset: 0x000E2928
		// (set) Token: 0x0600776B RID: 30571 RVA: 0x000E4754 File Offset: 0x000E2954
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

		// Token: 0x170025D2 RID: 9682
		// (get) Token: 0x0600776C RID: 30572 RVA: 0x000E4764 File Offset: 0x000E2964
		// (set) Token: 0x0600776D RID: 30573 RVA: 0x000E4784 File Offset: 0x000E2984
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

		// Token: 0x0600776E RID: 30574 RVA: 0x000E47C8 File Offset: 0x000E29C8
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x0600776F RID: 30575 RVA: 0x000E47E0 File Offset: 0x000E29E0
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x170025D3 RID: 9683
		// (get) Token: 0x06007770 RID: 30576 RVA: 0x000E47EC File Offset: 0x000E29EC
		// (set) Token: 0x06007771 RID: 30577 RVA: 0x000E4818 File Offset: 0x000E2A18
		[ProtoMember(7, IsRequired = false, Name = "pkpoint", DataFormat = DataFormat.TwosComplement)]
		public uint pkpoint
		{
			get
			{
				return this._pkpoint ?? 0U;
			}
			set
			{
				this._pkpoint = new uint?(value);
			}
		}

		// Token: 0x170025D4 RID: 9684
		// (get) Token: 0x06007772 RID: 30578 RVA: 0x000E4828 File Offset: 0x000E2A28
		// (set) Token: 0x06007773 RID: 30579 RVA: 0x000E4848 File Offset: 0x000E2A48
		[XmlIgnore]
		[Browsable(false)]
		public bool pkpointSpecified
		{
			get
			{
				return this._pkpoint != null;
			}
			set
			{
				bool flag = value == (this._pkpoint == null);
				if (flag)
				{
					this._pkpoint = (value ? new uint?(this.pkpoint) : null);
				}
			}
		}

		// Token: 0x06007774 RID: 30580 RVA: 0x000E488C File Offset: 0x000E2A8C
		private bool ShouldSerializepkpoint()
		{
			return this.pkpointSpecified;
		}

		// Token: 0x06007775 RID: 30581 RVA: 0x000E48A4 File Offset: 0x000E2AA4
		private void Resetpkpoint()
		{
			this.pkpointSpecified = false;
		}

		// Token: 0x170025D5 RID: 9685
		// (get) Token: 0x06007776 RID: 30582 RVA: 0x000E48B0 File Offset: 0x000E2AB0
		// (set) Token: 0x06007777 RID: 30583 RVA: 0x000E48D1 File Offset: 0x000E2AD1
		[ProtoMember(8, IsRequired = false, Name = "account", DataFormat = DataFormat.Default)]
		public string account
		{
			get
			{
				return this._account ?? "";
			}
			set
			{
				this._account = value;
			}
		}

		// Token: 0x170025D6 RID: 9686
		// (get) Token: 0x06007778 RID: 30584 RVA: 0x000E48DC File Offset: 0x000E2ADC
		// (set) Token: 0x06007779 RID: 30585 RVA: 0x000E48F8 File Offset: 0x000E2AF8
		[XmlIgnore]
		[Browsable(false)]
		public bool accountSpecified
		{
			get
			{
				return this._account != null;
			}
			set
			{
				bool flag = value == (this._account == null);
				if (flag)
				{
					this._account = (value ? this.account : null);
				}
			}
		}

		// Token: 0x0600777A RID: 30586 RVA: 0x000E4928 File Offset: 0x000E2B28
		private bool ShouldSerializeaccount()
		{
			return this.accountSpecified;
		}

		// Token: 0x0600777B RID: 30587 RVA: 0x000E4940 File Offset: 0x000E2B40
		private void Resetaccount()
		{
			this.accountSpecified = false;
		}

		// Token: 0x0600777C RID: 30588 RVA: 0x000E494C File Offset: 0x000E2B4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C3E RID: 7230
		private ulong? _roleid;

		// Token: 0x04001C3F RID: 7231
		private string _name;

		// Token: 0x04001C40 RID: 7232
		private uint? _level;

		// Token: 0x04001C41 RID: 7233
		private uint? _serverid;

		// Token: 0x04001C42 RID: 7234
		private uint? _profession;

		// Token: 0x04001C43 RID: 7235
		private uint? _ppt;

		// Token: 0x04001C44 RID: 7236
		private uint? _pkpoint;

		// Token: 0x04001C45 RID: 7237
		private string _account;

		// Token: 0x04001C46 RID: 7238
		private IExtension extensionObject;
	}
}
