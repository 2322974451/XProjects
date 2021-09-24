using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleFieldRoleAgainst")]
	[Serializable]
	public class BattleFieldRoleAgainst : IExtensible
	{

		[ProtoMember(1, Name = "roles", DataFormat = DataFormat.Default)]
		public List<BattleFieldRoleSimpleInfo> roles
		{
			get
			{
				return this._roles;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<BattleFieldRoleSimpleInfo> _roles = new List<BattleFieldRoleSimpleInfo>();

		private IExtension extensionObject;
	}
}
