using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000579 RID: 1401
	[ProtoContract(Name = "OutLookDisplayFashion")]
	[Serializable]
	public class OutLookDisplayFashion : IExtensible
	{
		// Token: 0x17001623 RID: 5667
		// (get) Token: 0x06004840 RID: 18496 RVA: 0x000893E0 File Offset: 0x000875E0
		[ProtoMember(1, Name = "display_fashions", DataFormat = DataFormat.TwosComplement)]
		public List<uint> display_fashions
		{
			get
			{
				return this._display_fashions;
			}
		}

		// Token: 0x17001624 RID: 5668
		// (get) Token: 0x06004841 RID: 18497 RVA: 0x000893F8 File Offset: 0x000875F8
		// (set) Token: 0x06004842 RID: 18498 RVA: 0x00089424 File Offset: 0x00087624
		[ProtoMember(2, IsRequired = false, Name = "hair_color_id", DataFormat = DataFormat.TwosComplement)]
		public uint hair_color_id
		{
			get
			{
				return this._hair_color_id ?? 0U;
			}
			set
			{
				this._hair_color_id = new uint?(value);
			}
		}

		// Token: 0x17001625 RID: 5669
		// (get) Token: 0x06004843 RID: 18499 RVA: 0x00089434 File Offset: 0x00087634
		// (set) Token: 0x06004844 RID: 18500 RVA: 0x00089454 File Offset: 0x00087654
		[XmlIgnore]
		[Browsable(false)]
		public bool hair_color_idSpecified
		{
			get
			{
				return this._hair_color_id != null;
			}
			set
			{
				bool flag = value == (this._hair_color_id == null);
				if (flag)
				{
					this._hair_color_id = (value ? new uint?(this.hair_color_id) : null);
				}
			}
		}

		// Token: 0x06004845 RID: 18501 RVA: 0x00089498 File Offset: 0x00087698
		private bool ShouldSerializehair_color_id()
		{
			return this.hair_color_idSpecified;
		}

		// Token: 0x06004846 RID: 18502 RVA: 0x000894B0 File Offset: 0x000876B0
		private void Resethair_color_id()
		{
			this.hair_color_idSpecified = false;
		}

		// Token: 0x17001626 RID: 5670
		// (get) Token: 0x06004847 RID: 18503 RVA: 0x000894BC File Offset: 0x000876BC
		// (set) Token: 0x06004848 RID: 18504 RVA: 0x000894E8 File Offset: 0x000876E8
		[ProtoMember(3, IsRequired = false, Name = "special_effects_id", DataFormat = DataFormat.TwosComplement)]
		public uint special_effects_id
		{
			get
			{
				return this._special_effects_id ?? 0U;
			}
			set
			{
				this._special_effects_id = new uint?(value);
			}
		}

		// Token: 0x17001627 RID: 5671
		// (get) Token: 0x06004849 RID: 18505 RVA: 0x000894F8 File Offset: 0x000876F8
		// (set) Token: 0x0600484A RID: 18506 RVA: 0x00089518 File Offset: 0x00087718
		[XmlIgnore]
		[Browsable(false)]
		public bool special_effects_idSpecified
		{
			get
			{
				return this._special_effects_id != null;
			}
			set
			{
				bool flag = value == (this._special_effects_id == null);
				if (flag)
				{
					this._special_effects_id = (value ? new uint?(this.special_effects_id) : null);
				}
			}
		}

		// Token: 0x0600484B RID: 18507 RVA: 0x0008955C File Offset: 0x0008775C
		private bool ShouldSerializespecial_effects_id()
		{
			return this.special_effects_idSpecified;
		}

		// Token: 0x0600484C RID: 18508 RVA: 0x00089574 File Offset: 0x00087774
		private void Resetspecial_effects_id()
		{
			this.special_effects_idSpecified = false;
		}

		// Token: 0x0600484D RID: 18509 RVA: 0x00089580 File Offset: 0x00087780
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001210 RID: 4624
		private readonly List<uint> _display_fashions = new List<uint>();

		// Token: 0x04001211 RID: 4625
		private uint? _hair_color_id;

		// Token: 0x04001212 RID: 4626
		private uint? _special_effects_id;

		// Token: 0x04001213 RID: 4627
		private IExtension extensionObject;
	}
}
