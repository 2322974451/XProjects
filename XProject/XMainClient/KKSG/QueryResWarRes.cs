using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryResWarRes")]
	[Serializable]
	public class QueryResWarRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ResWarGuildBrief data
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

		[ProtoMember(2, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "finalrank", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ResWarFinalAll finalrank
		{
			get
			{
				return this._finalrank;
			}
			set
			{
				this._finalrank = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ResWarGuildBrief _data = null;

		private ErrorCode? _error;

		private ResWarFinalAll _finalrank = null;

		private IExtension extensionObject;
	}
}
