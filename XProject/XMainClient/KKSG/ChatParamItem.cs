using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005A4 RID: 1444
	[ProtoContract(Name = "ChatParamItem")]
	[Serializable]
	public class ChatParamItem : IExtensible
	{
		// Token: 0x17001826 RID: 6182
		// (get) Token: 0x06004E42 RID: 20034 RVA: 0x00094E20 File Offset: 0x00093020
		// (set) Token: 0x06004E43 RID: 20035 RVA: 0x00094E38 File Offset: 0x00093038
		[ProtoMember(1, IsRequired = false, Name = "item", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item = value;
			}
		}

		// Token: 0x06004E44 RID: 20036 RVA: 0x00094E44 File Offset: 0x00093044
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400135B RID: 4955
		private ItemBrief _item = null;

		// Token: 0x0400135C RID: 4956
		private IExtension extensionObject;
	}
}
