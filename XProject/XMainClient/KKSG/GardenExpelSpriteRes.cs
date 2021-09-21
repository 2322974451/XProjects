using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000289 RID: 649
	[ProtoContract(Name = "GardenExpelSpriteRes")]
	[Serializable]
	public class GardenExpelSpriteRes : IExtensible
	{
		// Token: 0x17000B4F RID: 2895
		// (get) Token: 0x06002461 RID: 9313 RVA: 0x00046F7C File Offset: 0x0004517C
		// (set) Token: 0x06002462 RID: 9314 RVA: 0x00046FA8 File Offset: 0x000451A8
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000B50 RID: 2896
		// (get) Token: 0x06002463 RID: 9315 RVA: 0x00046FB8 File Offset: 0x000451B8
		// (set) Token: 0x06002464 RID: 9316 RVA: 0x00046FD8 File Offset: 0x000451D8
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06002465 RID: 9317 RVA: 0x0004701C File Offset: 0x0004521C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002466 RID: 9318 RVA: 0x00047034 File Offset: 0x00045234
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000B51 RID: 2897
		// (get) Token: 0x06002467 RID: 9319 RVA: 0x00047040 File Offset: 0x00045240
		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x00047058 File Offset: 0x00045258
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008FD RID: 2301
		private ErrorCode? _result;

		// Token: 0x040008FE RID: 2302
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x040008FF RID: 2303
		private IExtension extensionObject;
	}
}
