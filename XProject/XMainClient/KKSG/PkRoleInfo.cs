using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005C5 RID: 1477
	[ProtoContract(Name = "PkRoleInfo")]
	[Serializable]
	public class PkRoleInfo : IExtensible
	{
		// Token: 0x170019AC RID: 6572
		// (get) Token: 0x060052F8 RID: 21240 RVA: 0x0009DD38 File Offset: 0x0009BF38
		// (set) Token: 0x060052F9 RID: 21241 RVA: 0x0009DD50 File Offset: 0x0009BF50
		[ProtoMember(1, IsRequired = false, Name = "pkrec", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkRoleRec pkrec
		{
			get
			{
				return this._pkrec;
			}
			set
			{
				this._pkrec = value;
			}
		}

		// Token: 0x170019AD RID: 6573
		// (get) Token: 0x060052FA RID: 21242 RVA: 0x0009DD5C File Offset: 0x0009BF5C
		// (set) Token: 0x060052FB RID: 21243 RVA: 0x0009DD74 File Offset: 0x0009BF74
		[ProtoMember(2, IsRequired = false, Name = "rolebrief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleSmallInfo rolebrief
		{
			get
			{
				return this._rolebrief;
			}
			set
			{
				this._rolebrief = value;
			}
		}

		// Token: 0x170019AE RID: 6574
		// (get) Token: 0x060052FC RID: 21244 RVA: 0x0009DD80 File Offset: 0x0009BF80
		// (set) Token: 0x060052FD RID: 21245 RVA: 0x0009DDAC File Offset: 0x0009BFAC
		[ProtoMember(3, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170019AF RID: 6575
		// (get) Token: 0x060052FE RID: 21246 RVA: 0x0009DDBC File Offset: 0x0009BFBC
		// (set) Token: 0x060052FF RID: 21247 RVA: 0x0009DDDC File Offset: 0x0009BFDC
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

		// Token: 0x06005300 RID: 21248 RVA: 0x0009DE20 File Offset: 0x0009C020
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06005301 RID: 21249 RVA: 0x0009DE38 File Offset: 0x0009C038
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x06005302 RID: 21250 RVA: 0x0009DE44 File Offset: 0x0009C044
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001448 RID: 5192
		private PkRoleRec _pkrec = null;

		// Token: 0x04001449 RID: 5193
		private RoleSmallInfo _rolebrief = null;

		// Token: 0x0400144A RID: 5194
		private uint? _serverid;

		// Token: 0x0400144B RID: 5195
		private IExtension extensionObject;
	}
}
