using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetFlowerRewardListRes")]
	[Serializable]
	public class GetFlowerRewardListRes : IExtensible
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

		[ProtoMember(2, Name = "briefList", DataFormat = DataFormat.Default)]
		public List<RoleBriefInfo> briefList
		{
			get
			{
				return this._briefList;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "canGetReward", DataFormat = DataFormat.Default)]
		public bool canGetReward
		{
			get
			{
				return this._canGetReward ?? false;
			}
			set
			{
				this._canGetReward = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canGetRewardSpecified
		{
			get
			{
				return this._canGetReward != null;
			}
			set
			{
				bool flag = value == (this._canGetReward == null);
				if (flag)
				{
					this._canGetReward = (value ? new bool?(this.canGetReward) : null);
				}
			}
		}

		private bool ShouldSerializecanGetReward()
		{
			return this.canGetRewardSpecified;
		}

		private void ResetcanGetReward()
		{
			this.canGetRewardSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorCode;

		private readonly List<RoleBriefInfo> _briefList = new List<RoleBriefInfo>();

		private bool? _canGetReward;

		private IExtension extensionObject;
	}
}
