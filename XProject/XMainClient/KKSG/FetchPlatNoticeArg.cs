using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002E9 RID: 745
	[ProtoContract(Name = "FetchPlatNoticeArg")]
	[Serializable]
	public class FetchPlatNoticeArg : IExtensible
	{
		// Token: 0x17000CB6 RID: 3254
		// (get) Token: 0x060028F2 RID: 10482 RVA: 0x0004F830 File Offset: 0x0004DA30
		// (set) Token: 0x060028F3 RID: 10483 RVA: 0x0004F85C File Offset: 0x0004DA5C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public LoginType type
		{
			get
			{
				return this._type ?? LoginType.LOGIN_PASSWORD;
			}
			set
			{
				this._type = new LoginType?(value);
			}
		}

		// Token: 0x17000CB7 RID: 3255
		// (get) Token: 0x060028F4 RID: 10484 RVA: 0x0004F86C File Offset: 0x0004DA6C
		// (set) Token: 0x060028F5 RID: 10485 RVA: 0x0004F88C File Offset: 0x0004DA8C
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
					this._type = (value ? new LoginType?(this.type) : null);
				}
			}
		}

		// Token: 0x060028F6 RID: 10486 RVA: 0x0004F8D0 File Offset: 0x0004DAD0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060028F7 RID: 10487 RVA: 0x0004F8E8 File Offset: 0x0004DAE8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000CB8 RID: 3256
		// (get) Token: 0x060028F8 RID: 10488 RVA: 0x0004F8F4 File Offset: 0x0004DAF4
		// (set) Token: 0x060028F9 RID: 10489 RVA: 0x0004F920 File Offset: 0x0004DB20
		[ProtoMember(2, IsRequired = false, Name = "platid", DataFormat = DataFormat.TwosComplement)]
		public PlatType platid
		{
			get
			{
				return this._platid ?? PlatType.PLAT_IOS;
			}
			set
			{
				this._platid = new PlatType?(value);
			}
		}

		// Token: 0x17000CB9 RID: 3257
		// (get) Token: 0x060028FA RID: 10490 RVA: 0x0004F930 File Offset: 0x0004DB30
		// (set) Token: 0x060028FB RID: 10491 RVA: 0x0004F950 File Offset: 0x0004DB50
		[XmlIgnore]
		[Browsable(false)]
		public bool platidSpecified
		{
			get
			{
				return this._platid != null;
			}
			set
			{
				bool flag = value == (this._platid == null);
				if (flag)
				{
					this._platid = (value ? new PlatType?(this.platid) : null);
				}
			}
		}

		// Token: 0x060028FC RID: 10492 RVA: 0x0004F994 File Offset: 0x0004DB94
		private bool ShouldSerializeplatid()
		{
			return this.platidSpecified;
		}

		// Token: 0x060028FD RID: 10493 RVA: 0x0004F9AC File Offset: 0x0004DBAC
		private void Resetplatid()
		{
			this.platidSpecified = false;
		}

		// Token: 0x060028FE RID: 10494 RVA: 0x0004F9B8 File Offset: 0x0004DBB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A2D RID: 2605
		private LoginType? _type;

		// Token: 0x04000A2E RID: 2606
		private PlatType? _platid;

		// Token: 0x04000A2F RID: 2607
		private IExtension extensionObject;
	}
}
