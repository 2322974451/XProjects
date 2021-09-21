using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000653 RID: 1619
	[ProtoContract(Name = "SBuffRecord")]
	[Serializable]
	public class SBuffRecord : IExtensible
	{
		// Token: 0x17001FCB RID: 8139
		// (get) Token: 0x060064C9 RID: 25801 RVA: 0x000C0650 File Offset: 0x000BE850
		[ProtoMember(1, Name = "buffs", DataFormat = DataFormat.Default)]
		public List<Buff> buffs
		{
			get
			{
				return this._buffs;
			}
		}

		// Token: 0x17001FCC RID: 8140
		// (get) Token: 0x060064CA RID: 25802 RVA: 0x000C0668 File Offset: 0x000BE868
		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<BuffItem> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x17001FCD RID: 8141
		// (get) Token: 0x060064CB RID: 25803 RVA: 0x000C0680 File Offset: 0x000BE880
		// (set) Token: 0x060064CC RID: 25804 RVA: 0x000C0698 File Offset: 0x000BE898
		[ProtoMember(3, IsRequired = false, Name = "transbuff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public STransformBuff transbuff
		{
			get
			{
				return this._transbuff;
			}
			set
			{
				this._transbuff = value;
			}
		}

		// Token: 0x17001FCE RID: 8142
		// (get) Token: 0x060064CD RID: 25805 RVA: 0x000C06A4 File Offset: 0x000BE8A4
		// (set) Token: 0x060064CE RID: 25806 RVA: 0x000C06BC File Offset: 0x000BE8BC
		[ProtoMember(4, IsRequired = false, Name = "smallbuff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public STransformBuff smallbuff
		{
			get
			{
				return this._smallbuff;
			}
			set
			{
				this._smallbuff = value;
			}
		}

		// Token: 0x060064CF RID: 25807 RVA: 0x000C06C8 File Offset: 0x000BE8C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400186E RID: 6254
		private readonly List<Buff> _buffs = new List<Buff>();

		// Token: 0x0400186F RID: 6255
		private readonly List<BuffItem> _items = new List<BuffItem>();

		// Token: 0x04001870 RID: 6256
		private STransformBuff _transbuff = null;

		// Token: 0x04001871 RID: 6257
		private STransformBuff _smallbuff = null;

		// Token: 0x04001872 RID: 6258
		private IExtension extensionObject;
	}
}
