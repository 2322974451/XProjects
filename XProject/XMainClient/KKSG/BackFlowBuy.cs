using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000595 RID: 1429
	[ProtoContract(Name = "BackFlowBuy")]
	[Serializable]
	public class BackFlowBuy : IExtensible
	{
		// Token: 0x1700177A RID: 6010
		// (get) Token: 0x06004C3E RID: 19518 RVA: 0x0009107C File Offset: 0x0008F27C
		// (set) Token: 0x06004C3F RID: 19519 RVA: 0x000910A8 File Offset: 0x0008F2A8
		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x1700177B RID: 6011
		// (get) Token: 0x06004C40 RID: 19520 RVA: 0x000910B8 File Offset: 0x0008F2B8
		// (set) Token: 0x06004C41 RID: 19521 RVA: 0x000910D8 File Offset: 0x0008F2D8
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x06004C42 RID: 19522 RVA: 0x0009111C File Offset: 0x0008F31C
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06004C43 RID: 19523 RVA: 0x00091134 File Offset: 0x0008F334
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x1700177C RID: 6012
		// (get) Token: 0x06004C44 RID: 19524 RVA: 0x00091140 File Offset: 0x0008F340
		// (set) Token: 0x06004C45 RID: 19525 RVA: 0x0009116C File Offset: 0x0008F36C
		[ProtoMember(2, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public uint day
		{
			get
			{
				return this._day ?? 0U;
			}
			set
			{
				this._day = new uint?(value);
			}
		}

		// Token: 0x1700177D RID: 6013
		// (get) Token: 0x06004C46 RID: 19526 RVA: 0x0009117C File Offset: 0x0008F37C
		// (set) Token: 0x06004C47 RID: 19527 RVA: 0x0009119C File Offset: 0x0008F39C
		[XmlIgnore]
		[Browsable(false)]
		public bool daySpecified
		{
			get
			{
				return this._day != null;
			}
			set
			{
				bool flag = value == (this._day == null);
				if (flag)
				{
					this._day = (value ? new uint?(this.day) : null);
				}
			}
		}

		// Token: 0x06004C48 RID: 19528 RVA: 0x000911E0 File Offset: 0x0008F3E0
		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		// Token: 0x06004C49 RID: 19529 RVA: 0x000911F8 File Offset: 0x0008F3F8
		private void Resetday()
		{
			this.daySpecified = false;
		}

		// Token: 0x1700177E RID: 6014
		// (get) Token: 0x06004C4A RID: 19530 RVA: 0x00091204 File Offset: 0x0008F404
		// (set) Token: 0x06004C4B RID: 19531 RVA: 0x00091230 File Offset: 0x0008F430
		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x1700177F RID: 6015
		// (get) Token: 0x06004C4C RID: 19532 RVA: 0x00091240 File Offset: 0x0008F440
		// (set) Token: 0x06004C4D RID: 19533 RVA: 0x00091260 File Offset: 0x0008F460
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06004C4E RID: 19534 RVA: 0x000912A4 File Offset: 0x0008F4A4
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06004C4F RID: 19535 RVA: 0x000912BC File Offset: 0x0008F4BC
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06004C50 RID: 19536 RVA: 0x000912C8 File Offset: 0x0008F4C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012EA RID: 4842
		private uint? _index;

		// Token: 0x040012EB RID: 4843
		private uint? _day;

		// Token: 0x040012EC RID: 4844
		private uint? _count;

		// Token: 0x040012ED RID: 4845
		private IExtension extensionObject;
	}
}
