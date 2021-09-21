using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003EB RID: 1003
	[ProtoContract(Name = "GetGuildCamPartyRandItemRes")]
	[Serializable]
	public class GetGuildCamPartyRandItemRes : IExtensible
	{
		// Token: 0x17001064 RID: 4196
		// (get) Token: 0x0600354B RID: 13643 RVA: 0x00066244 File Offset: 0x00064444
		// (set) Token: 0x0600354C RID: 13644 RVA: 0x00066270 File Offset: 0x00064470
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

		// Token: 0x17001065 RID: 4197
		// (get) Token: 0x0600354D RID: 13645 RVA: 0x00066280 File Offset: 0x00064480
		// (set) Token: 0x0600354E RID: 13646 RVA: 0x000662A0 File Offset: 0x000644A0
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

		// Token: 0x0600354F RID: 13647 RVA: 0x000662E4 File Offset: 0x000644E4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003550 RID: 13648 RVA: 0x000662FC File Offset: 0x000644FC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001066 RID: 4198
		// (get) Token: 0x06003551 RID: 13649 RVA: 0x00066308 File Offset: 0x00064508
		[ProtoMember(2, Name = "random_items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> random_items
		{
			get
			{
				return this._random_items;
			}
		}

		// Token: 0x06003552 RID: 13650 RVA: 0x00066320 File Offset: 0x00064520
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D3C RID: 3388
		private ErrorCode? _result;

		// Token: 0x04000D3D RID: 3389
		private readonly List<ItemBrief> _random_items = new List<ItemBrief>();

		// Token: 0x04000D3E RID: 3390
		private IExtension extensionObject;
	}
}
