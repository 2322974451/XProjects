using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200036C RID: 876
	[ProtoContract(Name = "QueryRoleStateReq")]
	[Serializable]
	public class QueryRoleStateReq : IExtensible
	{
		// Token: 0x17000EBD RID: 3773
		// (get) Token: 0x06002F9F RID: 12191 RVA: 0x0005BE2C File Offset: 0x0005A02C
		[ProtoMember(1, Name = "roleids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleids
		{
			get
			{
				return this._roleids;
			}
		}

		// Token: 0x06002FA0 RID: 12192 RVA: 0x0005BE44 File Offset: 0x0005A044
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BD2 RID: 3026
		private readonly List<ulong> _roleids = new List<ulong>();

		// Token: 0x04000BD3 RID: 3027
		private IExtension extensionObject;
	}
}
