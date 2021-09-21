using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003BC RID: 956
	[ProtoContract(Name = "GiftIBBackInfo")]
	[Serializable]
	public class GiftIBBackInfo : IExtensible
	{
		// Token: 0x17000FC7 RID: 4039
		// (get) Token: 0x0600332A RID: 13098 RVA: 0x0006251C File Offset: 0x0006071C
		// (set) Token: 0x0600332B RID: 13099 RVA: 0x0006253D File Offset: 0x0006073D
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

		// Token: 0x17000FC8 RID: 4040
		// (get) Token: 0x0600332C RID: 13100 RVA: 0x00062548 File Offset: 0x00060748
		// (set) Token: 0x0600332D RID: 13101 RVA: 0x00062564 File Offset: 0x00060764
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

		// Token: 0x0600332E RID: 13102 RVA: 0x00062594 File Offset: 0x00060794
		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		// Token: 0x0600332F RID: 13103 RVA: 0x000625AC File Offset: 0x000607AC
		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		// Token: 0x17000FC9 RID: 4041
		// (get) Token: 0x06003330 RID: 13104 RVA: 0x000625B8 File Offset: 0x000607B8
		// (set) Token: 0x06003331 RID: 13105 RVA: 0x000625D9 File Offset: 0x000607D9
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

		// Token: 0x17000FCA RID: 4042
		// (get) Token: 0x06003332 RID: 13106 RVA: 0x000625E4 File Offset: 0x000607E4
		// (set) Token: 0x06003333 RID: 13107 RVA: 0x00062600 File Offset: 0x00060800
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

		// Token: 0x06003334 RID: 13108 RVA: 0x00062630 File Offset: 0x00060830
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06003335 RID: 13109 RVA: 0x00062648 File Offset: 0x00060848
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06003336 RID: 13110 RVA: 0x00062654 File Offset: 0x00060854
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CB8 RID: 3256
		private string _openid;

		// Token: 0x04000CB9 RID: 3257
		private string _name;

		// Token: 0x04000CBA RID: 3258
		private IExtension extensionObject;
	}
}
