using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatPlayerApplyC2S")]
	[Serializable]
	public class GroupChatPlayerApplyC2S : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "issueIndex", DataFormat = DataFormat.TwosComplement)]
		public ulong issueIndex
		{
			get
			{
				return this._issueIndex ?? 0UL;
			}
			set
			{
				this._issueIndex = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool issueIndexSpecified
		{
			get
			{
				return this._issueIndex != null;
			}
			set
			{
				bool flag = value == (this._issueIndex == null);
				if (flag)
				{
					this._issueIndex = (value ? new ulong?(this.issueIndex) : null);
				}
			}
		}

		private bool ShouldSerializeissueIndex()
		{
			return this.issueIndexSpecified;
		}

		private void ResetissueIndex()
		{
			this.issueIndexSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _groupchatID;

		private ulong? _issueIndex;

		private IExtension extensionObject;
	}
}
