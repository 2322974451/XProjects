using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpriteChanged")]
	[Serializable]
	public class SpriteChanged : IExtensible
	{

		[ProtoMember(1, Name = "NewSprites", DataFormat = DataFormat.Default)]
		public List<SpriteInfo> NewSprites
		{
			get
			{
				return this._NewSprites;
			}
		}

		[ProtoMember(2, Name = "ChangedSprites", DataFormat = DataFormat.Default)]
		public List<SpriteInfo> ChangedSprites
		{
			get
			{
				return this._ChangedSprites;
			}
		}

		[ProtoMember(3, Name = "RemovedSprites", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> RemovedSprites
		{
			get
			{
				return this._RemovedSprites;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<SpriteInfo> _NewSprites = new List<SpriteInfo>();

		private readonly List<SpriteInfo> _ChangedSprites = new List<SpriteInfo>();

		private readonly List<ulong> _RemovedSprites = new List<ulong>();

		private IExtension extensionObject;
	}
}
