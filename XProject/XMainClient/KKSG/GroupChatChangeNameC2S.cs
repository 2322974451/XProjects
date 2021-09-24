using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatChangeNameC2S")]
	[Serializable]
	public class GroupChatChangeNameC2S : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "newname", DataFormat = DataFormat.Default)]
		public string newname
		{
			get
			{
				return this._newname ?? "";
			}
			set
			{
				this._newname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool newnameSpecified
		{
			get
			{
				return this._newname != null;
			}
			set
			{
				bool flag = value == (this._newname == null);
				if (flag)
				{
					this._newname = (value ? this.newname : null);
				}
			}
		}

		private bool ShouldSerializenewname()
		{
			return this.newnameSpecified;
		}

		private void Resetnewname()
		{
			this.newnameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _groupchatID;

		private string _newname;

		private IExtension extensionObject;
	}
}
