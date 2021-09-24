using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GoalAwardsRedPointNtf")]
	[Serializable]
	public class GoalAwardsRedPointNtf : IExtensible
	{

		[ProtoMember(1, Name = "typelist", DataFormat = DataFormat.TwosComplement)]
		public List<uint> typelist
		{
			get
			{
				return this._typelist;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _typelist = new List<uint>();

		private IExtension extensionObject;
	}
}
