using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000480 RID: 1152
	[ProtoContract(Name = "WeddingLoadInfoNtf")]
	[Serializable]
	public class WeddingLoadInfoNtf : IExtensible
	{
		// Token: 0x17001276 RID: 4726
		// (get) Token: 0x06003C2E RID: 15406 RVA: 0x00072F88 File Offset: 0x00071188
		// (set) Token: 0x06003C2F RID: 15407 RVA: 0x00072FA0 File Offset: 0x000711A0
		[ProtoMember(1, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeddingBrief info
		{
			get
			{
				return this._info;
			}
			set
			{
				this._info = value;
			}
		}

		// Token: 0x06003C30 RID: 15408 RVA: 0x00072FAC File Offset: 0x000711AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EFD RID: 3837
		private WeddingBrief _info = null;

		// Token: 0x04000EFE RID: 3838
		private IExtension extensionObject;
	}
}
