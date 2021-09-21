using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001E8 RID: 488
	[ProtoContract(Name = "PkReqRes")]
	[Serializable]
	public class PkReqRes : IExtensible
	{
		// Token: 0x170008CC RID: 2252
		// (get) Token: 0x06001C0C RID: 7180 RVA: 0x000375A0 File Offset: 0x000357A0
		// (set) Token: 0x06001C0D RID: 7181 RVA: 0x000375CC File Offset: 0x000357CC
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170008CD RID: 2253
		// (get) Token: 0x06001C0E RID: 7182 RVA: 0x000375DC File Offset: 0x000357DC
		// (set) Token: 0x06001C0F RID: 7183 RVA: 0x000375FC File Offset: 0x000357FC
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

		// Token: 0x06001C10 RID: 7184 RVA: 0x00037640 File Offset: 0x00035840
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001C11 RID: 7185 RVA: 0x00037658 File Offset: 0x00035858
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170008CE RID: 2254
		// (get) Token: 0x06001C12 RID: 7186 RVA: 0x00037664 File Offset: 0x00035864
		// (set) Token: 0x06001C13 RID: 7187 RVA: 0x00037690 File Offset: 0x00035890
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x170008CF RID: 2255
		// (get) Token: 0x06001C14 RID: 7188 RVA: 0x000376A0 File Offset: 0x000358A0
		// (set) Token: 0x06001C15 RID: 7189 RVA: 0x000376C0 File Offset: 0x000358C0
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
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06001C16 RID: 7190 RVA: 0x00037704 File Offset: 0x00035904
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06001C17 RID: 7191 RVA: 0x0003771C File Offset: 0x0003591C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170008D0 RID: 2256
		// (get) Token: 0x06001C18 RID: 7192 RVA: 0x00037728 File Offset: 0x00035928
		// (set) Token: 0x06001C19 RID: 7193 RVA: 0x00037740 File Offset: 0x00035940
		[ProtoMember(3, IsRequired = false, Name = "allinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public QueryPkInfoRes allinfo
		{
			get
			{
				return this._allinfo;
			}
			set
			{
				this._allinfo = value;
			}
		}

		// Token: 0x06001C1A RID: 7194 RVA: 0x0003774C File Offset: 0x0003594C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006FA RID: 1786
		private ErrorCode? _errorcode;

		// Token: 0x040006FB RID: 1787
		private uint? _time;

		// Token: 0x040006FC RID: 1788
		private QueryPkInfoRes _allinfo = null;

		// Token: 0x040006FD RID: 1789
		private IExtension extensionObject;
	}
}
