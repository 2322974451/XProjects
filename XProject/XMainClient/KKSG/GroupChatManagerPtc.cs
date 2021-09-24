using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatManagerPtc")]
	[Serializable]
	public class GroupChatManagerPtc : IExtensible
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

		[ProtoMember(2, Name = "addrolelist", DataFormat = DataFormat.Default)]
		public List<GroupChatPlayerInfo> addrolelist
		{
			get
			{
				return this._addrolelist;
			}
		}

		[ProtoMember(3, Name = "subrolelist", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> subrolelist
		{
			get
			{
				return this._subrolelist;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _groupchatID;

		private readonly List<GroupChatPlayerInfo> _addrolelist = new List<GroupChatPlayerInfo>();

		private readonly List<ulong> _subrolelist = new List<ulong>();

		private IExtension extensionObject;
	}
}
