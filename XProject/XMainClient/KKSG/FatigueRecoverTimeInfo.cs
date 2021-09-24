using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FatigueRecoverTimeInfo")]
	[Serializable]
	public class FatigueRecoverTimeInfo : IExtensible
	{

		[ProtoMember(1, Name = "fatigueID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fatigueID
		{
			get
			{
				return this._fatigueID;
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

		private readonly List<uint> _fatigueID = new List<uint>();

		private readonly List<uint> _timeleft = new List<uint>();

		private IExtension extensionObject;
	}
}
