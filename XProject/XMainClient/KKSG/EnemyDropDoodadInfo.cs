using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnemyDropDoodadInfo")]
	[Serializable]
	public class EnemyDropDoodadInfo : IExtensible
	{

		[ProtoMember(1, Name = "doodadInfo", DataFormat = DataFormat.Default)]
		public List<EnemyDoodadInfo> doodadInfo
		{
			get
			{
				return this._doodadInfo;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<EnemyDoodadInfo> _doodadInfo = new List<EnemyDoodadInfo>();

		private IExtension extensionObject;
	}
}
