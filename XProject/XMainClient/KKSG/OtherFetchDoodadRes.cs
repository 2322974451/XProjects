using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OtherFetchDoodadRes")]
	[Serializable]
	public class OtherFetchDoodadRes : IExtensible
	{

		[ProtoMember(1, Name = "rollInfos", DataFormat = DataFormat.Default)]
		public List<RollInfo> rollInfos
		{
			get
			{
				return this._rollInfos;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "doodadInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public EnemyDoodadInfo doodadInfo
		{
			get
			{
				return this._doodadInfo;
			}
			set
			{
				this._doodadInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<RollInfo> _rollInfos = new List<RollInfo>();

		private EnemyDoodadInfo _doodadInfo = null;

		private IExtension extensionObject;
	}
}
