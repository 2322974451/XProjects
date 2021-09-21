using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001AB RID: 427
	[ProtoContract(Name = "NoticeGuildArenaBegin")]
	[Serializable]
	public class NoticeGuildArenaBegin : IExtensible
	{
		// Token: 0x170007F9 RID: 2041
		// (get) Token: 0x06001945 RID: 6469 RVA: 0x00032318 File Offset: 0x00030518
		// (set) Token: 0x06001946 RID: 6470 RVA: 0x00032344 File Offset: 0x00030544
		[ProtoMember(1, IsRequired = false, Name = "isstart", DataFormat = DataFormat.Default)]
		public bool isstart
		{
			get
			{
				return this._isstart ?? false;
			}
			set
			{
				this._isstart = new bool?(value);
			}
		}

		// Token: 0x170007FA RID: 2042
		// (get) Token: 0x06001947 RID: 6471 RVA: 0x00032354 File Offset: 0x00030554
		// (set) Token: 0x06001948 RID: 6472 RVA: 0x00032374 File Offset: 0x00030574
		[XmlIgnore]
		[Browsable(false)]
		public bool isstartSpecified
		{
			get
			{
				return this._isstart != null;
			}
			set
			{
				bool flag = value == (this._isstart == null);
				if (flag)
				{
					this._isstart = (value ? new bool?(this.isstart) : null);
				}
			}
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x000323B8 File Offset: 0x000305B8
		private bool ShouldSerializeisstart()
		{
			return this.isstartSpecified;
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x000323D0 File Offset: 0x000305D0
		private void Resetisstart()
		{
			this.isstartSpecified = false;
		}

		// Token: 0x0600194B RID: 6475 RVA: 0x000323DC File Offset: 0x000305DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000647 RID: 1607
		private bool? _isstart;

		// Token: 0x04000648 RID: 1608
		private IExtension extensionObject;
	}
}
