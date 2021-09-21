using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001EE RID: 494
	[ProtoContract(Name = "ChangeOutLookOpArg")]
	[Serializable]
	public class ChangeOutLookOpArg : IExtensible
	{
		// Token: 0x170008DE RID: 2270
		// (get) Token: 0x06001C4B RID: 7243 RVA: 0x00037CB8 File Offset: 0x00035EB8
		// (set) Token: 0x06001C4C RID: 7244 RVA: 0x00037CD0 File Offset: 0x00035ED0
		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookOp op
		{
			get
			{
				return this._op;
			}
			set
			{
				this._op = value;
			}
		}

		// Token: 0x06001C4D RID: 7245 RVA: 0x00037CDC File Offset: 0x00035EDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400070A RID: 1802
		private OutLookOp _op = null;

		// Token: 0x0400070B RID: 1803
		private IExtension extensionObject;
	}
}
