using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002DE RID: 734
	[ProtoContract(Name = "ReqGuildInheritInfoRes")]
	[Serializable]
	public class ReqGuildInheritInfoRes : IExtensible
	{
		// Token: 0x17000C94 RID: 3220
		// (get) Token: 0x06002879 RID: 10361 RVA: 0x0004EA6C File Offset: 0x0004CC6C
		[ProtoMember(1, Name = "data", DataFormat = DataFormat.Default)]
		public List<InheritData> data
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x0600287A RID: 10362 RVA: 0x0004EA84 File Offset: 0x0004CC84
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A10 RID: 2576
		private readonly List<InheritData> _data = new List<InheritData>();

		// Token: 0x04000A11 RID: 2577
		private IExtension extensionObject;
	}
}
