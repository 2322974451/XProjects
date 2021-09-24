using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatCreateC2S")]
	[Serializable]
	public class GroupChatCreateC2S : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "groupchatName", DataFormat = DataFormat.Default)]
		public string groupchatName
		{
			get
			{
				return this._groupchatName ?? "";
			}
			set
			{
				this._groupchatName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatNameSpecified
		{
			get
			{
				return this._groupchatName != null;
			}
			set
			{
				bool flag = value == (this._groupchatName == null);
				if (flag)
				{
					this._groupchatName = (value ? this.groupchatName : null);
				}
			}
		}

		private bool ShouldSerializegroupchatName()
		{
			return this.groupchatNameSpecified;
		}

		private void ResetgroupchatName()
		{
			this.groupchatNameSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "createtype", DataFormat = DataFormat.TwosComplement)]
		public uint createtype
		{
			get
			{
				return this._createtype ?? 0U;
			}
			set
			{
				this._createtype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool createtypeSpecified
		{
			get
			{
				return this._createtype != null;
			}
			set
			{
				bool flag = value == (this._createtype == null);
				if (flag)
				{
					this._createtype = (value ? new uint?(this.createtype) : null);
				}
			}
		}

		private bool ShouldSerializecreatetype()
		{
			return this.createtypeSpecified;
		}

		private void Resetcreatetype()
		{
			this.createtypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _groupchatName;

		private uint? _createtype;

		private IExtension extensionObject;
	}
}
