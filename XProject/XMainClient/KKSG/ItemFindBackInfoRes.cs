using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001F1 RID: 497
	[ProtoContract(Name = "ItemFindBackInfoRes")]
	[Serializable]
	public class ItemFindBackInfoRes : IExtensible
	{
		// Token: 0x170008E1 RID: 2273
		// (get) Token: 0x06001C59 RID: 7257 RVA: 0x00037E14 File Offset: 0x00036014
		// (set) Token: 0x06001C5A RID: 7258 RVA: 0x00037E40 File Offset: 0x00036040
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

		// Token: 0x170008E2 RID: 2274
		// (get) Token: 0x06001C5B RID: 7259 RVA: 0x00037E50 File Offset: 0x00036050
		// (set) Token: 0x06001C5C RID: 7260 RVA: 0x00037E70 File Offset: 0x00036070
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

		// Token: 0x06001C5D RID: 7261 RVA: 0x00037EB4 File Offset: 0x000360B4
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001C5E RID: 7262 RVA: 0x00037ECC File Offset: 0x000360CC
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x170008E3 RID: 2275
		// (get) Token: 0x06001C5F RID: 7263 RVA: 0x00037ED8 File Offset: 0x000360D8
		[ProtoMember(2, Name = "backInfo", DataFormat = DataFormat.Default)]
		public List<ItemFindBackInfo2Client> backInfo
		{
			get
			{
				return this._backInfo;
			}
		}

		// Token: 0x170008E4 RID: 2276
		// (get) Token: 0x06001C60 RID: 7264 RVA: 0x00037EF0 File Offset: 0x000360F0
		// (set) Token: 0x06001C61 RID: 7265 RVA: 0x00037F1C File Offset: 0x0003611C
		[ProtoMember(3, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public int time
		{
			get
			{
				return this._time ?? 0;
			}
			set
			{
				this._time = new int?(value);
			}
		}

		// Token: 0x170008E5 RID: 2277
		// (get) Token: 0x06001C62 RID: 7266 RVA: 0x00037F2C File Offset: 0x0003612C
		// (set) Token: 0x06001C63 RID: 7267 RVA: 0x00037F4C File Offset: 0x0003614C
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new int?(this.time) : null);
				}
			}
		}

		// Token: 0x06001C64 RID: 7268 RVA: 0x00037F90 File Offset: 0x00036190
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06001C65 RID: 7269 RVA: 0x00037FA8 File Offset: 0x000361A8
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06001C66 RID: 7270 RVA: 0x00037FB4 File Offset: 0x000361B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400070F RID: 1807
		private ErrorCode? _error;

		// Token: 0x04000710 RID: 1808
		private readonly List<ItemFindBackInfo2Client> _backInfo = new List<ItemFindBackInfo2Client>();

		// Token: 0x04000711 RID: 1809
		private int? _time;

		// Token: 0x04000712 RID: 1810
		private IExtension extensionObject;
	}
}
