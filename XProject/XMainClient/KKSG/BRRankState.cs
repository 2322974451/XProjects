using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005EE RID: 1518
	[ProtoContract(Name = "BRRankState")]
	[Serializable]
	public class BRRankState : IExtensible
	{
		// Token: 0x17001C34 RID: 7220
		// (get) Token: 0x06005A39 RID: 23097 RVA: 0x000ABC28 File Offset: 0x000A9E28
		// (set) Token: 0x06005A3A RID: 23098 RVA: 0x000ABC54 File Offset: 0x000A9E54
		[ProtoMember(1, IsRequired = false, Name = "confid", DataFormat = DataFormat.TwosComplement)]
		public int confid
		{
			get
			{
				return this._confid ?? 0;
			}
			set
			{
				this._confid = new int?(value);
			}
		}

		// Token: 0x17001C35 RID: 7221
		// (get) Token: 0x06005A3B RID: 23099 RVA: 0x000ABC64 File Offset: 0x000A9E64
		// (set) Token: 0x06005A3C RID: 23100 RVA: 0x000ABC84 File Offset: 0x000A9E84
		[XmlIgnore]
		[Browsable(false)]
		public bool confidSpecified
		{
			get
			{
				return this._confid != null;
			}
			set
			{
				bool flag = value == (this._confid == null);
				if (flag)
				{
					this._confid = (value ? new int?(this.confid) : null);
				}
			}
		}

		// Token: 0x06005A3D RID: 23101 RVA: 0x000ABCC8 File Offset: 0x000A9EC8
		private bool ShouldSerializeconfid()
		{
			return this.confidSpecified;
		}

		// Token: 0x06005A3E RID: 23102 RVA: 0x000ABCE0 File Offset: 0x000A9EE0
		private void Resetconfid()
		{
			this.confidSpecified = false;
		}

		// Token: 0x17001C36 RID: 7222
		// (get) Token: 0x06005A3F RID: 23103 RVA: 0x000ABCEC File Offset: 0x000A9EEC
		// (set) Token: 0x06005A40 RID: 23104 RVA: 0x000ABD18 File Offset: 0x000A9F18
		[ProtoMember(2, IsRequired = false, Name = "brbid1", DataFormat = DataFormat.TwosComplement)]
		public int brbid1
		{
			get
			{
				return this._brbid1 ?? 0;
			}
			set
			{
				this._brbid1 = new int?(value);
			}
		}

		// Token: 0x17001C37 RID: 7223
		// (get) Token: 0x06005A41 RID: 23105 RVA: 0x000ABD28 File Offset: 0x000A9F28
		// (set) Token: 0x06005A42 RID: 23106 RVA: 0x000ABD48 File Offset: 0x000A9F48
		[XmlIgnore]
		[Browsable(false)]
		public bool brbid1Specified
		{
			get
			{
				return this._brbid1 != null;
			}
			set
			{
				bool flag = value == (this._brbid1 == null);
				if (flag)
				{
					this._brbid1 = (value ? new int?(this.brbid1) : null);
				}
			}
		}

		// Token: 0x06005A43 RID: 23107 RVA: 0x000ABD8C File Offset: 0x000A9F8C
		private bool ShouldSerializebrbid1()
		{
			return this.brbid1Specified;
		}

		// Token: 0x06005A44 RID: 23108 RVA: 0x000ABDA4 File Offset: 0x000A9FA4
		private void Resetbrbid1()
		{
			this.brbid1Specified = false;
		}

		// Token: 0x17001C38 RID: 7224
		// (get) Token: 0x06005A45 RID: 23109 RVA: 0x000ABDB0 File Offset: 0x000A9FB0
		// (set) Token: 0x06005A46 RID: 23110 RVA: 0x000ABDDC File Offset: 0x000A9FDC
		[ProtoMember(3, IsRequired = false, Name = "brbid2", DataFormat = DataFormat.TwosComplement)]
		public int brbid2
		{
			get
			{
				return this._brbid2 ?? 0;
			}
			set
			{
				this._brbid2 = new int?(value);
			}
		}

		// Token: 0x17001C39 RID: 7225
		// (get) Token: 0x06005A47 RID: 23111 RVA: 0x000ABDEC File Offset: 0x000A9FEC
		// (set) Token: 0x06005A48 RID: 23112 RVA: 0x000ABE0C File Offset: 0x000AA00C
		[XmlIgnore]
		[Browsable(false)]
		public bool brbid2Specified
		{
			get
			{
				return this._brbid2 != null;
			}
			set
			{
				bool flag = value == (this._brbid2 == null);
				if (flag)
				{
					this._brbid2 = (value ? new int?(this.brbid2) : null);
				}
			}
		}

		// Token: 0x06005A49 RID: 23113 RVA: 0x000ABE50 File Offset: 0x000AA050
		private bool ShouldSerializebrbid2()
		{
			return this.brbid2Specified;
		}

		// Token: 0x06005A4A RID: 23114 RVA: 0x000ABE68 File Offset: 0x000AA068
		private void Resetbrbid2()
		{
			this.brbid2Specified = false;
		}

		// Token: 0x17001C3A RID: 7226
		// (get) Token: 0x06005A4B RID: 23115 RVA: 0x000ABE74 File Offset: 0x000AA074
		// (set) Token: 0x06005A4C RID: 23116 RVA: 0x000ABEA0 File Offset: 0x000AA0A0
		[ProtoMember(4, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001C3B RID: 7227
		// (get) Token: 0x06005A4D RID: 23117 RVA: 0x000ABEB0 File Offset: 0x000AA0B0
		// (set) Token: 0x06005A4E RID: 23118 RVA: 0x000ABED0 File Offset: 0x000AA0D0
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

		// Token: 0x06005A4F RID: 23119 RVA: 0x000ABF14 File Offset: 0x000AA114
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06005A50 RID: 23120 RVA: 0x000ABF2C File Offset: 0x000AA12C
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x06005A51 RID: 23121 RVA: 0x000ABF38 File Offset: 0x000AA138
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040015F5 RID: 5621
		private int? _confid;

		// Token: 0x040015F6 RID: 5622
		private int? _brbid1;

		// Token: 0x040015F7 RID: 5623
		private int? _brbid2;

		// Token: 0x040015F8 RID: 5624
		private int? _rank;

		// Token: 0x040015F9 RID: 5625
		private IExtension extensionObject;
	}
}
