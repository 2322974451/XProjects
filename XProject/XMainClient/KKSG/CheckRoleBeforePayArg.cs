using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000495 RID: 1173
	[ProtoContract(Name = "CheckRoleBeforePayArg")]
	[Serializable]
	public class CheckRoleBeforePayArg : IExtensible
	{
		// Token: 0x170012BB RID: 4795
		// (get) Token: 0x06003D18 RID: 15640 RVA: 0x00074A14 File Offset: 0x00072C14
		// (set) Token: 0x06003D19 RID: 15641 RVA: 0x00074A41 File Offset: 0x00072C41
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

		// Token: 0x170012BC RID: 4796
		// (get) Token: 0x06003D1A RID: 15642 RVA: 0x00074A50 File Offset: 0x00072C50
		// (set) Token: 0x06003D1B RID: 15643 RVA: 0x00074A70 File Offset: 0x00072C70
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

		// Token: 0x06003D1C RID: 15644 RVA: 0x00074AB4 File Offset: 0x00072CB4
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003D1D RID: 15645 RVA: 0x00074ACC File Offset: 0x00072CCC
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170012BD RID: 4797
		// (get) Token: 0x06003D1E RID: 15646 RVA: 0x00074AD8 File Offset: 0x00072CD8
		// (set) Token: 0x06003D1F RID: 15647 RVA: 0x00074B04 File Offset: 0x00072D04
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

		// Token: 0x170012BE RID: 4798
		// (get) Token: 0x06003D20 RID: 15648 RVA: 0x00074B14 File Offset: 0x00072D14
		// (set) Token: 0x06003D21 RID: 15649 RVA: 0x00074B34 File Offset: 0x00072D34
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

		// Token: 0x06003D22 RID: 15650 RVA: 0x00074B78 File Offset: 0x00072D78
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06003D23 RID: 15651 RVA: 0x00074B90 File Offset: 0x00072D90
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x170012BF RID: 4799
		// (get) Token: 0x06003D24 RID: 15652 RVA: 0x00074B9C File Offset: 0x00072D9C
		// (set) Token: 0x06003D25 RID: 15653 RVA: 0x00074BBD File Offset: 0x00072DBD
		[ProtoMember(3, IsRequired = false, Name = "openid", DataFormat = DataFormat.Default)]
		public string openid
		{
			get
			{
				return this._openid ?? "";
			}
			set
			{
				this._openid = value;
			}
		}

		// Token: 0x170012C0 RID: 4800
		// (get) Token: 0x06003D26 RID: 15654 RVA: 0x00074BC8 File Offset: 0x00072DC8
		// (set) Token: 0x06003D27 RID: 15655 RVA: 0x00074BE4 File Offset: 0x00072DE4
		[XmlIgnore]
		[Browsable(false)]
		public bool openidSpecified
		{
			get
			{
				return this._openid != null;
			}
			set
			{
				bool flag = value == (this._openid == null);
				if (flag)
				{
					this._openid = (value ? this.openid : null);
				}
			}
		}

		// Token: 0x06003D28 RID: 15656 RVA: 0x00074C14 File Offset: 0x00072E14
		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		// Token: 0x06003D29 RID: 15657 RVA: 0x00074C2C File Offset: 0x00072E2C
		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		// Token: 0x06003D2A RID: 15658 RVA: 0x00074C38 File Offset: 0x00072E38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F39 RID: 3897
		private ulong? _roleid;

		// Token: 0x04000F3A RID: 3898
		private uint? _serverid;

		// Token: 0x04000F3B RID: 3899
		private string _openid;

		// Token: 0x04000F3C RID: 3900
		private IExtension extensionObject;
	}
}
