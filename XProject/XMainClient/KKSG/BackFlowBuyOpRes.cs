using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004A0 RID: 1184
	[ProtoContract(Name = "BackFlowBuyOpRes")]
	[Serializable]
	public class BackFlowBuyOpRes : IExtensible
	{
		// Token: 0x170012DE RID: 4830
		// (get) Token: 0x06003D93 RID: 15763 RVA: 0x00075834 File Offset: 0x00073A34
		// (set) Token: 0x06003D94 RID: 15764 RVA: 0x00075860 File Offset: 0x00073A60
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170012DF RID: 4831
		// (get) Token: 0x06003D95 RID: 15765 RVA: 0x00075870 File Offset: 0x00073A70
		// (set) Token: 0x06003D96 RID: 15766 RVA: 0x00075890 File Offset: 0x00073A90
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06003D97 RID: 15767 RVA: 0x000758D4 File Offset: 0x00073AD4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003D98 RID: 15768 RVA: 0x000758EC File Offset: 0x00073AEC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170012E0 RID: 4832
		// (get) Token: 0x06003D99 RID: 15769 RVA: 0x000758F8 File Offset: 0x00073AF8
		// (set) Token: 0x06003D9A RID: 15770 RVA: 0x00075924 File Offset: 0x00073B24
		[ProtoMember(2, IsRequired = false, Name = "countleft", DataFormat = DataFormat.TwosComplement)]
		public int countleft
		{
			get
			{
				return this._countleft ?? 0;
			}
			set
			{
				this._countleft = new int?(value);
			}
		}

		// Token: 0x170012E1 RID: 4833
		// (get) Token: 0x06003D9B RID: 15771 RVA: 0x00075934 File Offset: 0x00073B34
		// (set) Token: 0x06003D9C RID: 15772 RVA: 0x00075954 File Offset: 0x00073B54
		[XmlIgnore]
		[Browsable(false)]
		public bool countleftSpecified
		{
			get
			{
				return this._countleft != null;
			}
			set
			{
				bool flag = value == (this._countleft == null);
				if (flag)
				{
					this._countleft = (value ? new int?(this.countleft) : null);
				}
			}
		}

		// Token: 0x06003D9D RID: 15773 RVA: 0x00075998 File Offset: 0x00073B98
		private bool ShouldSerializecountleft()
		{
			return this.countleftSpecified;
		}

		// Token: 0x06003D9E RID: 15774 RVA: 0x000759B0 File Offset: 0x00073BB0
		private void Resetcountleft()
		{
			this.countleftSpecified = false;
		}

		// Token: 0x170012E2 RID: 4834
		// (get) Token: 0x06003D9F RID: 15775 RVA: 0x000759BC File Offset: 0x00073BBC
		[ProtoMember(3, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x170012E3 RID: 4835
		// (get) Token: 0x06003DA0 RID: 15776 RVA: 0x000759D4 File Offset: 0x00073BD4
		// (set) Token: 0x06003DA1 RID: 15777 RVA: 0x00075A00 File Offset: 0x00073C00
		[ProtoMember(4, IsRequired = false, Name = "countmax", DataFormat = DataFormat.TwosComplement)]
		public int countmax
		{
			get
			{
				return this._countmax ?? 0;
			}
			set
			{
				this._countmax = new int?(value);
			}
		}

		// Token: 0x170012E4 RID: 4836
		// (get) Token: 0x06003DA2 RID: 15778 RVA: 0x00075A10 File Offset: 0x00073C10
		// (set) Token: 0x06003DA3 RID: 15779 RVA: 0x00075A30 File Offset: 0x00073C30
		[XmlIgnore]
		[Browsable(false)]
		public bool countmaxSpecified
		{
			get
			{
				return this._countmax != null;
			}
			set
			{
				bool flag = value == (this._countmax == null);
				if (flag)
				{
					this._countmax = (value ? new int?(this.countmax) : null);
				}
			}
		}

		// Token: 0x06003DA4 RID: 15780 RVA: 0x00075A74 File Offset: 0x00073C74
		private bool ShouldSerializecountmax()
		{
			return this.countmaxSpecified;
		}

		// Token: 0x06003DA5 RID: 15781 RVA: 0x00075A8C File Offset: 0x00073C8C
		private void Resetcountmax()
		{
			this.countmaxSpecified = false;
		}

		// Token: 0x170012E5 RID: 4837
		// (get) Token: 0x06003DA6 RID: 15782 RVA: 0x00075A98 File Offset: 0x00073C98
		// (set) Token: 0x06003DA7 RID: 15783 RVA: 0x00075AB0 File Offset: 0x00073CB0
		[ProtoMember(5, IsRequired = false, Name = "cost", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief cost
		{
			get
			{
				return this._cost;
			}
			set
			{
				this._cost = value;
			}
		}

		// Token: 0x06003DA8 RID: 15784 RVA: 0x00075ABC File Offset: 0x00073CBC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F57 RID: 3927
		private ErrorCode? _errorcode;

		// Token: 0x04000F58 RID: 3928
		private int? _countleft;

		// Token: 0x04000F59 RID: 3929
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x04000F5A RID: 3930
		private int? _countmax;

		// Token: 0x04000F5B RID: 3931
		private ItemBrief _cost = null;

		// Token: 0x04000F5C RID: 3932
		private IExtension extensionObject;
	}
}
