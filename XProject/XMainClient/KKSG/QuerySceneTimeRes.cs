using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200022E RID: 558
	[ProtoContract(Name = "QuerySceneTimeRes")]
	[Serializable]
	public class QuerySceneTimeRes : IExtensible
	{
		// Token: 0x170009B3 RID: 2483
		// (get) Token: 0x06001F17 RID: 7959 RVA: 0x0003CFE8 File Offset: 0x0003B1E8
		// (set) Token: 0x06001F18 RID: 7960 RVA: 0x0003D014 File Offset: 0x0003B214
		[ProtoMember(1, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170009B4 RID: 2484
		// (get) Token: 0x06001F19 RID: 7961 RVA: 0x0003D024 File Offset: 0x0003B224
		// (set) Token: 0x06001F1A RID: 7962 RVA: 0x0003D044 File Offset: 0x0003B244
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

		// Token: 0x06001F1B RID: 7963 RVA: 0x0003D088 File Offset: 0x0003B288
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06001F1C RID: 7964 RVA: 0x0003D0A0 File Offset: 0x0003B2A0
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170009B5 RID: 2485
		// (get) Token: 0x06001F1D RID: 7965 RVA: 0x0003D0AC File Offset: 0x0003B2AC
		// (set) Token: 0x06001F1E RID: 7966 RVA: 0x0003D0D8 File Offset: 0x0003B2D8
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170009B6 RID: 2486
		// (get) Token: 0x06001F1F RID: 7967 RVA: 0x0003D0E8 File Offset: 0x0003B2E8
		// (set) Token: 0x06001F20 RID: 7968 RVA: 0x0003D108 File Offset: 0x0003B308
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06001F21 RID: 7969 RVA: 0x0003D14C File Offset: 0x0003B34C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001F22 RID: 7970 RVA: 0x0003D164 File Offset: 0x0003B364
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001F23 RID: 7971 RVA: 0x0003D170 File Offset: 0x0003B370
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007C3 RID: 1987
		private int? _time;

		// Token: 0x040007C4 RID: 1988
		private ErrorCode? _errorcode;

		// Token: 0x040007C5 RID: 1989
		private IExtension extensionObject;
	}
}
