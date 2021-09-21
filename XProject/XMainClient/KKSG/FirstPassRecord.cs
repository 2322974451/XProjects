using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200062A RID: 1578
	[ProtoContract(Name = "FirstPassRecord")]
	[Serializable]
	public class FirstPassRecord : IExtensible
	{
		// Token: 0x17001E77 RID: 7799
		// (get) Token: 0x060060D9 RID: 24793 RVA: 0x000B8BC8 File Offset: 0x000B6DC8
		[ProtoMember(1, Name = "infos", DataFormat = DataFormat.Default)]
		public List<FirstPassStageInfo> infos
		{
			get
			{
				return this._infos;
			}
		}

		// Token: 0x060060DA RID: 24794 RVA: 0x000B8BE0 File Offset: 0x000B6DE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400177F RID: 6015
		private readonly List<FirstPassStageInfo> _infos = new List<FirstPassStageInfo>();

		// Token: 0x04001780 RID: 6016
		private IExtension extensionObject;
	}
}
