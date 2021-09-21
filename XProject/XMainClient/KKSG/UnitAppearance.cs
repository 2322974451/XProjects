using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200000D RID: 13
	[ProtoContract(Name = "UnitAppearance")]
	[Serializable]
	public class UnitAppearance : IExtensible
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00003F18 File Offset: 0x00002118
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00003F45 File Offset: 0x00002145
		[ProtoMember(1, IsRequired = false, Name = "uID", DataFormat = DataFormat.TwosComplement)]
		public ulong uID
		{
			get
			{
				return this._uID ?? 0UL;
			}
			set
			{
				this._uID = new ulong?(value);
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00003F54 File Offset: 0x00002154
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00003F74 File Offset: 0x00002174
		[XmlIgnore]
		[Browsable(false)]
		public bool uIDSpecified
		{
			get
			{
				return this._uID != null;
			}
			set
			{
				bool flag = value == (this._uID == null);
				if (flag)
				{
					this._uID = (value ? new ulong?(this.uID) : null);
				}
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003FB8 File Offset: 0x000021B8
		private bool ShouldSerializeuID()
		{
			return this.uIDSpecified;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003FD0 File Offset: 0x000021D0
		private void ResetuID()
		{
			this.uIDSpecified = false;
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00003FDC File Offset: 0x000021DC
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x00003FFD File Offset: 0x000021FD
		[ProtoMember(2, IsRequired = false, Name = "unitName", DataFormat = DataFormat.Default)]
		public string unitName
		{
			get
			{
				return this._unitName ?? "";
			}
			set
			{
				this._unitName = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x00004008 File Offset: 0x00002208
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x00004024 File Offset: 0x00002224
		[XmlIgnore]
		[Browsable(false)]
		public bool unitNameSpecified
		{
			get
			{
				return this._unitName != null;
			}
			set
			{
				bool flag = value == (this._unitName == null);
				if (flag)
				{
					this._unitName = (value ? this.unitName : null);
				}
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004054 File Offset: 0x00002254
		private bool ShouldSerializeunitName()
		{
			return this.unitNameSpecified;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000406C File Offset: 0x0000226C
		private void ResetunitName()
		{
			this.unitNameSpecified = false;
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00004078 File Offset: 0x00002278
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x000040A4 File Offset: 0x000022A4
		[ProtoMember(3, IsRequired = false, Name = "unitType", DataFormat = DataFormat.TwosComplement)]
		public uint unitType
		{
			get
			{
				return this._unitType ?? 0U;
			}
			set
			{
				this._unitType = new uint?(value);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000040B4 File Offset: 0x000022B4
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x000040D4 File Offset: 0x000022D4
		[XmlIgnore]
		[Browsable(false)]
		public bool unitTypeSpecified
		{
			get
			{
				return this._unitType != null;
			}
			set
			{
				bool flag = value == (this._unitType == null);
				if (flag)
				{
					this._unitType = (value ? new uint?(this.unitType) : null);
				}
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004118 File Offset: 0x00002318
		private bool ShouldSerializeunitType()
		{
			return this.unitTypeSpecified;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004130 File Offset: 0x00002330
		private void ResetunitType()
		{
			this.unitTypeSpecified = false;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000BC RID: 188 RVA: 0x0000413C File Offset: 0x0000233C
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00004154 File Offset: 0x00002354
		[ProtoMember(4, IsRequired = false, Name = "position", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Vec3 position
		{
			get
			{
				return this._position;
			}
			set
			{
				this._position = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00004160 File Offset: 0x00002360
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00004190 File Offset: 0x00002390
		[ProtoMember(5, IsRequired = false, Name = "direction", DataFormat = DataFormat.FixedSize)]
		public float direction
		{
			get
			{
				return this._direction ?? 0f;
			}
			set
			{
				this._direction = new float?(value);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x000041A0 File Offset: 0x000023A0
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x000041C0 File Offset: 0x000023C0
		[XmlIgnore]
		[Browsable(false)]
		public bool directionSpecified
		{
			get
			{
				return this._direction != null;
			}
			set
			{
				bool flag = value == (this._direction == null);
				if (flag)
				{
					this._direction = (value ? new float?(this.direction) : null);
				}
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004204 File Offset: 0x00002404
		private bool ShouldSerializedirection()
		{
			return this.directionSpecified;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000421C File Offset: 0x0000241C
		private void Resetdirection()
		{
			this.directionSpecified = false;
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00004228 File Offset: 0x00002428
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00004240 File Offset: 0x00002440
		[ProtoMember(6, IsRequired = false, Name = "attributes", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Attribute attributes
		{
			get
			{
				return this._attributes;
			}
			set
			{
				this._attributes = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x0000424C File Offset: 0x0000244C
		[ProtoMember(7, Name = "fashion", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fashion
		{
			get
			{
				return this._fashion;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00004264 File Offset: 0x00002464
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00004290 File Offset: 0x00002490
		[ProtoMember(8, IsRequired = false, Name = "waveID", DataFormat = DataFormat.TwosComplement)]
		public uint waveID
		{
			get
			{
				return this._waveID ?? 0U;
			}
			set
			{
				this._waveID = new uint?(value);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x000042A0 File Offset: 0x000024A0
		// (set) Token: 0x060000CA RID: 202 RVA: 0x000042C0 File Offset: 0x000024C0
		[XmlIgnore]
		[Browsable(false)]
		public bool waveIDSpecified
		{
			get
			{
				return this._waveID != null;
			}
			set
			{
				bool flag = value == (this._waveID == null);
				if (flag)
				{
					this._waveID = (value ? new uint?(this.waveID) : null);
				}
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004304 File Offset: 0x00002504
		private bool ShouldSerializewaveID()
		{
			return this.waveIDSpecified;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000431C File Offset: 0x0000251C
		private void ResetwaveID()
		{
			this.waveIDSpecified = false;
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00004328 File Offset: 0x00002528
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00004354 File Offset: 0x00002554
		[ProtoMember(9, IsRequired = false, Name = "isServerControl", DataFormat = DataFormat.Default)]
		public bool isServerControl
		{
			get
			{
				return this._isServerControl ?? false;
			}
			set
			{
				this._isServerControl = new bool?(value);
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00004364 File Offset: 0x00002564
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00004384 File Offset: 0x00002584
		[XmlIgnore]
		[Browsable(false)]
		public bool isServerControlSpecified
		{
			get
			{
				return this._isServerControl != null;
			}
			set
			{
				bool flag = value == (this._isServerControl == null);
				if (flag)
				{
					this._isServerControl = (value ? new bool?(this.isServerControl) : null);
				}
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000043C8 File Offset: 0x000025C8
		private bool ShouldSerializeisServerControl()
		{
			return this.isServerControlSpecified;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000043E0 File Offset: 0x000025E0
		private void ResetisServerControl()
		{
			this.isServerControlSpecified = false;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x000043EC File Offset: 0x000025EC
		[ProtoMember(10, Name = "skills", DataFormat = DataFormat.Default)]
		public List<SkillInfo> skills
		{
			get
			{
				return this._skills;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00004404 File Offset: 0x00002604
		[ProtoMember(11, Name = "equip", DataFormat = DataFormat.Default)]
		public List<Item> equip
		{
			get
			{
				return this._equip;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x0000441C File Offset: 0x0000261C
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00004448 File Offset: 0x00002648
		[ProtoMember(12, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00004458 File Offset: 0x00002658
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x00004478 File Offset: 0x00002678
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
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000044BC File Offset: 0x000026BC
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000044D4 File Offset: 0x000026D4
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000DB RID: 219 RVA: 0x000044E0 File Offset: 0x000026E0
		// (set) Token: 0x060000DC RID: 220 RVA: 0x0000450C File Offset: 0x0000270C
		[ProtoMember(13, IsRequired = false, Name = "PowerPoint", DataFormat = DataFormat.TwosComplement)]
		public uint PowerPoint
		{
			get
			{
				return this._PowerPoint ?? 0U;
			}
			set
			{
				this._PowerPoint = new uint?(value);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000DD RID: 221 RVA: 0x0000451C File Offset: 0x0000271C
		// (set) Token: 0x060000DE RID: 222 RVA: 0x0000453C File Offset: 0x0000273C
		[XmlIgnore]
		[Browsable(false)]
		public bool PowerPointSpecified
		{
			get
			{
				return this._PowerPoint != null;
			}
			set
			{
				bool flag = value == (this._PowerPoint == null);
				if (flag)
				{
					this._PowerPoint = (value ? new uint?(this.PowerPoint) : null);
				}
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00004580 File Offset: 0x00002780
		private bool ShouldSerializePowerPoint()
		{
			return this.PowerPointSpecified;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00004598 File Offset: 0x00002798
		private void ResetPowerPoint()
		{
			this.PowerPointSpecified = false;
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x000045A4 File Offset: 0x000027A4
		[ProtoMember(14, Name = "emblem", DataFormat = DataFormat.Default)]
		public List<Item> emblem
		{
			get
			{
				return this._emblem;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x000045BC File Offset: 0x000027BC
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x000045E8 File Offset: 0x000027E8
		[ProtoMember(15, IsRequired = false, Name = "fightgroup", DataFormat = DataFormat.TwosComplement)]
		public uint fightgroup
		{
			get
			{
				return this._fightgroup ?? 0U;
			}
			set
			{
				this._fightgroup = new uint?(value);
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x000045F8 File Offset: 0x000027F8
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x00004618 File Offset: 0x00002818
		[XmlIgnore]
		[Browsable(false)]
		public bool fightgroupSpecified
		{
			get
			{
				return this._fightgroup != null;
			}
			set
			{
				bool flag = value == (this._fightgroup == null);
				if (flag)
				{
					this._fightgroup = (value ? new uint?(this.fightgroup) : null);
				}
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000465C File Offset: 0x0000285C
		private bool ShouldSerializefightgroup()
		{
			return this.fightgroupSpecified;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00004674 File Offset: 0x00002874
		private void Resetfightgroup()
		{
			this.fightgroupSpecified = false;
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00004680 File Offset: 0x00002880
		[ProtoMember(16, Name = "buffs", DataFormat = DataFormat.Default)]
		public List<BuffInfo> buffs
		{
			get
			{
				return this._buffs;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00004698 File Offset: 0x00002898
		// (set) Token: 0x060000EA RID: 234 RVA: 0x000046C4 File Offset: 0x000028C4
		[ProtoMember(17, IsRequired = false, Name = "IsDead", DataFormat = DataFormat.Default)]
		public bool IsDead
		{
			get
			{
				return this._IsDead ?? false;
			}
			set
			{
				this._IsDead = new bool?(value);
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000EB RID: 235 RVA: 0x000046D4 File Offset: 0x000028D4
		// (set) Token: 0x060000EC RID: 236 RVA: 0x000046F4 File Offset: 0x000028F4
		[XmlIgnore]
		[Browsable(false)]
		public bool IsDeadSpecified
		{
			get
			{
				return this._IsDead != null;
			}
			set
			{
				bool flag = value == (this._IsDead == null);
				if (flag)
				{
					this._IsDead = (value ? new bool?(this.IsDead) : null);
				}
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00004738 File Offset: 0x00002938
		private bool ShouldSerializeIsDead()
		{
			return this.IsDeadSpecified;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00004750 File Offset: 0x00002950
		private void ResetIsDead()
		{
			this.IsDeadSpecified = false;
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000EF RID: 239 RVA: 0x0000475C File Offset: 0x0000295C
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x00004774 File Offset: 0x00002974
		[ProtoMember(18, IsRequired = false, Name = "outlook", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLook outlook
		{
			get
			{
				return this._outlook;
			}
			set
			{
				this._outlook = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00004780 File Offset: 0x00002980
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x000047AC File Offset: 0x000029AC
		[ProtoMember(19, IsRequired = false, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
		public uint viplevel
		{
			get
			{
				return this._viplevel ?? 0U;
			}
			set
			{
				this._viplevel = new uint?(value);
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x000047BC File Offset: 0x000029BC
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x000047DC File Offset: 0x000029DC
		[XmlIgnore]
		[Browsable(false)]
		public bool viplevelSpecified
		{
			get
			{
				return this._viplevel != null;
			}
			set
			{
				bool flag = value == (this._viplevel == null);
				if (flag)
				{
					this._viplevel = (value ? new uint?(this.viplevel) : null);
				}
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00004820 File Offset: 0x00002A20
		private bool ShouldSerializeviplevel()
		{
			return this.viplevelSpecified;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00004838 File Offset: 0x00002A38
		private void Resetviplevel()
		{
			this.viplevelSpecified = false;
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00004844 File Offset: 0x00002A44
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x00004870 File Offset: 0x00002A70
		[ProtoMember(20, IsRequired = false, Name = "lastlogin", DataFormat = DataFormat.TwosComplement)]
		public uint lastlogin
		{
			get
			{
				return this._lastlogin ?? 0U;
			}
			set
			{
				this._lastlogin = new uint?(value);
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00004880 File Offset: 0x00002A80
		// (set) Token: 0x060000FA RID: 250 RVA: 0x000048A0 File Offset: 0x00002AA0
		[XmlIgnore]
		[Browsable(false)]
		public bool lastloginSpecified
		{
			get
			{
				return this._lastlogin != null;
			}
			set
			{
				bool flag = value == (this._lastlogin == null);
				if (flag)
				{
					this._lastlogin = (value ? new uint?(this.lastlogin) : null);
				}
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000048E4 File Offset: 0x00002AE4
		private bool ShouldSerializelastlogin()
		{
			return this.lastloginSpecified;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000048FC File Offset: 0x00002AFC
		private void Resetlastlogin()
		{
			this.lastloginSpecified = false;
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00004908 File Offset: 0x00002B08
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00004934 File Offset: 0x00002B34
		[ProtoMember(21, IsRequired = false, Name = "nickid", DataFormat = DataFormat.TwosComplement)]
		public uint nickid
		{
			get
			{
				return this._nickid ?? 0U;
			}
			set
			{
				this._nickid = new uint?(value);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00004944 File Offset: 0x00002B44
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00004964 File Offset: 0x00002B64
		[XmlIgnore]
		[Browsable(false)]
		public bool nickidSpecified
		{
			get
			{
				return this._nickid != null;
			}
			set
			{
				bool flag = value == (this._nickid == null);
				if (flag)
				{
					this._nickid = (value ? new uint?(this.nickid) : null);
				}
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000049A8 File Offset: 0x00002BA8
		private bool ShouldSerializenickid()
		{
			return this.nickidSpecified;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000049C0 File Offset: 0x00002BC0
		private void Resetnickid()
		{
			this.nickidSpecified = false;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000103 RID: 259 RVA: 0x000049CC File Offset: 0x00002BCC
		// (set) Token: 0x06000104 RID: 260 RVA: 0x000049F8 File Offset: 0x00002BF8
		[ProtoMember(22, IsRequired = false, Name = "isnewmob", DataFormat = DataFormat.Default)]
		public bool isnewmob
		{
			get
			{
				return this._isnewmob ?? false;
			}
			set
			{
				this._isnewmob = new bool?(value);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00004A08 File Offset: 0x00002C08
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00004A28 File Offset: 0x00002C28
		[XmlIgnore]
		[Browsable(false)]
		public bool isnewmobSpecified
		{
			get
			{
				return this._isnewmob != null;
			}
			set
			{
				bool flag = value == (this._isnewmob == null);
				if (flag)
				{
					this._isnewmob = (value ? new bool?(this.isnewmob) : null);
				}
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00004A6C File Offset: 0x00002C6C
		private bool ShouldSerializeisnewmob()
		{
			return this.isnewmobSpecified;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00004A84 File Offset: 0x00002C84
		private void Resetisnewmob()
		{
			this.isnewmobSpecified = false;
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00004A90 File Offset: 0x00002C90
		[ProtoMember(23, Name = "bindskills", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bindskills
		{
			get
			{
				return this._bindskills;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00004AA8 File Offset: 0x00002CA8
		// (set) Token: 0x0600010B RID: 267 RVA: 0x00004AC0 File Offset: 0x00002CC0
		[ProtoMember(24, IsRequired = false, Name = "allbuffsinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public AllBuffsInfo allbuffsinfo
		{
			get
			{
				return this._allbuffsinfo;
			}
			set
			{
				this._allbuffsinfo = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00004ACC File Offset: 0x00002CCC
		[ProtoMember(25, Name = "sprites", DataFormat = DataFormat.Default)]
		public List<SpriteInfo> sprites
		{
			get
			{
				return this._sprites;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00004AE4 File Offset: 0x00002CE4
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00004AFC File Offset: 0x00002CFC
		[ProtoMember(26, IsRequired = false, Name = "pet", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PetSingle pet
		{
			get
			{
				return this._pet;
			}
			set
			{
				this._pet = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00004B08 File Offset: 0x00002D08
		// (set) Token: 0x06000110 RID: 272 RVA: 0x00004B35 File Offset: 0x00002D35
		[ProtoMember(27, IsRequired = false, Name = "hostid", DataFormat = DataFormat.TwosComplement)]
		public ulong hostid
		{
			get
			{
				return this._hostid ?? 0UL;
			}
			set
			{
				this._hostid = new ulong?(value);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00004B44 File Offset: 0x00002D44
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00004B64 File Offset: 0x00002D64
		[XmlIgnore]
		[Browsable(false)]
		public bool hostidSpecified
		{
			get
			{
				return this._hostid != null;
			}
			set
			{
				bool flag = value == (this._hostid == null);
				if (flag)
				{
					this._hostid = (value ? new ulong?(this.hostid) : null);
				}
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00004BA8 File Offset: 0x00002DA8
		private bool ShouldSerializehostid()
		{
			return this.hostidSpecified;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00004BC0 File Offset: 0x00002DC0
		private void Resethostid()
		{
			this.hostidSpecified = false;
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00004BCC File Offset: 0x00002DCC
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00004BF8 File Offset: 0x00002DF8
		[ProtoMember(28, IsRequired = false, Name = "category", DataFormat = DataFormat.TwosComplement)]
		public EntityCategory category
		{
			get
			{
				return this._category ?? EntityCategory.Category_Role;
			}
			set
			{
				this._category = new EntityCategory?(value);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00004C08 File Offset: 0x00002E08
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00004C28 File Offset: 0x00002E28
		[XmlIgnore]
		[Browsable(false)]
		public bool categorySpecified
		{
			get
			{
				return this._category != null;
			}
			set
			{
				bool flag = value == (this._category == null);
				if (flag)
				{
					this._category = (value ? new EntityCategory?(this.category) : null);
				}
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00004C6C File Offset: 0x00002E6C
		private bool ShouldSerializecategory()
		{
			return this.categorySpecified;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00004C84 File Offset: 0x00002E84
		private void Resetcategory()
		{
			this.categorySpecified = false;
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00004C90 File Offset: 0x00002E90
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00004CBC File Offset: 0x00002EBC
		[ProtoMember(29, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
		public uint paymemberid
		{
			get
			{
				return this._paymemberid ?? 0U;
			}
			set
			{
				this._paymemberid = new uint?(value);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00004CCC File Offset: 0x00002ECC
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00004CEC File Offset: 0x00002EEC
		[XmlIgnore]
		[Browsable(false)]
		public bool paymemberidSpecified
		{
			get
			{
				return this._paymemberid != null;
			}
			set
			{
				bool flag = value == (this._paymemberid == null);
				if (flag)
				{
					this._paymemberid = (value ? new uint?(this.paymemberid) : null);
				}
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004D30 File Offset: 0x00002F30
		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00004D48 File Offset: 0x00002F48
		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00004D54 File Offset: 0x00002F54
		// (set) Token: 0x06000122 RID: 290 RVA: 0x00004D6C File Offset: 0x00002F6C
		[ProtoMember(30, IsRequired = false, Name = "team", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearanceTeam team
		{
			get
			{
				return this._team;
			}
			set
			{
				this._team = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00004D78 File Offset: 0x00002F78
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00004DA4 File Offset: 0x00002FA4
		[ProtoMember(31, IsRequired = false, Name = "specialstate", DataFormat = DataFormat.TwosComplement)]
		public uint specialstate
		{
			get
			{
				return this._specialstate ?? 0U;
			}
			set
			{
				this._specialstate = new uint?(value);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00004DB4 File Offset: 0x00002FB4
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00004DD4 File Offset: 0x00002FD4
		[XmlIgnore]
		[Browsable(false)]
		public bool specialstateSpecified
		{
			get
			{
				return this._specialstate != null;
			}
			set
			{
				bool flag = value == (this._specialstate == null);
				if (flag)
				{
					this._specialstate = (value ? new uint?(this.specialstate) : null);
				}
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00004E18 File Offset: 0x00003018
		private bool ShouldSerializespecialstate()
		{
			return this.specialstateSpecified;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00004E30 File Offset: 0x00003030
		private void Resetspecialstate()
		{
			this.specialstateSpecified = false;
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00004E3C File Offset: 0x0000303C
		[ProtoMember(32, Name = "artifact", DataFormat = DataFormat.Default)]
		public List<Item> artifact
		{
			get
			{
				return this._artifact;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00004E54 File Offset: 0x00003054
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00004E80 File Offset: 0x00003080
		[ProtoMember(33, IsRequired = false, Name = "mobshieldable", DataFormat = DataFormat.Default)]
		public bool mobshieldable
		{
			get
			{
				return this._mobshieldable ?? false;
			}
			set
			{
				this._mobshieldable = new bool?(value);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00004E90 File Offset: 0x00003090
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00004EB0 File Offset: 0x000030B0
		[XmlIgnore]
		[Browsable(false)]
		public bool mobshieldableSpecified
		{
			get
			{
				return this._mobshieldable != null;
			}
			set
			{
				bool flag = value == (this._mobshieldable == null);
				if (flag)
				{
					this._mobshieldable = (value ? new bool?(this.mobshieldable) : null);
				}
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00004EF4 File Offset: 0x000030F4
		private bool ShouldSerializemobshieldable()
		{
			return this.mobshieldableSpecified;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00004F0C File Offset: 0x0000310C
		private void Resetmobshieldable()
		{
			this.mobshieldableSpecified = false;
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00004F18 File Offset: 0x00003118
		// (set) Token: 0x06000131 RID: 305 RVA: 0x00004F44 File Offset: 0x00003144
		[ProtoMember(34, IsRequired = false, Name = "forcedisappear", DataFormat = DataFormat.Default)]
		public bool forcedisappear
		{
			get
			{
				return this._forcedisappear ?? false;
			}
			set
			{
				this._forcedisappear = new bool?(value);
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000132 RID: 306 RVA: 0x00004F54 File Offset: 0x00003154
		// (set) Token: 0x06000133 RID: 307 RVA: 0x00004F74 File Offset: 0x00003174
		[XmlIgnore]
		[Browsable(false)]
		public bool forcedisappearSpecified
		{
			get
			{
				return this._forcedisappear != null;
			}
			set
			{
				bool flag = value == (this._forcedisappear == null);
				if (flag)
				{
					this._forcedisappear = (value ? new bool?(this.forcedisappear) : null);
				}
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00004FB8 File Offset: 0x000031B8
		private bool ShouldSerializeforcedisappear()
		{
			return this.forcedisappearSpecified;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00004FD0 File Offset: 0x000031D0
		private void Resetforcedisappear()
		{
			this.forcedisappearSpecified = false;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00004FDC File Offset: 0x000031DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000031 RID: 49
		private ulong? _uID;

		// Token: 0x04000032 RID: 50
		private string _unitName;

		// Token: 0x04000033 RID: 51
		private uint? _unitType;

		// Token: 0x04000034 RID: 52
		private Vec3 _position = null;

		// Token: 0x04000035 RID: 53
		private float? _direction;

		// Token: 0x04000036 RID: 54
		private Attribute _attributes = null;

		// Token: 0x04000037 RID: 55
		private readonly List<uint> _fashion = new List<uint>();

		// Token: 0x04000038 RID: 56
		private uint? _waveID;

		// Token: 0x04000039 RID: 57
		private bool? _isServerControl;

		// Token: 0x0400003A RID: 58
		private readonly List<SkillInfo> _skills = new List<SkillInfo>();

		// Token: 0x0400003B RID: 59
		private readonly List<Item> _equip = new List<Item>();

		// Token: 0x0400003C RID: 60
		private uint? _level;

		// Token: 0x0400003D RID: 61
		private uint? _PowerPoint;

		// Token: 0x0400003E RID: 62
		private readonly List<Item> _emblem = new List<Item>();

		// Token: 0x0400003F RID: 63
		private uint? _fightgroup;

		// Token: 0x04000040 RID: 64
		private readonly List<BuffInfo> _buffs = new List<BuffInfo>();

		// Token: 0x04000041 RID: 65
		private bool? _IsDead;

		// Token: 0x04000042 RID: 66
		private OutLook _outlook = null;

		// Token: 0x04000043 RID: 67
		private uint? _viplevel;

		// Token: 0x04000044 RID: 68
		private uint? _lastlogin;

		// Token: 0x04000045 RID: 69
		private uint? _nickid;

		// Token: 0x04000046 RID: 70
		private bool? _isnewmob;

		// Token: 0x04000047 RID: 71
		private readonly List<uint> _bindskills = new List<uint>();

		// Token: 0x04000048 RID: 72
		private AllBuffsInfo _allbuffsinfo = null;

		// Token: 0x04000049 RID: 73
		private readonly List<SpriteInfo> _sprites = new List<SpriteInfo>();

		// Token: 0x0400004A RID: 74
		private PetSingle _pet = null;

		// Token: 0x0400004B RID: 75
		private ulong? _hostid;

		// Token: 0x0400004C RID: 76
		private EntityCategory? _category;

		// Token: 0x0400004D RID: 77
		private uint? _paymemberid;

		// Token: 0x0400004E RID: 78
		private UnitAppearanceTeam _team = null;

		// Token: 0x0400004F RID: 79
		private uint? _specialstate;

		// Token: 0x04000050 RID: 80
		private readonly List<Item> _artifact = new List<Item>();

		// Token: 0x04000051 RID: 81
		private bool? _mobshieldable;

		// Token: 0x04000052 RID: 82
		private bool? _forcedisappear;

		// Token: 0x04000053 RID: 83
		private IExtension extensionObject;
	}
}
