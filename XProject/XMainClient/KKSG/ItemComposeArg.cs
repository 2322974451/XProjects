using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003BF RID: 959
	[ProtoContract(Name = "ItemComposeArg")]
	[Serializable]
	public class ItemComposeArg : IExtensible
	{
		// Token: 0x17000FD0 RID: 4048
		// (get) Token: 0x0600334A RID: 13130 RVA: 0x00062870 File Offset: 0x00060A70
		// (set) Token: 0x0600334B RID: 13131 RVA: 0x00062891 File Offset: 0x00060A91
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.Default)]
		public string uid
		{
			get
			{
				return this._uid ?? "";
			}
			set
			{
				this._uid = value;
			}
		}

		// Token: 0x17000FD1 RID: 4049
		// (get) Token: 0x0600334C RID: 13132 RVA: 0x0006289C File Offset: 0x00060A9C
		// (set) Token: 0x0600334D RID: 13133 RVA: 0x000628B8 File Offset: 0x00060AB8
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? this.uid : null);
				}
			}
		}

		// Token: 0x0600334E RID: 13134 RVA: 0x000628E8 File Offset: 0x00060AE8
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x0600334F RID: 13135 RVA: 0x00062900 File Offset: 0x00060B00
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x06003350 RID: 13136 RVA: 0x0006290C File Offset: 0x00060B0C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CC0 RID: 3264
		private string _uid;

		// Token: 0x04000CC1 RID: 3265
		private IExtension extensionObject;
	}
}
