using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PositionCheckList")]
	[Serializable]
	public class PositionCheckList : IExtensible
	{

		[ProtoMember(1, Name = "positions", DataFormat = DataFormat.Default)]
		public List<PositionCheck> positions
		{
			get
			{
				return this._positions;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<PositionCheck> _positions = new List<PositionCheck>();

		private IExtension extensionObject;
	}
}
