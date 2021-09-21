using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002BE RID: 702
	[ProtoContract(Name = "ResWarRoleRankRes")]
	[Serializable]
	public class ResWarRoleRankRes : IExtensible
	{
		// Token: 0x17000C1E RID: 3102
		// (get) Token: 0x060026F7 RID: 9975 RVA: 0x0004BCCC File Offset: 0x00049ECC
		[ProtoMember(1, Name = "data", DataFormat = DataFormat.Default)]
		public List<ResWarRoleRank> data
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x060026F8 RID: 9976 RVA: 0x0004BCE4 File Offset: 0x00049EE4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009AD RID: 2477
		private readonly List<ResWarRoleRank> _data = new List<ResWarRoleRank>();

		// Token: 0x040009AE RID: 2478
		private IExtension extensionObject;
	}
}
