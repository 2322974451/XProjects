using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleTeamMsg")]
	[Serializable]
	public class HeroBattleTeamMsg : IExtensible
	{

		[ProtoMember(1, Name = "teamdata", DataFormat = DataFormat.Default)]
		public List<HeroBattleTeamData> teamdata
		{
			get
			{
				return this._teamdata;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<HeroBattleTeamData> _teamdata = new List<HeroBattleTeamData>();

		private IExtension extensionObject;
	}
}
