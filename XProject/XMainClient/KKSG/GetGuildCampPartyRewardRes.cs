using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003F8 RID: 1016
	[ProtoContract(Name = "GetGuildCampPartyRewardRes")]
	[Serializable]
	public class GetGuildCampPartyRewardRes : IExtensible
	{
		// Token: 0x1700108F RID: 4239
		// (get) Token: 0x060035DC RID: 13788 RVA: 0x0006731C File Offset: 0x0006551C
		// (set) Token: 0x060035DD RID: 13789 RVA: 0x00067348 File Offset: 0x00065548
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

		// Token: 0x17001090 RID: 4240
		// (get) Token: 0x060035DE RID: 13790 RVA: 0x00067358 File Offset: 0x00065558
		// (set) Token: 0x060035DF RID: 13791 RVA: 0x00067378 File Offset: 0x00065578
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

		// Token: 0x060035E0 RID: 13792 RVA: 0x000673BC File Offset: 0x000655BC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060035E1 RID: 13793 RVA: 0x000673D4 File Offset: 0x000655D4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001091 RID: 4241
		// (get) Token: 0x060035E2 RID: 13794 RVA: 0x000673E0 File Offset: 0x000655E0
		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x060035E3 RID: 13795 RVA: 0x000673F8 File Offset: 0x000655F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D61 RID: 3425
		private ErrorCode? _result;

		// Token: 0x04000D62 RID: 3426
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x04000D63 RID: 3427
		private IExtension extensionObject;
	}
}
