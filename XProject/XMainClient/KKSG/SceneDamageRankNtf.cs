using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SceneDamageRankNtf")]
	[Serializable]
	public class SceneDamageRankNtf : IExtensible
	{

		[ProtoMember(1, Name = "name", DataFormat = DataFormat.Default)]
		public List<string> name
		{
			get
			{
				return this._name;
			}
		}

		[ProtoMember(2, Name = "damage", DataFormat = DataFormat.FixedSize)]
		public List<float> damage
		{
			get
			{
				return this._damage;
			}
		}

		[ProtoMember(3, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<string> _name = new List<string>();

		private readonly List<float> _damage = new List<float>();

		private readonly List<ulong> _roleid = new List<ulong>();

		private IExtension extensionObject;
	}
}
