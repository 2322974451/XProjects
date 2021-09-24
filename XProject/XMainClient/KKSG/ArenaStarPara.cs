using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArenaStarPara")]
	[Serializable]
	public class ArenaStarPara : IExtensible
	{

		[ProtoMember(1, Name = "newdata", DataFormat = DataFormat.TwosComplement)]
		public List<ArenaStarType> newdata
		{
			get
			{
				return this._newdata;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ArenaStarType> _newdata = new List<ArenaStarType>();

		private IExtension extensionObject;
	}
}
