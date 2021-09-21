using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000703 RID: 1795
	[ProtoContract(Name = "ArenaStarTopRoleData")]
	[Serializable]
	public class ArenaStarTopRoleData : IExtensible
	{
		// Token: 0x17002672 RID: 9842
		// (get) Token: 0x0600795F RID: 31071 RVA: 0x000E80BC File Offset: 0x000E62BC
		// (set) Token: 0x06007960 RID: 31072 RVA: 0x000E80D4 File Offset: 0x000E62D4
		[ProtoMember(1, IsRequired = false, Name = "historydata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ArenaStarHistData historydata
		{
			get
			{
				return this._historydata;
			}
			set
			{
				this._historydata = value;
			}
		}

		// Token: 0x17002673 RID: 9843
		// (get) Token: 0x06007961 RID: 31073 RVA: 0x000E80E0 File Offset: 0x000E62E0
		// (set) Token: 0x06007962 RID: 31074 RVA: 0x000E80F8 File Offset: 0x000E62F8
		[ProtoMember(2, IsRequired = false, Name = "outlook", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleOutLookBrief outlook
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

		// Token: 0x17002674 RID: 9844
		// (get) Token: 0x06007963 RID: 31075 RVA: 0x000E8104 File Offset: 0x000E6304
		// (set) Token: 0x06007964 RID: 31076 RVA: 0x000E8130 File Offset: 0x000E6330
		[ProtoMember(3, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002675 RID: 9845
		// (get) Token: 0x06007965 RID: 31077 RVA: 0x000E8140 File Offset: 0x000E6340
		// (set) Token: 0x06007966 RID: 31078 RVA: 0x000E8160 File Offset: 0x000E6360
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

		// Token: 0x06007967 RID: 31079 RVA: 0x000E81A4 File Offset: 0x000E63A4
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06007968 RID: 31080 RVA: 0x000E81BC File Offset: 0x000E63BC
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17002676 RID: 9846
		// (get) Token: 0x06007969 RID: 31081 RVA: 0x000E81C8 File Offset: 0x000E63C8
		// (set) Token: 0x0600796A RID: 31082 RVA: 0x000E81F4 File Offset: 0x000E63F4
		[ProtoMember(4, IsRequired = false, Name = "season", DataFormat = DataFormat.TwosComplement)]
		public uint season
		{
			get
			{
				return this._season ?? 0U;
			}
			set
			{
				this._season = new uint?(value);
			}
		}

		// Token: 0x17002677 RID: 9847
		// (get) Token: 0x0600796B RID: 31083 RVA: 0x000E8204 File Offset: 0x000E6404
		// (set) Token: 0x0600796C RID: 31084 RVA: 0x000E8224 File Offset: 0x000E6424
		[XmlIgnore]
		[Browsable(false)]
		public bool seasonSpecified
		{
			get
			{
				return this._season != null;
			}
			set
			{
				bool flag = value == (this._season == null);
				if (flag)
				{
					this._season = (value ? new uint?(this.season) : null);
				}
			}
		}

		// Token: 0x0600796D RID: 31085 RVA: 0x000E8268 File Offset: 0x000E6468
		private bool ShouldSerializeseason()
		{
			return this.seasonSpecified;
		}

		// Token: 0x0600796E RID: 31086 RVA: 0x000E8280 File Offset: 0x000E6480
		private void Resetseason()
		{
			this.seasonSpecified = false;
		}

		// Token: 0x0600796F RID: 31087 RVA: 0x000E828C File Offset: 0x000E648C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CAC RID: 7340
		private ArenaStarHistData _historydata = null;

		// Token: 0x04001CAD RID: 7341
		private RoleOutLookBrief _outlook = null;

		// Token: 0x04001CAE RID: 7342
		private uint? _rank;

		// Token: 0x04001CAF RID: 7343
		private uint? _season;

		// Token: 0x04001CB0 RID: 7344
		private IExtension extensionObject;
	}
}
