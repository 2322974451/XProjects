using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LevelScriptStateData")]
	[Serializable]
	public class LevelScriptStateData : IExtensible
	{

		[ProtoMember(1, Name = "doorStates", DataFormat = DataFormat.Default)]
		public List<DoorState> doorStates
		{
			get
			{
				return this._doorStates;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<DoorState> _doorStates = new List<DoorState>();

		private IExtension extensionObject;
	}
}
