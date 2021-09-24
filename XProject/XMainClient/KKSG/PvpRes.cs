using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpRes")]
	[Serializable]
	public class PvpRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "basedata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PvpBaseData basedata
		{
			get
			{
				return this._basedata;
			}
			set
			{
				this._basedata = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "history", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PvpHistory history
		{
			get
			{
				return this._history;
			}
			set
			{
				this._history = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public PvpReqType reqtype
		{
			get
			{
				return this._reqtype ?? PvpReqType.PVP_REQ_IN_MATCH;
			}
			set
			{
				this._reqtype = new PvpReqType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reqtypeSpecified
		{
			get
			{
				return this._reqtype != null;
			}
			set
			{
				bool flag = value == (this._reqtype == null);
				if (flag)
				{
					this._reqtype = (value ? new PvpReqType?(this.reqtype) : null);
				}
			}
		}

		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "err", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode err
		{
			get
			{
				return this._err ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._err = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errSpecified
		{
			get
			{
				return this._err != null;
			}
			set
			{
				bool flag = value == (this._err == null);
				if (flag)
				{
					this._err = (value ? new ErrorCode?(this.err) : null);
				}
			}
		}

		private bool ShouldSerializeerr()
		{
			return this.errSpecified;
		}

		private void Reseterr()
		{
			this.errSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PvpBaseData _basedata = null;

		private PvpHistory _history = null;

		private PvpReqType? _reqtype;

		private ErrorCode? _err;

		private IExtension extensionObject;
	}
}
