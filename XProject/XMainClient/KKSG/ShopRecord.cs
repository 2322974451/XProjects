using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005FA RID: 1530
	[ProtoContract(Name = "ShopRecord")]
	[Serializable]
	public class ShopRecord : IExtensible
	{
		// Token: 0x17001C7D RID: 7293
		// (get) Token: 0x06005B1A RID: 23322 RVA: 0x000AD758 File Offset: 0x000AB958
		// (set) Token: 0x06005B1B RID: 23323 RVA: 0x000AD784 File Offset: 0x000AB984
		[ProtoMember(1, IsRequired = false, Name = "dayupdate", DataFormat = DataFormat.TwosComplement)]
		public uint dayupdate
		{
			get
			{
				return this._dayupdate ?? 0U;
			}
			set
			{
				this._dayupdate = new uint?(value);
			}
		}

		// Token: 0x17001C7E RID: 7294
		// (get) Token: 0x06005B1C RID: 23324 RVA: 0x000AD794 File Offset: 0x000AB994
		// (set) Token: 0x06005B1D RID: 23325 RVA: 0x000AD7B4 File Offset: 0x000AB9B4
		[XmlIgnore]
		[Browsable(false)]
		public bool dayupdateSpecified
		{
			get
			{
				return this._dayupdate != null;
			}
			set
			{
				bool flag = value == (this._dayupdate == null);
				if (flag)
				{
					this._dayupdate = (value ? new uint?(this.dayupdate) : null);
				}
			}
		}

		// Token: 0x06005B1E RID: 23326 RVA: 0x000AD7F8 File Offset: 0x000AB9F8
		private bool ShouldSerializedayupdate()
		{
			return this.dayupdateSpecified;
		}

		// Token: 0x06005B1F RID: 23327 RVA: 0x000AD810 File Offset: 0x000ABA10
		private void Resetdayupdate()
		{
			this.dayupdateSpecified = false;
		}

		// Token: 0x17001C7F RID: 7295
		// (get) Token: 0x06005B20 RID: 23328 RVA: 0x000AD81C File Offset: 0x000ABA1C
		[ProtoMember(2, Name = "shops", DataFormat = DataFormat.Default)]
		public List<ShopRecordOne> shops
		{
			get
			{
				return this._shops;
			}
		}

		// Token: 0x17001C80 RID: 7296
		// (get) Token: 0x06005B21 RID: 23329 RVA: 0x000AD834 File Offset: 0x000ABA34
		// (set) Token: 0x06005B22 RID: 23330 RVA: 0x000AD860 File Offset: 0x000ABA60
		[ProtoMember(3, IsRequired = false, Name = "weekupdate", DataFormat = DataFormat.TwosComplement)]
		public uint weekupdate
		{
			get
			{
				return this._weekupdate ?? 0U;
			}
			set
			{
				this._weekupdate = new uint?(value);
			}
		}

		// Token: 0x17001C81 RID: 7297
		// (get) Token: 0x06005B23 RID: 23331 RVA: 0x000AD870 File Offset: 0x000ABA70
		// (set) Token: 0x06005B24 RID: 23332 RVA: 0x000AD890 File Offset: 0x000ABA90
		[XmlIgnore]
		[Browsable(false)]
		public bool weekupdateSpecified
		{
			get
			{
				return this._weekupdate != null;
			}
			set
			{
				bool flag = value == (this._weekupdate == null);
				if (flag)
				{
					this._weekupdate = (value ? new uint?(this.weekupdate) : null);
				}
			}
		}

		// Token: 0x06005B25 RID: 23333 RVA: 0x000AD8D4 File Offset: 0x000ABAD4
		private bool ShouldSerializeweekupdate()
		{
			return this.weekupdateSpecified;
		}

		// Token: 0x06005B26 RID: 23334 RVA: 0x000AD8EC File Offset: 0x000ABAEC
		private void Resetweekupdate()
		{
			this.weekupdateSpecified = false;
		}

		// Token: 0x06005B27 RID: 23335 RVA: 0x000AD8F8 File Offset: 0x000ABAF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400162A RID: 5674
		private uint? _dayupdate;

		// Token: 0x0400162B RID: 5675
		private readonly List<ShopRecordOne> _shops = new List<ShopRecordOne>();

		// Token: 0x0400162C RID: 5676
		private uint? _weekupdate;

		// Token: 0x0400162D RID: 5677
		private IExtension extensionObject;
	}
}
