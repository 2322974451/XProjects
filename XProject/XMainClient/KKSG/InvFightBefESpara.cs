using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000339 RID: 825
	[ProtoContract(Name = "InvFightBefESpara")]
	[Serializable]
	public class InvFightBefESpara : IExtensible
	{
		// Token: 0x17000E11 RID: 3601
		// (get) Token: 0x06002D57 RID: 11607 RVA: 0x00057BE8 File Offset: 0x00055DE8
		[ProtoMember(1, Name = "roles", DataFormat = DataFormat.Default)]
		public List<RoleSmallInfo> roles
		{
			get
			{
				return this._roles;
			}
		}

		// Token: 0x06002D58 RID: 11608 RVA: 0x00057C00 File Offset: 0x00055E00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B40 RID: 2880
		private readonly List<RoleSmallInfo> _roles = new List<RoleSmallInfo>();

		// Token: 0x04000B41 RID: 2881
		private IExtension extensionObject;
	}
}
