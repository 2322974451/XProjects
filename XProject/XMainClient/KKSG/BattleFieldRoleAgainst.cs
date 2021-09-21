using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004DD RID: 1245
	[ProtoContract(Name = "BattleFieldRoleAgainst")]
	[Serializable]
	public class BattleFieldRoleAgainst : IExtensible
	{
		// Token: 0x170013B1 RID: 5041
		// (get) Token: 0x0600405A RID: 16474 RVA: 0x0007A8D4 File Offset: 0x00078AD4
		[ProtoMember(1, Name = "roles", DataFormat = DataFormat.Default)]
		public List<BattleFieldRoleSimpleInfo> roles
		{
			get
			{
				return this._roles;
			}
		}

		// Token: 0x0600405B RID: 16475 RVA: 0x0007A8EC File Offset: 0x00078AEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001009 RID: 4105
		private readonly List<BattleFieldRoleSimpleInfo> _roles = new List<BattleFieldRoleSimpleInfo>();

		// Token: 0x0400100A RID: 4106
		private IExtension extensionObject;
	}
}
