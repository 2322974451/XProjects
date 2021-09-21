using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000705 RID: 1797
	[ProtoContract(Name = "RankOnce")]
	[Serializable]
	public class RankOnce : IExtensible
	{
		// Token: 0x1700267D RID: 9853
		// (get) Token: 0x06007980 RID: 31104 RVA: 0x000E8480 File Offset: 0x000E6680
		// (set) Token: 0x06007981 RID: 31105 RVA: 0x000E84AC File Offset: 0x000E66AC
		[ProtoMember(1, IsRequired = false, Name = "season", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700267E RID: 9854
		// (get) Token: 0x06007982 RID: 31106 RVA: 0x000E84BC File Offset: 0x000E66BC
		// (set) Token: 0x06007983 RID: 31107 RVA: 0x000E84DC File Offset: 0x000E66DC
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

		// Token: 0x06007984 RID: 31108 RVA: 0x000E8520 File Offset: 0x000E6720
		private bool ShouldSerializeseason()
		{
			return this.seasonSpecified;
		}

		// Token: 0x06007985 RID: 31109 RVA: 0x000E8538 File Offset: 0x000E6738
		private void Resetseason()
		{
			this.seasonSpecified = false;
		}

		// Token: 0x1700267F RID: 9855
		// (get) Token: 0x06007986 RID: 31110 RVA: 0x000E8544 File Offset: 0x000E6744
		// (set) Token: 0x06007987 RID: 31111 RVA: 0x000E8570 File Offset: 0x000E6770
		[ProtoMember(2, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002680 RID: 9856
		// (get) Token: 0x06007988 RID: 31112 RVA: 0x000E8580 File Offset: 0x000E6780
		// (set) Token: 0x06007989 RID: 31113 RVA: 0x000E85A0 File Offset: 0x000E67A0
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

		// Token: 0x0600798A RID: 31114 RVA: 0x000E85E4 File Offset: 0x000E67E4
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x0600798B RID: 31115 RVA: 0x000E85FC File Offset: 0x000E67FC
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x0600798C RID: 31116 RVA: 0x000E8608 File Offset: 0x000E6808
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CB5 RID: 7349
		private uint? _season;

		// Token: 0x04001CB6 RID: 7350
		private uint? _rank;

		// Token: 0x04001CB7 RID: 7351
		private IExtension extensionObject;
	}
}
