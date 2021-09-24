using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QAIDNameList")]
	[Serializable]
	public class QAIDNameList : IExtensible
	{

		[ProtoMember(1, Name = "idname", DataFormat = DataFormat.Default)]
		public List<QAIDName> idname
		{
			get
			{
				return this._idname;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<QAIDName> _idname = new List<QAIDName>();

		private IExtension extensionObject;
	}
}
