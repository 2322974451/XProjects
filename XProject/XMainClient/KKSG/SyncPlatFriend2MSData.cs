using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SyncPlatFriend2MSData")]
	[Serializable]
	public class SyncPlatFriend2MSData : IExtensible
	{

		[ProtoMember(1, Name = "friendInfo", DataFormat = DataFormat.Default)]
		public List<PlatFriend> friendInfo
		{
			get
			{
				return this._friendInfo;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "selfInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatFriend selfInfo
		{
			get
			{
				return this._selfInfo;
			}
			set
			{
				this._selfInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<PlatFriend> _friendInfo = new List<PlatFriend>();

		private PlatFriend _selfInfo = null;

		private IExtension extensionObject;
	}
}
