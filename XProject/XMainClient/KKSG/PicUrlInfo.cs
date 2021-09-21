using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000307 RID: 775
	[ProtoContract(Name = "PicUrlInfo")]
	[Serializable]
	public class PicUrlInfo : IExtensible
	{
		// Token: 0x17000D26 RID: 3366
		// (get) Token: 0x06002A6D RID: 10861 RVA: 0x000523F4 File Offset: 0x000505F4
		// (set) Token: 0x06002A6E RID: 10862 RVA: 0x00052415 File Offset: 0x00050615
		[ProtoMember(1, IsRequired = false, Name = "url", DataFormat = DataFormat.Default)]
		public string url
		{
			get
			{
				return this._url ?? "";
			}
			set
			{
				this._url = value;
			}
		}

		// Token: 0x17000D27 RID: 3367
		// (get) Token: 0x06002A6F RID: 10863 RVA: 0x00052420 File Offset: 0x00050620
		// (set) Token: 0x06002A70 RID: 10864 RVA: 0x0005243C File Offset: 0x0005063C
		[XmlIgnore]
		[Browsable(false)]
		public bool urlSpecified
		{
			get
			{
				return this._url != null;
			}
			set
			{
				bool flag = value == (this._url == null);
				if (flag)
				{
					this._url = (value ? this.url : null);
				}
			}
		}

		// Token: 0x06002A71 RID: 10865 RVA: 0x0005246C File Offset: 0x0005066C
		private bool ShouldSerializeurl()
		{
			return this.urlSpecified;
		}

		// Token: 0x06002A72 RID: 10866 RVA: 0x00052484 File Offset: 0x00050684
		private void Reseturl()
		{
			this.urlSpecified = false;
		}

		// Token: 0x06002A73 RID: 10867 RVA: 0x00052490 File Offset: 0x00050690
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A88 RID: 2696
		private string _url;

		// Token: 0x04000A89 RID: 2697
		private IExtension extensionObject;
	}
}
