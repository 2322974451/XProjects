using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004C7 RID: 1223
	[ProtoContract(Name = "GetDragonGuildShopRecordRes")]
	[Serializable]
	public class GetDragonGuildShopRecordRes : IExtensible
	{
		// Token: 0x1700137C RID: 4988
		// (get) Token: 0x06003F99 RID: 16281 RVA: 0x000793C8 File Offset: 0x000775C8
		// (set) Token: 0x06003F9A RID: 16282 RVA: 0x000793F4 File Offset: 0x000775F4
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

		// Token: 0x1700137D RID: 4989
		// (get) Token: 0x06003F9B RID: 16283 RVA: 0x00079404 File Offset: 0x00077604
		// (set) Token: 0x06003F9C RID: 16284 RVA: 0x00079424 File Offset: 0x00077624
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

		// Token: 0x06003F9D RID: 16285 RVA: 0x00079468 File Offset: 0x00077668
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003F9E RID: 16286 RVA: 0x00079480 File Offset: 0x00077680
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700137E RID: 4990
		// (get) Token: 0x06003F9F RID: 16287 RVA: 0x0007948C File Offset: 0x0007768C
		[ProtoMember(2, Name = "record", DataFormat = DataFormat.Default)]
		public List<DragonGuildShopRecordItem> record
		{
			get
			{
				return this._record;
			}
		}

		// Token: 0x06003FA0 RID: 16288 RVA: 0x000794A4 File Offset: 0x000776A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FD6 RID: 4054
		private ErrorCode? _result;

		// Token: 0x04000FD7 RID: 4055
		private readonly List<DragonGuildShopRecordItem> _record = new List<DragonGuildShopRecordItem>();

		// Token: 0x04000FD8 RID: 4056
		private IExtension extensionObject;
	}
}
