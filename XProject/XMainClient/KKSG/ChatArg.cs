using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000CF RID: 207
	[ProtoContract(Name = "ChatArg")]
	[Serializable]
	public class ChatArg : IExtensible
	{
		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000D4D RID: 3405 RVA: 0x0001BCE0 File Offset: 0x00019EE0
		// (set) Token: 0x06000D4E RID: 3406 RVA: 0x0001BCF8 File Offset: 0x00019EF8
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

		// Token: 0x06000D4F RID: 3407 RVA: 0x0001BD04 File Offset: 0x00019F04
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000359 RID: 857
		private ChatInfo _chatinfo = null;

		// Token: 0x0400035A RID: 858
		private IExtension extensionObject;
	}
}
