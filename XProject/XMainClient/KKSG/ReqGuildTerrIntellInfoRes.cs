using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003B3 RID: 947
	[ProtoContract(Name = "ReqGuildTerrIntellInfoRes")]
	[Serializable]
	public class ReqGuildTerrIntellInfoRes : IExtensible
	{
		// Token: 0x17000F9B RID: 3995
		// (get) Token: 0x0600329B RID: 12955 RVA: 0x000614D0 File Offset: 0x0005F6D0
		[ProtoMember(1, Name = "intellInfo", DataFormat = DataFormat.Default)]
		public List<TerrData> intellInfo
		{
			get
			{
				return this._intellInfo;
			}
		}

		// Token: 0x0600329C RID: 12956 RVA: 0x000614E8 File Offset: 0x0005F6E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C97 RID: 3223
		private readonly List<TerrData> _intellInfo = new List<TerrData>();

		// Token: 0x04000C98 RID: 3224
		private IExtension extensionObject;
	}
}
