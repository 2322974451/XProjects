using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200070F RID: 1807
	[ProtoContract(Name = "SkyTeamMemberInfo")]
	[Serializable]
	public class SkyTeamMemberInfo : IExtensible
	{
		// Token: 0x170026E5 RID: 9957
		// (get) Token: 0x06007AB9 RID: 31417 RVA: 0x000EA998 File Offset: 0x000E8B98
		// (set) Token: 0x06007ABA RID: 31418 RVA: 0x000EA9B0 File Offset: 0x000E8BB0
		[ProtoMember(1, IsRequired = false, Name = "brief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleOutLookBrief brief
		{
			get
			{
				return this._brief;
			}
			set
			{
				this._brief = value;
			}
		}

		// Token: 0x06007ABB RID: 31419 RVA: 0x000EA9BC File Offset: 0x000E8BBC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CFA RID: 7418
		private RoleOutLookBrief _brief = null;

		// Token: 0x04001CFB RID: 7419
		private IExtension extensionObject;
	}
}
