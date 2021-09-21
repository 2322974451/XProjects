using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000524 RID: 1316
	[ProtoContract(Name = "PayGiftNtfData")]
	[Serializable]
	public class PayGiftNtfData : IExtensible
	{
		// Token: 0x170014AD RID: 5293
		// (get) Token: 0x060043A9 RID: 17321 RVA: 0x00080B80 File Offset: 0x0007ED80
		[ProtoMember(1, Name = "gift", DataFormat = DataFormat.Default)]
		public List<PayGiftRecord> gift
		{
			get
			{
				return this._gift;
			}
		}

		// Token: 0x170014AE RID: 5294
		// (get) Token: 0x060043AA RID: 17322 RVA: 0x00080B98 File Offset: 0x0007ED98
		// (set) Token: 0x060043AB RID: 17323 RVA: 0x00080BC4 File Offset: 0x0007EDC4
		[ProtoMember(2, IsRequired = false, Name = "isShowDetail", DataFormat = DataFormat.Default)]
		public bool isShowDetail
		{
			get
			{
				return this._isShowDetail ?? false;
			}
			set
			{
				this._isShowDetail = new bool?(value);
			}
		}

		// Token: 0x170014AF RID: 5295
		// (get) Token: 0x060043AC RID: 17324 RVA: 0x00080BD4 File Offset: 0x0007EDD4
		// (set) Token: 0x060043AD RID: 17325 RVA: 0x00080BF4 File Offset: 0x0007EDF4
		[XmlIgnore]
		[Browsable(false)]
		public bool isShowDetailSpecified
		{
			get
			{
				return this._isShowDetail != null;
			}
			set
			{
				bool flag = value == (this._isShowDetail == null);
				if (flag)
				{
					this._isShowDetail = (value ? new bool?(this.isShowDetail) : null);
				}
			}
		}

		// Token: 0x060043AE RID: 17326 RVA: 0x00080C38 File Offset: 0x0007EE38
		private bool ShouldSerializeisShowDetail()
		{
			return this.isShowDetailSpecified;
		}

		// Token: 0x060043AF RID: 17327 RVA: 0x00080C50 File Offset: 0x0007EE50
		private void ResetisShowDetail()
		{
			this.isShowDetailSpecified = false;
		}

		// Token: 0x060043B0 RID: 17328 RVA: 0x00080C5C File Offset: 0x0007EE5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010DD RID: 4317
		private readonly List<PayGiftRecord> _gift = new List<PayGiftRecord>();

		// Token: 0x040010DE RID: 4318
		private bool? _isShowDetail;

		// Token: 0x040010DF RID: 4319
		private IExtension extensionObject;
	}
}
