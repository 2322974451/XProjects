using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaMiniMapData")]
	[Serializable]
	public class MobaMiniMapData : IExtensible
	{

		[ProtoMember(1, Name = "canSeePosIndex", DataFormat = DataFormat.TwosComplement)]
		public List<uint> canSeePosIndex
		{
			get
			{
				return this._canSeePosIndex;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _canSeePosIndex = new List<uint>();

		private IExtension extensionObject;
	}
}
