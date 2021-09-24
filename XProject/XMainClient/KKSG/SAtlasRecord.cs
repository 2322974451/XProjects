using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SAtlasRecord")]
	[Serializable]
	public class SAtlasRecord : IExtensible
	{

		[ProtoMember(1, Name = "atlas", DataFormat = DataFormat.TwosComplement)]
		public List<uint> atlas
		{
			get
			{
				return this._atlas;
			}
		}

		[ProtoMember(2, Name = "finishdata", DataFormat = DataFormat.Default)]
		public List<atlasdata> finishdata
		{
			get
			{
				return this._finishdata;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _atlas = new List<uint>();

		private readonly List<atlasdata> _finishdata = new List<atlasdata>();

		private IExtension extensionObject;
	}
}
