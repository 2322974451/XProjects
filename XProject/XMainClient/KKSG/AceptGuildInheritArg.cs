using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002DA RID: 730
	[ProtoContract(Name = "AceptGuildInheritArg")]
	[Serializable]
	public class AceptGuildInheritArg : IExtensible
	{
		// Token: 0x17000C82 RID: 3202
		// (get) Token: 0x0600283B RID: 10299 RVA: 0x0004E2F4 File Offset: 0x0004C4F4
		// (set) Token: 0x0600283C RID: 10300 RVA: 0x0004E321 File Offset: 0x0004C521
		[ProtoMember(1, IsRequired = false, Name = "roleId", DataFormat = DataFormat.TwosComplement)]
		public ulong roleId
		{
			get
			{
				return this._roleId ?? 0UL;
			}
			set
			{
				this._roleId = new ulong?(value);
			}
		}

		// Token: 0x17000C83 RID: 3203
		// (get) Token: 0x0600283D RID: 10301 RVA: 0x0004E330 File Offset: 0x0004C530
		// (set) Token: 0x0600283E RID: 10302 RVA: 0x0004E350 File Offset: 0x0004C550
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIdSpecified
		{
			get
			{
				return this._roleId != null;
			}
			set
			{
				bool flag = value == (this._roleId == null);
				if (flag)
				{
					this._roleId = (value ? new ulong?(this.roleId) : null);
				}
			}
		}

		// Token: 0x0600283F RID: 10303 RVA: 0x0004E394 File Offset: 0x0004C594
		private bool ShouldSerializeroleId()
		{
			return this.roleIdSpecified;
		}

		// Token: 0x06002840 RID: 10304 RVA: 0x0004E3AC File Offset: 0x0004C5AC
		private void ResetroleId()
		{
			this.roleIdSpecified = false;
		}

		// Token: 0x06002841 RID: 10305 RVA: 0x0004E3B8 File Offset: 0x0004C5B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A03 RID: 2563
		private ulong? _roleId;

		// Token: 0x04000A04 RID: 2564
		private IExtension extensionObject;
	}
}
