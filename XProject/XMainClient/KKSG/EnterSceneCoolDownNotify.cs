using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnterSceneCoolDownNotify")]
	[Serializable]
	public class EnterSceneCoolDownNotify : IExtensible
	{

		[ProtoMember(1, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> groupid
		{
			get
			{
				return this._groupid;
			}
		}

		[ProtoMember(2, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
		public List<uint> cooldown
		{
			get
			{
				return this._cooldown;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _groupid = new List<uint>();

		private readonly List<uint> _cooldown = new List<uint>();

		private IExtension extensionObject;
	}
}
