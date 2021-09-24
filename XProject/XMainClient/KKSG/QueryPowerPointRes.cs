using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryPowerPointRes")]
	[Serializable]
	public class QueryPowerPointRes : IExtensible
	{

		[ProtoMember(1, Name = "bqID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bqID
		{
			get
			{
				return this._bqID;
			}
		}

		[ProtoMember(2, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public List<double> ppt
		{
			get
			{
				return this._ppt;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _bqID = new List<uint>();

		private readonly List<double> _ppt = new List<double>();

		private ErrorCode? _errorcode;

		private IExtension extensionObject;
	}
}
