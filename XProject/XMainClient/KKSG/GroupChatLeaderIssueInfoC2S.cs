using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatLeaderIssueInfoC2S")]
	[Serializable]
	public class GroupChatLeaderIssueInfoC2S : IExtensible
	{

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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GroupChatFindTeamInfo _teaminfo = null;

		private IExtension extensionObject;
	}
}
