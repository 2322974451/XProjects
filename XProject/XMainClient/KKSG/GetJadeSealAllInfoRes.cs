using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetJadeSealAllInfoRes")]
	[Serializable]
	public class GetJadeSealAllInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorCode
		{
			get
			{
				return this._errorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorCode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorCodeSpecified
		{
			get
			{
				return this._errorCode != null;
			}
			set
			{
				bool flag = value == (this._errorCode == null);
				if (flag)
				{
					this._errorCode = (value ? new ErrorCode?(this.errorCode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		[ProtoMember(2, Name = "jadeSealInfo", DataFormat = DataFormat.Default)]
		public List<JadeSealInfo> jadeSealInfo
		{
			get
			{
				return this._jadeSealInfo;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorCode;

		private readonly List<JadeSealInfo> _jadeSealInfo = new List<JadeSealInfo>();

		private IExtension extensionObject;
	}
}
