using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001C4 RID: 452
	[ProtoContract(Name = "PayCardAwardRes")]
	[Serializable]
	public class PayCardAwardRes : IExtensible
	{
		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x06001A33 RID: 6707 RVA: 0x00033DFC File Offset: 0x00031FFC
		// (set) Token: 0x06001A34 RID: 6708 RVA: 0x00033E28 File Offset: 0x00032028
		[ProtoMember(1, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700083D RID: 2109
		// (get) Token: 0x06001A35 RID: 6709 RVA: 0x00033E38 File Offset: 0x00032038
		// (set) Token: 0x06001A36 RID: 6710 RVA: 0x00033E58 File Offset: 0x00032058
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06001A37 RID: 6711 RVA: 0x00033E9C File Offset: 0x0003209C
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x00033EB4 File Offset: 0x000320B4
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x1700083E RID: 2110
		// (get) Token: 0x06001A39 RID: 6713 RVA: 0x00033EC0 File Offset: 0x000320C0
		// (set) Token: 0x06001A3A RID: 6714 RVA: 0x00033ED8 File Offset: 0x000320D8
		[ProtoMember(2, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayCard info
		{
			get
			{
				return this._info;
			}
			set
			{
				this._info = value;
			}
		}

		// Token: 0x06001A3B RID: 6715 RVA: 0x00033EE4 File Offset: 0x000320E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000685 RID: 1669
		private ErrorCode? _errcode;

		// Token: 0x04000686 RID: 1670
		private PayCard _info = null;

		// Token: 0x04000687 RID: 1671
		private IExtension extensionObject;
	}
}
