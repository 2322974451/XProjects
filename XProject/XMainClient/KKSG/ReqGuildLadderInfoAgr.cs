using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200023C RID: 572
	[ProtoContract(Name = "ReqGuildLadderInfoAgr")]
	[Serializable]
	public class ReqGuildLadderInfoAgr : IExtensible
	{
		// Token: 0x170009EA RID: 2538
		// (get) Token: 0x06001FCB RID: 8139 RVA: 0x0003E50C File Offset: 0x0003C70C
		// (set) Token: 0x06001FCC RID: 8140 RVA: 0x0003E539 File Offset: 0x0003C739
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

		// Token: 0x170009EB RID: 2539
		// (get) Token: 0x06001FCD RID: 8141 RVA: 0x0003E548 File Offset: 0x0003C748
		// (set) Token: 0x06001FCE RID: 8142 RVA: 0x0003E568 File Offset: 0x0003C768
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

		// Token: 0x06001FCF RID: 8143 RVA: 0x0003E5AC File Offset: 0x0003C7AC
		private bool ShouldSerializeroleId()
		{
			return this.roleIdSpecified;
		}

		// Token: 0x06001FD0 RID: 8144 RVA: 0x0003E5C4 File Offset: 0x0003C7C4
		private void ResetroleId()
		{
			this.roleIdSpecified = false;
		}

		// Token: 0x06001FD1 RID: 8145 RVA: 0x0003E5D0 File Offset: 0x0003C7D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007F0 RID: 2032
		private ulong? _roleId;

		// Token: 0x040007F1 RID: 2033
		private IExtension extensionObject;
	}
}
