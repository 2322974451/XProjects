using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AudioAuthKeyRes")]
	[Serializable]
	public class AudioAuthKeyRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "dwMainSvrId", DataFormat = DataFormat.TwosComplement)]
		public uint dwMainSvrId
		{
			get
			{
				return this._dwMainSvrId ?? 0U;
			}
			set
			{
				this._dwMainSvrId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dwMainSvrIdSpecified
		{
			get
			{
				return this._dwMainSvrId != null;
			}
			set
			{
				bool flag = value == (this._dwMainSvrId == null);
				if (flag)
				{
					this._dwMainSvrId = (value ? new uint?(this.dwMainSvrId) : null);
				}
			}
		}

		private bool ShouldSerializedwMainSvrId()
		{
			return this.dwMainSvrIdSpecified;
		}

		private void ResetdwMainSvrId()
		{
			this.dwMainSvrIdSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "dwMainSvrUrl1", DataFormat = DataFormat.TwosComplement)]
		public uint dwMainSvrUrl1
		{
			get
			{
				return this._dwMainSvrUrl1 ?? 0U;
			}
			set
			{
				this._dwMainSvrUrl1 = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dwMainSvrUrl1Specified
		{
			get
			{
				return this._dwMainSvrUrl1 != null;
			}
			set
			{
				bool flag = value == (this._dwMainSvrUrl1 == null);
				if (flag)
				{
					this._dwMainSvrUrl1 = (value ? new uint?(this.dwMainSvrUrl1) : null);
				}
			}
		}

		private bool ShouldSerializedwMainSvrUrl1()
		{
			return this.dwMainSvrUrl1Specified;
		}

		private void ResetdwMainSvrUrl1()
		{
			this.dwMainSvrUrl1Specified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "dwMainSvrUrl2", DataFormat = DataFormat.TwosComplement)]
		public uint dwMainSvrUrl2
		{
			get
			{
				return this._dwMainSvrUrl2 ?? 0U;
			}
			set
			{
				this._dwMainSvrUrl2 = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dwMainSvrUrl2Specified
		{
			get
			{
				return this._dwMainSvrUrl2 != null;
			}
			set
			{
				bool flag = value == (this._dwMainSvrUrl2 == null);
				if (flag)
				{
					this._dwMainSvrUrl2 = (value ? new uint?(this.dwMainSvrUrl2) : null);
				}
			}
		}

		private bool ShouldSerializedwMainSvrUrl2()
		{
			return this.dwMainSvrUrl2Specified;
		}

		private void ResetdwMainSvrUrl2()
		{
			this.dwMainSvrUrl2Specified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "dwSlaveSvrId", DataFormat = DataFormat.TwosComplement)]
		public uint dwSlaveSvrId
		{
			get
			{
				return this._dwSlaveSvrId ?? 0U;
			}
			set
			{
				this._dwSlaveSvrId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dwSlaveSvrIdSpecified
		{
			get
			{
				return this._dwSlaveSvrId != null;
			}
			set
			{
				bool flag = value == (this._dwSlaveSvrId == null);
				if (flag)
				{
					this._dwSlaveSvrId = (value ? new uint?(this.dwSlaveSvrId) : null);
				}
			}
		}

		private bool ShouldSerializedwSlaveSvrId()
		{
			return this.dwSlaveSvrIdSpecified;
		}

		private void ResetdwSlaveSvrId()
		{
			this.dwSlaveSvrIdSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "dwSlaveSvrUrl1", DataFormat = DataFormat.TwosComplement)]
		public uint dwSlaveSvrUrl1
		{
			get
			{
				return this._dwSlaveSvrUrl1 ?? 0U;
			}
			set
			{
				this._dwSlaveSvrUrl1 = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dwSlaveSvrUrl1Specified
		{
			get
			{
				return this._dwSlaveSvrUrl1 != null;
			}
			set
			{
				bool flag = value == (this._dwSlaveSvrUrl1 == null);
				if (flag)
				{
					this._dwSlaveSvrUrl1 = (value ? new uint?(this.dwSlaveSvrUrl1) : null);
				}
			}
		}

		private bool ShouldSerializedwSlaveSvrUrl1()
		{
			return this.dwSlaveSvrUrl1Specified;
		}

		private void ResetdwSlaveSvrUrl1()
		{
			this.dwSlaveSvrUrl1Specified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "dwSlaveSvrUrl2", DataFormat = DataFormat.TwosComplement)]
		public uint dwSlaveSvrUrl2
		{
			get
			{
				return this._dwSlaveSvrUrl2 ?? 0U;
			}
			set
			{
				this._dwSlaveSvrUrl2 = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dwSlaveSvrUrl2Specified
		{
			get
			{
				return this._dwSlaveSvrUrl2 != null;
			}
			set
			{
				bool flag = value == (this._dwSlaveSvrUrl2 == null);
				if (flag)
				{
					this._dwSlaveSvrUrl2 = (value ? new uint?(this.dwSlaveSvrUrl2) : null);
				}
			}
		}

		private bool ShouldSerializedwSlaveSvrUrl2()
		{
			return this.dwSlaveSvrUrl2Specified;
		}

		private void ResetdwSlaveSvrUrl2()
		{
			this.dwSlaveSvrUrl2Specified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "szAuthKey", DataFormat = DataFormat.Default)]
		public string szAuthKey
		{
			get
			{
				return this._szAuthKey ?? "";
			}
			set
			{
				this._szAuthKey = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool szAuthKeySpecified
		{
			get
			{
				return this._szAuthKey != null;
			}
			set
			{
				bool flag = value == (this._szAuthKey == null);
				if (flag)
				{
					this._szAuthKey = (value ? this.szAuthKey : null);
				}
			}
		}

		private bool ShouldSerializeszAuthKey()
		{
			return this.szAuthKeySpecified;
		}

		private void ResetszAuthKey()
		{
			this.szAuthKeySpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "dwExpireIn", DataFormat = DataFormat.TwosComplement)]
		public uint dwExpireIn
		{
			get
			{
				return this._dwExpireIn ?? 0U;
			}
			set
			{
				this._dwExpireIn = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dwExpireInSpecified
		{
			get
			{
				return this._dwExpireIn != null;
			}
			set
			{
				bool flag = value == (this._dwExpireIn == null);
				if (flag)
				{
					this._dwExpireIn = (value ? new uint?(this.dwExpireIn) : null);
				}
			}
		}

		private bool ShouldSerializedwExpireIn()
		{
			return this.dwExpireInSpecified;
		}

		private void ResetdwExpireIn()
		{
			this.dwExpireInSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private uint? _dwMainSvrId;

		private uint? _dwMainSvrUrl1;

		private uint? _dwMainSvrUrl2;

		private uint? _dwSlaveSvrId;

		private uint? _dwSlaveSvrUrl1;

		private uint? _dwSlaveSvrUrl2;

		private string _szAuthKey;

		private uint? _dwExpireIn;

		private IExtension extensionObject;
	}
}
