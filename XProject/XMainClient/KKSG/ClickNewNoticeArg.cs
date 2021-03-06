using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ClickNewNoticeArg")]
	[Serializable]
	public class ClickNewNoticeArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatNotice info
		{
			get
			{
				return this._info;
			}
			set
			{
				this._info = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PlatNotice _info = null;

		private IExtension extensionObject;
	}
}
