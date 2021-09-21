using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000336 RID: 822
	[ProtoContract(Name = "GetPartnerShopRes")]
	[Serializable]
	public class GetPartnerShopRes : IExtensible
	{
		// Token: 0x17000E08 RID: 3592
		// (get) Token: 0x06002D38 RID: 11576 RVA: 0x0005784C File Offset: 0x00055A4C
		[ProtoMember(1, Name = "item", DataFormat = DataFormat.Default)]
		public List<PartnerShopItemClient> item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x17000E09 RID: 3593
		// (get) Token: 0x06002D39 RID: 11577 RVA: 0x00057864 File Offset: 0x00055A64
		// (set) Token: 0x06002D3A RID: 11578 RVA: 0x00057890 File Offset: 0x00055A90
		[ProtoMember(2, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000E0A RID: 3594
		// (get) Token: 0x06002D3B RID: 11579 RVA: 0x000578A0 File Offset: 0x00055AA0
		// (set) Token: 0x06002D3C RID: 11580 RVA: 0x000578C0 File Offset: 0x00055AC0
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

		// Token: 0x06002D3D RID: 11581 RVA: 0x00057904 File Offset: 0x00055B04
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002D3E RID: 11582 RVA: 0x0005791C File Offset: 0x00055B1C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06002D3F RID: 11583 RVA: 0x00057928 File Offset: 0x00055B28
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B38 RID: 2872
		private readonly List<PartnerShopItemClient> _item = new List<PartnerShopItemClient>();

		// Token: 0x04000B39 RID: 2873
		private ErrorCode? _result;

		// Token: 0x04000B3A RID: 2874
		private IExtension extensionObject;
	}
}
