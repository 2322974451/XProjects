using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200023A RID: 570
	[ProtoContract(Name = "SkyCityTimeInfo")]
	[Serializable]
	public class SkyCityTimeInfo : IExtensible
	{
		// Token: 0x170009E1 RID: 2529
		// (get) Token: 0x06001FAE RID: 8110 RVA: 0x0003E190 File Offset: 0x0003C390
		// (set) Token: 0x06001FAF RID: 8111 RVA: 0x0003E1BC File Offset: 0x0003C3BC
		[ProtoMember(1, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170009E2 RID: 2530
		// (get) Token: 0x06001FB0 RID: 8112 RVA: 0x0003E1CC File Offset: 0x0003C3CC
		// (set) Token: 0x06001FB1 RID: 8113 RVA: 0x0003E1EC File Offset: 0x0003C3EC
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

		// Token: 0x06001FB2 RID: 8114 RVA: 0x0003E230 File Offset: 0x0003C430
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06001FB3 RID: 8115 RVA: 0x0003E248 File Offset: 0x0003C448
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170009E3 RID: 2531
		// (get) Token: 0x06001FB4 RID: 8116 RVA: 0x0003E254 File Offset: 0x0003C454
		// (set) Token: 0x06001FB5 RID: 8117 RVA: 0x0003E280 File Offset: 0x0003C480
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public SkyCityTimeType type
		{
			get
			{
				return this._type ?? SkyCityTimeType.Waiting;
			}
			set
			{
				this._type = new SkyCityTimeType?(value);
			}
		}

		// Token: 0x170009E4 RID: 2532
		// (get) Token: 0x06001FB6 RID: 8118 RVA: 0x0003E290 File Offset: 0x0003C490
		// (set) Token: 0x06001FB7 RID: 8119 RVA: 0x0003E2B0 File Offset: 0x0003C4B0
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new SkyCityTimeType?(this.type) : null);
				}
			}
		}

		// Token: 0x06001FB8 RID: 8120 RVA: 0x0003E2F4 File Offset: 0x0003C4F4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001FB9 RID: 8121 RVA: 0x0003E30C File Offset: 0x0003C50C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06001FBA RID: 8122 RVA: 0x0003E318 File Offset: 0x0003C518
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007E9 RID: 2025
		private uint? _time;

		// Token: 0x040007EA RID: 2026
		private SkyCityTimeType? _type;

		// Token: 0x040007EB RID: 2027
		private IExtension extensionObject;
	}
}
