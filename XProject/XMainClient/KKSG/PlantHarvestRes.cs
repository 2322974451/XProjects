using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200025D RID: 605
	[ProtoContract(Name = "PlantHarvestRes")]
	[Serializable]
	public class PlantHarvestRes : IExtensible
	{
		// Token: 0x17000A8E RID: 2702
		// (get) Token: 0x060021E3 RID: 8675 RVA: 0x000424A4 File Offset: 0x000406A4
		// (set) Token: 0x060021E4 RID: 8676 RVA: 0x000424D0 File Offset: 0x000406D0
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

		// Token: 0x17000A8F RID: 2703
		// (get) Token: 0x060021E5 RID: 8677 RVA: 0x000424E0 File Offset: 0x000406E0
		// (set) Token: 0x060021E6 RID: 8678 RVA: 0x00042500 File Offset: 0x00040700
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

		// Token: 0x060021E7 RID: 8679 RVA: 0x00042544 File Offset: 0x00040744
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060021E8 RID: 8680 RVA: 0x0004255C File Offset: 0x0004075C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000A90 RID: 2704
		// (get) Token: 0x060021E9 RID: 8681 RVA: 0x00042568 File Offset: 0x00040768
		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x17000A91 RID: 2705
		// (get) Token: 0x060021EA RID: 8682 RVA: 0x00042580 File Offset: 0x00040780
		// (set) Token: 0x060021EB RID: 8683 RVA: 0x000425AC File Offset: 0x000407AC
		[ProtoMember(3, IsRequired = false, Name = "harvest", DataFormat = DataFormat.Default)]
		public bool harvest
		{
			get
			{
				return this._harvest ?? false;
			}
			set
			{
				this._harvest = new bool?(value);
			}
		}

		// Token: 0x17000A92 RID: 2706
		// (get) Token: 0x060021EC RID: 8684 RVA: 0x000425BC File Offset: 0x000407BC
		// (set) Token: 0x060021ED RID: 8685 RVA: 0x000425DC File Offset: 0x000407DC
		[XmlIgnore]
		[Browsable(false)]
		public bool harvestSpecified
		{
			get
			{
				return this._harvest != null;
			}
			set
			{
				bool flag = value == (this._harvest == null);
				if (flag)
				{
					this._harvest = (value ? new bool?(this.harvest) : null);
				}
			}
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x00042620 File Offset: 0x00040820
		private bool ShouldSerializeharvest()
		{
			return this.harvestSpecified;
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x00042638 File Offset: 0x00040838
		private void Resetharvest()
		{
			this.harvestSpecified = false;
		}

		// Token: 0x17000A93 RID: 2707
		// (get) Token: 0x060021F0 RID: 8688 RVA: 0x00042644 File Offset: 0x00040844
		// (set) Token: 0x060021F1 RID: 8689 RVA: 0x00042670 File Offset: 0x00040870
		[ProtoMember(4, IsRequired = false, Name = "extra", DataFormat = DataFormat.Default)]
		public bool extra
		{
			get
			{
				return this._extra ?? false;
			}
			set
			{
				this._extra = new bool?(value);
			}
		}

		// Token: 0x17000A94 RID: 2708
		// (get) Token: 0x060021F2 RID: 8690 RVA: 0x00042680 File Offset: 0x00040880
		// (set) Token: 0x060021F3 RID: 8691 RVA: 0x000426A0 File Offset: 0x000408A0
		[XmlIgnore]
		[Browsable(false)]
		public bool extraSpecified
		{
			get
			{
				return this._extra != null;
			}
			set
			{
				bool flag = value == (this._extra == null);
				if (flag)
				{
					this._extra = (value ? new bool?(this.extra) : null);
				}
			}
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x000426E4 File Offset: 0x000408E4
		private bool ShouldSerializeextra()
		{
			return this.extraSpecified;
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x000426FC File Offset: 0x000408FC
		private void Resetextra()
		{
			this.extraSpecified = false;
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x00042708 File Offset: 0x00040908
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000869 RID: 2153
		private ErrorCode? _result;

		// Token: 0x0400086A RID: 2154
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x0400086B RID: 2155
		private bool? _harvest;

		// Token: 0x0400086C RID: 2156
		private bool? _extra;

		// Token: 0x0400086D RID: 2157
		private IExtension extensionObject;
	}
}
