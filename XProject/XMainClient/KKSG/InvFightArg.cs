using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000325 RID: 805
	[ProtoContract(Name = "InvFightArg")]
	[Serializable]
	public class InvFightArg : IExtensible
	{
		// Token: 0x17000DBD RID: 3517
		// (get) Token: 0x06002C51 RID: 11345 RVA: 0x00055D6C File Offset: 0x00053F6C
		// (set) Token: 0x06002C52 RID: 11346 RVA: 0x00055D98 File Offset: 0x00053F98
		[ProtoMember(1, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public InvFightReqType reqtype
		{
			get
			{
				return this._reqtype ?? InvFightReqType.IFRT_INV_ONE;
			}
			set
			{
				this._reqtype = new InvFightReqType?(value);
			}
		}

		// Token: 0x17000DBE RID: 3518
		// (get) Token: 0x06002C53 RID: 11347 RVA: 0x00055DA8 File Offset: 0x00053FA8
		// (set) Token: 0x06002C54 RID: 11348 RVA: 0x00055DC8 File Offset: 0x00053FC8
		[XmlIgnore]
		[Browsable(false)]
		public bool reqtypeSpecified
		{
			get
			{
				return this._reqtype != null;
			}
			set
			{
				bool flag = value == (this._reqtype == null);
				if (flag)
				{
					this._reqtype = (value ? new InvFightReqType?(this.reqtype) : null);
				}
			}
		}

		// Token: 0x06002C55 RID: 11349 RVA: 0x00055E0C File Offset: 0x0005400C
		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		// Token: 0x06002C56 RID: 11350 RVA: 0x00055E24 File Offset: 0x00054024
		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

		// Token: 0x17000DBF RID: 3519
		// (get) Token: 0x06002C57 RID: 11351 RVA: 0x00055E30 File Offset: 0x00054030
		// (set) Token: 0x06002C58 RID: 11352 RVA: 0x00055E5D File Offset: 0x0005405D
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000DC0 RID: 3520
		// (get) Token: 0x06002C59 RID: 11353 RVA: 0x00055E6C File Offset: 0x0005406C
		// (set) Token: 0x06002C5A RID: 11354 RVA: 0x00055E8C File Offset: 0x0005408C
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

		// Token: 0x06002C5B RID: 11355 RVA: 0x00055ED0 File Offset: 0x000540D0
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06002C5C RID: 11356 RVA: 0x00055EE8 File Offset: 0x000540E8
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17000DC1 RID: 3521
		// (get) Token: 0x06002C5D RID: 11357 RVA: 0x00055EF4 File Offset: 0x000540F4
		// (set) Token: 0x06002C5E RID: 11358 RVA: 0x00055F21 File Offset: 0x00054121
		[ProtoMember(3, IsRequired = false, Name = "invid", DataFormat = DataFormat.TwosComplement)]
		public ulong invid
		{
			get
			{
				return this._invid ?? 0UL;
			}
			set
			{
				this._invid = new ulong?(value);
			}
		}

		// Token: 0x17000DC2 RID: 3522
		// (get) Token: 0x06002C5F RID: 11359 RVA: 0x00055F30 File Offset: 0x00054130
		// (set) Token: 0x06002C60 RID: 11360 RVA: 0x00055F50 File Offset: 0x00054150
		[XmlIgnore]
		[Browsable(false)]
		public bool invidSpecified
		{
			get
			{
				return this._invid != null;
			}
			set
			{
				bool flag = value == (this._invid == null);
				if (flag)
				{
					this._invid = (value ? new ulong?(this.invid) : null);
				}
			}
		}

		// Token: 0x06002C61 RID: 11361 RVA: 0x00055F94 File Offset: 0x00054194
		private bool ShouldSerializeinvid()
		{
			return this.invidSpecified;
		}

		// Token: 0x06002C62 RID: 11362 RVA: 0x00055FAC File Offset: 0x000541AC
		private void Resetinvid()
		{
			this.invidSpecified = false;
		}

		// Token: 0x17000DC3 RID: 3523
		// (get) Token: 0x06002C63 RID: 11363 RVA: 0x00055FB8 File Offset: 0x000541B8
		// (set) Token: 0x06002C64 RID: 11364 RVA: 0x00055FE4 File Offset: 0x000541E4
		[ProtoMember(4, IsRequired = false, Name = "iscross", DataFormat = DataFormat.Default)]
		public bool iscross
		{
			get
			{
				return this._iscross ?? false;
			}
			set
			{
				this._iscross = new bool?(value);
			}
		}

		// Token: 0x17000DC4 RID: 3524
		// (get) Token: 0x06002C65 RID: 11365 RVA: 0x00055FF4 File Offset: 0x000541F4
		// (set) Token: 0x06002C66 RID: 11366 RVA: 0x00056014 File Offset: 0x00054214
		[XmlIgnore]
		[Browsable(false)]
		public bool iscrossSpecified
		{
			get
			{
				return this._iscross != null;
			}
			set
			{
				bool flag = value == (this._iscross == null);
				if (flag)
				{
					this._iscross = (value ? new bool?(this.iscross) : null);
				}
			}
		}

		// Token: 0x06002C67 RID: 11367 RVA: 0x00056058 File Offset: 0x00054258
		private bool ShouldSerializeiscross()
		{
			return this.iscrossSpecified;
		}

		// Token: 0x06002C68 RID: 11368 RVA: 0x00056070 File Offset: 0x00054270
		private void Resetiscross()
		{
			this.iscrossSpecified = false;
		}

		// Token: 0x17000DC5 RID: 3525
		// (get) Token: 0x06002C69 RID: 11369 RVA: 0x0005607C File Offset: 0x0005427C
		// (set) Token: 0x06002C6A RID: 11370 RVA: 0x0005609D File Offset: 0x0005429D
		[ProtoMember(5, IsRequired = false, Name = "account", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000DC6 RID: 3526
		// (get) Token: 0x06002C6B RID: 11371 RVA: 0x000560A8 File Offset: 0x000542A8
		// (set) Token: 0x06002C6C RID: 11372 RVA: 0x000560C4 File Offset: 0x000542C4
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

		// Token: 0x06002C6D RID: 11373 RVA: 0x000560F4 File Offset: 0x000542F4
		private bool ShouldSerializeaccount()
		{
			return this.accountSpecified;
		}

		// Token: 0x06002C6E RID: 11374 RVA: 0x0005610C File Offset: 0x0005430C
		private void Resetaccount()
		{
			this.accountSpecified = false;
		}

		// Token: 0x06002C6F RID: 11375 RVA: 0x00056118 File Offset: 0x00054318
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AF9 RID: 2809
		private InvFightReqType? _reqtype;

		// Token: 0x04000AFA RID: 2810
		private ulong? _roleid;

		// Token: 0x04000AFB RID: 2811
		private ulong? _invid;

		// Token: 0x04000AFC RID: 2812
		private bool? _iscross;

		// Token: 0x04000AFD RID: 2813
		private string _account;

		// Token: 0x04000AFE RID: 2814
		private IExtension extensionObject;
	}
}
