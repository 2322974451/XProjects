using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AgreeQAReq")]
	[Serializable]
	public class AgreeQAReq : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "agree", DataFormat = DataFormat.Default)]
		public bool agree
		{
			get
			{
				return this._agree ?? false;
			}
			set
			{
				this._agree = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool agreeSpecified
		{
			get
			{
				return this._agree != null;
			}
			set
			{
				bool flag = value == (this._agree == null);
				if (flag)
				{
					this._agree = (value ? new bool?(this.agree) : null);
				}
			}
		}

		private bool ShouldSerializeagree()
		{
			return this.agreeSpecified;
		}

		private void Resetagree()
		{
			this.agreeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
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
					this._type = (value ? new uint?(this.type) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _agree;

		private uint? _type;

		private IExtension extensionObject;
	}
}
