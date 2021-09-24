using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetFlowerRes")]
	[Serializable]
	public class GetFlowerRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public int leftTime
		{
			get
			{
				return this._leftTime ?? 0;
			}
			set
			{
				this._leftTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new int?(this.leftTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "canGet", DataFormat = DataFormat.Default)]
		public bool canGet
		{
			get
			{
				return this._canGet ?? false;
			}
			set
			{
				this._canGet = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canGetSpecified
		{
			get
			{
				return this._canGet != null;
			}
			set
			{
				bool flag = value == (this._canGet == null);
				if (flag)
				{
					this._canGet = (value ? new bool?(this.canGet) : null);
				}
			}
		}

		private bool ShouldSerializecanGet()
		{
			return this.canGetSpecified;
		}

		private void ResetcanGet()
		{
			this.canGetSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorCode;

		private int? _leftTime;

		private bool? _canGet;

		private IExtension extensionObject;
	}
}
