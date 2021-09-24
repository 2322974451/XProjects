using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RollInfoRes")]
	[Serializable]
	public class RollInfoRes : IExtensible
	{

		[ProtoMember(1, Name = "info", DataFormat = DataFormat.Default)]
		public List<RollInfo> info
		{
			get
			{
				return this._info;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "errCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errCode
		{
			get
			{
				return this._errCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errCode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errCodeSpecified
		{
			get
			{
				return this._errCode != null;
			}
			set
			{
				bool flag = value == (this._errCode == null);
				if (flag)
				{
					this._errCode = (value ? new ErrorCode?(this.errCode) : null);
				}
			}
		}

		private bool ShouldSerializeerrCode()
		{
			return this.errCodeSpecified;
		}

		private void ReseterrCode()
		{
			this.errCodeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<RollInfo> _info = new List<RollInfo>();

		private ErrorCode? _errCode;

		private IExtension extensionObject;
	}
}
