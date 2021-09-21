using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000424 RID: 1060
	[ProtoContract(Name = "MobaRoleChangeData")]
	[Serializable]
	public class MobaRoleChangeData : IExtensible
	{
		// Token: 0x17001148 RID: 4424
		// (get) Token: 0x06003841 RID: 14401 RVA: 0x0006BB08 File Offset: 0x00069D08
		[ProtoMember(1, Name = "changeRole", DataFormat = DataFormat.Default)]
		public List<MobaRoleData> changeRole
		{
			get
			{
				return this._changeRole;
			}
		}

		// Token: 0x06003842 RID: 14402 RVA: 0x0006BB20 File Offset: 0x00069D20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DF2 RID: 3570
		private readonly List<MobaRoleData> _changeRole = new List<MobaRoleData>();

		// Token: 0x04000DF3 RID: 3571
		private IExtension extensionObject;
	}
}
