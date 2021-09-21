using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004F0 RID: 1264
	[ProtoContract(Name = "NpcFlArg")]
	[Serializable]
	public class NpcFlArg : IExtensible
	{
		// Token: 0x170013F0 RID: 5104
		// (get) Token: 0x06004130 RID: 16688 RVA: 0x0007C1DC File Offset: 0x0007A3DC
		// (set) Token: 0x06004131 RID: 16689 RVA: 0x0007C208 File Offset: 0x0007A408
		[ProtoMember(1, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public NpcFlReqType reqtype
		{
			get
			{
				return this._reqtype ?? NpcFlReqType.NPCFL_GIVE_GIFT;
			}
			set
			{
				this._reqtype = new NpcFlReqType?(value);
			}
		}

		// Token: 0x170013F1 RID: 5105
		// (get) Token: 0x06004132 RID: 16690 RVA: 0x0007C218 File Offset: 0x0007A418
		// (set) Token: 0x06004133 RID: 16691 RVA: 0x0007C238 File Offset: 0x0007A438
		[XmlIgnore]
		[Browsable(false)]
		public bool reqtypeSpecified
		{
			get
			{
				return this._reqtype != null;
			}
			set
			{
				bool flag = value == (this._reqtype == null);
				if (flag)
				{
					this._reqtype = (value ? new NpcFlReqType?(this.reqtype) : null);
				}
			}
		}

		// Token: 0x06004134 RID: 16692 RVA: 0x0007C27C File Offset: 0x0007A47C
		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		// Token: 0x06004135 RID: 16693 RVA: 0x0007C294 File Offset: 0x0007A494
		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

		// Token: 0x170013F2 RID: 5106
		// (get) Token: 0x06004136 RID: 16694 RVA: 0x0007C2A0 File Offset: 0x0007A4A0
		// (set) Token: 0x06004137 RID: 16695 RVA: 0x0007C2B8 File Offset: 0x0007A4B8
		[ProtoMember(2, IsRequired = false, Name = "likeitem", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public NpcLikeItem likeitem
		{
			get
			{
				return this._likeitem;
			}
			set
			{
				this._likeitem = value;
			}
		}

		// Token: 0x170013F3 RID: 5107
		// (get) Token: 0x06004138 RID: 16696 RVA: 0x0007C2C4 File Offset: 0x0007A4C4
		// (set) Token: 0x06004139 RID: 16697 RVA: 0x0007C2F0 File Offset: 0x0007A4F0
		[ProtoMember(3, IsRequired = false, Name = "npcid", DataFormat = DataFormat.TwosComplement)]
		public uint npcid
		{
			get
			{
				return this._npcid ?? 0U;
			}
			set
			{
				this._npcid = new uint?(value);
			}
		}

		// Token: 0x170013F4 RID: 5108
		// (get) Token: 0x0600413A RID: 16698 RVA: 0x0007C300 File Offset: 0x0007A500
		// (set) Token: 0x0600413B RID: 16699 RVA: 0x0007C320 File Offset: 0x0007A520
		[XmlIgnore]
		[Browsable(false)]
		public bool npcidSpecified
		{
			get
			{
				return this._npcid != null;
			}
			set
			{
				bool flag = value == (this._npcid == null);
				if (flag)
				{
					this._npcid = (value ? new uint?(this.npcid) : null);
				}
			}
		}

		// Token: 0x0600413C RID: 16700 RVA: 0x0007C364 File Offset: 0x0007A564
		private bool ShouldSerializenpcid()
		{
			return this.npcidSpecified;
		}

		// Token: 0x0600413D RID: 16701 RVA: 0x0007C37C File Offset: 0x0007A57C
		private void Resetnpcid()
		{
			this.npcidSpecified = false;
		}

		// Token: 0x170013F5 RID: 5109
		// (get) Token: 0x0600413E RID: 16702 RVA: 0x0007C388 File Offset: 0x0007A588
		// (set) Token: 0x0600413F RID: 16703 RVA: 0x0007C3A0 File Offset: 0x0007A5A0
		[ProtoMember(4, IsRequired = false, Name = "role2npc", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief role2npc
		{
			get
			{
				return this._role2npc;
			}
			set
			{
				this._role2npc = value;
			}
		}

		// Token: 0x170013F6 RID: 5110
		// (get) Token: 0x06004140 RID: 16704 RVA: 0x0007C3AC File Offset: 0x0007A5AC
		// (set) Token: 0x06004141 RID: 16705 RVA: 0x0007C3C4 File Offset: 0x0007A5C4
		[ProtoMember(5, IsRequired = false, Name = "npc2role", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief npc2role
		{
			get
			{
				return this._npc2role;
			}
			set
			{
				this._npc2role = value;
			}
		}

		// Token: 0x170013F7 RID: 5111
		// (get) Token: 0x06004142 RID: 16706 RVA: 0x0007C3D0 File Offset: 0x0007A5D0
		// (set) Token: 0x06004143 RID: 16707 RVA: 0x0007C3FC File Offset: 0x0007A5FC
		[ProtoMember(6, IsRequired = false, Name = "uniteid", DataFormat = DataFormat.TwosComplement)]
		public uint uniteid
		{
			get
			{
				return this._uniteid ?? 0U;
			}
			set
			{
				this._uniteid = new uint?(value);
			}
		}

		// Token: 0x170013F8 RID: 5112
		// (get) Token: 0x06004144 RID: 16708 RVA: 0x0007C40C File Offset: 0x0007A60C
		// (set) Token: 0x06004145 RID: 16709 RVA: 0x0007C42C File Offset: 0x0007A62C
		[XmlIgnore]
		[Browsable(false)]
		public bool uniteidSpecified
		{
			get
			{
				return this._uniteid != null;
			}
			set
			{
				bool flag = value == (this._uniteid == null);
				if (flag)
				{
					this._uniteid = (value ? new uint?(this.uniteid) : null);
				}
			}
		}

		// Token: 0x06004146 RID: 16710 RVA: 0x0007C470 File Offset: 0x0007A670
		private bool ShouldSerializeuniteid()
		{
			return this.uniteidSpecified;
		}

		// Token: 0x06004147 RID: 16711 RVA: 0x0007C488 File Offset: 0x0007A688
		private void Resetuniteid()
		{
			this.uniteidSpecified = false;
		}

		// Token: 0x170013F9 RID: 5113
		// (get) Token: 0x06004148 RID: 16712 RVA: 0x0007C494 File Offset: 0x0007A694
		// (set) Token: 0x06004149 RID: 16713 RVA: 0x0007C4C0 File Offset: 0x0007A6C0
		[ProtoMember(7, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170013FA RID: 5114
		// (get) Token: 0x0600414A RID: 16714 RVA: 0x0007C4D0 File Offset: 0x0007A6D0
		// (set) Token: 0x0600414B RID: 16715 RVA: 0x0007C4F0 File Offset: 0x0007A6F0
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

		// Token: 0x0600414C RID: 16716 RVA: 0x0007C534 File Offset: 0x0007A734
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x0600414D RID: 16717 RVA: 0x0007C54C File Offset: 0x0007A74C
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x0600414E RID: 16718 RVA: 0x0007C558 File Offset: 0x0007A758
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400103F RID: 4159
		private NpcFlReqType? _reqtype;

		// Token: 0x04001040 RID: 4160
		private NpcLikeItem _likeitem = null;

		// Token: 0x04001041 RID: 4161
		private uint? _npcid;

		// Token: 0x04001042 RID: 4162
		private ItemBrief _role2npc = null;

		// Token: 0x04001043 RID: 4163
		private ItemBrief _npc2role = null;

		// Token: 0x04001044 RID: 4164
		private uint? _uniteid;

		// Token: 0x04001045 RID: 4165
		private uint? _level;

		// Token: 0x04001046 RID: 4166
		private IExtension extensionObject;
	}
}
