using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SetSubscirbeArg")]
	[Serializable]
	public class SetSubscirbeArg : IExtensible
	{

		[ProtoMember(1, Name = "msgid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> msgid
		{
			get
			{
				return this._msgid;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "msgtype", DataFormat = DataFormat.TwosComplement)]
		public int msgtype
		{
			get
			{
				return this._msgtype ?? 0;
			}
			set
			{
				this._msgtype = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool msgtypeSpecified
		{
			get
			{
				return this._msgtype != null;
			}
			set
			{
				bool flag = value == (this._msgtype == null);
				if (flag)
				{
					this._msgtype = (value ? new int?(this.msgtype) : null);
				}
			}
		}

		private bool ShouldSerializemsgtype()
		{
			return this.msgtypeSpecified;
		}

		private void Resetmsgtype()
		{
			this.msgtypeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public string token
		{
			get
			{
				return this._token ?? "";
			}
			set
			{
				this._token = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tokenSpecified
		{
			get
			{
				return this._token != null;
			}
			set
			{
				bool flag = value == (this._token == null);
				if (flag)
				{
					this._token = (value ? this.token : null);
				}
			}
		}

		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _msgid = new List<uint>();

		private int? _msgtype;

		private string _token;

		private IExtension extensionObject;
	}
}
