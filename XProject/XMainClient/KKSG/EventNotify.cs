using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001ED RID: 493
	[ProtoContract(Name = "EventNotify")]
	[Serializable]
	public class EventNotify : IExtensible
	{
		// Token: 0x170008DC RID: 2268
		// (get) Token: 0x06001C43 RID: 7235 RVA: 0x00037BEC File Offset: 0x00035DEC
		// (set) Token: 0x06001C44 RID: 7236 RVA: 0x00037C0D File Offset: 0x00035E0D
		[ProtoMember(1, IsRequired = false, Name = "notify", DataFormat = DataFormat.Default)]
		public string notify
		{
			get
			{
				return this._notify ?? "";
			}
			set
			{
				this._notify = value;
			}
		}

		// Token: 0x170008DD RID: 2269
		// (get) Token: 0x06001C45 RID: 7237 RVA: 0x00037C18 File Offset: 0x00035E18
		// (set) Token: 0x06001C46 RID: 7238 RVA: 0x00037C34 File Offset: 0x00035E34
		[XmlIgnore]
		[Browsable(false)]
		public bool notifySpecified
		{
			get
			{
				return this._notify != null;
			}
			set
			{
				bool flag = value == (this._notify == null);
				if (flag)
				{
					this._notify = (value ? this.notify : null);
				}
			}
		}

		// Token: 0x06001C47 RID: 7239 RVA: 0x00037C64 File Offset: 0x00035E64
		private bool ShouldSerializenotify()
		{
			return this.notifySpecified;
		}

		// Token: 0x06001C48 RID: 7240 RVA: 0x00037C7C File Offset: 0x00035E7C
		private void Resetnotify()
		{
			this.notifySpecified = false;
		}

		// Token: 0x06001C49 RID: 7241 RVA: 0x00037C88 File Offset: 0x00035E88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000708 RID: 1800
		private string _notify;

		// Token: 0x04000709 RID: 1801
		private IExtension extensionObject;
	}
}
