using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginArg")]
	[Serializable]
	public class LoginArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "gameserverid", DataFormat = DataFormat.TwosComplement)]
		public uint gameserverid
		{
			get
			{
				return this._gameserverid ?? 0U;
			}
			set
			{
				this._gameserverid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gameserveridSpecified
		{
			get
			{
				return this._gameserverid != null;
			}
			set
			{
				bool flag = value == (this._gameserverid == null);
				if (flag)
				{
					this._gameserverid = (value ? new uint?(this.gameserverid) : null);
				}
			}
		}

		private bool ShouldSerializegameserverid()
		{
			return this.gameserveridSpecified;
		}

		private void Resetgameserverid()
		{
			this.gameserveridSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public byte[] token
		{
			get
			{
				return this._token ?? null;
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

		[ProtoMember(3, IsRequired = false, Name = "ios", DataFormat = DataFormat.Default)]
		public string ios
		{
			get
			{
				return this._ios ?? "";
			}
			set
			{
				this._ios = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iosSpecified
		{
			get
			{
				return this._ios != null;
			}
			set
			{
				bool flag = value == (this._ios == null);
				if (flag)
				{
					this._ios = (value ? this.ios : null);
				}
			}
		}

		private bool ShouldSerializeios()
		{
			return this.iosSpecified;
		}

		private void Resetios()
		{
			this.iosSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "android", DataFormat = DataFormat.Default)]
		public string android
		{
			get
			{
				return this._android ?? "";
			}
			set
			{
				this._android = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool androidSpecified
		{
			get
			{
				return this._android != null;
			}
			set
			{
				bool flag = value == (this._android == null);
				if (flag)
				{
					this._android = (value ? this.android : null);
				}
			}
		}

		private bool ShouldSerializeandroid()
		{
			return this.androidSpecified;
		}

		private void Resetandroid()
		{
			this.androidSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "pc", DataFormat = DataFormat.Default)]
		public string pc
		{
			get
			{
				return this._pc ?? "";
			}
			set
			{
				this._pc = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pcSpecified
		{
			get
			{
				return this._pc != null;
			}
			set
			{
				bool flag = value == (this._pc == null);
				if (flag)
				{
					this._pc = (value ? this.pc : null);
				}
			}
		}

		private bool ShouldSerializepc()
		{
			return this.pcSpecified;
		}

		private void Resetpc()
		{
			this.pcSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "openid", DataFormat = DataFormat.Default)]
		public string openid
		{
			get
			{
				return this._openid ?? "";
			}
			set
			{
				this._openid = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool openidSpecified
		{
			get
			{
				return this._openid != null;
			}
			set
			{
				bool flag = value == (this._openid == null);
				if (flag)
				{
					this._openid = (value ? this.openid : null);
				}
			}
		}

		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "clientInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ClientInfo clientInfo
		{
			get
			{
				return this._clientInfo;
			}
			set
			{
				this._clientInfo = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "loginzoneid", DataFormat = DataFormat.TwosComplement)]
		public uint loginzoneid
		{
			get
			{
				return this._loginzoneid ?? 0U;
			}
			set
			{
				this._loginzoneid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool loginzoneidSpecified
		{
			get
			{
				return this._loginzoneid != null;
			}
			set
			{
				bool flag = value == (this._loginzoneid == null);
				if (flag)
				{
					this._loginzoneid = (value ? new uint?(this.loginzoneid) : null);
				}
			}
		}

		private bool ShouldSerializeloginzoneid()
		{
			return this.loginzoneidSpecified;
		}

		private void Resetloginzoneid()
		{
			this.loginzoneidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _gameserverid;

		private byte[] _token;

		private string _ios;

		private string _android;

		private string _pc;

		private string _openid;

		private ClientInfo _clientInfo = null;

		private uint? _loginzoneid;

		private IExtension extensionObject;
	}
}
