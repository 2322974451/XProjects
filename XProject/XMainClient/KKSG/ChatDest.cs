using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005A1 RID: 1441
	[ProtoContract(Name = "ChatDest")]
	[Serializable]
	public class ChatDest : IExtensible
	{
		// Token: 0x17001817 RID: 6167
		// (get) Token: 0x06004E19 RID: 19993 RVA: 0x00094A04 File Offset: 0x00092C04
		[ProtoMember(1, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x06004E1A RID: 19994 RVA: 0x00094A1C File Offset: 0x00092C1C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400134C RID: 4940
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x0400134D RID: 4941
		private IExtension extensionObject;
	}
}
