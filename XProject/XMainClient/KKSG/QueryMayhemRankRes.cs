using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200043E RID: 1086
	[ProtoContract(Name = "QueryMayhemRankRes")]
	[Serializable]
	public class QueryMayhemRankRes : IExtensible
	{
		// Token: 0x17001194 RID: 4500
		// (get) Token: 0x06003947 RID: 14663 RVA: 0x0006D95C File Offset: 0x0006BB5C
		// (set) Token: 0x06003948 RID: 14664 RVA: 0x0006D988 File Offset: 0x0006BB88
		[ProtoMember(1, IsRequired = false, Name = "err", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode err
		{
			get
			{
				return this._err ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._err = new ErrorCode?(value);
			}
		}

		// Token: 0x17001195 RID: 4501
		// (get) Token: 0x06003949 RID: 14665 RVA: 0x0006D998 File Offset: 0x0006BB98
		// (set) Token: 0x0600394A RID: 14666 RVA: 0x0006D9B8 File Offset: 0x0006BBB8
		[XmlIgnore]
		[Browsable(false)]
		public bool errSpecified
		{
			get
			{
				return this._err != null;
			}
			set
			{
				bool flag = value == (this._err == null);
				if (flag)
				{
					this._err = (value ? new ErrorCode?(this.err) : null);
				}
			}
		}

		// Token: 0x0600394B RID: 14667 RVA: 0x0006D9FC File Offset: 0x0006BBFC
		private bool ShouldSerializeerr()
		{
			return this.errSpecified;
		}

		// Token: 0x0600394C RID: 14668 RVA: 0x0006DA14 File Offset: 0x0006BC14
		private void Reseterr()
		{
			this.errSpecified = false;
		}

		// Token: 0x17001196 RID: 4502
		// (get) Token: 0x0600394D RID: 14669 RVA: 0x0006DA20 File Offset: 0x0006BC20
		// (set) Token: 0x0600394E RID: 14670 RVA: 0x0006DA4C File Offset: 0x0006BC4C
		[ProtoMember(2, IsRequired = false, Name = "selfrank", DataFormat = DataFormat.TwosComplement)]
		public int selfrank
		{
			get
			{
				return this._selfrank ?? 0;
			}
			set
			{
				this._selfrank = new int?(value);
			}
		}

		// Token: 0x17001197 RID: 4503
		// (get) Token: 0x0600394F RID: 14671 RVA: 0x0006DA5C File Offset: 0x0006BC5C
		// (set) Token: 0x06003950 RID: 14672 RVA: 0x0006DA7C File Offset: 0x0006BC7C
		[XmlIgnore]
		[Browsable(false)]
		public bool selfrankSpecified
		{
			get
			{
				return this._selfrank != null;
			}
			set
			{
				bool flag = value == (this._selfrank == null);
				if (flag)
				{
					this._selfrank = (value ? new int?(this.selfrank) : null);
				}
			}
		}

		// Token: 0x06003951 RID: 14673 RVA: 0x0006DAC0 File Offset: 0x0006BCC0
		private bool ShouldSerializeselfrank()
		{
			return this.selfrankSpecified;
		}

		// Token: 0x06003952 RID: 14674 RVA: 0x0006DAD8 File Offset: 0x0006BCD8
		private void Resetselfrank()
		{
			this.selfrankSpecified = false;
		}

		// Token: 0x17001198 RID: 4504
		// (get) Token: 0x06003953 RID: 14675 RVA: 0x0006DAE4 File Offset: 0x0006BCE4
		[ProtoMember(3, Name = "rank", DataFormat = DataFormat.Default)]
		public List<MayhemRankInfo> rank
		{
			get
			{
				return this._rank;
			}
		}

		// Token: 0x17001199 RID: 4505
		// (get) Token: 0x06003954 RID: 14676 RVA: 0x0006DAFC File Offset: 0x0006BCFC
		// (set) Token: 0x06003955 RID: 14677 RVA: 0x0006DB28 File Offset: 0x0006BD28
		[ProtoMember(4, IsRequired = false, Name = "infight", DataFormat = DataFormat.Default)]
		public bool infight
		{
			get
			{
				return this._infight ?? false;
			}
			set
			{
				this._infight = new bool?(value);
			}
		}

		// Token: 0x1700119A RID: 4506
		// (get) Token: 0x06003956 RID: 14678 RVA: 0x0006DB38 File Offset: 0x0006BD38
		// (set) Token: 0x06003957 RID: 14679 RVA: 0x0006DB58 File Offset: 0x0006BD58
		[XmlIgnore]
		[Browsable(false)]
		public bool infightSpecified
		{
			get
			{
				return this._infight != null;
			}
			set
			{
				bool flag = value == (this._infight == null);
				if (flag)
				{
					this._infight = (value ? new bool?(this.infight) : null);
				}
			}
		}

		// Token: 0x06003958 RID: 14680 RVA: 0x0006DB9C File Offset: 0x0006BD9C
		private bool ShouldSerializeinfight()
		{
			return this.infightSpecified;
		}

		// Token: 0x06003959 RID: 14681 RVA: 0x0006DBB4 File Offset: 0x0006BDB4
		private void Resetinfight()
		{
			this.infightSpecified = false;
		}

		// Token: 0x1700119B RID: 4507
		// (get) Token: 0x0600395A RID: 14682 RVA: 0x0006DBC0 File Offset: 0x0006BDC0
		// (set) Token: 0x0600395B RID: 14683 RVA: 0x0006DBD8 File Offset: 0x0006BDD8
		[ProtoMember(5, IsRequired = false, Name = "selfinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MayhemRankInfo selfinfo
		{
			get
			{
				return this._selfinfo;
			}
			set
			{
				this._selfinfo = value;
			}
		}

		// Token: 0x1700119C RID: 4508
		// (get) Token: 0x0600395C RID: 14684 RVA: 0x0006DBE4 File Offset: 0x0006BDE4
		// (set) Token: 0x0600395D RID: 14685 RVA: 0x0006DC10 File Offset: 0x0006BE10
		[ProtoMember(6, IsRequired = false, Name = "gamezoneid", DataFormat = DataFormat.TwosComplement)]
		public uint gamezoneid
		{
			get
			{
				return this._gamezoneid ?? 0U;
			}
			set
			{
				this._gamezoneid = new uint?(value);
			}
		}

		// Token: 0x1700119D RID: 4509
		// (get) Token: 0x0600395E RID: 14686 RVA: 0x0006DC20 File Offset: 0x0006BE20
		// (set) Token: 0x0600395F RID: 14687 RVA: 0x0006DC40 File Offset: 0x0006BE40
		[XmlIgnore]
		[Browsable(false)]
		public bool gamezoneidSpecified
		{
			get
			{
				return this._gamezoneid != null;
			}
			set
			{
				bool flag = value == (this._gamezoneid == null);
				if (flag)
				{
					this._gamezoneid = (value ? new uint?(this.gamezoneid) : null);
				}
			}
		}

		// Token: 0x06003960 RID: 14688 RVA: 0x0006DC84 File Offset: 0x0006BE84
		private bool ShouldSerializegamezoneid()
		{
			return this.gamezoneidSpecified;
		}

		// Token: 0x06003961 RID: 14689 RVA: 0x0006DC9C File Offset: 0x0006BE9C
		private void Resetgamezoneid()
		{
			this.gamezoneidSpecified = false;
		}

		// Token: 0x06003962 RID: 14690 RVA: 0x0006DCA8 File Offset: 0x0006BEA8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E37 RID: 3639
		private ErrorCode? _err;

		// Token: 0x04000E38 RID: 3640
		private int? _selfrank;

		// Token: 0x04000E39 RID: 3641
		private readonly List<MayhemRankInfo> _rank = new List<MayhemRankInfo>();

		// Token: 0x04000E3A RID: 3642
		private bool? _infight;

		// Token: 0x04000E3B RID: 3643
		private MayhemRankInfo _selfinfo = null;

		// Token: 0x04000E3C RID: 3644
		private uint? _gamezoneid;

		// Token: 0x04000E3D RID: 3645
		private IExtension extensionObject;
	}
}
