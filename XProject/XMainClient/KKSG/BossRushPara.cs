using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000202 RID: 514
	[ProtoContract(Name = "BossRushPara")]
	[Serializable]
	public class BossRushPara : IExtensible
	{
		// Token: 0x17000925 RID: 2341
		// (get) Token: 0x06001D2D RID: 7469 RVA: 0x00039700 File Offset: 0x00037900
		// (set) Token: 0x06001D2E RID: 7470 RVA: 0x0003972C File Offset: 0x0003792C
		[ProtoMember(1, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public int rank
		{
			get
			{
				return this._rank ?? 0;
			}
			set
			{
				this._rank = new int?(value);
			}
		}

		// Token: 0x17000926 RID: 2342
		// (get) Token: 0x06001D2F RID: 7471 RVA: 0x0003973C File Offset: 0x0003793C
		// (set) Token: 0x06001D30 RID: 7472 RVA: 0x0003975C File Offset: 0x0003795C
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
					this._rank = (value ? new int?(this.rank) : null);
				}
			}
		}

		// Token: 0x06001D31 RID: 7473 RVA: 0x000397A0 File Offset: 0x000379A0
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06001D32 RID: 7474 RVA: 0x000397B8 File Offset: 0x000379B8
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17000927 RID: 2343
		// (get) Token: 0x06001D33 RID: 7475 RVA: 0x000397C4 File Offset: 0x000379C4
		// (set) Token: 0x06001D34 RID: 7476 RVA: 0x000397F0 File Offset: 0x000379F0
		[ProtoMember(2, IsRequired = false, Name = "win", DataFormat = DataFormat.Default)]
		public bool win
		{
			get
			{
				return this._win ?? false;
			}
			set
			{
				this._win = new bool?(value);
			}
		}

		// Token: 0x17000928 RID: 2344
		// (get) Token: 0x06001D35 RID: 7477 RVA: 0x00039800 File Offset: 0x00037A00
		// (set) Token: 0x06001D36 RID: 7478 RVA: 0x00039820 File Offset: 0x00037A20
		[XmlIgnore]
		[Browsable(false)]
		public bool winSpecified
		{
			get
			{
				return this._win != null;
			}
			set
			{
				bool flag = value == (this._win == null);
				if (flag)
				{
					this._win = (value ? new bool?(this.win) : null);
				}
			}
		}

		// Token: 0x06001D37 RID: 7479 RVA: 0x00039864 File Offset: 0x00037A64
		private bool ShouldSerializewin()
		{
			return this.winSpecified;
		}

		// Token: 0x06001D38 RID: 7480 RVA: 0x0003987C File Offset: 0x00037A7C
		private void Resetwin()
		{
			this.winSpecified = false;
		}

		// Token: 0x06001D39 RID: 7481 RVA: 0x00039888 File Offset: 0x00037A88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000749 RID: 1865
		private int? _rank;

		// Token: 0x0400074A RID: 1866
		private bool? _win;

		// Token: 0x0400074B RID: 1867
		private IExtension extensionObject;
	}
}
