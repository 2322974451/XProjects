using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000666 RID: 1638
	[ProtoContract(Name = "SkillRecord")]
	[Serializable]
	public class SkillRecord : IExtensible
	{
		// Token: 0x170020A3 RID: 8355
		// (get) Token: 0x06006756 RID: 26454 RVA: 0x000C56D8 File Offset: 0x000C38D8
		[ProtoMember(1, Name = "Skills", DataFormat = DataFormat.Default)]
		public List<SkillInfo> Skills
		{
			get
			{
				return this._Skills;
			}
		}

		// Token: 0x170020A4 RID: 8356
		// (get) Token: 0x06006757 RID: 26455 RVA: 0x000C56F0 File Offset: 0x000C38F0
		[ProtoMember(2, Name = "SkillSlot", DataFormat = DataFormat.TwosComplement)]
		public List<uint> SkillSlot
		{
			get
			{
				return this._SkillSlot;
			}
		}

		// Token: 0x170020A5 RID: 8357
		// (get) Token: 0x06006758 RID: 26456 RVA: 0x000C5708 File Offset: 0x000C3908
		// (set) Token: 0x06006759 RID: 26457 RVA: 0x000C5734 File Offset: 0x000C3934
		[ProtoMember(3, IsRequired = false, Name = "freeresetskill", DataFormat = DataFormat.Default)]
		public bool freeresetskill
		{
			get
			{
				return this._freeresetskill ?? false;
			}
			set
			{
				this._freeresetskill = new bool?(value);
			}
		}

		// Token: 0x170020A6 RID: 8358
		// (get) Token: 0x0600675A RID: 26458 RVA: 0x000C5744 File Offset: 0x000C3944
		// (set) Token: 0x0600675B RID: 26459 RVA: 0x000C5764 File Offset: 0x000C3964
		[XmlIgnore]
		[Browsable(false)]
		public bool freeresetskillSpecified
		{
			get
			{
				return this._freeresetskill != null;
			}
			set
			{
				bool flag = value == (this._freeresetskill == null);
				if (flag)
				{
					this._freeresetskill = (value ? new bool?(this.freeresetskill) : null);
				}
			}
		}

		// Token: 0x0600675C RID: 26460 RVA: 0x000C57A8 File Offset: 0x000C39A8
		private bool ShouldSerializefreeresetskill()
		{
			return this.freeresetskillSpecified;
		}

		// Token: 0x0600675D RID: 26461 RVA: 0x000C57C0 File Offset: 0x000C39C0
		private void Resetfreeresetskill()
		{
			this.freeresetskillSpecified = false;
		}

		// Token: 0x170020A7 RID: 8359
		// (get) Token: 0x0600675E RID: 26462 RVA: 0x000C57CC File Offset: 0x000C39CC
		// (set) Token: 0x0600675F RID: 26463 RVA: 0x000C57F8 File Offset: 0x000C39F8
		[ProtoMember(4, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x170020A8 RID: 8360
		// (get) Token: 0x06006760 RID: 26464 RVA: 0x000C5808 File Offset: 0x000C3A08
		// (set) Token: 0x06006761 RID: 26465 RVA: 0x000C5828 File Offset: 0x000C3A28
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x06006762 RID: 26466 RVA: 0x000C586C File Offset: 0x000C3A6C
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06006763 RID: 26467 RVA: 0x000C5884 File Offset: 0x000C3A84
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x170020A9 RID: 8361
		// (get) Token: 0x06006764 RID: 26468 RVA: 0x000C5890 File Offset: 0x000C3A90
		[ProtoMember(5, Name = "SkillsTwo", DataFormat = DataFormat.Default)]
		public List<SkillInfo> SkillsTwo
		{
			get
			{
				return this._SkillsTwo;
			}
		}

		// Token: 0x170020AA RID: 8362
		// (get) Token: 0x06006765 RID: 26469 RVA: 0x000C58A8 File Offset: 0x000C3AA8
		[ProtoMember(6, Name = "SkillSlotTwo", DataFormat = DataFormat.TwosComplement)]
		public List<uint> SkillSlotTwo
		{
			get
			{
				return this._SkillSlotTwo;
			}
		}

		// Token: 0x170020AB RID: 8363
		// (get) Token: 0x06006766 RID: 26470 RVA: 0x000C58C0 File Offset: 0x000C3AC0
		// (set) Token: 0x06006767 RID: 26471 RVA: 0x000C58EC File Offset: 0x000C3AEC
		[ProtoMember(7, IsRequired = false, Name = "awakepoint", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170020AC RID: 8364
		// (get) Token: 0x06006768 RID: 26472 RVA: 0x000C58FC File Offset: 0x000C3AFC
		// (set) Token: 0x06006769 RID: 26473 RVA: 0x000C591C File Offset: 0x000C3B1C
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

		// Token: 0x0600676A RID: 26474 RVA: 0x000C5960 File Offset: 0x000C3B60
		private bool ShouldSerializeawakepoint()
		{
			return this.awakepointSpecified;
		}

		// Token: 0x0600676B RID: 26475 RVA: 0x000C5978 File Offset: 0x000C3B78
		private void Resetawakepoint()
		{
			this.awakepointSpecified = false;
		}

		// Token: 0x0600676C RID: 26476 RVA: 0x000C5984 File Offset: 0x000C3B84
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018F7 RID: 6391
		private readonly List<SkillInfo> _Skills = new List<SkillInfo>();

		// Token: 0x040018F8 RID: 6392
		private readonly List<uint> _SkillSlot = new List<uint>();

		// Token: 0x040018F9 RID: 6393
		private bool? _freeresetskill;

		// Token: 0x040018FA RID: 6394
		private uint? _index;

		// Token: 0x040018FB RID: 6395
		private readonly List<SkillInfo> _SkillsTwo = new List<SkillInfo>();

		// Token: 0x040018FC RID: 6396
		private readonly List<uint> _SkillSlotTwo = new List<uint>();

		// Token: 0x040018FD RID: 6397
		private uint? _awakepoint;

		// Token: 0x040018FE RID: 6398
		private IExtension extensionObject;
	}
}
