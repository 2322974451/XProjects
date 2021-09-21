using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000028 RID: 40
	[ProtoContract(Name = "SkillChangedData")]
	[Serializable]
	public class SkillChangedData : IExtensible
	{
		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00007EC0 File Offset: 0x000060C0
		[ProtoMember(1, Name = "newSkill", DataFormat = DataFormat.TwosComplement)]
		public List<uint> newSkill
		{
			get
			{
				return this._newSkill;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060002BB RID: 699 RVA: 0x00007ED8 File Offset: 0x000060D8
		[ProtoMember(2, Name = "newSkillLevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> newSkillLevel
		{
			get
			{
				return this._newSkillLevel;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00007EF0 File Offset: 0x000060F0
		[ProtoMember(3, Name = "removeSkill", DataFormat = DataFormat.TwosComplement)]
		public List<uint> removeSkill
		{
			get
			{
				return this._removeSkill;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060002BD RID: 701 RVA: 0x00007F08 File Offset: 0x00006108
		[ProtoMember(4, Name = "changedSkillHash", DataFormat = DataFormat.TwosComplement)]
		public List<uint> changedSkillHash
		{
			get
			{
				return this._changedSkillHash;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00007F20 File Offset: 0x00006120
		[ProtoMember(5, Name = "changedSkillLevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> changedSkillLevel
		{
			get
			{
				return this._changedSkillLevel;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060002BF RID: 703 RVA: 0x00007F38 File Offset: 0x00006138
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x00007F64 File Offset: 0x00006164
		[ProtoMember(6, IsRequired = false, Name = "skillpoint", DataFormat = DataFormat.TwosComplement)]
		public int skillpoint
		{
			get
			{
				return this._skillpoint ?? 0;
			}
			set
			{
				this._skillpoint = new int?(value);
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x00007F74 File Offset: 0x00006174
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x00007F94 File Offset: 0x00006194
		[XmlIgnore]
		[Browsable(false)]
		public bool skillpointSpecified
		{
			get
			{
				return this._skillpoint != null;
			}
			set
			{
				bool flag = value == (this._skillpoint == null);
				if (flag)
				{
					this._skillpoint = (value ? new int?(this.skillpoint) : null);
				}
			}
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00007FD8 File Offset: 0x000061D8
		private bool ShouldSerializeskillpoint()
		{
			return this.skillpointSpecified;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00007FF0 File Offset: 0x000061F0
		private void Resetskillpoint()
		{
			this.skillpointSpecified = false;
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x00007FFC File Offset: 0x000061FC
		[ProtoMember(7, Name = "skillSlot", DataFormat = DataFormat.TwosComplement)]
		public List<uint> skillSlot
		{
			get
			{
				return this._skillSlot;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00008014 File Offset: 0x00006214
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00008040 File Offset: 0x00006240
		[ProtoMember(8, IsRequired = false, Name = "skillType", DataFormat = DataFormat.TwosComplement)]
		public int skillType
		{
			get
			{
				return this._skillType ?? 0;
			}
			set
			{
				this._skillType = new int?(value);
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00008050 File Offset: 0x00006250
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00008070 File Offset: 0x00006270
		[XmlIgnore]
		[Browsable(false)]
		public bool skillTypeSpecified
		{
			get
			{
				return this._skillType != null;
			}
			set
			{
				bool flag = value == (this._skillType == null);
				if (flag)
				{
					this._skillType = (value ? new int?(this.skillType) : null);
				}
			}
		}

		// Token: 0x060002CA RID: 714 RVA: 0x000080B4 File Offset: 0x000062B4
		private bool ShouldSerializeskillType()
		{
			return this.skillTypeSpecified;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x000080CC File Offset: 0x000062CC
		private void ResetskillType()
		{
			this.skillTypeSpecified = false;
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060002CC RID: 716 RVA: 0x000080D8 File Offset: 0x000062D8
		// (set) Token: 0x060002CD RID: 717 RVA: 0x00008104 File Offset: 0x00006304
		[ProtoMember(9, IsRequired = false, Name = "skillpointtwo", DataFormat = DataFormat.TwosComplement)]
		public uint skillpointtwo
		{
			get
			{
				return this._skillpointtwo ?? 0U;
			}
			set
			{
				this._skillpointtwo = new uint?(value);
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060002CE RID: 718 RVA: 0x00008114 File Offset: 0x00006314
		// (set) Token: 0x060002CF RID: 719 RVA: 0x00008134 File Offset: 0x00006334
		[XmlIgnore]
		[Browsable(false)]
		public bool skillpointtwoSpecified
		{
			get
			{
				return this._skillpointtwo != null;
			}
			set
			{
				bool flag = value == (this._skillpointtwo == null);
				if (flag)
				{
					this._skillpointtwo = (value ? new uint?(this.skillpointtwo) : null);
				}
			}
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00008178 File Offset: 0x00006378
		private bool ShouldSerializeskillpointtwo()
		{
			return this.skillpointtwoSpecified;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00008190 File Offset: 0x00006390
		private void Resetskillpointtwo()
		{
			this.skillpointtwoSpecified = false;
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x0000819C File Offset: 0x0000639C
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x000081C8 File Offset: 0x000063C8
		[ProtoMember(10, IsRequired = false, Name = "awakepoint", DataFormat = DataFormat.TwosComplement)]
		public uint awakepoint
		{
			get
			{
				return this._awakepoint ?? 0U;
			}
			set
			{
				this._awakepoint = new uint?(value);
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x000081D8 File Offset: 0x000063D8
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x000081F8 File Offset: 0x000063F8
		[XmlIgnore]
		[Browsable(false)]
		public bool awakepointSpecified
		{
			get
			{
				return this._awakepoint != null;
			}
			set
			{
				bool flag = value == (this._awakepoint == null);
				if (flag)
				{
					this._awakepoint = (value ? new uint?(this.awakepoint) : null);
				}
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000823C File Offset: 0x0000643C
		private bool ShouldSerializeawakepoint()
		{
			return this.awakepointSpecified;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00008254 File Offset: 0x00006454
		private void Resetawakepoint()
		{
			this.awakepointSpecified = false;
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00008260 File Offset: 0x00006460
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x0000828C File Offset: 0x0000648C
		[ProtoMember(11, IsRequired = false, Name = "awakepointtwo", DataFormat = DataFormat.TwosComplement)]
		public uint awakepointtwo
		{
			get
			{
				return this._awakepointtwo ?? 0U;
			}
			set
			{
				this._awakepointtwo = new uint?(value);
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060002DA RID: 730 RVA: 0x0000829C File Offset: 0x0000649C
		// (set) Token: 0x060002DB RID: 731 RVA: 0x000082BC File Offset: 0x000064BC
		[XmlIgnore]
		[Browsable(false)]
		public bool awakepointtwoSpecified
		{
			get
			{
				return this._awakepointtwo != null;
			}
			set
			{
				bool flag = value == (this._awakepointtwo == null);
				if (flag)
				{
					this._awakepointtwo = (value ? new uint?(this.awakepointtwo) : null);
				}
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00008300 File Offset: 0x00006500
		private bool ShouldSerializeawakepointtwo()
		{
			return this.awakepointtwoSpecified;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00008318 File Offset: 0x00006518
		private void Resetawakepointtwo()
		{
			this.awakepointtwoSpecified = false;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00008324 File Offset: 0x00006524
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000B8 RID: 184
		private readonly List<uint> _newSkill = new List<uint>();

		// Token: 0x040000B9 RID: 185
		private readonly List<uint> _newSkillLevel = new List<uint>();

		// Token: 0x040000BA RID: 186
		private readonly List<uint> _removeSkill = new List<uint>();

		// Token: 0x040000BB RID: 187
		private readonly List<uint> _changedSkillHash = new List<uint>();

		// Token: 0x040000BC RID: 188
		private readonly List<uint> _changedSkillLevel = new List<uint>();

		// Token: 0x040000BD RID: 189
		private int? _skillpoint;

		// Token: 0x040000BE RID: 190
		private readonly List<uint> _skillSlot = new List<uint>();

		// Token: 0x040000BF RID: 191
		private int? _skillType;

		// Token: 0x040000C0 RID: 192
		private uint? _skillpointtwo;

		// Token: 0x040000C1 RID: 193
		private uint? _awakepoint;

		// Token: 0x040000C2 RID: 194
		private uint? _awakepointtwo;

		// Token: 0x040000C3 RID: 195
		private IExtension extensionObject;
	}
}
