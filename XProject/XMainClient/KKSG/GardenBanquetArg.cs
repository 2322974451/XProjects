using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000272 RID: 626
	[ProtoContract(Name = "GardenBanquetArg")]
	[Serializable]
	public class GardenBanquetArg : IExtensible
	{
		// Token: 0x17000AD5 RID: 2773
		// (get) Token: 0x060022D4 RID: 8916 RVA: 0x0004405C File Offset: 0x0004225C
		// (set) Token: 0x060022D5 RID: 8917 RVA: 0x00044088 File Offset: 0x00042288
		[ProtoMember(1, IsRequired = false, Name = "banquet_id", DataFormat = DataFormat.TwosComplement)]
		public uint banquet_id
		{
			get
			{
				return this._banquet_id ?? 0U;
			}
			set
			{
				this._banquet_id = new uint?(value);
			}
		}

		// Token: 0x17000AD6 RID: 2774
		// (get) Token: 0x060022D6 RID: 8918 RVA: 0x00044098 File Offset: 0x00042298
		// (set) Token: 0x060022D7 RID: 8919 RVA: 0x000440B8 File Offset: 0x000422B8
		[XmlIgnore]
		[Browsable(false)]
		public bool banquet_idSpecified
		{
			get
			{
				return this._banquet_id != null;
			}
			set
			{
				bool flag = value == (this._banquet_id == null);
				if (flag)
				{
					this._banquet_id = (value ? new uint?(this.banquet_id) : null);
				}
			}
		}

		// Token: 0x060022D8 RID: 8920 RVA: 0x000440FC File Offset: 0x000422FC
		private bool ShouldSerializebanquet_id()
		{
			return this.banquet_idSpecified;
		}

		// Token: 0x060022D9 RID: 8921 RVA: 0x00044114 File Offset: 0x00042314
		private void Resetbanquet_id()
		{
			this.banquet_idSpecified = false;
		}

		// Token: 0x060022DA RID: 8922 RVA: 0x00044120 File Offset: 0x00042320
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008A5 RID: 2213
		private uint? _banquet_id;

		// Token: 0x040008A6 RID: 2214
		private IExtension extensionObject;
	}
}
