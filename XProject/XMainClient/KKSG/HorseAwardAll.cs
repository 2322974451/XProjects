using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HorseAwardAll")]
	[Serializable]
	public class HorseAwardAll : IExtensible
	{

		[ProtoMember(1, Name = "award", DataFormat = DataFormat.Default)]
		public List<HorseAward> award
		{
			get
			{
				return this._award;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<HorseAward> _award = new List<HorseAward>();

		private IExtension extensionObject;
	}
}
