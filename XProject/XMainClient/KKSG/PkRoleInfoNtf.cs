using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000E4 RID: 228
	[ProtoContract(Name = "PkRoleInfoNtf")]
	[Serializable]
	public class PkRoleInfoNtf : IExtensible
	{
		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06000EC1 RID: 3777 RVA: 0x0001E8C8 File Offset: 0x0001CAC8
		[ProtoMember(1, Name = "pkroleinfo", DataFormat = DataFormat.Default)]
		public List<PkRoleInfo> pkroleinfo
		{
			get
			{
				return this._pkroleinfo;
			}
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x0001E8E0 File Offset: 0x0001CAE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003B2 RID: 946
		private readonly List<PkRoleInfo> _pkroleinfo = new List<PkRoleInfo>();

		// Token: 0x040003B3 RID: 947
		private IExtension extensionObject;
	}
}
