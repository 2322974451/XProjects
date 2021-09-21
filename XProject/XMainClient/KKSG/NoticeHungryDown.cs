using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001DA RID: 474
	[ProtoContract(Name = "NoticeHungryDown")]
	[Serializable]
	public class NoticeHungryDown : IExtensible
	{
		// Token: 0x1700089E RID: 2206
		// (get) Token: 0x06001B6A RID: 7018 RVA: 0x000362A0 File Offset: 0x000344A0
		// (set) Token: 0x06001B6B RID: 7019 RVA: 0x000362CD File Offset: 0x000344CD
		[ProtoMember(1, IsRequired = false, Name = "petid", DataFormat = DataFormat.TwosComplement)]
		public ulong petid
		{
			get
			{
				return this._petid ?? 0UL;
			}
			set
			{
				this._petid = new ulong?(value);
			}
		}

		// Token: 0x1700089F RID: 2207
		// (get) Token: 0x06001B6C RID: 7020 RVA: 0x000362DC File Offset: 0x000344DC
		// (set) Token: 0x06001B6D RID: 7021 RVA: 0x000362FC File Offset: 0x000344FC
		[XmlIgnore]
		[Browsable(false)]
		public bool petidSpecified
		{
			get
			{
				return this._petid != null;
			}
			set
			{
				bool flag = value == (this._petid == null);
				if (flag)
				{
					this._petid = (value ? new ulong?(this.petid) : null);
				}
			}
		}

		// Token: 0x06001B6E RID: 7022 RVA: 0x00036340 File Offset: 0x00034540
		private bool ShouldSerializepetid()
		{
			return this.petidSpecified;
		}

		// Token: 0x06001B6F RID: 7023 RVA: 0x00036358 File Offset: 0x00034558
		private void Resetpetid()
		{
			this.petidSpecified = false;
		}

		// Token: 0x170008A0 RID: 2208
		// (get) Token: 0x06001B70 RID: 7024 RVA: 0x00036364 File Offset: 0x00034564
		// (set) Token: 0x06001B71 RID: 7025 RVA: 0x00036390 File Offset: 0x00034590
		[ProtoMember(2, IsRequired = false, Name = "hungry", DataFormat = DataFormat.TwosComplement)]
		public uint hungry
		{
			get
			{
				return this._hungry ?? 0U;
			}
			set
			{
				this._hungry = new uint?(value);
			}
		}

		// Token: 0x170008A1 RID: 2209
		// (get) Token: 0x06001B72 RID: 7026 RVA: 0x000363A0 File Offset: 0x000345A0
		// (set) Token: 0x06001B73 RID: 7027 RVA: 0x000363C0 File Offset: 0x000345C0
		[XmlIgnore]
		[Browsable(false)]
		public bool hungrySpecified
		{
			get
			{
				return this._hungry != null;
			}
			set
			{
				bool flag = value == (this._hungry == null);
				if (flag)
				{
					this._hungry = (value ? new uint?(this.hungry) : null);
				}
			}
		}

		// Token: 0x06001B74 RID: 7028 RVA: 0x00036404 File Offset: 0x00034604
		private bool ShouldSerializehungry()
		{
			return this.hungrySpecified;
		}

		// Token: 0x06001B75 RID: 7029 RVA: 0x0003641C File Offset: 0x0003461C
		private void Resethungry()
		{
			this.hungrySpecified = false;
		}

		// Token: 0x06001B76 RID: 7030 RVA: 0x00036428 File Offset: 0x00034628
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006D4 RID: 1748
		private ulong? _petid;

		// Token: 0x040006D5 RID: 1749
		private uint? _hungry;

		// Token: 0x040006D6 RID: 1750
		private IExtension extensionObject;
	}
}
