using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000448 RID: 1096
	[ProtoContract(Name = "BuySpriteEggRes")]
	[Serializable]
	public class BuySpriteEggRes : IExtensible
	{
		// Token: 0x170011B7 RID: 4535
		// (get) Token: 0x060039BF RID: 14783 RVA: 0x0006E758 File Offset: 0x0006C958
		// (set) Token: 0x060039C0 RID: 14784 RVA: 0x0006E784 File Offset: 0x0006C984
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

		// Token: 0x170011B8 RID: 4536
		// (get) Token: 0x060039C1 RID: 14785 RVA: 0x0006E794 File Offset: 0x0006C994
		// (set) Token: 0x060039C2 RID: 14786 RVA: 0x0006E7B4 File Offset: 0x0006C9B4
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

		// Token: 0x060039C3 RID: 14787 RVA: 0x0006E7F8 File Offset: 0x0006C9F8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060039C4 RID: 14788 RVA: 0x0006E810 File Offset: 0x0006CA10
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170011B9 RID: 4537
		// (get) Token: 0x060039C5 RID: 14789 RVA: 0x0006E81C File Offset: 0x0006CA1C
		[ProtoMember(2, Name = "item", DataFormat = DataFormat.Default)]
		public List<ItemBrief> item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x170011BA RID: 4538
		// (get) Token: 0x060039C6 RID: 14790 RVA: 0x0006E834 File Offset: 0x0006CA34
		// (set) Token: 0x060039C7 RID: 14791 RVA: 0x0006E860 File Offset: 0x0006CA60
		[ProtoMember(3, IsRequired = false, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
		public uint cooldown
		{
			get
			{
				return this._cooldown ?? 0U;
			}
			set
			{
				this._cooldown = new uint?(value);
			}
		}

		// Token: 0x170011BB RID: 4539
		// (get) Token: 0x060039C8 RID: 14792 RVA: 0x0006E870 File Offset: 0x0006CA70
		// (set) Token: 0x060039C9 RID: 14793 RVA: 0x0006E890 File Offset: 0x0006CA90
		[XmlIgnore]
		[Browsable(false)]
		public bool cooldownSpecified
		{
			get
			{
				return this._cooldown != null;
			}
			set
			{
				bool flag = value == (this._cooldown == null);
				if (flag)
				{
					this._cooldown = (value ? new uint?(this.cooldown) : null);
				}
			}
		}

		// Token: 0x060039CA RID: 14794 RVA: 0x0006E8D4 File Offset: 0x0006CAD4
		private bool ShouldSerializecooldown()
		{
			return this.cooldownSpecified;
		}

		// Token: 0x060039CB RID: 14795 RVA: 0x0006E8EC File Offset: 0x0006CAEC
		private void Resetcooldown()
		{
			this.cooldownSpecified = false;
		}

		// Token: 0x170011BC RID: 4540
		// (get) Token: 0x060039CC RID: 14796 RVA: 0x0006E8F8 File Offset: 0x0006CAF8
		// (set) Token: 0x060039CD RID: 14797 RVA: 0x0006E924 File Offset: 0x0006CB24
		[ProtoMember(4, IsRequired = false, Name = "goldfreebuycount", DataFormat = DataFormat.TwosComplement)]
		public uint goldfreebuycount
		{
			get
			{
				return this._goldfreebuycount ?? 0U;
			}
			set
			{
				this._goldfreebuycount = new uint?(value);
			}
		}

		// Token: 0x170011BD RID: 4541
		// (get) Token: 0x060039CE RID: 14798 RVA: 0x0006E934 File Offset: 0x0006CB34
		// (set) Token: 0x060039CF RID: 14799 RVA: 0x0006E954 File Offset: 0x0006CB54
		[XmlIgnore]
		[Browsable(false)]
		public bool goldfreebuycountSpecified
		{
			get
			{
				return this._goldfreebuycount != null;
			}
			set
			{
				bool flag = value == (this._goldfreebuycount == null);
				if (flag)
				{
					this._goldfreebuycount = (value ? new uint?(this.goldfreebuycount) : null);
				}
			}
		}

		// Token: 0x060039D0 RID: 14800 RVA: 0x0006E998 File Offset: 0x0006CB98
		private bool ShouldSerializegoldfreebuycount()
		{
			return this.goldfreebuycountSpecified;
		}

		// Token: 0x060039D1 RID: 14801 RVA: 0x0006E9B0 File Offset: 0x0006CBB0
		private void Resetgoldfreebuycount()
		{
			this.goldfreebuycountSpecified = false;
		}

		// Token: 0x170011BE RID: 4542
		// (get) Token: 0x060039D2 RID: 14802 RVA: 0x0006E9BC File Offset: 0x0006CBBC
		// (set) Token: 0x060039D3 RID: 14803 RVA: 0x0006E9E8 File Offset: 0x0006CBE8
		[ProtoMember(5, IsRequired = false, Name = "goldfreebuycooldown", DataFormat = DataFormat.TwosComplement)]
		public uint goldfreebuycooldown
		{
			get
			{
				return this._goldfreebuycooldown ?? 0U;
			}
			set
			{
				this._goldfreebuycooldown = new uint?(value);
			}
		}

		// Token: 0x170011BF RID: 4543
		// (get) Token: 0x060039D4 RID: 14804 RVA: 0x0006E9F8 File Offset: 0x0006CBF8
		// (set) Token: 0x060039D5 RID: 14805 RVA: 0x0006EA18 File Offset: 0x0006CC18
		[XmlIgnore]
		[Browsable(false)]
		public bool goldfreebuycooldownSpecified
		{
			get
			{
				return this._goldfreebuycooldown != null;
			}
			set
			{
				bool flag = value == (this._goldfreebuycooldown == null);
				if (flag)
				{
					this._goldfreebuycooldown = (value ? new uint?(this.goldfreebuycooldown) : null);
				}
			}
		}

		// Token: 0x060039D6 RID: 14806 RVA: 0x0006EA5C File Offset: 0x0006CC5C
		private bool ShouldSerializegoldfreebuycooldown()
		{
			return this.goldfreebuycooldownSpecified;
		}

		// Token: 0x060039D7 RID: 14807 RVA: 0x0006EA74 File Offset: 0x0006CC74
		private void Resetgoldfreebuycooldown()
		{
			this.goldfreebuycooldownSpecified = false;
		}

		// Token: 0x060039D8 RID: 14808 RVA: 0x0006EA80 File Offset: 0x0006CC80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E54 RID: 3668
		private ErrorCode? _errorcode;

		// Token: 0x04000E55 RID: 3669
		private readonly List<ItemBrief> _item = new List<ItemBrief>();

		// Token: 0x04000E56 RID: 3670
		private uint? _cooldown;

		// Token: 0x04000E57 RID: 3671
		private uint? _goldfreebuycount;

		// Token: 0x04000E58 RID: 3672
		private uint? _goldfreebuycooldown;

		// Token: 0x04000E59 RID: 3673
		private IExtension extensionObject;
	}
}
