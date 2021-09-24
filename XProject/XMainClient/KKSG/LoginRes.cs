using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginRes")]
	[Serializable]
	public class LoginRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "version", DataFormat = DataFormat.Default)]
		public string version
		{
			get
			{
				return this._version ?? "";
			}
			set
			{
				this._version = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool versionSpecified
		{
			get
			{
				return this._version != null;
			}
			set
			{
				bool flag = value == (this._version == null);
				if (flag)
				{
					this._version = (value ? this.version : null);
				}
			}
		}

		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "accountData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoadAccountData accountData
		{
			get
			{
				return this._accountData;
			}
			set
			{
				this._accountData = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "function_open", DataFormat = DataFormat.TwosComplement)]
		public uint function_open
		{
			get
			{
				return this._function_open ?? 0U;
			}
			set
			{
				this._function_open = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool function_openSpecified
		{
			get
			{
				return this._function_open != null;
			}
			set
			{
				bool flag = value == (this._function_open == null);
				if (flag)
				{
					this._function_open = (value ? new uint?(this.function_open) : null);
				}
			}
		}

		private bool ShouldSerializefunction_open()
		{
			return this.function_openSpecified;
		}

		private void Resetfunction_open()
		{
			this.function_openSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoginExtraData data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "rinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoginReconnectInfo rinfo
		{
			get
			{
				return this._rinfo;
			}
			set
			{
				this._rinfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private string _version;

		private LoadAccountData _accountData = null;

		private uint? _function_open;

		private LoginExtraData _data = null;

		private LoginReconnectInfo _rinfo = null;

		private IExtension extensionObject;
	}
}
