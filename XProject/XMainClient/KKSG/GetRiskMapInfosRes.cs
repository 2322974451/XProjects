using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200020B RID: 523
	[ProtoContract(Name = "GetRiskMapInfosRes")]
	[Serializable]
	public class GetRiskMapInfosRes : IExtensible
	{
		// Token: 0x17000940 RID: 2368
		// (get) Token: 0x06001D87 RID: 7559 RVA: 0x0003A178 File Offset: 0x00038378
		// (set) Token: 0x06001D88 RID: 7560 RVA: 0x0003A1A4 File Offset: 0x000383A4
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000941 RID: 2369
		// (get) Token: 0x06001D89 RID: 7561 RVA: 0x0003A1B4 File Offset: 0x000383B4
		// (set) Token: 0x06001D8A RID: 7562 RVA: 0x0003A1D4 File Offset: 0x000383D4
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06001D8B RID: 7563 RVA: 0x0003A218 File Offset: 0x00038418
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001D8C RID: 7564 RVA: 0x0003A230 File Offset: 0x00038430
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000942 RID: 2370
		// (get) Token: 0x06001D8D RID: 7565 RVA: 0x0003A23C File Offset: 0x0003843C
		// (set) Token: 0x06001D8E RID: 7566 RVA: 0x0003A254 File Offset: 0x00038454
		[ProtoMember(2, IsRequired = false, Name = "mapInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RiskMapInfos mapInfo
		{
			get
			{
				return this._mapInfo;
			}
			set
			{
				this._mapInfo = value;
			}
		}

		// Token: 0x06001D8F RID: 7567 RVA: 0x0003A260 File Offset: 0x00038460
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000762 RID: 1890
		private ErrorCode? _error;

		// Token: 0x04000763 RID: 1891
		private RiskMapInfos _mapInfo = null;

		// Token: 0x04000764 RID: 1892
		private IExtension extensionObject;
	}
}
