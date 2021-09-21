using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003F9 RID: 1017
	[ProtoContract(Name = "GiftIbReqGoodsArg")]
	[Serializable]
	public class GiftIbReqGoodsArg : IExtensible
	{
		// Token: 0x17001092 RID: 4242
		// (get) Token: 0x060035E5 RID: 13797 RVA: 0x00067418 File Offset: 0x00065618
		// (set) Token: 0x060035E6 RID: 13798 RVA: 0x00067439 File Offset: 0x00065639
		[ProtoMember(1, IsRequired = false, Name = "orderid", DataFormat = DataFormat.Default)]
		public string orderid
		{
			get
			{
				return this._orderid ?? "";
			}
			set
			{
				this._orderid = value;
			}
		}

		// Token: 0x17001093 RID: 4243
		// (get) Token: 0x060035E7 RID: 13799 RVA: 0x00067444 File Offset: 0x00065644
		// (set) Token: 0x060035E8 RID: 13800 RVA: 0x00067460 File Offset: 0x00065660
		[XmlIgnore]
		[Browsable(false)]
		public bool orderidSpecified
		{
			get
			{
				return this._orderid != null;
			}
			set
			{
				bool flag = value == (this._orderid == null);
				if (flag)
				{
					this._orderid = (value ? this.orderid : null);
				}
			}
		}

		// Token: 0x060035E9 RID: 13801 RVA: 0x00067490 File Offset: 0x00065690
		private bool ShouldSerializeorderid()
		{
			return this.orderidSpecified;
		}

		// Token: 0x060035EA RID: 13802 RVA: 0x000674A8 File Offset: 0x000656A8
		private void Resetorderid()
		{
			this.orderidSpecified = false;
		}

		// Token: 0x060035EB RID: 13803 RVA: 0x000674B4 File Offset: 0x000656B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D64 RID: 3428
		private string _orderid;

		// Token: 0x04000D65 RID: 3429
		private IExtension extensionObject;
	}
}
