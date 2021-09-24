using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpActivityOffsetDay")]
	[Serializable]
	public class SpActivityOffsetDay : IExtensible
	{

		[ProtoMember(1, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> actid
		{
			get
			{
				return this._actid;
			}
		}

		[ProtoMember(2, Name = "offsetday", DataFormat = DataFormat.TwosComplement)]
		public List<int> offsetday
		{
			get
			{
				return this._offsetday;
			}
		}

		[ProtoMember(3, Name = "offsettime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> offsettime
		{
			get
			{
				return this._offsettime;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _actid = new List<uint>();

		private readonly List<int> _offsetday = new List<int>();

		private readonly List<uint> _offsettime = new List<uint>();

		private IExtension extensionObject;
	}
}
