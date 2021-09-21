using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200034B RID: 843
	[ProtoContract(Name = "HeroBattleOverTimeData")]
	[Serializable]
	public class HeroBattleOverTimeData : IExtensible
	{
		// Token: 0x17000E46 RID: 3654
		// (get) Token: 0x06002E04 RID: 11780 RVA: 0x0005900C File Offset: 0x0005720C
		// (set) Token: 0x06002E05 RID: 11781 RVA: 0x00059039 File Offset: 0x00057239
		[ProtoMember(1, IsRequired = false, Name = "millisecond", DataFormat = DataFormat.TwosComplement)]
		public ulong millisecond
		{
			get
			{
				return this._millisecond ?? 0UL;
			}
			set
			{
				this._millisecond = new ulong?(value);
			}
		}

		// Token: 0x17000E47 RID: 3655
		// (get) Token: 0x06002E06 RID: 11782 RVA: 0x00059048 File Offset: 0x00057248
		// (set) Token: 0x06002E07 RID: 11783 RVA: 0x00059068 File Offset: 0x00057268
		[XmlIgnore]
		[Browsable(false)]
		public bool millisecondSpecified
		{
			get
			{
				return this._millisecond != null;
			}
			set
			{
				bool flag = value == (this._millisecond == null);
				if (flag)
				{
					this._millisecond = (value ? new ulong?(this.millisecond) : null);
				}
			}
		}

		// Token: 0x06002E08 RID: 11784 RVA: 0x000590AC File Offset: 0x000572AC
		private bool ShouldSerializemillisecond()
		{
			return this.millisecondSpecified;
		}

		// Token: 0x06002E09 RID: 11785 RVA: 0x000590C4 File Offset: 0x000572C4
		private void Resetmillisecond()
		{
			this.millisecondSpecified = false;
		}

		// Token: 0x06002E0A RID: 11786 RVA: 0x000590D0 File Offset: 0x000572D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B72 RID: 2930
		private ulong? _millisecond;

		// Token: 0x04000B73 RID: 2931
		private IExtension extensionObject;
	}
}
