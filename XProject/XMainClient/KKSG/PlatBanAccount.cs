using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005B0 RID: 1456
	[ProtoContract(Name = "PlatBanAccount")]
	[Serializable]
	public class PlatBanAccount : IExtensible
	{
		// Token: 0x17001880 RID: 6272
		// (get) Token: 0x06004F62 RID: 20322 RVA: 0x00096FAC File Offset: 0x000951AC
		// (set) Token: 0x06004F63 RID: 20323 RVA: 0x00096FCD File Offset: 0x000951CD
		[ProtoMember(1, IsRequired = false, Name = "reason", DataFormat = DataFormat.Default)]
		public string reason
		{
			get
			{
				return this._reason ?? "";
			}
			set
			{
				this._reason = value;
			}
		}

		// Token: 0x17001881 RID: 6273
		// (get) Token: 0x06004F64 RID: 20324 RVA: 0x00096FD8 File Offset: 0x000951D8
		// (set) Token: 0x06004F65 RID: 20325 RVA: 0x00096FF4 File Offset: 0x000951F4
		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? this.reason : null);
				}
			}
		}

		// Token: 0x06004F66 RID: 20326 RVA: 0x00097024 File Offset: 0x00095224
		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		// Token: 0x06004F67 RID: 20327 RVA: 0x0009703C File Offset: 0x0009523C
		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		// Token: 0x17001882 RID: 6274
		// (get) Token: 0x06004F68 RID: 20328 RVA: 0x00097048 File Offset: 0x00095248
		// (set) Token: 0x06004F69 RID: 20329 RVA: 0x00097074 File Offset: 0x00095274
		[ProtoMember(2, IsRequired = false, Name = "endtime", DataFormat = DataFormat.TwosComplement)]
		public uint endtime
		{
			get
			{
				return this._endtime ?? 0U;
			}
			set
			{
				this._endtime = new uint?(value);
			}
		}

		// Token: 0x17001883 RID: 6275
		// (get) Token: 0x06004F6A RID: 20330 RVA: 0x00097084 File Offset: 0x00095284
		// (set) Token: 0x06004F6B RID: 20331 RVA: 0x000970A4 File Offset: 0x000952A4
		[XmlIgnore]
		[Browsable(false)]
		public bool endtimeSpecified
		{
			get
			{
				return this._endtime != null;
			}
			set
			{
				bool flag = value == (this._endtime == null);
				if (flag)
				{
					this._endtime = (value ? new uint?(this.endtime) : null);
				}
			}
		}

		// Token: 0x06004F6C RID: 20332 RVA: 0x000970E8 File Offset: 0x000952E8
		private bool ShouldSerializeendtime()
		{
			return this.endtimeSpecified;
		}

		// Token: 0x06004F6D RID: 20333 RVA: 0x00097100 File Offset: 0x00095300
		private void Resetendtime()
		{
			this.endtimeSpecified = false;
		}

		// Token: 0x06004F6E RID: 20334 RVA: 0x0009710C File Offset: 0x0009530C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001396 RID: 5014
		private string _reason;

		// Token: 0x04001397 RID: 5015
		private uint? _endtime;

		// Token: 0x04001398 RID: 5016
		private IExtension extensionObject;
	}
}
