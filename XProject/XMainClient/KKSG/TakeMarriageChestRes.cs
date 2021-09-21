using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000494 RID: 1172
	[ProtoContract(Name = "TakeMarriageChestRes")]
	[Serializable]
	public class TakeMarriageChestRes : IExtensible
	{
		// Token: 0x170012B5 RID: 4789
		// (get) Token: 0x06003D08 RID: 15624 RVA: 0x0007483C File Offset: 0x00072A3C
		// (set) Token: 0x06003D09 RID: 15625 RVA: 0x00074868 File Offset: 0x00072A68
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x170012B6 RID: 4790
		// (get) Token: 0x06003D0A RID: 15626 RVA: 0x00074878 File Offset: 0x00072A78
		// (set) Token: 0x06003D0B RID: 15627 RVA: 0x00074898 File Offset: 0x00072A98
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06003D0C RID: 15628 RVA: 0x000748DC File Offset: 0x00072ADC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003D0D RID: 15629 RVA: 0x000748F4 File Offset: 0x00072AF4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170012B7 RID: 4791
		// (get) Token: 0x06003D0E RID: 15630 RVA: 0x00074900 File Offset: 0x00072B00
		[ProtoMember(2, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemid
		{
			get
			{
				return this._itemid;
			}
		}

		// Token: 0x170012B8 RID: 4792
		// (get) Token: 0x06003D0F RID: 15631 RVA: 0x00074918 File Offset: 0x00072B18
		[ProtoMember(3, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemcount
		{
			get
			{
				return this._itemcount;
			}
		}

		// Token: 0x170012B9 RID: 4793
		// (get) Token: 0x06003D10 RID: 15632 RVA: 0x00074930 File Offset: 0x00072B30
		// (set) Token: 0x06003D11 RID: 15633 RVA: 0x0007495C File Offset: 0x00072B5C
		[ProtoMember(4, IsRequired = false, Name = "takedchest", DataFormat = DataFormat.TwosComplement)]
		public uint takedchest
		{
			get
			{
				return this._takedchest ?? 0U;
			}
			set
			{
				this._takedchest = new uint?(value);
			}
		}

		// Token: 0x170012BA RID: 4794
		// (get) Token: 0x06003D12 RID: 15634 RVA: 0x0007496C File Offset: 0x00072B6C
		// (set) Token: 0x06003D13 RID: 15635 RVA: 0x0007498C File Offset: 0x00072B8C
		[XmlIgnore]
		[Browsable(false)]
		public bool takedchestSpecified
		{
			get
			{
				return this._takedchest != null;
			}
			set
			{
				bool flag = value == (this._takedchest == null);
				if (flag)
				{
					this._takedchest = (value ? new uint?(this.takedchest) : null);
				}
			}
		}

		// Token: 0x06003D14 RID: 15636 RVA: 0x000749D0 File Offset: 0x00072BD0
		private bool ShouldSerializetakedchest()
		{
			return this.takedchestSpecified;
		}

		// Token: 0x06003D15 RID: 15637 RVA: 0x000749E8 File Offset: 0x00072BE8
		private void Resettakedchest()
		{
			this.takedchestSpecified = false;
		}

		// Token: 0x06003D16 RID: 15638 RVA: 0x000749F4 File Offset: 0x00072BF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F34 RID: 3892
		private ErrorCode? _result;

		// Token: 0x04000F35 RID: 3893
		private readonly List<uint> _itemid = new List<uint>();

		// Token: 0x04000F36 RID: 3894
		private readonly List<uint> _itemcount = new List<uint>();

		// Token: 0x04000F37 RID: 3895
		private uint? _takedchest;

		// Token: 0x04000F38 RID: 3896
		private IExtension extensionObject;
	}
}
