using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WorldLevel")]
	[Serializable]
	public class WorldLevel : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "worldLevel", DataFormat = DataFormat.TwosComplement)]
		public uint worldLevel
		{
			get
			{
				return this._worldLevel ?? 0U;
			}
			set
			{
				this._worldLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool worldLevelSpecified
		{
			get
			{
				return this._worldLevel != null;
			}
			set
			{
				bool flag = value == (this._worldLevel == null);
				if (flag)
				{
					this._worldLevel = (value ? new uint?(this.worldLevel) : null);
				}
			}
		}

		private bool ShouldSerializeworldLevel()
		{
			return this.worldLevelSpecified;
		}

		private void ResetworldLevel()
		{
			this.worldLevelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _worldLevel;

		private IExtension extensionObject;
	}
}
