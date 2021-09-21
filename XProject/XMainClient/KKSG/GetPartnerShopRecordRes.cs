using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000343 RID: 835
	[ProtoContract(Name = "GetPartnerShopRecordRes")]
	[Serializable]
	public class GetPartnerShopRecordRes : IExtensible
	{
		// Token: 0x17000E2E RID: 3630
		// (get) Token: 0x06002DB4 RID: 11700 RVA: 0x000586C4 File Offset: 0x000568C4
		// (set) Token: 0x06002DB5 RID: 11701 RVA: 0x000586F0 File Offset: 0x000568F0
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

		// Token: 0x17000E2F RID: 3631
		// (get) Token: 0x06002DB6 RID: 11702 RVA: 0x00058700 File Offset: 0x00056900
		// (set) Token: 0x06002DB7 RID: 11703 RVA: 0x00058720 File Offset: 0x00056920
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

		// Token: 0x06002DB8 RID: 11704 RVA: 0x00058764 File Offset: 0x00056964
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002DB9 RID: 11705 RVA: 0x0005877C File Offset: 0x0005697C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000E30 RID: 3632
		// (get) Token: 0x06002DBA RID: 11706 RVA: 0x00058788 File Offset: 0x00056988
		[ProtoMember(2, Name = "record", DataFormat = DataFormat.Default)]
		public List<PartnerShopRecordItem> record
		{
			get
			{
				return this._record;
			}
		}

		// Token: 0x06002DBB RID: 11707 RVA: 0x000587A0 File Offset: 0x000569A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B5C RID: 2908
		private ErrorCode? _result;

		// Token: 0x04000B5D RID: 2909
		private readonly List<PartnerShopRecordItem> _record = new List<PartnerShopRecordItem>();

		// Token: 0x04000B5E RID: 2910
		private IExtension extensionObject;
	}
}
