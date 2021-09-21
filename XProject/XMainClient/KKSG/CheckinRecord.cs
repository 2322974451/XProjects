using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005F7 RID: 1527
	[ProtoContract(Name = "CheckinRecord")]
	[Serializable]
	public class CheckinRecord : IExtensible
	{
		// Token: 0x17001C67 RID: 7271
		// (get) Token: 0x06005ADA RID: 23258 RVA: 0x000ACFB8 File Offset: 0x000AB1B8
		// (set) Token: 0x06005ADB RID: 23259 RVA: 0x000ACFE4 File Offset: 0x000AB1E4
		[ProtoMember(1, IsRequired = false, Name = "CheckinInfo", DataFormat = DataFormat.TwosComplement)]
		public uint CheckinInfo
		{
			get
			{
				return this._CheckinInfo ?? 0U;
			}
			set
			{
				this._CheckinInfo = new uint?(value);
			}
		}

		// Token: 0x17001C68 RID: 7272
		// (get) Token: 0x06005ADC RID: 23260 RVA: 0x000ACFF4 File Offset: 0x000AB1F4
		// (set) Token: 0x06005ADD RID: 23261 RVA: 0x000AD014 File Offset: 0x000AB214
		[XmlIgnore]
		[Browsable(false)]
		public bool CheckinInfoSpecified
		{
			get
			{
				return this._CheckinInfo != null;
			}
			set
			{
				bool flag = value == (this._CheckinInfo == null);
				if (flag)
				{
					this._CheckinInfo = (value ? new uint?(this.CheckinInfo) : null);
				}
			}
		}

		// Token: 0x06005ADE RID: 23262 RVA: 0x000AD058 File Offset: 0x000AB258
		private bool ShouldSerializeCheckinInfo()
		{
			return this.CheckinInfoSpecified;
		}

		// Token: 0x06005ADF RID: 23263 RVA: 0x000AD070 File Offset: 0x000AB270
		private void ResetCheckinInfo()
		{
			this.CheckinInfoSpecified = false;
		}

		// Token: 0x17001C69 RID: 7273
		// (get) Token: 0x06005AE0 RID: 23264 RVA: 0x000AD07C File Offset: 0x000AB27C
		// (set) Token: 0x06005AE1 RID: 23265 RVA: 0x000AD0A8 File Offset: 0x000AB2A8
		[ProtoMember(2, IsRequired = false, Name = "CheckinTime", DataFormat = DataFormat.TwosComplement)]
		public uint CheckinTime
		{
			get
			{
				return this._CheckinTime ?? 0U;
			}
			set
			{
				this._CheckinTime = new uint?(value);
			}
		}

		// Token: 0x17001C6A RID: 7274
		// (get) Token: 0x06005AE2 RID: 23266 RVA: 0x000AD0B8 File Offset: 0x000AB2B8
		// (set) Token: 0x06005AE3 RID: 23267 RVA: 0x000AD0D8 File Offset: 0x000AB2D8
		[XmlIgnore]
		[Browsable(false)]
		public bool CheckinTimeSpecified
		{
			get
			{
				return this._CheckinTime != null;
			}
			set
			{
				bool flag = value == (this._CheckinTime == null);
				if (flag)
				{
					this._CheckinTime = (value ? new uint?(this.CheckinTime) : null);
				}
			}
		}

		// Token: 0x06005AE4 RID: 23268 RVA: 0x000AD11C File Offset: 0x000AB31C
		private bool ShouldSerializeCheckinTime()
		{
			return this.CheckinTimeSpecified;
		}

		// Token: 0x06005AE5 RID: 23269 RVA: 0x000AD134 File Offset: 0x000AB334
		private void ResetCheckinTime()
		{
			this.CheckinTimeSpecified = false;
		}

		// Token: 0x17001C6B RID: 7275
		// (get) Token: 0x06005AE6 RID: 23270 RVA: 0x000AD140 File Offset: 0x000AB340
		// (set) Token: 0x06005AE7 RID: 23271 RVA: 0x000AD16C File Offset: 0x000AB36C
		[ProtoMember(3, IsRequired = false, Name = "CheckinCount", DataFormat = DataFormat.TwosComplement)]
		public uint CheckinCount
		{
			get
			{
				return this._CheckinCount ?? 0U;
			}
			set
			{
				this._CheckinCount = new uint?(value);
			}
		}

		// Token: 0x17001C6C RID: 7276
		// (get) Token: 0x06005AE8 RID: 23272 RVA: 0x000AD17C File Offset: 0x000AB37C
		// (set) Token: 0x06005AE9 RID: 23273 RVA: 0x000AD19C File Offset: 0x000AB39C
		[XmlIgnore]
		[Browsable(false)]
		public bool CheckinCountSpecified
		{
			get
			{
				return this._CheckinCount != null;
			}
			set
			{
				bool flag = value == (this._CheckinCount == null);
				if (flag)
				{
					this._CheckinCount = (value ? new uint?(this.CheckinCount) : null);
				}
			}
		}

		// Token: 0x06005AEA RID: 23274 RVA: 0x000AD1E0 File Offset: 0x000AB3E0
		private bool ShouldSerializeCheckinCount()
		{
			return this.CheckinCountSpecified;
		}

		// Token: 0x06005AEB RID: 23275 RVA: 0x000AD1F8 File Offset: 0x000AB3F8
		private void ResetCheckinCount()
		{
			this.CheckinCountSpecified = false;
		}

		// Token: 0x06005AEC RID: 23276 RVA: 0x000AD204 File Offset: 0x000AB404
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400161A RID: 5658
		private uint? _CheckinInfo;

		// Token: 0x0400161B RID: 5659
		private uint? _CheckinTime;

		// Token: 0x0400161C RID: 5660
		private uint? _CheckinCount;

		// Token: 0x0400161D RID: 5661
		private IExtension extensionObject;
	}
}
