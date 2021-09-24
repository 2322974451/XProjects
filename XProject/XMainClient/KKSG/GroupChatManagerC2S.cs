using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatManagerC2S")]
	[Serializable]
	public class GroupChatManagerC2S : IExtensible
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

		[ProtoMember(2, Name = "subrolelist", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> subrolelist
		{
			get
			{
				return this._subrolelist;
			}
		}

		[ProtoMember(3, Name = "addrolelist", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> addrolelist
		{
			get
			{
				return this._addrolelist;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _groupchatID;

		private readonly List<ulong> _subrolelist = new List<ulong>();

		private readonly List<ulong> _addrolelist = new List<ulong>();

		private IExtension extensionObject;
	}
}
