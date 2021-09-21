using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000095 RID: 149
	[ProtoContract(Name = "MyGuild")]
	[Serializable]
	public class MyGuild : IExtensible
	{
		// Token: 0x1700033B RID: 827
		// (get) Token: 0x060009D3 RID: 2515 RVA: 0x00015570 File Offset: 0x00013770
		// (set) Token: 0x060009D4 RID: 2516 RVA: 0x0001559D File Offset: 0x0001379D
		[ProtoMember(1, IsRequired = false, Name = "gid", DataFormat = DataFormat.TwosComplement)]
		public ulong gid
		{
			get
			{
				return this._gid ?? 0UL;
			}
			set
			{
				this._gid = new ulong?(value);
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x060009D5 RID: 2517 RVA: 0x000155AC File Offset: 0x000137AC
		// (set) Token: 0x060009D6 RID: 2518 RVA: 0x000155CC File Offset: 0x000137CC
		[XmlIgnore]
		[Browsable(false)]
		public bool gidSpecified
		{
			get
			{
				return this._gid != null;
			}
			set
			{
				bool flag = value == (this._gid == null);
				if (flag)
				{
					this._gid = (value ? new ulong?(this.gid) : null);
				}
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x00015610 File Offset: 0x00013810
		private bool ShouldSerializegid()
		{
			return this.gidSpecified;
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00015628 File Offset: 0x00013828
		private void Resetgid()
		{
			this.gidSpecified = false;
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x00015634 File Offset: 0x00013834
		// (set) Token: 0x060009DA RID: 2522 RVA: 0x00015660 File Offset: 0x00013860
		[ProtoMember(2, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public int position
		{
			get
			{
				return this._position ?? 0;
			}
			set
			{
				this._position = new int?(value);
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x060009DB RID: 2523 RVA: 0x00015670 File Offset: 0x00013870
		// (set) Token: 0x060009DC RID: 2524 RVA: 0x00015690 File Offset: 0x00013890
		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new int?(this.position) : null);
				}
			}
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x000156D4 File Offset: 0x000138D4
		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x000156EC File Offset: 0x000138EC
		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x060009DF RID: 2527 RVA: 0x000156F8 File Offset: 0x000138F8
		// (set) Token: 0x060009E0 RID: 2528 RVA: 0x00015724 File Offset: 0x00013924
		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x060009E1 RID: 2529 RVA: 0x00015734 File Offset: 0x00013934
		// (set) Token: 0x060009E2 RID: 2530 RVA: 0x00015754 File Offset: 0x00013954
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x00015798 File Offset: 0x00013998
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x000157B0 File Offset: 0x000139B0
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x000157BC File Offset: 0x000139BC
		// (set) Token: 0x060009E6 RID: 2534 RVA: 0x000157E8 File Offset: 0x000139E8
		[ProtoMember(4, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public uint icon
		{
			get
			{
				return this._icon ?? 0U;
			}
			set
			{
				this._icon = new uint?(value);
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x060009E7 RID: 2535 RVA: 0x000157F8 File Offset: 0x000139F8
		// (set) Token: 0x060009E8 RID: 2536 RVA: 0x00015818 File Offset: 0x00013A18
		[XmlIgnore]
		[Browsable(false)]
		public bool iconSpecified
		{
			get
			{
				return this._icon != null;
			}
			set
			{
				bool flag = value == (this._icon == null);
				if (flag)
				{
					this._icon = (value ? new uint?(this.icon) : null);
				}
			}
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0001585C File Offset: 0x00013A5C
		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x00015874 File Offset: 0x00013A74
		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x060009EB RID: 2539 RVA: 0x00015880 File Offset: 0x00013A80
		// (set) Token: 0x060009EC RID: 2540 RVA: 0x000158A1 File Offset: 0x00013AA1
		[ProtoMember(5, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x060009ED RID: 2541 RVA: 0x000158AC File Offset: 0x00013AAC
		// (set) Token: 0x060009EE RID: 2542 RVA: 0x000158C8 File Offset: 0x00013AC8
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x000158F8 File Offset: 0x00013AF8
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x00015910 File Offset: 0x00013B10
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0001591C File Offset: 0x00013B1C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000287 RID: 647
		private ulong? _gid;

		// Token: 0x04000288 RID: 648
		private int? _position;

		// Token: 0x04000289 RID: 649
		private int? _level;

		// Token: 0x0400028A RID: 650
		private uint? _icon;

		// Token: 0x0400028B RID: 651
		private string _name;

		// Token: 0x0400028C RID: 652
		private IExtension extensionObject;
	}
}
