using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleFieldAwardNumRes")]
	[Serializable]
	public class BattleFieldAwardNumRes : IExtensible
	{

		[ProtoMember(1, Name = "award", DataFormat = DataFormat.Default)]
		public List<BattleFieldLeftAward> award
		{
			get
			{
				return this._award;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<BattleFieldLeftAward> _award = new List<BattleFieldLeftAward>();

		private IExtension extensionObject;
	}
}
