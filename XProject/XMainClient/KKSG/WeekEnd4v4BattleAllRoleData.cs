using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeekEnd4v4BattleAllRoleData")]
	[Serializable]
	public class WeekEnd4v4BattleAllRoleData : IExtensible
	{

		[ProtoMember(1, Name = "roleData", DataFormat = DataFormat.Default)]
		public List<WeekEnd4v4BattleRoleData> roleData
		{
			get
			{
				return this._roleData;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<WeekEnd4v4BattleRoleData> _roleData = new List<WeekEnd4v4BattleRoleData>();

		private IExtension extensionObject;
	}
}
