using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001EB RID: 491
	[ProtoContract(Name = "QAIDNameList")]
	[Serializable]
	public class QAIDNameList : IExtensible
	{
		// Token: 0x170008D7 RID: 2263
		// (get) Token: 0x06001C32 RID: 7218 RVA: 0x00037A0C File Offset: 0x00035C0C
		[ProtoMember(1, Name = "idname", DataFormat = DataFormat.Default)]
		public List<QAIDName> idname
		{
			get
			{
				return this._idname;
			}
		}

		// Token: 0x06001C33 RID: 7219 RVA: 0x00037A24 File Offset: 0x00035C24
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000703 RID: 1795
		private readonly List<QAIDName> _idname = new List<QAIDName>();

		// Token: 0x04000704 RID: 1796
		private IExtension extensionObject;
	}
}
