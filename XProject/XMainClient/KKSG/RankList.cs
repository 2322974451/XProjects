using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000586 RID: 1414
	[ProtoContract(Name = "RankList")]
	[Serializable]
	public class RankList : IExtensible
	{
		// Token: 0x1700169F RID: 5791
		// (get) Token: 0x060049B0 RID: 18864 RVA: 0x0008C168 File Offset: 0x0008A368
		[ProtoMember(1, Name = "RankData", DataFormat = DataFormat.Default)]
		public List<RankData> RankData
		{
			get
			{
				return this._RankData;
			}
		}

		// Token: 0x060049B1 RID: 18865 RVA: 0x0008C180 File Offset: 0x0008A380
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001263 RID: 4707
		private readonly List<RankData> _RankData = new List<RankData>();

		// Token: 0x04001264 RID: 4708
		private IExtension extensionObject;
	}
}
