using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildCheckinRecordsRes")]
	[Serializable]
	public class GetGuildCheckinRecordsRes : IExtensible
	{

		[ProtoMember(1, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		[ProtoMember(2, Name = "name", DataFormat = DataFormat.Default)]
		public List<string> name
		{
			get
			{
				return this._name;
			}
		}

		[ProtoMember(3, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public List<uint> type
		{
			get
			{
				return this._type;
			}
		}

		[ProtoMember(4, Name = "timestamp", DataFormat = DataFormat.TwosComplement)]
		public List<uint> timestamp
		{
			get
			{
				return this._timestamp;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		private readonly List<ulong> _roleid = new List<ulong>();

		private readonly List<string> _name = new List<string>();

		private readonly List<uint> _type = new List<uint>();

		private readonly List<uint> _timestamp = new List<uint>();

		private ErrorCode? _errorcode;

		private IExtension extensionObject;
	}
}
