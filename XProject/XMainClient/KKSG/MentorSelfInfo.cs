using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MentorSelfInfo")]
	[Serializable]
	public class MentorSelfInfo : IExtensible
	{

		[ProtoMember(1, Name = "selfTaskList", DataFormat = DataFormat.Default)]
		public List<OneMentorTaskInfo> selfTaskList
		{
			get
			{
				return this._selfTaskList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<OneMentorTaskInfo> _selfTaskList = new List<OneMentorTaskInfo>();

		private IExtension extensionObject;
	}
}
