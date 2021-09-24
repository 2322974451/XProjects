using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayParameterInfo")]
	[Serializable]
	public class PayParameterInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "openkey", DataFormat = DataFormat.Default)]
		public string openkey
		{
			get
			{
				return this._openkey ?? "";
			}
			set
			{
				this._openkey = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool openkeySpecified
		{
			get
			{
				return this._openkey != null;
			}
			set
			{
				bool flag = value == (this._openkey == null);
				if (flag)
				{
					this._openkey = (value ? this.openkey : null);
				}
			}
		}

		private bool ShouldSerializeopenkey()
		{
			return this.openkeySpecified;
		}

		private void Resetopenkey()
		{
			this.openkeySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "sessionId", DataFormat = DataFormat.Default)]
		public string sessionId
		{
			get
			{
				return this._sessionId ?? "";
			}
			set
			{
				this._sessionId = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sessionIdSpecified
		{
			get
			{
				return this._sessionId != null;
			}
			set
			{
				bool flag = value == (this._sessionId == null);
				if (flag)
				{
					this._sessionId = (value ? this.sessionId : null);
				}
			}
		}

		private bool ShouldSerializesessionId()
		{
			return this.sessionIdSpecified;
		}

		private void ResetsessionId()
		{
			this.sessionIdSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "sessionType", DataFormat = DataFormat.Default)]
		public string sessionType
		{
			get
			{
				return this._sessionType ?? "";
			}
			set
			{
				this._sessionType = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sessionTypeSpecified
		{
			get
			{
				return this._sessionType != null;
			}
			set
			{
				bool flag = value == (this._sessionType == null);
				if (flag)
				{
					this._sessionType = (value ? this.sessionType : null);
				}
			}
		}

		private bool ShouldSerializesessionType()
		{
			return this.sessionTypeSpecified;
		}

		private void ResetsessionType()
		{
			this.sessionTypeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "pf", DataFormat = DataFormat.Default)]
		public string pf
		{
			get
			{
				return this._pf ?? "";
			}
			set
			{
				this._pf = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pfSpecified
		{
			get
			{
				return this._pf != null;
			}
			set
			{
				bool flag = value == (this._pf == null);
				if (flag)
				{
					this._pf = (value ? this.pf : null);
				}
			}
		}

		private bool ShouldSerializepf()
		{
			return this.pfSpecified;
		}

		private void Resetpf()
		{
			this.pfSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "pfKey", DataFormat = DataFormat.Default)]
		public string pfKey
		{
			get
			{
				return this._pfKey ?? "";
			}
			set
			{
				this._pfKey = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pfKeySpecified
		{
			get
			{
				return this._pfKey != null;
			}
			set
			{
				bool flag = value == (this._pfKey == null);
				if (flag)
				{
					this._pfKey = (value ? this.pfKey : null);
				}
			}
		}

		private bool ShouldSerializepfKey()
		{
			return this.pfKeySpecified;
		}

		private void ResetpfKey()
		{
			this.pfKeySpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "appid", DataFormat = DataFormat.Default)]
		public string appid
		{
			get
			{
				return this._appid ?? "";
			}
			set
			{
				this._appid = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool appidSpecified
		{
			get
			{
				return this._appid != null;
			}
			set
			{
				bool flag = value == (this._appid == null);
				if (flag)
				{
					this._appid = (value ? this.appid : null);
				}
			}
		}

		private bool ShouldSerializeappid()
		{
			return this.appidSpecified;
		}

		private void Resetappid()
		{
			this.appidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _openkey;

		private string _sessionId;

		private string _sessionType;

		private string _pf;

		private string _pfKey;

		private string _appid;

		private IExtension extensionObject;
	}
}
