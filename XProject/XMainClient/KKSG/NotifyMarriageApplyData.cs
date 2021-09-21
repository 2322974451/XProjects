using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200047E RID: 1150
	[ProtoContract(Name = "NotifyMarriageApplyData")]
	[Serializable]
	public class NotifyMarriageApplyData : IExtensible
	{
		// Token: 0x1700126E RID: 4718
		// (get) Token: 0x06003C20 RID: 15392 RVA: 0x00072E08 File Offset: 0x00071008
		// (set) Token: 0x06003C21 RID: 15393 RVA: 0x00072E20 File Offset: 0x00071020
		[ProtoMember(1, IsRequired = false, Name = "applyInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MarriageApplyInfo applyInfo
		{
			get
			{
				return this._applyInfo;
			}
			set
			{
				this._applyInfo = value;
			}
		}

		// Token: 0x1700126F RID: 4719
		// (get) Token: 0x06003C22 RID: 15394 RVA: 0x00072E2C File Offset: 0x0007102C
		// (set) Token: 0x06003C23 RID: 15395 RVA: 0x00072E44 File Offset: 0x00071044
		[ProtoMember(2, IsRequired = false, Name = "response", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MarriageApplyResponse response
		{
			get
			{
				return this._response;
			}
			set
			{
				this._response = value;
			}
		}

		// Token: 0x06003C24 RID: 15396 RVA: 0x00072E50 File Offset: 0x00071050
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EF3 RID: 3827
		private MarriageApplyInfo _applyInfo = null;

		// Token: 0x04000EF4 RID: 3828
		private MarriageApplyResponse _response = null;

		// Token: 0x04000EF5 RID: 3829
		private IExtension extensionObject;
	}
}
