using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChatArg")]
	[Serializable]
	public class ChatArg : IExtensible
	{

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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ChatInfo _chatinfo = null;

		private IExtension extensionObject;
	}
}
