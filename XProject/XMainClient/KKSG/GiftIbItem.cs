using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000700 RID: 1792
	[ProtoContract(Name = "GiftIbItem")]
	[Serializable]
	public class GiftIbItem : IExtensible
	{
		// Token: 0x17002663 RID: 9827
		// (get) Token: 0x06007930 RID: 31024 RVA: 0x000E7BF0 File Offset: 0x000E5DF0
		// (set) Token: 0x06007931 RID: 31025 RVA: 0x000E7C11 File Offset: 0x000E5E11
		[ProtoMember(1, IsRequired = false, Name = "openid", DataFormat = DataFormat.Default)]
		public string openid
		{
			get
			{
				return this._openid ?? "";
			}
			set
			{
				this._openid = value;
			}
		}

		// Token: 0x17002664 RID: 9828
		// (get) Token: 0x06007932 RID: 31026 RVA: 0x000E7C1C File Offset: 0x000E5E1C
		// (set) Token: 0x06007933 RID: 31027 RVA: 0x000E7C38 File Offset: 0x000E5E38
		[XmlIgnore]
		[Browsable(false)]
		public bool openidSpecified
		{
			get
			{
				return this._openid != null;
			}
			set
			{
				bool flag = value == (this._openid == null);
				if (flag)
				{
					this._openid = (value ? this.openid : null);
				}
			}
		}

		// Token: 0x06007934 RID: 31028 RVA: 0x000E7C68 File Offset: 0x000E5E68
		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		// Token: 0x06007935 RID: 31029 RVA: 0x000E7C80 File Offset: 0x000E5E80
		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		// Token: 0x17002665 RID: 9829
		// (get) Token: 0x06007936 RID: 31030 RVA: 0x000E7C8C File Offset: 0x000E5E8C
		// (set) Token: 0x06007937 RID: 31031 RVA: 0x000E7CAD File Offset: 0x000E5EAD
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17002666 RID: 9830
		// (get) Token: 0x06007938 RID: 31032 RVA: 0x000E7CB8 File Offset: 0x000E5EB8
		// (set) Token: 0x06007939 RID: 31033 RVA: 0x000E7CD4 File Offset: 0x000E5ED4
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x0600793A RID: 31034 RVA: 0x000E7D04 File Offset: 0x000E5F04
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600793B RID: 31035 RVA: 0x000E7D1C File Offset: 0x000E5F1C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002667 RID: 9831
		// (get) Token: 0x0600793C RID: 31036 RVA: 0x000E7D28 File Offset: 0x000E5F28
		// (set) Token: 0x0600793D RID: 31037 RVA: 0x000E7D40 File Offset: 0x000E5F40
		[ProtoMember(3, IsRequired = false, Name = "item", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item = value;
			}
		}

		// Token: 0x17002668 RID: 9832
		// (get) Token: 0x0600793E RID: 31038 RVA: 0x000E7D4C File Offset: 0x000E5F4C
		// (set) Token: 0x0600793F RID: 31039 RVA: 0x000E7D6D File Offset: 0x000E5F6D
		[ProtoMember(4, IsRequired = false, Name = "text", DataFormat = DataFormat.Default)]
		public string text
		{
			get
			{
				return this._text ?? "";
			}
			set
			{
				this._text = value;
			}
		}

		// Token: 0x17002669 RID: 9833
		// (get) Token: 0x06007940 RID: 31040 RVA: 0x000E7D78 File Offset: 0x000E5F78
		// (set) Token: 0x06007941 RID: 31041 RVA: 0x000E7D94 File Offset: 0x000E5F94
		[XmlIgnore]
		[Browsable(false)]
		public bool textSpecified
		{
			get
			{
				return this._text != null;
			}
			set
			{
				bool flag = value == (this._text == null);
				if (flag)
				{
					this._text = (value ? this.text : null);
				}
			}
		}

		// Token: 0x06007942 RID: 31042 RVA: 0x000E7DC4 File Offset: 0x000E5FC4
		private bool ShouldSerializetext()
		{
			return this.textSpecified;
		}

		// Token: 0x06007943 RID: 31043 RVA: 0x000E7DDC File Offset: 0x000E5FDC
		private void Resettext()
		{
			this.textSpecified = false;
		}

		// Token: 0x1700266A RID: 9834
		// (get) Token: 0x06007944 RID: 31044 RVA: 0x000E7DE8 File Offset: 0x000E5FE8
		// (set) Token: 0x06007945 RID: 31045 RVA: 0x000E7E09 File Offset: 0x000E6009
		[ProtoMember(5, IsRequired = false, Name = "orderid", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700266B RID: 9835
		// (get) Token: 0x06007946 RID: 31046 RVA: 0x000E7E14 File Offset: 0x000E6014
		// (set) Token: 0x06007947 RID: 31047 RVA: 0x000E7E30 File Offset: 0x000E6030
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

		// Token: 0x06007948 RID: 31048 RVA: 0x000E7E60 File Offset: 0x000E6060
		private bool ShouldSerializeorderid()
		{
			return this.orderidSpecified;
		}

		// Token: 0x06007949 RID: 31049 RVA: 0x000E7E78 File Offset: 0x000E6078
		private void Resetorderid()
		{
			this.orderidSpecified = false;
		}

		// Token: 0x0600794A RID: 31050 RVA: 0x000E7E84 File Offset: 0x000E6084
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CA0 RID: 7328
		private string _openid;

		// Token: 0x04001CA1 RID: 7329
		private string _name;

		// Token: 0x04001CA2 RID: 7330
		private ItemBrief _item = null;

		// Token: 0x04001CA3 RID: 7331
		private string _text;

		// Token: 0x04001CA4 RID: 7332
		private string _orderid;

		// Token: 0x04001CA5 RID: 7333
		private IExtension extensionObject;
	}
}
