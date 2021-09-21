using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005F3 RID: 1523
	[ProtoContract(Name = "StageTrophyData")]
	[Serializable]
	public class StageTrophyData : IExtensible
	{
		// Token: 0x17001C4D RID: 7245
		// (get) Token: 0x06005A88 RID: 23176 RVA: 0x000AC5C4 File Offset: 0x000AA7C4
		// (set) Token: 0x06005A89 RID: 23177 RVA: 0x000AC5F0 File Offset: 0x000AA7F0
		[ProtoMember(1, IsRequired = false, Name = "scene_id", DataFormat = DataFormat.TwosComplement)]
		public uint scene_id
		{
			get
			{
				return this._scene_id ?? 0U;
			}
			set
			{
				this._scene_id = new uint?(value);
			}
		}

		// Token: 0x17001C4E RID: 7246
		// (get) Token: 0x06005A8A RID: 23178 RVA: 0x000AC600 File Offset: 0x000AA800
		// (set) Token: 0x06005A8B RID: 23179 RVA: 0x000AC620 File Offset: 0x000AA820
		[XmlIgnore]
		[Browsable(false)]
		public bool scene_idSpecified
		{
			get
			{
				return this._scene_id != null;
			}
			set
			{
				bool flag = value == (this._scene_id == null);
				if (flag)
				{
					this._scene_id = (value ? new uint?(this.scene_id) : null);
				}
			}
		}

		// Token: 0x06005A8C RID: 23180 RVA: 0x000AC664 File Offset: 0x000AA864
		private bool ShouldSerializescene_id()
		{
			return this.scene_idSpecified;
		}

		// Token: 0x06005A8D RID: 23181 RVA: 0x000AC67C File Offset: 0x000AA87C
		private void Resetscene_id()
		{
			this.scene_idSpecified = false;
		}

		// Token: 0x17001C4F RID: 7247
		// (get) Token: 0x06005A8E RID: 23182 RVA: 0x000AC688 File Offset: 0x000AA888
		// (set) Token: 0x06005A8F RID: 23183 RVA: 0x000AC6B4 File Offset: 0x000AA8B4
		[ProtoMember(2, IsRequired = false, Name = "pass_count", DataFormat = DataFormat.TwosComplement)]
		public uint pass_count
		{
			get
			{
				return this._pass_count ?? 0U;
			}
			set
			{
				this._pass_count = new uint?(value);
			}
		}

		// Token: 0x17001C50 RID: 7248
		// (get) Token: 0x06005A90 RID: 23184 RVA: 0x000AC6C4 File Offset: 0x000AA8C4
		// (set) Token: 0x06005A91 RID: 23185 RVA: 0x000AC6E4 File Offset: 0x000AA8E4
		[XmlIgnore]
		[Browsable(false)]
		public bool pass_countSpecified
		{
			get
			{
				return this._pass_count != null;
			}
			set
			{
				bool flag = value == (this._pass_count == null);
				if (flag)
				{
					this._pass_count = (value ? new uint?(this.pass_count) : null);
				}
			}
		}

		// Token: 0x06005A92 RID: 23186 RVA: 0x000AC728 File Offset: 0x000AA928
		private bool ShouldSerializepass_count()
		{
			return this.pass_countSpecified;
		}

		// Token: 0x06005A93 RID: 23187 RVA: 0x000AC740 File Offset: 0x000AA940
		private void Resetpass_count()
		{
			this.pass_countSpecified = false;
		}

		// Token: 0x17001C51 RID: 7249
		// (get) Token: 0x06005A94 RID: 23188 RVA: 0x000AC74C File Offset: 0x000AA94C
		// (set) Token: 0x06005A95 RID: 23189 RVA: 0x000AC778 File Offset: 0x000AA978
		[ProtoMember(3, IsRequired = false, Name = "quickly_pass_time", DataFormat = DataFormat.TwosComplement)]
		public uint quickly_pass_time
		{
			get
			{
				return this._quickly_pass_time ?? 0U;
			}
			set
			{
				this._quickly_pass_time = new uint?(value);
			}
		}

		// Token: 0x17001C52 RID: 7250
		// (get) Token: 0x06005A96 RID: 23190 RVA: 0x000AC788 File Offset: 0x000AA988
		// (set) Token: 0x06005A97 RID: 23191 RVA: 0x000AC7A8 File Offset: 0x000AA9A8
		[XmlIgnore]
		[Browsable(false)]
		public bool quickly_pass_timeSpecified
		{
			get
			{
				return this._quickly_pass_time != null;
			}
			set
			{
				bool flag = value == (this._quickly_pass_time == null);
				if (flag)
				{
					this._quickly_pass_time = (value ? new uint?(this.quickly_pass_time) : null);
				}
			}
		}

		// Token: 0x06005A98 RID: 23192 RVA: 0x000AC7EC File Offset: 0x000AA9EC
		private bool ShouldSerializequickly_pass_time()
		{
			return this.quickly_pass_timeSpecified;
		}

		// Token: 0x06005A99 RID: 23193 RVA: 0x000AC804 File Offset: 0x000AAA04
		private void Resetquickly_pass_time()
		{
			this.quickly_pass_timeSpecified = false;
		}

		// Token: 0x17001C53 RID: 7251
		// (get) Token: 0x06005A9A RID: 23194 RVA: 0x000AC810 File Offset: 0x000AAA10
		// (set) Token: 0x06005A9B RID: 23195 RVA: 0x000AC83D File Offset: 0x000AAA3D
		[ProtoMember(4, IsRequired = false, Name = "hight_damage", DataFormat = DataFormat.TwosComplement)]
		public ulong hight_damage
		{
			get
			{
				return this._hight_damage ?? 0UL;
			}
			set
			{
				this._hight_damage = new ulong?(value);
			}
		}

		// Token: 0x17001C54 RID: 7252
		// (get) Token: 0x06005A9C RID: 23196 RVA: 0x000AC84C File Offset: 0x000AAA4C
		// (set) Token: 0x06005A9D RID: 23197 RVA: 0x000AC86C File Offset: 0x000AAA6C
		[XmlIgnore]
		[Browsable(false)]
		public bool hight_damageSpecified
		{
			get
			{
				return this._hight_damage != null;
			}
			set
			{
				bool flag = value == (this._hight_damage == null);
				if (flag)
				{
					this._hight_damage = (value ? new ulong?(this.hight_damage) : null);
				}
			}
		}

		// Token: 0x06005A9E RID: 23198 RVA: 0x000AC8B0 File Offset: 0x000AAAB0
		private bool ShouldSerializehight_damage()
		{
			return this.hight_damageSpecified;
		}

		// Token: 0x06005A9F RID: 23199 RVA: 0x000AC8C8 File Offset: 0x000AAAC8
		private void Resethight_damage()
		{
			this.hight_damageSpecified = false;
		}

		// Token: 0x17001C55 RID: 7253
		// (get) Token: 0x06005AA0 RID: 23200 RVA: 0x000AC8D4 File Offset: 0x000AAAD4
		// (set) Token: 0x06005AA1 RID: 23201 RVA: 0x000AC901 File Offset: 0x000AAB01
		[ProtoMember(5, IsRequired = false, Name = "hight_treat", DataFormat = DataFormat.TwosComplement)]
		public ulong hight_treat
		{
			get
			{
				return this._hight_treat ?? 0UL;
			}
			set
			{
				this._hight_treat = new ulong?(value);
			}
		}

		// Token: 0x17001C56 RID: 7254
		// (get) Token: 0x06005AA2 RID: 23202 RVA: 0x000AC910 File Offset: 0x000AAB10
		// (set) Token: 0x06005AA3 RID: 23203 RVA: 0x000AC930 File Offset: 0x000AAB30
		[XmlIgnore]
		[Browsable(false)]
		public bool hight_treatSpecified
		{
			get
			{
				return this._hight_treat != null;
			}
			set
			{
				bool flag = value == (this._hight_treat == null);
				if (flag)
				{
					this._hight_treat = (value ? new ulong?(this.hight_treat) : null);
				}
			}
		}

		// Token: 0x06005AA4 RID: 23204 RVA: 0x000AC974 File Offset: 0x000AAB74
		private bool ShouldSerializehight_treat()
		{
			return this.hight_treatSpecified;
		}

		// Token: 0x06005AA5 RID: 23205 RVA: 0x000AC98C File Offset: 0x000AAB8C
		private void Resethight_treat()
		{
			this.hight_treatSpecified = false;
		}

		// Token: 0x17001C57 RID: 7255
		// (get) Token: 0x06005AA6 RID: 23206 RVA: 0x000AC998 File Offset: 0x000AAB98
		// (set) Token: 0x06005AA7 RID: 23207 RVA: 0x000AC9C4 File Offset: 0x000AABC4
		[ProtoMember(6, IsRequired = false, Name = "help_count", DataFormat = DataFormat.TwosComplement)]
		public uint help_count
		{
			get
			{
				return this._help_count ?? 0U;
			}
			set
			{
				this._help_count = new uint?(value);
			}
		}

		// Token: 0x17001C58 RID: 7256
		// (get) Token: 0x06005AA8 RID: 23208 RVA: 0x000AC9D4 File Offset: 0x000AABD4
		// (set) Token: 0x06005AA9 RID: 23209 RVA: 0x000AC9F4 File Offset: 0x000AABF4
		[XmlIgnore]
		[Browsable(false)]
		public bool help_countSpecified
		{
			get
			{
				return this._help_count != null;
			}
			set
			{
				bool flag = value == (this._help_count == null);
				if (flag)
				{
					this._help_count = (value ? new uint?(this.help_count) : null);
				}
			}
		}

		// Token: 0x06005AAA RID: 23210 RVA: 0x000ACA38 File Offset: 0x000AAC38
		private bool ShouldSerializehelp_count()
		{
			return this.help_countSpecified;
		}

		// Token: 0x06005AAB RID: 23211 RVA: 0x000ACA50 File Offset: 0x000AAC50
		private void Resethelp_count()
		{
			this.help_countSpecified = false;
		}

		// Token: 0x17001C59 RID: 7257
		// (get) Token: 0x06005AAC RID: 23212 RVA: 0x000ACA5C File Offset: 0x000AAC5C
		// (set) Token: 0x06005AAD RID: 23213 RVA: 0x000ACA88 File Offset: 0x000AAC88
		[ProtoMember(7, IsRequired = false, Name = "no_deathpass_count", DataFormat = DataFormat.TwosComplement)]
		public uint no_deathpass_count
		{
			get
			{
				return this._no_deathpass_count ?? 0U;
			}
			set
			{
				this._no_deathpass_count = new uint?(value);
			}
		}

		// Token: 0x17001C5A RID: 7258
		// (get) Token: 0x06005AAE RID: 23214 RVA: 0x000ACA98 File Offset: 0x000AAC98
		// (set) Token: 0x06005AAF RID: 23215 RVA: 0x000ACAB8 File Offset: 0x000AACB8
		[XmlIgnore]
		[Browsable(false)]
		public bool no_deathpass_countSpecified
		{
			get
			{
				return this._no_deathpass_count != null;
			}
			set
			{
				bool flag = value == (this._no_deathpass_count == null);
				if (flag)
				{
					this._no_deathpass_count = (value ? new uint?(this.no_deathpass_count) : null);
				}
			}
		}

		// Token: 0x06005AB0 RID: 23216 RVA: 0x000ACAFC File Offset: 0x000AACFC
		private bool ShouldSerializeno_deathpass_count()
		{
			return this.no_deathpass_countSpecified;
		}

		// Token: 0x06005AB1 RID: 23217 RVA: 0x000ACB14 File Offset: 0x000AAD14
		private void Resetno_deathpass_count()
		{
			this.no_deathpass_countSpecified = false;
		}

		// Token: 0x17001C5B RID: 7259
		// (get) Token: 0x06005AB2 RID: 23218 RVA: 0x000ACB20 File Offset: 0x000AAD20
		[ProtoMember(8, Name = "get_trophy_detail", DataFormat = DataFormat.Default)]
		public List<TrophyGetTypeDetail> get_trophy_detail
		{
			get
			{
				return this._get_trophy_detail;
			}
		}

		// Token: 0x06005AB3 RID: 23219 RVA: 0x000ACB38 File Offset: 0x000AAD38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001608 RID: 5640
		private uint? _scene_id;

		// Token: 0x04001609 RID: 5641
		private uint? _pass_count;

		// Token: 0x0400160A RID: 5642
		private uint? _quickly_pass_time;

		// Token: 0x0400160B RID: 5643
		private ulong? _hight_damage;

		// Token: 0x0400160C RID: 5644
		private ulong? _hight_treat;

		// Token: 0x0400160D RID: 5645
		private uint? _help_count;

		// Token: 0x0400160E RID: 5646
		private uint? _no_deathpass_count;

		// Token: 0x0400160F RID: 5647
		private readonly List<TrophyGetTypeDetail> _get_trophy_detail = new List<TrophyGetTypeDetail>();

		// Token: 0x04001610 RID: 5648
		private IExtension extensionObject;
	}
}
