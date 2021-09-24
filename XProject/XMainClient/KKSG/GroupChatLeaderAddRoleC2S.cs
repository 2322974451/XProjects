using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatLeaderAddRoleC2S")]
	[Serializable]
	public class GroupChatLeaderAddRoleC2S : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "groupchatID", DataFormat = DataFormat.TwosComplement)]
		public ulong groupchatID
		{
			get
			{
				return this._groupchatID ?? 0UL;
			}
			set
			{
				this._groupchatID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatIDSpecified
		{
			get
			{
				return this._groupchatID != null;
			}
			set
			{
				bool flag = value == (this._groupchatID == null);
				if (flag)
				{
					this._groupchatID = (value ? new ulong?(this.groupchatID) : null);
				}
			}
		}

		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "roleIssueIndex", DataFormat = DataFormat.TwosComplement)]
		public ulong roleIssueIndex
		{
			get
			{
				return this._roleIssueIndex ?? 0UL;
			}
			set
			{
				this._roleIssueIndex = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIssueIndexSpecified
		{
			get
			{
				return this._roleIssueIndex != null;
			}
			set
			{
				bool flag = value == (this._roleIssueIndex == null);
				if (flag)
				{
					this._roleIssueIndex = (value ? new ulong?(this.roleIssueIndex) : null);
				}
			}
		}

		private bool ShouldSerializeroleIssueIndex()
		{
			return this.roleIssueIndexSpecified;
		}

		private void ResetroleIssueIndex()
		{
			this.roleIssueIndexSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _groupchatID;

		private ulong? _roleid;

		private ulong? _roleIssueIndex;

		private IExtension extensionObject;
	}
}
