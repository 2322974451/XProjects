using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000689 RID: 1673
	[ProtoContract(Name = "QARoomRankData")]
	[Serializable]
	public class QARoomRankData : IExtensible
	{
		// Token: 0x17002220 RID: 8736
		// (get) Token: 0x06006BD1 RID: 27601 RVA: 0x000CE3EC File Offset: 0x000CC5EC
		// (set) Token: 0x06006BD2 RID: 27602 RVA: 0x000CE419 File Offset: 0x000CC619
		[ProtoMember(1, IsRequired = false, Name = "uuid", DataFormat = DataFormat.TwosComplement)]
		public ulong uuid
		{
			get
			{
				return this._uuid ?? 0UL;
			}
			set
			{
				this._uuid = new ulong?(value);
			}
		}

		// Token: 0x17002221 RID: 8737
		// (get) Token: 0x06006BD3 RID: 27603 RVA: 0x000CE428 File Offset: 0x000CC628
		// (set) Token: 0x06006BD4 RID: 27604 RVA: 0x000CE448 File Offset: 0x000CC648
		[XmlIgnore]
		[Browsable(false)]
		public bool uuidSpecified
		{
			get
			{
				return this._uuid != null;
			}
			set
			{
				bool flag = value == (this._uuid == null);
				if (flag)
				{
					this._uuid = (value ? new ulong?(this.uuid) : null);
				}
			}
		}

		// Token: 0x06006BD5 RID: 27605 RVA: 0x000CE48C File Offset: 0x000CC68C
		private bool ShouldSerializeuuid()
		{
			return this.uuidSpecified;
		}

		// Token: 0x06006BD6 RID: 27606 RVA: 0x000CE4A4 File Offset: 0x000CC6A4
		private void Resetuuid()
		{
			this.uuidSpecified = false;
		}

		// Token: 0x17002222 RID: 8738
		// (get) Token: 0x06006BD7 RID: 27607 RVA: 0x000CE4B0 File Offset: 0x000CC6B0
		// (set) Token: 0x06006BD8 RID: 27608 RVA: 0x000CE4DC File Offset: 0x000CC6DC
		[ProtoMember(2, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x17002223 RID: 8739
		// (get) Token: 0x06006BD9 RID: 27609 RVA: 0x000CE4EC File Offset: 0x000CC6EC
		// (set) Token: 0x06006BDA RID: 27610 RVA: 0x000CE50C File Offset: 0x000CC70C
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x06006BDB RID: 27611 RVA: 0x000CE550 File Offset: 0x000CC750
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06006BDC RID: 27612 RVA: 0x000CE568 File Offset: 0x000CC768
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x06006BDD RID: 27613 RVA: 0x000CE574 File Offset: 0x000CC774
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019EA RID: 6634
		private ulong? _uuid;

		// Token: 0x040019EB RID: 6635
		private uint? _score;

		// Token: 0x040019EC RID: 6636
		private IExtension extensionObject;
	}
}
