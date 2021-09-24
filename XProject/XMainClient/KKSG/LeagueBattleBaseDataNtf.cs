using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleBaseDataNtf")]
	[Serializable]
	public class LeagueBattleBaseDataNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "team1", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleOneTeam team1
		{
			get
			{
				return this._team1;
			}
			set
			{
				this._team1 = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "team2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleOneTeam team2
		{
			get
			{
				return this._team2;
			}
			set
			{
				this._team2 = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private LeagueBattleOneTeam _team1 = null;

		private LeagueBattleOneTeam _team2 = null;

		private IExtension extensionObject;
	}
}
