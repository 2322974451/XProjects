using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000333 RID: 819
	[ProtoContract(Name = "GCFFightInfoRes")]
	[Serializable]
	public class GCFFightInfoRes : IExtensible
	{
		// Token: 0x17000DFB RID: 3579
		// (get) Token: 0x06002D10 RID: 11536 RVA: 0x000573B0 File Offset: 0x000555B0
		[ProtoMember(1, Name = "guilds", DataFormat = DataFormat.Default)]
		public List<GCFGuildBrief> guilds
		{
			get
			{
				return this._guilds;
			}
		}

		// Token: 0x17000DFC RID: 3580
		// (get) Token: 0x06002D11 RID: 11537 RVA: 0x000573C8 File Offset: 0x000555C8
		[ProtoMember(2, Name = "JvDians", DataFormat = DataFormat.Default)]
		public List<GCFJvDianInfo> JvDians
		{
			get
			{
				return this._JvDians;
			}
		}

		// Token: 0x17000DFD RID: 3581
		// (get) Token: 0x06002D12 RID: 11538 RVA: 0x000573E0 File Offset: 0x000555E0
		// (set) Token: 0x06002D13 RID: 11539 RVA: 0x0005740C File Offset: 0x0005560C
		[ProtoMember(3, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x17000DFE RID: 3582
		// (get) Token: 0x06002D14 RID: 11540 RVA: 0x0005741C File Offset: 0x0005561C
		// (set) Token: 0x06002D15 RID: 11541 RVA: 0x0005743C File Offset: 0x0005563C
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x06002D16 RID: 11542 RVA: 0x00057480 File Offset: 0x00055680
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06002D17 RID: 11543 RVA: 0x00057498 File Offset: 0x00055698
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x17000DFF RID: 3583
		// (get) Token: 0x06002D18 RID: 11544 RVA: 0x000574A4 File Offset: 0x000556A4
		// (set) Token: 0x06002D19 RID: 11545 RVA: 0x000574D0 File Offset: 0x000556D0
		[ProtoMember(4, IsRequired = false, Name = "mygroup", DataFormat = DataFormat.TwosComplement)]
		public int mygroup
		{
			get
			{
				return this._mygroup ?? 0;
			}
			set
			{
				this._mygroup = new int?(value);
			}
		}

		// Token: 0x17000E00 RID: 3584
		// (get) Token: 0x06002D1A RID: 11546 RVA: 0x000574E0 File Offset: 0x000556E0
		// (set) Token: 0x06002D1B RID: 11547 RVA: 0x00057500 File Offset: 0x00055700
		[XmlIgnore]
		[Browsable(false)]
		public bool mygroupSpecified
		{
			get
			{
				return this._mygroup != null;
			}
			set
			{
				bool flag = value == (this._mygroup == null);
				if (flag)
				{
					this._mygroup = (value ? new int?(this.mygroup) : null);
				}
			}
		}

		// Token: 0x06002D1C RID: 11548 RVA: 0x00057544 File Offset: 0x00055744
		private bool ShouldSerializemygroup()
		{
			return this.mygroupSpecified;
		}

		// Token: 0x06002D1D RID: 11549 RVA: 0x0005755C File Offset: 0x0005575C
		private void Resetmygroup()
		{
			this.mygroupSpecified = false;
		}

		// Token: 0x17000E01 RID: 3585
		// (get) Token: 0x06002D1E RID: 11550 RVA: 0x00057568 File Offset: 0x00055768
		// (set) Token: 0x06002D1F RID: 11551 RVA: 0x00057580 File Offset: 0x00055780
		[ProtoMember(5, IsRequired = false, Name = "myinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GCFRoleBrief myinfo
		{
			get
			{
				return this._myinfo;
			}
			set
			{
				this._myinfo = value;
			}
		}

		// Token: 0x06002D20 RID: 11552 RVA: 0x0005758C File Offset: 0x0005578C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B2D RID: 2861
		private readonly List<GCFGuildBrief> _guilds = new List<GCFGuildBrief>();

		// Token: 0x04000B2E RID: 2862
		private readonly List<GCFJvDianInfo> _JvDians = new List<GCFJvDianInfo>();

		// Token: 0x04000B2F RID: 2863
		private uint? _lefttime;

		// Token: 0x04000B30 RID: 2864
		private int? _mygroup;

		// Token: 0x04000B31 RID: 2865
		private GCFRoleBrief _myinfo = null;

		// Token: 0x04000B32 RID: 2866
		private IExtension extensionObject;
	}
}
