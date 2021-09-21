using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002D9 RID: 729
	[ProtoContract(Name = "AddGuildInheritArg")]
	[Serializable]
	public class AddGuildInheritArg : IExtensible
	{
		// Token: 0x17000C80 RID: 3200
		// (get) Token: 0x06002833 RID: 10291 RVA: 0x0004E210 File Offset: 0x0004C410
		// (set) Token: 0x06002834 RID: 10292 RVA: 0x0004E23D File Offset: 0x0004C43D
		[ProtoMember(1, IsRequired = false, Name = "reqRoleId", DataFormat = DataFormat.TwosComplement)]
		public ulong reqRoleId
		{
			get
			{
				return this._reqRoleId ?? 0UL;
			}
			set
			{
				this._reqRoleId = new ulong?(value);
			}
		}

		// Token: 0x17000C81 RID: 3201
		// (get) Token: 0x06002835 RID: 10293 RVA: 0x0004E24C File Offset: 0x0004C44C
		// (set) Token: 0x06002836 RID: 10294 RVA: 0x0004E26C File Offset: 0x0004C46C
		[XmlIgnore]
		[Browsable(false)]
		public bool reqRoleIdSpecified
		{
			get
			{
				return this._reqRoleId != null;
			}
			set
			{
				bool flag = value == (this._reqRoleId == null);
				if (flag)
				{
					this._reqRoleId = (value ? new ulong?(this.reqRoleId) : null);
				}
			}
		}

		// Token: 0x06002837 RID: 10295 RVA: 0x0004E2B0 File Offset: 0x0004C4B0
		private bool ShouldSerializereqRoleId()
		{
			return this.reqRoleIdSpecified;
		}

		// Token: 0x06002838 RID: 10296 RVA: 0x0004E2C8 File Offset: 0x0004C4C8
		private void ResetreqRoleId()
		{
			this.reqRoleIdSpecified = false;
		}

		// Token: 0x06002839 RID: 10297 RVA: 0x0004E2D4 File Offset: 0x0004C4D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A01 RID: 2561
		private ulong? _reqRoleId;

		// Token: 0x04000A02 RID: 2562
		private IExtension extensionObject;
	}
}
