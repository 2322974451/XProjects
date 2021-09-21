using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006D6 RID: 1750
	[ProtoContract(Name = "MentorSelfInfo")]
	[Serializable]
	public class MentorSelfInfo : IExtensible
	{
		// Token: 0x170024D7 RID: 9431
		// (get) Token: 0x0600745B RID: 29787 RVA: 0x000DEA6C File Offset: 0x000DCC6C
		[ProtoMember(1, Name = "selfTaskList", DataFormat = DataFormat.Default)]
		public List<OneMentorTaskInfo> selfTaskList
		{
			get
			{
				return this._selfTaskList;
			}
		}

		// Token: 0x0600745C RID: 29788 RVA: 0x000DEA84 File Offset: 0x000DCC84
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BA4 RID: 7076
		private readonly List<OneMentorTaskInfo> _selfTaskList = new List<OneMentorTaskInfo>();

		// Token: 0x04001BA5 RID: 7077
		private IExtension extensionObject;
	}
}
