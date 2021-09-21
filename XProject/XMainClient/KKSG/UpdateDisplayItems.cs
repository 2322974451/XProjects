using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200040A RID: 1034
	[ProtoContract(Name = "UpdateDisplayItems")]
	[Serializable]
	public class UpdateDisplayItems : IExtensible
	{
		// Token: 0x170010EC RID: 4332
		// (get) Token: 0x0600370B RID: 14091 RVA: 0x00069704 File Offset: 0x00067904
		[ProtoMember(1, Name = "display_items", DataFormat = DataFormat.TwosComplement)]
		public List<uint> display_items
		{
			get
			{
				return this._display_items;
			}
		}

		// Token: 0x170010ED RID: 4333
		// (get) Token: 0x0600370C RID: 14092 RVA: 0x0006971C File Offset: 0x0006791C
		// (set) Token: 0x0600370D RID: 14093 RVA: 0x00069748 File Offset: 0x00067948
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

		// Token: 0x170010EE RID: 4334
		// (get) Token: 0x0600370E RID: 14094 RVA: 0x00069758 File Offset: 0x00067958
		// (set) Token: 0x0600370F RID: 14095 RVA: 0x00069778 File Offset: 0x00067978
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

		// Token: 0x06003710 RID: 14096 RVA: 0x000697BC File Offset: 0x000679BC
		private bool ShouldSerializehair_color_id()
		{
			return this.hair_color_idSpecified;
		}

		// Token: 0x06003711 RID: 14097 RVA: 0x000697D4 File Offset: 0x000679D4
		private void Resethair_color_id()
		{
			this.hair_color_idSpecified = false;
		}

		// Token: 0x170010EF RID: 4335
		// (get) Token: 0x06003712 RID: 14098 RVA: 0x000697E0 File Offset: 0x000679E0
		// (set) Token: 0x06003713 RID: 14099 RVA: 0x0006980C File Offset: 0x00067A0C
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

		// Token: 0x170010F0 RID: 4336
		// (get) Token: 0x06003714 RID: 14100 RVA: 0x0006981C File Offset: 0x00067A1C
		// (set) Token: 0x06003715 RID: 14101 RVA: 0x0006983C File Offset: 0x00067A3C
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

		// Token: 0x06003716 RID: 14102 RVA: 0x00069880 File Offset: 0x00067A80
		private bool ShouldSerializespecial_effects_id()
		{
			return this.special_effects_idSpecified;
		}

		// Token: 0x06003717 RID: 14103 RVA: 0x00069898 File Offset: 0x00067A98
		private void Resetspecial_effects_id()
		{
			this.special_effects_idSpecified = false;
		}

		// Token: 0x06003718 RID: 14104 RVA: 0x000698A4 File Offset: 0x00067AA4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DA5 RID: 3493
		private readonly List<uint> _display_items = new List<uint>();

		// Token: 0x04000DA6 RID: 3494
		private uint? _hair_color_id;

		// Token: 0x04000DA7 RID: 3495
		private uint? _special_effects_id;

		// Token: 0x04000DA8 RID: 3496
		private IExtension extensionObject;
	}
}
