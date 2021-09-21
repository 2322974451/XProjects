using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000019 RID: 25
	[ProtoContract(Name = "LevelChanged")]
	[Serializable]
	public class LevelChanged : IExtensible
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00006B24 File Offset: 0x00004D24
		// (set) Token: 0x06000216 RID: 534 RVA: 0x00006B50 File Offset: 0x00004D50
		[ProtoMember(1, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000217 RID: 535 RVA: 0x00006B60 File Offset: 0x00004D60
		// (set) Token: 0x06000218 RID: 536 RVA: 0x00006B80 File Offset: 0x00004D80
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

		// Token: 0x06000219 RID: 537 RVA: 0x00006BC4 File Offset: 0x00004DC4
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00006BDC File Offset: 0x00004DDC
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600021B RID: 539 RVA: 0x00006BE8 File Offset: 0x00004DE8
		// (set) Token: 0x0600021C RID: 540 RVA: 0x00006C15 File Offset: 0x00004E15
		[ProtoMember(2, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public ulong exp
		{
			get
			{
				return this._exp ?? 0UL;
			}
			set
			{
				this._exp = new ulong?(value);
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600021D RID: 541 RVA: 0x00006C24 File Offset: 0x00004E24
		// (set) Token: 0x0600021E RID: 542 RVA: 0x00006C44 File Offset: 0x00004E44
		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new ulong?(this.exp) : null);
				}
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00006C88 File Offset: 0x00004E88
		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00006CA0 File Offset: 0x00004EA0
		private void Resetexp()
		{
			this.expSpecified = false;
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00006CAC File Offset: 0x00004EAC
		// (set) Token: 0x06000222 RID: 546 RVA: 0x00006CD9 File Offset: 0x00004ED9
		[ProtoMember(3, IsRequired = false, Name = "maxexp", DataFormat = DataFormat.TwosComplement)]
		public ulong maxexp
		{
			get
			{
				return this._maxexp ?? 0UL;
			}
			set
			{
				this._maxexp = new ulong?(value);
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000223 RID: 547 RVA: 0x00006CE8 File Offset: 0x00004EE8
		// (set) Token: 0x06000224 RID: 548 RVA: 0x00006D08 File Offset: 0x00004F08
		[XmlIgnore]
		[Browsable(false)]
		public bool maxexpSpecified
		{
			get
			{
				return this._maxexp != null;
			}
			set
			{
				bool flag = value == (this._maxexp == null);
				if (flag)
				{
					this._maxexp = (value ? new ulong?(this.maxexp) : null);
				}
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00006D4C File Offset: 0x00004F4C
		private bool ShouldSerializemaxexp()
		{
			return this.maxexpSpecified;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00006D64 File Offset: 0x00004F64
		private void Resetmaxexp()
		{
			this.maxexpSpecified = false;
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00006D70 File Offset: 0x00004F70
		[ProtoMember(4, Name = "attrid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> attrid
		{
			get
			{
				return this._attrid;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000228 RID: 552 RVA: 0x00006D88 File Offset: 0x00004F88
		[ProtoMember(5, Name = "attroldvalue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> attroldvalue
		{
			get
			{
				return this._attroldvalue;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00006DA0 File Offset: 0x00004FA0
		[ProtoMember(6, Name = "attrnewvalue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> attrnewvalue
		{
			get
			{
				return this._attrnewvalue;
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00006DB8 File Offset: 0x00004FB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000086 RID: 134
		private uint? _level;

		// Token: 0x04000087 RID: 135
		private ulong? _exp;

		// Token: 0x04000088 RID: 136
		private ulong? _maxexp;

		// Token: 0x04000089 RID: 137
		private readonly List<uint> _attrid = new List<uint>();

		// Token: 0x0400008A RID: 138
		private readonly List<uint> _attroldvalue = new List<uint>();

		// Token: 0x0400008B RID: 139
		private readonly List<uint> _attrnewvalue = new List<uint>();

		// Token: 0x0400008C RID: 140
		private IExtension extensionObject;
	}
}
