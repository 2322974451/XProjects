using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200006D RID: 109
	[ProtoContract(Name = "ChatNotify")]
	[Serializable]
	public class ChatNotify : IExtensible
	{
		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000722 RID: 1826 RVA: 0x00010538 File Offset: 0x0000E738
		// (set) Token: 0x06000723 RID: 1827 RVA: 0x00010550 File Offset: 0x0000E750
		[ProtoMember(1, IsRequired = false, Name = "chatinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatInfo chatinfo
		{
			get
			{
				return this._chatinfo;
			}
			set
			{
				this._chatinfo = value;
			}
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0001055C File Offset: 0x0000E75C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001D0 RID: 464
		private ChatInfo _chatinfo = null;

		// Token: 0x040001D1 RID: 465
		private IExtension extensionObject;
	}
}
