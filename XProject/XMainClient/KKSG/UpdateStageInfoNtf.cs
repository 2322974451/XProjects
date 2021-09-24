using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UpdateStageInfoNtf")]
	[Serializable]
	public class UpdateStageInfoNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "Stages", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public StageInfo Stages
		{
			get
			{
				return this._Stages;
			}
			set
			{
				this._Stages = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private StageInfo _Stages = null;

		private IExtension extensionObject;
	}
}
