using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000505 RID: 1285
	[ProtoContract(Name = "UpdateFreeflowHintInfo")]
	[Serializable]
	public class UpdateFreeflowHintInfo : IExtensible
	{
		// Token: 0x1700144C RID: 5196
		// (get) Token: 0x06004253 RID: 16979 RVA: 0x0007E424 File Offset: 0x0007C624
		// (set) Token: 0x06004254 RID: 16980 RVA: 0x0007E450 File Offset: 0x0007C650
		[ProtoMember(1, IsRequired = false, Name = "hint_time", DataFormat = DataFormat.TwosComplement)]
		public uint hint_time
		{
			get
			{
				return this._hint_time ?? 0U;
			}
			set
			{
				this._hint_time = new uint?(value);
			}
		}

		// Token: 0x1700144D RID: 5197
		// (get) Token: 0x06004255 RID: 16981 RVA: 0x0007E460 File Offset: 0x0007C660
		// (set) Token: 0x06004256 RID: 16982 RVA: 0x0007E480 File Offset: 0x0007C680
		[XmlIgnore]
		[Browsable(false)]
		public bool hint_timeSpecified
		{
			get
			{
				return this._hint_time != null;
			}
			set
			{
				bool flag = value == (this._hint_time == null);
				if (flag)
				{
					this._hint_time = (value ? new uint?(this.hint_time) : null);
				}
			}
		}

		// Token: 0x06004257 RID: 16983 RVA: 0x0007E4C4 File Offset: 0x0007C6C4
		private bool ShouldSerializehint_time()
		{
			return this.hint_timeSpecified;
		}

		// Token: 0x06004258 RID: 16984 RVA: 0x0007E4DC File Offset: 0x0007C6DC
		private void Resethint_time()
		{
			this.hint_timeSpecified = false;
		}

		// Token: 0x06004259 RID: 16985 RVA: 0x0007E4E8 File Offset: 0x0007C6E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400108A RID: 4234
		private uint? _hint_time;

		// Token: 0x0400108B RID: 4235
		private IExtension extensionObject;
	}
}
