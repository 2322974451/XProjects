using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200041B RID: 1051
	[ProtoContract(Name = "WeekEnd4v4BattleAllRoleData")]
	[Serializable]
	public class WeekEnd4v4BattleAllRoleData : IExtensible
	{
		// Token: 0x17001128 RID: 4392
		// (get) Token: 0x060037D9 RID: 14297 RVA: 0x0006AEF4 File Offset: 0x000690F4
		[ProtoMember(1, Name = "roleData", DataFormat = DataFormat.Default)]
		public List<WeekEnd4v4BattleRoleData> roleData
		{
			get
			{
				return this._roleData;
			}
		}

		// Token: 0x060037DA RID: 14298 RVA: 0x0006AF0C File Offset: 0x0006910C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DD6 RID: 3542
		private readonly List<WeekEnd4v4BattleRoleData> _roleData = new List<WeekEnd4v4BattleRoleData>();

		// Token: 0x04000DD7 RID: 3543
		private IExtension extensionObject;
	}
}
