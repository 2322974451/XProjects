using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200069C RID: 1692
	[ProtoContract(Name = "PayAileen")]
	[Serializable]
	public class PayAileen : IExtensible
	{
		// Token: 0x170022D5 RID: 8917
		// (get) Token: 0x06006E0F RID: 28175 RVA: 0x000D2994 File Offset: 0x000D0B94
		// (set) Token: 0x06006E10 RID: 28176 RVA: 0x000D29C0 File Offset: 0x000D0BC0
		[ProtoMember(1, IsRequired = false, Name = "remainedTime", DataFormat = DataFormat.TwosComplement)]
		public uint remainedTime
		{
			get
			{
				return this._remainedTime ?? 0U;
			}
			set
			{
				this._remainedTime = new uint?(value);
			}
		}

		// Token: 0x170022D6 RID: 8918
		// (get) Token: 0x06006E11 RID: 28177 RVA: 0x000D29D0 File Offset: 0x000D0BD0
		// (set) Token: 0x06006E12 RID: 28178 RVA: 0x000D29F0 File Offset: 0x000D0BF0
		[XmlIgnore]
		[Browsable(false)]
		public bool remainedTimeSpecified
		{
			get
			{
				return this._remainedTime != null;
			}
			set
			{
				bool flag = value == (this._remainedTime == null);
				if (flag)
				{
					this._remainedTime = (value ? new uint?(this.remainedTime) : null);
				}
			}
		}

		// Token: 0x06006E13 RID: 28179 RVA: 0x000D2A34 File Offset: 0x000D0C34
		private bool ShouldSerializeremainedTime()
		{
			return this.remainedTimeSpecified;
		}

		// Token: 0x06006E14 RID: 28180 RVA: 0x000D2A4C File Offset: 0x000D0C4C
		private void ResetremainedTime()
		{
			this.remainedTimeSpecified = false;
		}

		// Token: 0x170022D7 RID: 8919
		// (get) Token: 0x06006E15 RID: 28181 RVA: 0x000D2A58 File Offset: 0x000D0C58
		[ProtoMember(2, Name = "AileenInfo", DataFormat = DataFormat.Default)]
		public List<PayAileenInfo> AileenInfo
		{
			get
			{
				return this._AileenInfo;
			}
		}

		// Token: 0x170022D8 RID: 8920
		// (get) Token: 0x06006E16 RID: 28182 RVA: 0x000D2A70 File Offset: 0x000D0C70
		// (set) Token: 0x06006E17 RID: 28183 RVA: 0x000D2A9C File Offset: 0x000D0C9C
		[ProtoMember(3, IsRequired = false, Name = "weekDays", DataFormat = DataFormat.TwosComplement)]
		public uint weekDays
		{
			get
			{
				return this._weekDays ?? 0U;
			}
			set
			{
				this._weekDays = new uint?(value);
			}
		}

		// Token: 0x170022D9 RID: 8921
		// (get) Token: 0x06006E18 RID: 28184 RVA: 0x000D2AAC File Offset: 0x000D0CAC
		// (set) Token: 0x06006E19 RID: 28185 RVA: 0x000D2ACC File Offset: 0x000D0CCC
		[XmlIgnore]
		[Browsable(false)]
		public bool weekDaysSpecified
		{
			get
			{
				return this._weekDays != null;
			}
			set
			{
				bool flag = value == (this._weekDays == null);
				if (flag)
				{
					this._weekDays = (value ? new uint?(this.weekDays) : null);
				}
			}
		}

		// Token: 0x06006E1A RID: 28186 RVA: 0x000D2B10 File Offset: 0x000D0D10
		private bool ShouldSerializeweekDays()
		{
			return this.weekDaysSpecified;
		}

		// Token: 0x06006E1B RID: 28187 RVA: 0x000D2B28 File Offset: 0x000D0D28
		private void ResetweekDays()
		{
			this.weekDaysSpecified = false;
		}

		// Token: 0x06006E1C RID: 28188 RVA: 0x000D2B34 File Offset: 0x000D0D34
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A5A RID: 6746
		private uint? _remainedTime;

		// Token: 0x04001A5B RID: 6747
		private readonly List<PayAileenInfo> _AileenInfo = new List<PayAileenInfo>();

		// Token: 0x04001A5C RID: 6748
		private uint? _weekDays;

		// Token: 0x04001A5D RID: 6749
		private IExtension extensionObject;
	}
}
