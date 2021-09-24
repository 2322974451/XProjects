using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RolePushInfo")]
	[Serializable]
	public class RolePushInfo : IExtensible
	{

		[ProtoMember(1, Name = "infos", DataFormat = DataFormat.Default)]
		public List<PushInfo> infos
		{
			get
			{
				return this._infos;
			}
		}

		[ProtoMember(2, Name = "configs", DataFormat = DataFormat.Default)]
		public List<PushConfig> configs
		{
			get
			{
				return this._configs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<PushInfo> _infos = new List<PushInfo>();

		private readonly List<PushConfig> _configs = new List<PushConfig>();

		private IExtension extensionObject;
	}
}
