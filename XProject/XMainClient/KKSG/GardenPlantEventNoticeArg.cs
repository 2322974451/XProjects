using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000281 RID: 641
	[ProtoContract(Name = "GardenPlantEventNoticeArg")]
	[Serializable]
	public class GardenPlantEventNoticeArg : IExtensible
	{
		// Token: 0x17000B15 RID: 2837
		// (get) Token: 0x060023A6 RID: 9126 RVA: 0x00045960 File Offset: 0x00043B60
		// (set) Token: 0x060023A7 RID: 9127 RVA: 0x0004598C File Offset: 0x00043B8C
		[ProtoMember(1, IsRequired = false, Name = "event_type", DataFormat = DataFormat.TwosComplement)]
		public GardenPlayEventType event_type
		{
			get
			{
				return this._event_type ?? GardenPlayEventType.PLANT;
			}
			set
			{
				this._event_type = new GardenPlayEventType?(value);
			}
		}

		// Token: 0x17000B16 RID: 2838
		// (get) Token: 0x060023A8 RID: 9128 RVA: 0x0004599C File Offset: 0x00043B9C
		// (set) Token: 0x060023A9 RID: 9129 RVA: 0x000459BC File Offset: 0x00043BBC
		[XmlIgnore]
		[Browsable(false)]
		public bool event_typeSpecified
		{
			get
			{
				return this._event_type != null;
			}
			set
			{
				bool flag = value == (this._event_type == null);
				if (flag)
				{
					this._event_type = (value ? new GardenPlayEventType?(this.event_type) : null);
				}
			}
		}

		// Token: 0x060023AA RID: 9130 RVA: 0x00045A00 File Offset: 0x00043C00
		private bool ShouldSerializeevent_type()
		{
			return this.event_typeSpecified;
		}

		// Token: 0x060023AB RID: 9131 RVA: 0x00045A18 File Offset: 0x00043C18
		private void Resetevent_type()
		{
			this.event_typeSpecified = false;
		}

		// Token: 0x17000B17 RID: 2839
		// (get) Token: 0x060023AC RID: 9132 RVA: 0x00045A24 File Offset: 0x00043C24
		// (set) Token: 0x060023AD RID: 9133 RVA: 0x00045A50 File Offset: 0x00043C50
		[ProtoMember(2, IsRequired = false, Name = "farmland_id", DataFormat = DataFormat.TwosComplement)]
		public uint farmland_id
		{
			get
			{
				return this._farmland_id ?? 0U;
			}
			set
			{
				this._farmland_id = new uint?(value);
			}
		}

		// Token: 0x17000B18 RID: 2840
		// (get) Token: 0x060023AE RID: 9134 RVA: 0x00045A60 File Offset: 0x00043C60
		// (set) Token: 0x060023AF RID: 9135 RVA: 0x00045A80 File Offset: 0x00043C80
		[XmlIgnore]
		[Browsable(false)]
		public bool farmland_idSpecified
		{
			get
			{
				return this._farmland_id != null;
			}
			set
			{
				bool flag = value == (this._farmland_id == null);
				if (flag)
				{
					this._farmland_id = (value ? new uint?(this.farmland_id) : null);
				}
			}
		}

		// Token: 0x060023B0 RID: 9136 RVA: 0x00045AC4 File Offset: 0x00043CC4
		private bool ShouldSerializefarmland_id()
		{
			return this.farmland_idSpecified;
		}

		// Token: 0x060023B1 RID: 9137 RVA: 0x00045ADC File Offset: 0x00043CDC
		private void Resetfarmland_id()
		{
			this.farmland_idSpecified = false;
		}

		// Token: 0x17000B19 RID: 2841
		// (get) Token: 0x060023B2 RID: 9138 RVA: 0x00045AE8 File Offset: 0x00043CE8
		// (set) Token: 0x060023B3 RID: 9139 RVA: 0x00045B14 File Offset: 0x00043D14
		[ProtoMember(3, IsRequired = false, Name = "sprite_id", DataFormat = DataFormat.TwosComplement)]
		public uint sprite_id
		{
			get
			{
				return this._sprite_id ?? 0U;
			}
			set
			{
				this._sprite_id = new uint?(value);
			}
		}

		// Token: 0x17000B1A RID: 2842
		// (get) Token: 0x060023B4 RID: 9140 RVA: 0x00045B24 File Offset: 0x00043D24
		// (set) Token: 0x060023B5 RID: 9141 RVA: 0x00045B44 File Offset: 0x00043D44
		[XmlIgnore]
		[Browsable(false)]
		public bool sprite_idSpecified
		{
			get
			{
				return this._sprite_id != null;
			}
			set
			{
				bool flag = value == (this._sprite_id == null);
				if (flag)
				{
					this._sprite_id = (value ? new uint?(this.sprite_id) : null);
				}
			}
		}

		// Token: 0x060023B6 RID: 9142 RVA: 0x00045B88 File Offset: 0x00043D88
		private bool ShouldSerializesprite_id()
		{
			return this.sprite_idSpecified;
		}

		// Token: 0x060023B7 RID: 9143 RVA: 0x00045BA0 File Offset: 0x00043DA0
		private void Resetsprite_id()
		{
			this.sprite_idSpecified = false;
		}

		// Token: 0x17000B1B RID: 2843
		// (get) Token: 0x060023B8 RID: 9144 RVA: 0x00045BAC File Offset: 0x00043DAC
		// (set) Token: 0x060023B9 RID: 9145 RVA: 0x00045BD9 File Offset: 0x00043DD9
		[ProtoMember(4, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
		public ulong garden_id
		{
			get
			{
				return this._garden_id ?? 0UL;
			}
			set
			{
				this._garden_id = new ulong?(value);
			}
		}

		// Token: 0x17000B1C RID: 2844
		// (get) Token: 0x060023BA RID: 9146 RVA: 0x00045BE8 File Offset: 0x00043DE8
		// (set) Token: 0x060023BB RID: 9147 RVA: 0x00045C08 File Offset: 0x00043E08
		[XmlIgnore]
		[Browsable(false)]
		public bool garden_idSpecified
		{
			get
			{
				return this._garden_id != null;
			}
			set
			{
				bool flag = value == (this._garden_id == null);
				if (flag)
				{
					this._garden_id = (value ? new ulong?(this.garden_id) : null);
				}
			}
		}

		// Token: 0x060023BC RID: 9148 RVA: 0x00045C4C File Offset: 0x00043E4C
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x060023BD RID: 9149 RVA: 0x00045C64 File Offset: 0x00043E64
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x17000B1D RID: 2845
		// (get) Token: 0x060023BE RID: 9150 RVA: 0x00045C70 File Offset: 0x00043E70
		// (set) Token: 0x060023BF RID: 9151 RVA: 0x00045C9C File Offset: 0x00043E9C
		[ProtoMember(5, IsRequired = false, Name = "exist", DataFormat = DataFormat.Default)]
		public bool exist
		{
			get
			{
				return this._exist ?? false;
			}
			set
			{
				this._exist = new bool?(value);
			}
		}

		// Token: 0x17000B1E RID: 2846
		// (get) Token: 0x060023C0 RID: 9152 RVA: 0x00045CAC File Offset: 0x00043EAC
		// (set) Token: 0x060023C1 RID: 9153 RVA: 0x00045CCC File Offset: 0x00043ECC
		[XmlIgnore]
		[Browsable(false)]
		public bool existSpecified
		{
			get
			{
				return this._exist != null;
			}
			set
			{
				bool flag = value == (this._exist == null);
				if (flag)
				{
					this._exist = (value ? new bool?(this.exist) : null);
				}
			}
		}

		// Token: 0x060023C2 RID: 9154 RVA: 0x00045D10 File Offset: 0x00043F10
		private bool ShouldSerializeexist()
		{
			return this.existSpecified;
		}

		// Token: 0x060023C3 RID: 9155 RVA: 0x00045D28 File Offset: 0x00043F28
		private void Resetexist()
		{
			this.existSpecified = false;
		}

		// Token: 0x17000B1F RID: 2847
		// (get) Token: 0x060023C4 RID: 9156 RVA: 0x00045D34 File Offset: 0x00043F34
		// (set) Token: 0x060023C5 RID: 9157 RVA: 0x00045D61 File Offset: 0x00043F61
		[ProtoMember(6, IsRequired = false, Name = "role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong role_id
		{
			get
			{
				return this._role_id ?? 0UL;
			}
			set
			{
				this._role_id = new ulong?(value);
			}
		}

		// Token: 0x17000B20 RID: 2848
		// (get) Token: 0x060023C6 RID: 9158 RVA: 0x00045D70 File Offset: 0x00043F70
		// (set) Token: 0x060023C7 RID: 9159 RVA: 0x00045D90 File Offset: 0x00043F90
		[XmlIgnore]
		[Browsable(false)]
		public bool role_idSpecified
		{
			get
			{
				return this._role_id != null;
			}
			set
			{
				bool flag = value == (this._role_id == null);
				if (flag)
				{
					this._role_id = (value ? new ulong?(this.role_id) : null);
				}
			}
		}

		// Token: 0x060023C8 RID: 9160 RVA: 0x00045DD4 File Offset: 0x00043FD4
		private bool ShouldSerializerole_id()
		{
			return this.role_idSpecified;
		}

		// Token: 0x060023C9 RID: 9161 RVA: 0x00045DEC File Offset: 0x00043FEC
		private void Resetrole_id()
		{
			this.role_idSpecified = false;
		}

		// Token: 0x17000B21 RID: 2849
		// (get) Token: 0x060023CA RID: 9162 RVA: 0x00045DF8 File Offset: 0x00043FF8
		// (set) Token: 0x060023CB RID: 9163 RVA: 0x00045E24 File Offset: 0x00044024
		[ProtoMember(7, IsRequired = false, Name = "fish_result", DataFormat = DataFormat.Default)]
		public bool fish_result
		{
			get
			{
				return this._fish_result ?? false;
			}
			set
			{
				this._fish_result = new bool?(value);
			}
		}

		// Token: 0x17000B22 RID: 2850
		// (get) Token: 0x060023CC RID: 9164 RVA: 0x00045E34 File Offset: 0x00044034
		// (set) Token: 0x060023CD RID: 9165 RVA: 0x00045E54 File Offset: 0x00044054
		[XmlIgnore]
		[Browsable(false)]
		public bool fish_resultSpecified
		{
			get
			{
				return this._fish_result != null;
			}
			set
			{
				bool flag = value == (this._fish_result == null);
				if (flag)
				{
					this._fish_result = (value ? new bool?(this.fish_result) : null);
				}
			}
		}

		// Token: 0x060023CE RID: 9166 RVA: 0x00045E98 File Offset: 0x00044098
		private bool ShouldSerializefish_result()
		{
			return this.fish_resultSpecified;
		}

		// Token: 0x060023CF RID: 9167 RVA: 0x00045EB0 File Offset: 0x000440B0
		private void Resetfish_result()
		{
			this.fish_resultSpecified = false;
		}

		// Token: 0x17000B23 RID: 2851
		// (get) Token: 0x060023D0 RID: 9168 RVA: 0x00045EBC File Offset: 0x000440BC
		// (set) Token: 0x060023D1 RID: 9169 RVA: 0x00045EE8 File Offset: 0x000440E8
		[ProtoMember(8, IsRequired = false, Name = "fish_stop", DataFormat = DataFormat.Default)]
		public bool fish_stop
		{
			get
			{
				return this._fish_stop ?? false;
			}
			set
			{
				this._fish_stop = new bool?(value);
			}
		}

		// Token: 0x17000B24 RID: 2852
		// (get) Token: 0x060023D2 RID: 9170 RVA: 0x00045EF8 File Offset: 0x000440F8
		// (set) Token: 0x060023D3 RID: 9171 RVA: 0x00045F18 File Offset: 0x00044118
		[XmlIgnore]
		[Browsable(false)]
		public bool fish_stopSpecified
		{
			get
			{
				return this._fish_stop != null;
			}
			set
			{
				bool flag = value == (this._fish_stop == null);
				if (flag)
				{
					this._fish_stop = (value ? new bool?(this.fish_stop) : null);
				}
			}
		}

		// Token: 0x060023D4 RID: 9172 RVA: 0x00045F5C File Offset: 0x0004415C
		private bool ShouldSerializefish_stop()
		{
			return this.fish_stopSpecified;
		}

		// Token: 0x060023D5 RID: 9173 RVA: 0x00045F74 File Offset: 0x00044174
		private void Resetfish_stop()
		{
			this.fish_stopSpecified = false;
		}

		// Token: 0x060023D6 RID: 9174 RVA: 0x00045F80 File Offset: 0x00044180
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008D7 RID: 2263
		private GardenPlayEventType? _event_type;

		// Token: 0x040008D8 RID: 2264
		private uint? _farmland_id;

		// Token: 0x040008D9 RID: 2265
		private uint? _sprite_id;

		// Token: 0x040008DA RID: 2266
		private ulong? _garden_id;

		// Token: 0x040008DB RID: 2267
		private bool? _exist;

		// Token: 0x040008DC RID: 2268
		private ulong? _role_id;

		// Token: 0x040008DD RID: 2269
		private bool? _fish_result;

		// Token: 0x040008DE RID: 2270
		private bool? _fish_stop;

		// Token: 0x040008DF RID: 2271
		private IExtension extensionObject;
	}
}
