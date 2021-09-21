using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000454 RID: 1108
	[ProtoContract(Name = "GroupChatLeaderIssueInfoC2S")]
	[Serializable]
	public class GroupChatLeaderIssueInfoC2S : IExtensible
	{
		// Token: 0x170011E3 RID: 4579
		// (get) Token: 0x06003A50 RID: 14928 RVA: 0x0006F870 File Offset: 0x0006DA70
		// (set) Token: 0x06003A51 RID: 14929 RVA: 0x0006F888 File Offset: 0x0006DA88
		[ProtoMember(1, IsRequired = false, Name = "teaminfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GroupChatFindTeamInfo teaminfo
		{
			get
			{
				return this._teaminfo;
			}
			set
			{
				this._teaminfo = value;
			}
		}

		// Token: 0x06003A52 RID: 14930 RVA: 0x0006F894 File Offset: 0x0006DA94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E79 RID: 3705
		private GroupChatFindTeamInfo _teaminfo = null;

		// Token: 0x04000E7A RID: 3706
		private IExtension extensionObject;
	}
}
