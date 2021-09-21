using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002EF RID: 751
	[ProtoContract(Name = "LargeRoomRoleParam")]
	[Serializable]
	public class LargeRoomRoleParam : IExtensible
	{
		// Token: 0x17000CD7 RID: 3287
		// (get) Token: 0x0600295D RID: 10589 RVA: 0x000504C8 File Offset: 0x0004E6C8
		[ProtoMember(1, Name = "name", DataFormat = DataFormat.Default)]
		public List<string> name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000CD8 RID: 3288
		// (get) Token: 0x0600295E RID: 10590 RVA: 0x000504E0 File Offset: 0x0004E6E0
		[ProtoMember(2, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x0600295F RID: 10591 RVA: 0x000504F8 File Offset: 0x0004E6F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A45 RID: 2629
		private readonly List<string> _name = new List<string>();

		// Token: 0x04000A46 RID: 2630
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x04000A47 RID: 2631
		private IExtension extensionObject;
	}
}
