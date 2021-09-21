using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006DF RID: 1759
	[ProtoContract(Name = "GCFGuildBrief")]
	[Serializable]
	public class GCFGuildBrief : IExtensible
	{
		// Token: 0x17002523 RID: 9507
		// (get) Token: 0x06007549 RID: 30025 RVA: 0x000E064C File Offset: 0x000DE84C
		// (set) Token: 0x0600754A RID: 30026 RVA: 0x000E0679 File Offset: 0x000DE879
		[ProtoMember(1, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		// Token: 0x17002524 RID: 9508
		// (get) Token: 0x0600754B RID: 30027 RVA: 0x000E0688 File Offset: 0x000DE888
		// (set) Token: 0x0600754C RID: 30028 RVA: 0x000E06A8 File Offset: 0x000DE8A8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		// Token: 0x0600754D RID: 30029 RVA: 0x000E06EC File Offset: 0x000DE8EC
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x0600754E RID: 30030 RVA: 0x000E0704 File Offset: 0x000DE904
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x17002525 RID: 9509
		// (get) Token: 0x0600754F RID: 30031 RVA: 0x000E0710 File Offset: 0x000DE910
		// (set) Token: 0x06007550 RID: 30032 RVA: 0x000E0731 File Offset: 0x000DE931
		[ProtoMember(2, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		// Token: 0x17002526 RID: 9510
		// (get) Token: 0x06007551 RID: 30033 RVA: 0x000E073C File Offset: 0x000DE93C
		// (set) Token: 0x06007552 RID: 30034 RVA: 0x000E0758 File Offset: 0x000DE958
		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		// Token: 0x06007553 RID: 30035 RVA: 0x000E0788 File Offset: 0x000DE988
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x06007554 RID: 30036 RVA: 0x000E07A0 File Offset: 0x000DE9A0
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x17002527 RID: 9511
		// (get) Token: 0x06007555 RID: 30037 RVA: 0x000E07AC File Offset: 0x000DE9AC
		// (set) Token: 0x06007556 RID: 30038 RVA: 0x000E07D8 File Offset: 0x000DE9D8
		[ProtoMember(3, IsRequired = false, Name = "guildicon", DataFormat = DataFormat.TwosComplement)]
		public uint guildicon
		{
			get
			{
				return this._guildicon ?? 0U;
			}
			set
			{
				this._guildicon = new uint?(value);
			}
		}

		// Token: 0x17002528 RID: 9512
		// (get) Token: 0x06007557 RID: 30039 RVA: 0x000E07E8 File Offset: 0x000DE9E8
		// (set) Token: 0x06007558 RID: 30040 RVA: 0x000E0808 File Offset: 0x000DEA08
		[XmlIgnore]
		[Browsable(false)]
		public bool guildiconSpecified
		{
			get
			{
				return this._guildicon != null;
			}
			set
			{
				bool flag = value == (this._guildicon == null);
				if (flag)
				{
					this._guildicon = (value ? new uint?(this.guildicon) : null);
				}
			}
		}

		// Token: 0x06007559 RID: 30041 RVA: 0x000E084C File Offset: 0x000DEA4C
		private bool ShouldSerializeguildicon()
		{
			return this.guildiconSpecified;
		}

		// Token: 0x0600755A RID: 30042 RVA: 0x000E0864 File Offset: 0x000DEA64
		private void Resetguildicon()
		{
			this.guildiconSpecified = false;
		}

		// Token: 0x17002529 RID: 9513
		// (get) Token: 0x0600755B RID: 30043 RVA: 0x000E0870 File Offset: 0x000DEA70
		// (set) Token: 0x0600755C RID: 30044 RVA: 0x000E089C File Offset: 0x000DEA9C
		[ProtoMember(4, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x1700252A RID: 9514
		// (get) Token: 0x0600755D RID: 30045 RVA: 0x000E08AC File Offset: 0x000DEAAC
		// (set) Token: 0x0600755E RID: 30046 RVA: 0x000E08CC File Offset: 0x000DEACC
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x0600755F RID: 30047 RVA: 0x000E0910 File Offset: 0x000DEB10
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06007560 RID: 30048 RVA: 0x000E0928 File Offset: 0x000DEB28
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x1700252B RID: 9515
		// (get) Token: 0x06007561 RID: 30049 RVA: 0x000E0934 File Offset: 0x000DEB34
		// (set) Token: 0x06007562 RID: 30050 RVA: 0x000E0960 File Offset: 0x000DEB60
		[ProtoMember(5, IsRequired = false, Name = "group", DataFormat = DataFormat.TwosComplement)]
		public int group
		{
			get
			{
				return this._group ?? 0;
			}
			set
			{
				this._group = new int?(value);
			}
		}

		// Token: 0x1700252C RID: 9516
		// (get) Token: 0x06007563 RID: 30051 RVA: 0x000E0970 File Offset: 0x000DEB70
		// (set) Token: 0x06007564 RID: 30052 RVA: 0x000E0990 File Offset: 0x000DEB90
		[XmlIgnore]
		[Browsable(false)]
		public bool groupSpecified
		{
			get
			{
				return this._group != null;
			}
			set
			{
				bool flag = value == (this._group == null);
				if (flag)
				{
					this._group = (value ? new int?(this.group) : null);
				}
			}
		}

		// Token: 0x06007565 RID: 30053 RVA: 0x000E09D4 File Offset: 0x000DEBD4
		private bool ShouldSerializegroup()
		{
			return this.groupSpecified;
		}

		// Token: 0x06007566 RID: 30054 RVA: 0x000E09EC File Offset: 0x000DEBEC
		private void Resetgroup()
		{
			this.groupSpecified = false;
		}

		// Token: 0x06007567 RID: 30055 RVA: 0x000E09F8 File Offset: 0x000DEBF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BD6 RID: 7126
		private ulong? _guildid;

		// Token: 0x04001BD7 RID: 7127
		private string _guildname;

		// Token: 0x04001BD8 RID: 7128
		private uint? _guildicon;

		// Token: 0x04001BD9 RID: 7129
		private uint? _point;

		// Token: 0x04001BDA RID: 7130
		private int? _group;

		// Token: 0x04001BDB RID: 7131
		private IExtension extensionObject;
	}
}
