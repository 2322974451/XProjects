using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200044A RID: 1098
	[ProtoContract(Name = "GetEnhanceAttrArg")]
	[Serializable]
	public class GetEnhanceAttrArg : IExtensible
	{
		// Token: 0x170011CA RID: 4554
		// (get) Token: 0x060039FA RID: 14842 RVA: 0x0006EE94 File Offset: 0x0006D094
		// (set) Token: 0x060039FB RID: 14843 RVA: 0x0006EEC0 File Offset: 0x0006D0C0
		[ProtoMember(1, IsRequired = false, Name = "prof", DataFormat = DataFormat.TwosComplement)]
		public uint prof
		{
			get
			{
				return this._prof ?? 0U;
			}
			set
			{
				this._prof = new uint?(value);
			}
		}

		// Token: 0x170011CB RID: 4555
		// (get) Token: 0x060039FC RID: 14844 RVA: 0x0006EED0 File Offset: 0x0006D0D0
		// (set) Token: 0x060039FD RID: 14845 RVA: 0x0006EEF0 File Offset: 0x0006D0F0
		[XmlIgnore]
		[Browsable(false)]
		public bool profSpecified
		{
			get
			{
				return this._prof != null;
			}
			set
			{
				bool flag = value == (this._prof == null);
				if (flag)
				{
					this._prof = (value ? new uint?(this.prof) : null);
				}
			}
		}

		// Token: 0x060039FE RID: 14846 RVA: 0x0006EF34 File Offset: 0x0006D134
		private bool ShouldSerializeprof()
		{
			return this.profSpecified;
		}

		// Token: 0x060039FF RID: 14847 RVA: 0x0006EF4C File Offset: 0x0006D14C
		private void Resetprof()
		{
			this.profSpecified = false;
		}

		// Token: 0x170011CC RID: 4556
		// (get) Token: 0x06003A00 RID: 14848 RVA: 0x0006EF58 File Offset: 0x0006D158
		// (set) Token: 0x06003A01 RID: 14849 RVA: 0x0006EF84 File Offset: 0x0006D184
		[ProtoMember(2, IsRequired = false, Name = "equippos", DataFormat = DataFormat.TwosComplement)]
		public uint equippos
		{
			get
			{
				return this._equippos ?? 0U;
			}
			set
			{
				this._equippos = new uint?(value);
			}
		}

		// Token: 0x170011CD RID: 4557
		// (get) Token: 0x06003A02 RID: 14850 RVA: 0x0006EF94 File Offset: 0x0006D194
		// (set) Token: 0x06003A03 RID: 14851 RVA: 0x0006EFB4 File Offset: 0x0006D1B4
		[XmlIgnore]
		[Browsable(false)]
		public bool equipposSpecified
		{
			get
			{
				return this._equippos != null;
			}
			set
			{
				bool flag = value == (this._equippos == null);
				if (flag)
				{
					this._equippos = (value ? new uint?(this.equippos) : null);
				}
			}
		}

		// Token: 0x06003A04 RID: 14852 RVA: 0x0006EFF8 File Offset: 0x0006D1F8
		private bool ShouldSerializeequippos()
		{
			return this.equipposSpecified;
		}

		// Token: 0x06003A05 RID: 14853 RVA: 0x0006F010 File Offset: 0x0006D210
		private void Resetequippos()
		{
			this.equipposSpecified = false;
		}

		// Token: 0x170011CE RID: 4558
		// (get) Token: 0x06003A06 RID: 14854 RVA: 0x0006F01C File Offset: 0x0006D21C
		// (set) Token: 0x06003A07 RID: 14855 RVA: 0x0006F048 File Offset: 0x0006D248
		[ProtoMember(3, IsRequired = false, Name = "enhancelevel", DataFormat = DataFormat.TwosComplement)]
		public uint enhancelevel
		{
			get
			{
				return this._enhancelevel ?? 0U;
			}
			set
			{
				this._enhancelevel = new uint?(value);
			}
		}

		// Token: 0x170011CF RID: 4559
		// (get) Token: 0x06003A08 RID: 14856 RVA: 0x0006F058 File Offset: 0x0006D258
		// (set) Token: 0x06003A09 RID: 14857 RVA: 0x0006F078 File Offset: 0x0006D278
		[XmlIgnore]
		[Browsable(false)]
		public bool enhancelevelSpecified
		{
			get
			{
				return this._enhancelevel != null;
			}
			set
			{
				bool flag = value == (this._enhancelevel == null);
				if (flag)
				{
					this._enhancelevel = (value ? new uint?(this.enhancelevel) : null);
				}
			}
		}

		// Token: 0x06003A0A RID: 14858 RVA: 0x0006F0BC File Offset: 0x0006D2BC
		private bool ShouldSerializeenhancelevel()
		{
			return this.enhancelevelSpecified;
		}

		// Token: 0x06003A0B RID: 14859 RVA: 0x0006F0D4 File Offset: 0x0006D2D4
		private void Resetenhancelevel()
		{
			this.enhancelevelSpecified = false;
		}

		// Token: 0x06003A0C RID: 14860 RVA: 0x0006F0E0 File Offset: 0x0006D2E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E60 RID: 3680
		private uint? _prof;

		// Token: 0x04000E61 RID: 3681
		private uint? _equippos;

		// Token: 0x04000E62 RID: 3682
		private uint? _enhancelevel;

		// Token: 0x04000E63 RID: 3683
		private IExtension extensionObject;
	}
}
