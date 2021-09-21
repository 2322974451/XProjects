using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000104 RID: 260
	[ProtoContract(Name = "ExpFindBackData")]
	[Serializable]
	public class ExpFindBackData : IExtensible
	{
		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x060010AF RID: 4271 RVA: 0x00022328 File Offset: 0x00020528
		[ProtoMember(1, Name = "expBackInfos", DataFormat = DataFormat.Default)]
		public List<ExpFindBackInfo> expBackInfos
		{
			get
			{
				return this._expBackInfos;
			}
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x00022340 File Offset: 0x00020540
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400042B RID: 1067
		private readonly List<ExpFindBackInfo> _expBackInfos = new List<ExpFindBackInfo>();

		// Token: 0x0400042C RID: 1068
		private IExtension extensionObject;
	}
}
