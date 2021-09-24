using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DecomposeEquipmentArg")]
	[Serializable]
	public class DecomposeEquipmentArg : IExtensible
	{

		[ProtoMember(1, Name = "equipuniqueid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> equipuniqueid
		{
			get
			{
				return this._equipuniqueid;
			}
		}

		[ProtoMember(2, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public List<uint> count
		{
			get
			{
				return this._count;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ulong> _equipuniqueid = new List<ulong>();

		private readonly List<uint> _count = new List<uint>();

		private IExtension extensionObject;
	}
}
