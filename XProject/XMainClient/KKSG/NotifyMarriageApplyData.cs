using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NotifyMarriageApplyData")]
	[Serializable]
	public class NotifyMarriageApplyData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "applyInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MarriageApplyInfo applyInfo
		{
			get
			{
				return this._applyInfo;
			}
			set
			{
				this._applyInfo = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "response", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MarriageApplyResponse response
		{
			get
			{
				return this._response;
			}
			set
			{
				this._response = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private MarriageApplyInfo _applyInfo = null;

		private MarriageApplyResponse _response = null;

		private IExtension extensionObject;
	}
}
