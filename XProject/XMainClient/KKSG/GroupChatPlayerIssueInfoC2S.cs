using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatPlayerIssueInfoC2S")]
	[Serializable]
	public class GroupChatPlayerIssueInfoC2S : IExtensible
	{

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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GroupChatFindRoleInfo _roleinfo = null;

		private IExtension extensionObject;
	}
}
