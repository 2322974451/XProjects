using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006E0 RID: 1760
	[ProtoContract(Name = "GCFRoleBrief")]
	[Serializable]
	public class GCFRoleBrief : IExtensible
	{
		// Token: 0x1700252D RID: 9517
		// (get) Token: 0x06007569 RID: 30057 RVA: 0x000E0A18 File Offset: 0x000DEC18
		// (set) Token: 0x0600756A RID: 30058 RVA: 0x000E0A44 File Offset: 0x000DEC44
		[ProtoMember(1, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x1700252E RID: 9518
		// (get) Token: 0x0600756B RID: 30059 RVA: 0x000E0A54 File Offset: 0x000DEC54
		// (set) Token: 0x0600756C RID: 30060 RVA: 0x000E0A74 File Offset: 0x000DEC74
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x0600756D RID: 30061 RVA: 0x000E0AB8 File Offset: 0x000DECB8
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x0600756E RID: 30062 RVA: 0x000E0AD0 File Offset: 0x000DECD0
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x1700252F RID: 9519
		// (get) Token: 0x0600756F RID: 30063 RVA: 0x000E0ADC File Offset: 0x000DECDC
		// (set) Token: 0x06007570 RID: 30064 RVA: 0x000E0B09 File Offset: 0x000DED09
		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x17002530 RID: 9520
		// (get) Token: 0x06007571 RID: 30065 RVA: 0x000E0B18 File Offset: 0x000DED18
		// (set) Token: 0x06007572 RID: 30066 RVA: 0x000E0B38 File Offset: 0x000DED38
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x06007573 RID: 30067 RVA: 0x000E0B7C File Offset: 0x000DED7C
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06007574 RID: 30068 RVA: 0x000E0B94 File Offset: 0x000DED94
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x17002531 RID: 9521
		// (get) Token: 0x06007575 RID: 30069 RVA: 0x000E0BA0 File Offset: 0x000DEDA0
		// (set) Token: 0x06007576 RID: 30070 RVA: 0x000E0BC1 File Offset: 0x000DEDC1
		[ProtoMember(3, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x17002532 RID: 9522
		// (get) Token: 0x06007577 RID: 30071 RVA: 0x000E0BCC File Offset: 0x000DEDCC
		// (set) Token: 0x06007578 RID: 30072 RVA: 0x000E0BE8 File Offset: 0x000DEDE8
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x06007579 RID: 30073 RVA: 0x000E0C18 File Offset: 0x000DEE18
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x0600757A RID: 30074 RVA: 0x000E0C30 File Offset: 0x000DEE30
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x17002533 RID: 9523
		// (get) Token: 0x0600757B RID: 30075 RVA: 0x000E0C3C File Offset: 0x000DEE3C
		// (set) Token: 0x0600757C RID: 30076 RVA: 0x000E0C68 File Offset: 0x000DEE68
		[ProtoMember(4, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public uint killcount
		{
			get
			{
				return this._killcount ?? 0U;
			}
			set
			{
				this._killcount = new uint?(value);
			}
		}

		// Token: 0x17002534 RID: 9524
		// (get) Token: 0x0600757D RID: 30077 RVA: 0x000E0C78 File Offset: 0x000DEE78
		// (set) Token: 0x0600757E RID: 30078 RVA: 0x000E0C98 File Offset: 0x000DEE98
		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new uint?(this.killcount) : null);
				}
			}
		}

		// Token: 0x0600757F RID: 30079 RVA: 0x000E0CDC File Offset: 0x000DEEDC
		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		// Token: 0x06007580 RID: 30080 RVA: 0x000E0CF4 File Offset: 0x000DEEF4
		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		// Token: 0x17002535 RID: 9525
		// (get) Token: 0x06007581 RID: 30081 RVA: 0x000E0D00 File Offset: 0x000DEF00
		// (set) Token: 0x06007582 RID: 30082 RVA: 0x000E0D2C File Offset: 0x000DEF2C
		[ProtoMember(5, IsRequired = false, Name = "occupycount", DataFormat = DataFormat.TwosComplement)]
		public uint occupycount
		{
			get
			{
				return this._occupycount ?? 0U;
			}
			set
			{
				this._occupycount = new uint?(value);
			}
		}

		// Token: 0x17002536 RID: 9526
		// (get) Token: 0x06007583 RID: 30083 RVA: 0x000E0D3C File Offset: 0x000DEF3C
		// (set) Token: 0x06007584 RID: 30084 RVA: 0x000E0D5C File Offset: 0x000DEF5C
		[XmlIgnore]
		[Browsable(false)]
		public bool occupycountSpecified
		{
			get
			{
				return this._occupycount != null;
			}
			set
			{
				bool flag = value == (this._occupycount == null);
				if (flag)
				{
					this._occupycount = (value ? new uint?(this.occupycount) : null);
				}
			}
		}

		// Token: 0x06007585 RID: 30085 RVA: 0x000E0DA0 File Offset: 0x000DEFA0
		private bool ShouldSerializeoccupycount()
		{
			return this.occupycountSpecified;
		}

		// Token: 0x06007586 RID: 30086 RVA: 0x000E0DB8 File Offset: 0x000DEFB8
		private void Resetoccupycount()
		{
			this.occupycountSpecified = false;
		}

		// Token: 0x17002537 RID: 9527
		// (get) Token: 0x06007587 RID: 30087 RVA: 0x000E0DC4 File Offset: 0x000DEFC4
		// (set) Token: 0x06007588 RID: 30088 RVA: 0x000E0DF0 File Offset: 0x000DEFF0
		[ProtoMember(6, IsRequired = false, Name = "feats", DataFormat = DataFormat.TwosComplement)]
		public uint feats
		{
			get
			{
				return this._feats ?? 0U;
			}
			set
			{
				this._feats = new uint?(value);
			}
		}

		// Token: 0x17002538 RID: 9528
		// (get) Token: 0x06007589 RID: 30089 RVA: 0x000E0E00 File Offset: 0x000DF000
		// (set) Token: 0x0600758A RID: 30090 RVA: 0x000E0E20 File Offset: 0x000DF020
		[XmlIgnore]
		[Browsable(false)]
		public bool featsSpecified
		{
			get
			{
				return this._feats != null;
			}
			set
			{
				bool flag = value == (this._feats == null);
				if (flag)
				{
					this._feats = (value ? new uint?(this.feats) : null);
				}
			}
		}

		// Token: 0x0600758B RID: 30091 RVA: 0x000E0E64 File Offset: 0x000DF064
		private bool ShouldSerializefeats()
		{
			return this.featsSpecified;
		}

		// Token: 0x0600758C RID: 30092 RVA: 0x000E0E7C File Offset: 0x000DF07C
		private void Resetfeats()
		{
			this.featsSpecified = false;
		}

		// Token: 0x0600758D RID: 30093 RVA: 0x000E0E88 File Offset: 0x000DF088
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BDC RID: 7132
		private uint? _rank;

		// Token: 0x04001BDD RID: 7133
		private ulong? _roleID;

		// Token: 0x04001BDE RID: 7134
		private string _rolename;

		// Token: 0x04001BDF RID: 7135
		private uint? _killcount;

		// Token: 0x04001BE0 RID: 7136
		private uint? _occupycount;

		// Token: 0x04001BE1 RID: 7137
		private uint? _feats;

		// Token: 0x04001BE2 RID: 7138
		private IExtension extensionObject;
	}
}
