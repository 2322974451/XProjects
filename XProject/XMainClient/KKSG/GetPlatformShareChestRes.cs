using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPlatformShareChestRes")]
	[Serializable]
	public class GetPlatformShareChestRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "boxid", DataFormat = DataFormat.Default)]
		public string boxid
		{
			get
			{
				return this._boxid ?? "";
			}
			set
			{
				this._boxid = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool boxidSpecified
		{
			get
			{
				return this._boxid != null;
			}
			set
			{
				bool flag = value == (this._boxid == null);
				if (flag)
				{
					this._boxid = (value ? this.boxid : null);
				}
			}
		}

		private bool ShouldSerializeboxid()
		{
			return this.boxidSpecified;
		}

		private void Resetboxid()
		{
			this.boxidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "act_id", DataFormat = DataFormat.TwosComplement)]
		public uint act_id
		{
			get
			{
				return this._act_id ?? 0U;
			}
			set
			{
				this._act_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool act_idSpecified
		{
			get
			{
				return this._act_id != null;
			}
			set
			{
				bool flag = value == (this._act_id == null);
				if (flag)
				{
					this._act_id = (value ? new uint?(this.act_id) : null);
				}
			}
		}

		private bool ShouldSerializeact_id()
		{
			return this.act_idSpecified;
		}

		private void Resetact_id()
		{
			this.act_idSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "url", DataFormat = DataFormat.Default)]
		public string url
		{
			get
			{
				return this._url ?? "";
			}
			set
			{
				this._url = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool urlSpecified
		{
			get
			{
				return this._url != null;
			}
			set
			{
				bool flag = value == (this._url == null);
				if (flag)
				{
					this._url = (value ? this.url : null);
				}
			}
		}

		private bool ShouldSerializeurl()
		{
			return this.urlSpecified;
		}

		private void Reseturl()
		{
			this.urlSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private string _boxid;

		private uint? _act_id;

		private string _url;

		private IExtension extensionObject;
	}
}
