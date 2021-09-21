using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000251 RID: 593
	[ProtoContract(Name = "OpenPrivateChat")]
	[Serializable]
	public class OpenPrivateChat : IExtensible
	{
		// Token: 0x17000A5F RID: 2655
		// (get) Token: 0x06002142 RID: 8514 RVA: 0x00041220 File Offset: 0x0003F420
		// (set) Token: 0x06002143 RID: 8515 RVA: 0x0004124D File Offset: 0x0003F44D
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

		// Token: 0x17000A60 RID: 2656
		// (get) Token: 0x06002144 RID: 8516 RVA: 0x0004125C File Offset: 0x0003F45C
		// (set) Token: 0x06002145 RID: 8517 RVA: 0x0004127C File Offset: 0x0003F47C
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

		// Token: 0x06002146 RID: 8518 RVA: 0x000412C0 File Offset: 0x0003F4C0
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06002147 RID: 8519 RVA: 0x000412D8 File Offset: 0x0003F4D8
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06002148 RID: 8520 RVA: 0x000412E4 File Offset: 0x0003F4E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000844 RID: 2116
		private ulong? _roleid;

		// Token: 0x04000845 RID: 2117
		private IExtension extensionObject;
	}
}
