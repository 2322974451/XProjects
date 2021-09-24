using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeddingInviteNtf")]
	[Serializable]
	public class WeddingInviteNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingInviteOperType type
		{
			get
			{
				return this._type ?? WeddingInviteOperType.Wedding_Invite;
			}
			set
			{
				this._type = new WeddingInviteOperType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new WeddingInviteOperType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "weddinginfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeddingBrief weddinginfo
		{
			get
			{
				return this._weddinginfo;
			}
			set
			{
				this._weddinginfo = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "applyer", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeddingRoleBrief applyer
		{
			get
			{
				return this._applyer;
			}
			set
			{
				this._applyer = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private WeddingInviteOperType? _type;

		private WeddingBrief _weddinginfo = null;

		private WeddingRoleBrief _applyer = null;

		private IExtension extensionObject;
	}
}
