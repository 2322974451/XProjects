using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleFieldRankRes")]
	[Serializable]
	public class BattleFieldRankRes : IExtensible
	{

		[ProtoMember(1, Name = "ranks", DataFormat = DataFormat.Default)]
		public List<BattleFieldRank> ranks
		{
			get
			{
				return this._ranks;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<BattleFieldRank> _ranks = new List<BattleFieldRank>();

		private IExtension extensionObject;
	}
}
