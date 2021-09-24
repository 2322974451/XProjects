using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FetchPlatNoticeArg")]
	[Serializable]
	public class FetchPlatNoticeArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public LoginType type
		{
			get
			{
				return this._type ?? LoginType.LOGIN_PASSWORD;
			}
			set
			{
				this._type = new LoginType?(value);
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
					this._type = (value ? new LoginType?(this.type) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "platid", DataFormat = DataFormat.TwosComplement)]
		public PlatType platid
		{
			get
			{
				return this._platid ?? PlatType.PLAT_IOS;
			}
			set
			{
				this._platid = new PlatType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool platidSpecified
		{
			get
			{
				return this._platid != null;
			}
			set
			{
				bool flag = value == (this._platid == null);
				if (flag)
				{
					this._platid = (value ? new PlatType?(this.platid) : null);
				}
			}
		}

		private bool ShouldSerializeplatid()
		{
			return this.platidSpecified;
		}

		private void Resetplatid()
		{
			this.platidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private LoginType? _type;

		private PlatType? _platid;

		private IExtension extensionObject;
	}
}
