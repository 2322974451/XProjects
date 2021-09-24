using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaBattleTeamMsg")]
	[Serializable]
	public class MobaBattleTeamMsg : IExtensible
	{

		[ProtoMember(1, Name = "teamdata", DataFormat = DataFormat.Default)]
		public List<MobaBattleTeamData> teamdata
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

		private readonly List<MobaBattleTeamData> _teamdata = new List<MobaBattleTeamData>();

		private IExtension extensionObject;
	}
}
