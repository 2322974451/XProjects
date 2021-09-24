using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OperateRecord")]
	[Serializable]
	public class OperateRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public uint position
		{
			get
			{
				return this._position ?? 0U;
			}
			set
			{
				this._position = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new uint?(this.position) : null);
				}
			}
		}

		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "arg", DataFormat = DataFormat.Default)]
		public string arg
		{
			get
			{
				return this._arg ?? "";
			}
			set
			{
				this._arg = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool argSpecified
		{
			get
			{
				return this._arg != null;
			}
			set
			{
				bool flag = value == (this._arg == null);
				if (flag)
				{
					this._arg = (value ? this.arg : null);
				}
			}
		}

		private bool ShouldSerializearg()
		{
			return this.argSpecified;
		}

		private void Resetarg()
		{
			this.argSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "account", DataFormat = DataFormat.Default)]
		public string account
		{
			get
			{
				return this._account ?? "";
			}
			set
			{
				this._account = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool accountSpecified
		{
			get
			{
				return this._account != null;
			}
			set
			{
				bool flag = value == (this._account == null);
				if (flag)
				{
					this._account = (value ? this.account : null);
				}
			}
		}

		private bool ShouldSerializeaccount()
		{
			return this.accountSpecified;
		}

		private void Resetaccount()
		{
			this.accountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _position;

		private string _arg;

		private string _account;

		private IExtension extensionObject;
	}
}
