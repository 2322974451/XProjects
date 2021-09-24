using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPayRewardRes")]
	[Serializable]
	public class GetPayRewardRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "cdTime", DataFormat = DataFormat.TwosComplement)]
		public uint cdTime
		{
			get
			{
				return this._cdTime ?? 0U;
			}
			set
			{
				this._cdTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cdTimeSpecified
		{
			get
			{
				return this._cdTime != null;
			}
			set
			{
				bool flag = value == (this._cdTime == null);
				if (flag)
				{
					this._cdTime = (value ? new uint?(this.cdTime) : null);
				}
			}
		}

		private bool ShouldSerializecdTime()
		{
			return this.cdTimeSpecified;
		}

		private void ResetcdTime()
		{
			this.cdTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _cdTime;

		private IExtension extensionObject;
	}
}
