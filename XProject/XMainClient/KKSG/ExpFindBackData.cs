using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ExpFindBackData")]
	[Serializable]
	public class ExpFindBackData : IExtensible
	{

		[ProtoMember(1, Name = "expBackInfos", DataFormat = DataFormat.Default)]
		public List<ExpFindBackInfo> expBackInfos
		{
			get
			{
				return this._expBackInfos;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ExpFindBackInfo> _expBackInfos = new List<ExpFindBackInfo>();

		private IExtension extensionObject;
	}
}
