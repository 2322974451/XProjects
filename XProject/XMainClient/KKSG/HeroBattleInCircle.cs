using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleInCircle")]
	[Serializable]
	public class HeroBattleInCircle : IExtensible
	{

		[ProtoMember(1, Name = "roleInCircle", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleInCircle
		{
			get
			{
				return this._roleInCircle;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ulong> _roleInCircle = new List<ulong>();

		private IExtension extensionObject;
	}
}
