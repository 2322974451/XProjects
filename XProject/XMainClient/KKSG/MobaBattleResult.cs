using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005CC RID: 1484
	[ProtoContract(Name = "MobaBattleResult")]
	[Serializable]
	public class MobaBattleResult : IExtensible
	{
		// Token: 0x170019EF RID: 6639
		// (get) Token: 0x060053C6 RID: 21446 RVA: 0x0009F5C4 File Offset: 0x0009D7C4
		// (set) Token: 0x060053C7 RID: 21447 RVA: 0x0009F5F1 File Offset: 0x0009D7F1
		[ProtoMember(1, IsRequired = false, Name = "mvpid", DataFormat = DataFormat.TwosComplement)]
		public ulong mvpid
		{
			get
			{
				return this._mvpid ?? 0UL;
			}
			set
			{
				this._mvpid = new ulong?(value);
			}
		}

		// Token: 0x170019F0 RID: 6640
		// (get) Token: 0x060053C8 RID: 21448 RVA: 0x0009F600 File Offset: 0x0009D800
		// (set) Token: 0x060053C9 RID: 21449 RVA: 0x0009F620 File Offset: 0x0009D820
		[XmlIgnore]
		[Browsable(false)]
		public bool mvpidSpecified
		{
			get
			{
				return this._mvpid != null;
			}
			set
			{
				bool flag = value == (this._mvpid == null);
				if (flag)
				{
					this._mvpid = (value ? new ulong?(this.mvpid) : null);
				}
			}
		}

		// Token: 0x060053CA RID: 21450 RVA: 0x0009F664 File Offset: 0x0009D864
		private bool ShouldSerializemvpid()
		{
			return this.mvpidSpecified;
		}

		// Token: 0x060053CB RID: 21451 RVA: 0x0009F67C File Offset: 0x0009D87C
		private void Resetmvpid()
		{
			this.mvpidSpecified = false;
		}

		// Token: 0x170019F1 RID: 6641
		// (get) Token: 0x060053CC RID: 21452 RVA: 0x0009F688 File Offset: 0x0009D888
		// (set) Token: 0x060053CD RID: 21453 RVA: 0x0009F6B5 File Offset: 0x0009D8B5
		[ProtoMember(2, IsRequired = false, Name = "losemvpid", DataFormat = DataFormat.TwosComplement)]
		public ulong losemvpid
		{
			get
			{
				return this._losemvpid ?? 0UL;
			}
			set
			{
				this._losemvpid = new ulong?(value);
			}
		}

		// Token: 0x170019F2 RID: 6642
		// (get) Token: 0x060053CE RID: 21454 RVA: 0x0009F6C4 File Offset: 0x0009D8C4
		// (set) Token: 0x060053CF RID: 21455 RVA: 0x0009F6E4 File Offset: 0x0009D8E4
		[XmlIgnore]
		[Browsable(false)]
		public bool losemvpidSpecified
		{
			get
			{
				return this._losemvpid != null;
			}
			set
			{
				bool flag = value == (this._losemvpid == null);
				if (flag)
				{
					this._losemvpid = (value ? new ulong?(this.losemvpid) : null);
				}
			}
		}

		// Token: 0x060053D0 RID: 21456 RVA: 0x0009F728 File Offset: 0x0009D928
		private bool ShouldSerializelosemvpid()
		{
			return this.losemvpidSpecified;
		}

		// Token: 0x060053D1 RID: 21457 RVA: 0x0009F740 File Offset: 0x0009D940
		private void Resetlosemvpid()
		{
			this.losemvpidSpecified = false;
		}

		// Token: 0x170019F3 RID: 6643
		// (get) Token: 0x060053D2 RID: 21458 RVA: 0x0009F74C File Offset: 0x0009D94C
		// (set) Token: 0x060053D3 RID: 21459 RVA: 0x0009F779 File Offset: 0x0009D979
		[ProtoMember(3, IsRequired = false, Name = "damagemaxid", DataFormat = DataFormat.TwosComplement)]
		public ulong damagemaxid
		{
			get
			{
				return this._damagemaxid ?? 0UL;
			}
			set
			{
				this._damagemaxid = new ulong?(value);
			}
		}

		// Token: 0x170019F4 RID: 6644
		// (get) Token: 0x060053D4 RID: 21460 RVA: 0x0009F788 File Offset: 0x0009D988
		// (set) Token: 0x060053D5 RID: 21461 RVA: 0x0009F7A8 File Offset: 0x0009D9A8
		[XmlIgnore]
		[Browsable(false)]
		public bool damagemaxidSpecified
		{
			get
			{
				return this._damagemaxid != null;
			}
			set
			{
				bool flag = value == (this._damagemaxid == null);
				if (flag)
				{
					this._damagemaxid = (value ? new ulong?(this.damagemaxid) : null);
				}
			}
		}

		// Token: 0x060053D6 RID: 21462 RVA: 0x0009F7EC File Offset: 0x0009D9EC
		private bool ShouldSerializedamagemaxid()
		{
			return this.damagemaxidSpecified;
		}

		// Token: 0x060053D7 RID: 21463 RVA: 0x0009F804 File Offset: 0x0009DA04
		private void Resetdamagemaxid()
		{
			this.damagemaxidSpecified = false;
		}

		// Token: 0x170019F5 RID: 6645
		// (get) Token: 0x060053D8 RID: 21464 RVA: 0x0009F810 File Offset: 0x0009DA10
		// (set) Token: 0x060053D9 RID: 21465 RVA: 0x0009F83D File Offset: 0x0009DA3D
		[ProtoMember(4, IsRequired = false, Name = "behitdamagemaxid", DataFormat = DataFormat.TwosComplement)]
		public ulong behitdamagemaxid
		{
			get
			{
				return this._behitdamagemaxid ?? 0UL;
			}
			set
			{
				this._behitdamagemaxid = new ulong?(value);
			}
		}

		// Token: 0x170019F6 RID: 6646
		// (get) Token: 0x060053DA RID: 21466 RVA: 0x0009F84C File Offset: 0x0009DA4C
		// (set) Token: 0x060053DB RID: 21467 RVA: 0x0009F86C File Offset: 0x0009DA6C
		[XmlIgnore]
		[Browsable(false)]
		public bool behitdamagemaxidSpecified
		{
			get
			{
				return this._behitdamagemaxid != null;
			}
			set
			{
				bool flag = value == (this._behitdamagemaxid == null);
				if (flag)
				{
					this._behitdamagemaxid = (value ? new ulong?(this.behitdamagemaxid) : null);
				}
			}
		}

		// Token: 0x060053DC RID: 21468 RVA: 0x0009F8B0 File Offset: 0x0009DAB0
		private bool ShouldSerializebehitdamagemaxid()
		{
			return this.behitdamagemaxidSpecified;
		}

		// Token: 0x060053DD RID: 21469 RVA: 0x0009F8C8 File Offset: 0x0009DAC8
		private void Resetbehitdamagemaxid()
		{
			this.behitdamagemaxidSpecified = false;
		}

		// Token: 0x060053DE RID: 21470 RVA: 0x0009F8D4 File Offset: 0x0009DAD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001474 RID: 5236
		private ulong? _mvpid;

		// Token: 0x04001475 RID: 5237
		private ulong? _losemvpid;

		// Token: 0x04001476 RID: 5238
		private ulong? _damagemaxid;

		// Token: 0x04001477 RID: 5239
		private ulong? _behitdamagemaxid;

		// Token: 0x04001478 RID: 5240
		private IExtension extensionObject;
	}
}
