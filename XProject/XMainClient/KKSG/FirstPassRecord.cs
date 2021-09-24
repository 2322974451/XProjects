using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FirstPassRecord")]
	[Serializable]
	public class FirstPassRecord : IExtensible
	{

		[ProtoMember(1, Name = "infos", DataFormat = DataFormat.Default)]
		public List<FirstPassStageInfo> infos
		{
			get
			{
				return this._infos;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<FirstPassStageInfo> _infos = new List<FirstPassStageInfo>();

		private IExtension extensionObject;
	}
}
