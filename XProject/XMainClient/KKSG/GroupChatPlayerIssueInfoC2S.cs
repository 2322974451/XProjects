using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000452 RID: 1106
	[ProtoContract(Name = "GroupChatPlayerIssueInfoC2S")]
	[Serializable]
	public class GroupChatPlayerIssueInfoC2S : IExtensible
	{
		// Token: 0x170011E0 RID: 4576
		// (get) Token: 0x06003A44 RID: 14916 RVA: 0x0006F738 File Offset: 0x0006D938
		// (set) Token: 0x06003A45 RID: 14917 RVA: 0x0006F750 File Offset: 0x0006D950
		[ProtoMember(1, IsRequired = false, Name = "roleinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GroupChatFindRoleInfo roleinfo
		{
			get
			{
				return this._roleinfo;
			}
			set
			{
				this._roleinfo = value;
			}
		}

		// Token: 0x06003A46 RID: 14918 RVA: 0x0006F75C File Offset: 0x0006D95C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E75 RID: 3701
		private GroupChatFindRoleInfo _roleinfo = null;

		// Token: 0x04000E76 RID: 3702
		private IExtension extensionObject;
	}
}
