using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006C1 RID: 1729
	[ProtoContract(Name = "ResWarFinalAll")]
	[Serializable]
	public class ResWarFinalAll : IExtensible
	{
		// Token: 0x170023F9 RID: 9209
		// (get) Token: 0x060071A5 RID: 29093 RVA: 0x000D96D8 File Offset: 0x000D78D8
		[ProtoMember(1, Name = "data", DataFormat = DataFormat.Default)]
		public List<ResWarFinal> data
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x060071A6 RID: 29094 RVA: 0x000D96F0 File Offset: 0x000D78F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B1C RID: 6940
		private readonly List<ResWarFinal> _data = new List<ResWarFinal>();

		// Token: 0x04001B1D RID: 6941
		private IExtension extensionObject;
	}
}
