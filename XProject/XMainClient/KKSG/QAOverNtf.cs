using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000158 RID: 344
	[ProtoContract(Name = "QAOverNtf")]
	[Serializable]
	public class QAOverNtf : IExtensible
	{
		// Token: 0x170006B3 RID: 1715
		// (get) Token: 0x06001513 RID: 5395 RVA: 0x0002A6B4 File Offset: 0x000288B4
		// (set) Token: 0x06001514 RID: 5396 RVA: 0x0002A6E0 File Offset: 0x000288E0
		[ProtoMember(1, IsRequired = false, Name = "total", DataFormat = DataFormat.TwosComplement)]
		public uint total
		{
			get
			{
				return this._total ?? 0U;
			}
			set
			{
				this._total = new uint?(value);
			}
		}

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x06001515 RID: 5397 RVA: 0x0002A6F0 File Offset: 0x000288F0
		// (set) Token: 0x06001516 RID: 5398 RVA: 0x0002A710 File Offset: 0x00028910
		[XmlIgnore]
		[Browsable(false)]
		public bool totalSpecified
		{
			get
			{
				return this._total != null;
			}
			set
			{
				bool flag = value == (this._total == null);
				if (flag)
				{
					this._total = (value ? new uint?(this.total) : null);
				}
			}
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x0002A754 File Offset: 0x00028954
		private bool ShouldSerializetotal()
		{
			return this.totalSpecified;
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x0002A76C File Offset: 0x0002896C
		private void Resettotal()
		{
			this.totalSpecified = false;
		}

		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x06001519 RID: 5401 RVA: 0x0002A778 File Offset: 0x00028978
		// (set) Token: 0x0600151A RID: 5402 RVA: 0x0002A7A4 File Offset: 0x000289A4
		[ProtoMember(2, IsRequired = false, Name = "correct", DataFormat = DataFormat.TwosComplement)]
		public uint correct
		{
			get
			{
				return this._correct ?? 0U;
			}
			set
			{
				this._correct = new uint?(value);
			}
		}

		// Token: 0x170006B6 RID: 1718
		// (get) Token: 0x0600151B RID: 5403 RVA: 0x0002A7B4 File Offset: 0x000289B4
		// (set) Token: 0x0600151C RID: 5404 RVA: 0x0002A7D4 File Offset: 0x000289D4
		[XmlIgnore]
		[Browsable(false)]
		public bool correctSpecified
		{
			get
			{
				return this._correct != null;
			}
			set
			{
				bool flag = value == (this._correct == null);
				if (flag)
				{
					this._correct = (value ? new uint?(this.correct) : null);
				}
			}
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x0002A818 File Offset: 0x00028A18
		private bool ShouldSerializecorrect()
		{
			return this.correctSpecified;
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x0002A830 File Offset: 0x00028A30
		private void Resetcorrect()
		{
			this.correctSpecified = false;
		}

		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x0600151F RID: 5407 RVA: 0x0002A83C File Offset: 0x00028A3C
		[ProtoMember(3, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<ItemBrief> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x0002A854 File Offset: 0x00028A54
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400053A RID: 1338
		private uint? _total;

		// Token: 0x0400053B RID: 1339
		private uint? _correct;

		// Token: 0x0400053C RID: 1340
		private readonly List<ItemBrief> _dataList = new List<ItemBrief>();

		// Token: 0x0400053D RID: 1341
		private IExtension extensionObject;
	}
}
