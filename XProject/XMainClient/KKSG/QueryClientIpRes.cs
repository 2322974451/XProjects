using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200035C RID: 860
	[ProtoContract(Name = "QueryClientIpRes")]
	[Serializable]
	public class QueryClientIpRes : IExtensible
	{
		// Token: 0x17000E99 RID: 3737
		// (get) Token: 0x06002F1A RID: 12058 RVA: 0x0005AF48 File Offset: 0x00059148
		// (set) Token: 0x06002F1B RID: 12059 RVA: 0x0005AF69 File Offset: 0x00059169
		[ProtoMember(1, IsRequired = false, Name = "ip", DataFormat = DataFormat.Default)]
		public string ip
		{
			get
			{
				return this._ip ?? "";
			}
			set
			{
				this._ip = value;
			}
		}

		// Token: 0x17000E9A RID: 3738
		// (get) Token: 0x06002F1C RID: 12060 RVA: 0x0005AF74 File Offset: 0x00059174
		// (set) Token: 0x06002F1D RID: 12061 RVA: 0x0005AF90 File Offset: 0x00059190
		[XmlIgnore]
		[Browsable(false)]
		public bool ipSpecified
		{
			get
			{
				return this._ip != null;
			}
			set
			{
				bool flag = value == (this._ip == null);
				if (flag)
				{
					this._ip = (value ? this.ip : null);
				}
			}
		}

		// Token: 0x06002F1E RID: 12062 RVA: 0x0005AFC0 File Offset: 0x000591C0
		private bool ShouldSerializeip()
		{
			return this.ipSpecified;
		}

		// Token: 0x06002F1F RID: 12063 RVA: 0x0005AFD8 File Offset: 0x000591D8
		private void Resetip()
		{
			this.ipSpecified = false;
		}

		// Token: 0x06002F20 RID: 12064 RVA: 0x0005AFE4 File Offset: 0x000591E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BAE RID: 2990
		private string _ip;

		// Token: 0x04000BAF RID: 2991
		private IExtension extensionObject;
	}
}
