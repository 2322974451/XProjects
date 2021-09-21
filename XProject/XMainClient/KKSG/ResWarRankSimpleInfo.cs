using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002CA RID: 714
	[ProtoContract(Name = "ResWarRankSimpleInfo")]
	[Serializable]
	public class ResWarRankSimpleInfo : IExtensible
	{
		// Token: 0x17000C44 RID: 3140
		// (get) Token: 0x06002775 RID: 10101 RVA: 0x0004CB78 File Offset: 0x0004AD78
		[ProtoMember(1, Name = "rank", DataFormat = DataFormat.Default)]
		public List<ResWarRank> rank
		{
			get
			{
				return this._rank;
			}
		}

		// Token: 0x06002776 RID: 10102 RVA: 0x0004CB90 File Offset: 0x0004AD90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009CF RID: 2511
		private readonly List<ResWarRank> _rank = new List<ResWarRank>();

		// Token: 0x040009D0 RID: 2512
		private IExtension extensionObject;
	}
}
