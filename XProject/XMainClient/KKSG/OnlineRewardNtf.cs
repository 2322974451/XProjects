using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OnlineRewardNtf")]
	[Serializable]
	public class OnlineRewardNtf : IExtensible
	{

		[ProtoMember(1, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public List<uint> state
		{
			get
			{
				return this._state;
			}
		}

		[ProtoMember(2, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public List<uint> timeleft
		{
			get
			{
				return this._timeleft;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _state = new List<uint>();

		private readonly List<uint> _timeleft = new List<uint>();

		private IExtension extensionObject;
	}
}
