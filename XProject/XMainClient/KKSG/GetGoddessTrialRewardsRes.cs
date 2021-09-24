using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGoddessTrialRewardsRes")]
	[Serializable]
	public class GetGoddessTrialRewardsRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "leftGoddessReward", DataFormat = DataFormat.TwosComplement)]
		public uint leftGoddessReward
		{
			get
			{
				return this._leftGoddessReward ?? 0U;
			}
			set
			{
				this._leftGoddessReward = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftGoddessRewardSpecified
		{
			get
			{
				return this._leftGoddessReward != null;
			}
			set
			{
				bool flag = value == (this._leftGoddessReward == null);
				if (flag)
				{
					this._leftGoddessReward = (value ? new uint?(this.leftGoddessReward) : null);
				}
			}
		}

		private bool ShouldSerializeleftGoddessReward()
		{
			return this.leftGoddessRewardSpecified;
		}

		private void ResetleftGoddessReward()
		{
			this.leftGoddessRewardSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _leftGoddessReward;

		private IExtension extensionObject;
	}
}
