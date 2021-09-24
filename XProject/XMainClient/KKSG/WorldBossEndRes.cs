using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WorldBossEndRes")]
	[Serializable]
	public class WorldBossEndRes : IExtensible
	{

		[ProtoMember(1, Name = "damages", DataFormat = DataFormat.Default)]
		public List<WorldBossDamageInfo> damages
		{
			get
			{
				return this._damages;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "selfdamage", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WorldBossDamageInfo selfdamage
		{
			get
			{
				return this._selfdamage;
			}
			set
			{
				this._selfdamage = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<WorldBossDamageInfo> _damages = new List<WorldBossDamageInfo>();

		private WorldBossDamageInfo _selfdamage = null;

		private IExtension extensionObject;
	}
}
