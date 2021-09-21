using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000717 RID: 1815
	[ProtoContract(Name = "PkMatchStage")]
	[Serializable]
	public class PkMatchStage : IExtensible
	{
		// Token: 0x17002726 RID: 10022
		// (get) Token: 0x06007B83 RID: 31619 RVA: 0x000EC16C File Offset: 0x000EA36C
		// (set) Token: 0x06007B84 RID: 31620 RVA: 0x000EC198 File Offset: 0x000EA398
		[ProtoMember(1, IsRequired = false, Name = "ctime", DataFormat = DataFormat.TwosComplement)]
		public uint ctime
		{
			get
			{
				return this._ctime ?? 0U;
			}
			set
			{
				this._ctime = new uint?(value);
			}
		}

		// Token: 0x17002727 RID: 10023
		// (get) Token: 0x06007B85 RID: 31621 RVA: 0x000EC1A8 File Offset: 0x000EA3A8
		// (set) Token: 0x06007B86 RID: 31622 RVA: 0x000EC1C8 File Offset: 0x000EA3C8
		[XmlIgnore]
		[Browsable(false)]
		public bool ctimeSpecified
		{
			get
			{
				return this._ctime != null;
			}
			set
			{
				bool flag = value == (this._ctime == null);
				if (flag)
				{
					this._ctime = (value ? new uint?(this.ctime) : null);
				}
			}
		}

		// Token: 0x06007B87 RID: 31623 RVA: 0x000EC20C File Offset: 0x000EA40C
		private bool ShouldSerializectime()
		{
			return this.ctimeSpecified;
		}

		// Token: 0x06007B88 RID: 31624 RVA: 0x000EC224 File Offset: 0x000EA424
		private void Resetctime()
		{
			this.ctimeSpecified = false;
		}

		// Token: 0x17002728 RID: 10024
		// (get) Token: 0x06007B89 RID: 31625 RVA: 0x000EC230 File Offset: 0x000EA430
		// (set) Token: 0x06007B8A RID: 31626 RVA: 0x000EC25C File Offset: 0x000EA45C
		[ProtoMember(2, IsRequired = false, Name = "span", DataFormat = DataFormat.TwosComplement)]
		public uint span
		{
			get
			{
				return this._span ?? 0U;
			}
			set
			{
				this._span = new uint?(value);
			}
		}

		// Token: 0x17002729 RID: 10025
		// (get) Token: 0x06007B8B RID: 31627 RVA: 0x000EC26C File Offset: 0x000EA46C
		// (set) Token: 0x06007B8C RID: 31628 RVA: 0x000EC28C File Offset: 0x000EA48C
		[XmlIgnore]
		[Browsable(false)]
		public bool spanSpecified
		{
			get
			{
				return this._span != null;
			}
			set
			{
				bool flag = value == (this._span == null);
				if (flag)
				{
					this._span = (value ? new uint?(this.span) : null);
				}
			}
		}

		// Token: 0x06007B8D RID: 31629 RVA: 0x000EC2D0 File Offset: 0x000EA4D0
		private bool ShouldSerializespan()
		{
			return this.spanSpecified;
		}

		// Token: 0x06007B8E RID: 31630 RVA: 0x000EC2E8 File Offset: 0x000EA4E8
		private void Resetspan()
		{
			this.spanSpecified = false;
		}

		// Token: 0x1700272A RID: 10026
		// (get) Token: 0x06007B8F RID: 31631 RVA: 0x000EC2F4 File Offset: 0x000EA4F4
		// (set) Token: 0x06007B90 RID: 31632 RVA: 0x000EC320 File Offset: 0x000EA520
		[ProtoMember(3, IsRequired = false, Name = "robotpercent", DataFormat = DataFormat.TwosComplement)]
		public uint robotpercent
		{
			get
			{
				return this._robotpercent ?? 0U;
			}
			set
			{
				this._robotpercent = new uint?(value);
			}
		}

		// Token: 0x1700272B RID: 10027
		// (get) Token: 0x06007B91 RID: 31633 RVA: 0x000EC330 File Offset: 0x000EA530
		// (set) Token: 0x06007B92 RID: 31634 RVA: 0x000EC350 File Offset: 0x000EA550
		[XmlIgnore]
		[Browsable(false)]
		public bool robotpercentSpecified
		{
			get
			{
				return this._robotpercent != null;
			}
			set
			{
				bool flag = value == (this._robotpercent == null);
				if (flag)
				{
					this._robotpercent = (value ? new uint?(this.robotpercent) : null);
				}
			}
		}

		// Token: 0x06007B93 RID: 31635 RVA: 0x000EC394 File Offset: 0x000EA594
		private bool ShouldSerializerobotpercent()
		{
			return this.robotpercentSpecified;
		}

		// Token: 0x06007B94 RID: 31636 RVA: 0x000EC3AC File Offset: 0x000EA5AC
		private void Resetrobotpercent()
		{
			this.robotpercentSpecified = false;
		}

		// Token: 0x1700272C RID: 10028
		// (get) Token: 0x06007B95 RID: 31637 RVA: 0x000EC3B8 File Offset: 0x000EA5B8
		// (set) Token: 0x06007B96 RID: 31638 RVA: 0x000EC3E4 File Offset: 0x000EA5E4
		[ProtoMember(4, IsRequired = false, Name = "lookupid", DataFormat = DataFormat.TwosComplement)]
		public int lookupid
		{
			get
			{
				return this._lookupid ?? 0;
			}
			set
			{
				this._lookupid = new int?(value);
			}
		}

		// Token: 0x1700272D RID: 10029
		// (get) Token: 0x06007B97 RID: 31639 RVA: 0x000EC3F4 File Offset: 0x000EA5F4
		// (set) Token: 0x06007B98 RID: 31640 RVA: 0x000EC414 File Offset: 0x000EA614
		[XmlIgnore]
		[Browsable(false)]
		public bool lookupidSpecified
		{
			get
			{
				return this._lookupid != null;
			}
			set
			{
				bool flag = value == (this._lookupid == null);
				if (flag)
				{
					this._lookupid = (value ? new int?(this.lookupid) : null);
				}
			}
		}

		// Token: 0x06007B99 RID: 31641 RVA: 0x000EC458 File Offset: 0x000EA658
		private bool ShouldSerializelookupid()
		{
			return this.lookupidSpecified;
		}

		// Token: 0x06007B9A RID: 31642 RVA: 0x000EC470 File Offset: 0x000EA670
		private void Resetlookupid()
		{
			this.lookupidSpecified = false;
		}

		// Token: 0x06007B9B RID: 31643 RVA: 0x000EC47C File Offset: 0x000EA67C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D25 RID: 7461
		private uint? _ctime;

		// Token: 0x04001D26 RID: 7462
		private uint? _span;

		// Token: 0x04001D27 RID: 7463
		private uint? _robotpercent;

		// Token: 0x04001D28 RID: 7464
		private int? _lookupid;

		// Token: 0x04001D29 RID: 7465
		private IExtension extensionObject;
	}
}
