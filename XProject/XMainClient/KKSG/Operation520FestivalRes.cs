using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Operation520FestivalRes")]
	[Serializable]
	public class Operation520FestivalRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Festival520Data data
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

		[ProtoMember(3, IsRequired = false, Name = "totalLoveValue", DataFormat = DataFormat.TwosComplement)]
		public uint totalLoveValue
		{
			get
			{
				return this._totalLoveValue ?? 0U;
			}
			set
			{
				this._totalLoveValue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalLoveValueSpecified
		{
			get
			{
				return this._totalLoveValue != null;
			}
			set
			{
				bool flag = value == (this._totalLoveValue == null);
				if (flag)
				{
					this._totalLoveValue = (value ? new uint?(this.totalLoveValue) : null);
				}
			}
		}

		private bool ShouldSerializetotalLoveValue()
		{
			return this.totalLoveValueSpecified;
		}

		private void ResettotalLoveValue()
		{
			this.totalLoveValueSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private Festival520Data _data = null;

		private uint? _totalLoveValue;

		private IExtension extensionObject;
	}
}
