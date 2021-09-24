using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DoodadItemAllSkill")]
	[Serializable]
	public class DoodadItemAllSkill : IExtensible
	{

		[ProtoMember(1, Name = "skills", DataFormat = DataFormat.Default)]
		public List<DoodadItemSkill> skills
		{
			get
			{
				return this._skills;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<DoodadItemSkill> _skills = new List<DoodadItemSkill>();

		private IExtension extensionObject;
	}
}
