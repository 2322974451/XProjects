using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004B5 RID: 1205
	[ProtoContract(Name = "LeaveDragonGuildArg")]
	[Serializable]
	public class LeaveDragonGuildArg : IExtensible
	{
		// Token: 0x17001341 RID: 4929
		// (get) Token: 0x06003ED6 RID: 16086 RVA: 0x00077D88 File Offset: 0x00075F88
		// (set) Token: 0x06003ED7 RID: 16087 RVA: 0x00077DB5 File Offset: 0x00075FB5
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

		// Token: 0x17001342 RID: 4930
		// (get) Token: 0x06003ED8 RID: 16088 RVA: 0x00077DC4 File Offset: 0x00075FC4
		// (set) Token: 0x06003ED9 RID: 16089 RVA: 0x00077DE4 File Offset: 0x00075FE4
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

		// Token: 0x06003EDA RID: 16090 RVA: 0x00077E28 File Offset: 0x00076028
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003EDB RID: 16091 RVA: 0x00077E40 File Offset: 0x00076040
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06003EDC RID: 16092 RVA: 0x00077E4C File Offset: 0x0007604C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FA2 RID: 4002
		private ulong? _roleid;

		// Token: 0x04000FA3 RID: 4003
		private IExtension extensionObject;
	}
}
