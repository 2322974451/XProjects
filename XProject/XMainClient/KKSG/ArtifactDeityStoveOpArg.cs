using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArtifactDeityStoveOpArg")]
	[Serializable]
	public class ArtifactDeityStoveOpArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ArtifactDeityStoveOpType type
		{
			get
			{
				return this._type ?? ArtifactDeityStoveOpType.ArtifactDeityStove_Recast;
			}
			set
			{
				this._type = new ArtifactDeityStoveOpType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new ArtifactDeityStoveOpType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "uid1", DataFormat = DataFormat.TwosComplement)]
		public ulong uid1
		{
			get
			{
				return this._uid1 ?? 0UL;
			}
			set
			{
				this._uid1 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uid1Specified
		{
			get
			{
				return this._uid1 != null;
			}
			set
			{
				bool flag = value == (this._uid1 == null);
				if (flag)
				{
					this._uid1 = (value ? new ulong?(this.uid1) : null);
				}
			}
		}

		private bool ShouldSerializeuid1()
		{
			return this.uid1Specified;
		}

		private void Resetuid1()
		{
			this.uid1Specified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "uid2", DataFormat = DataFormat.TwosComplement)]
		public ulong uid2
		{
			get
			{
				return this._uid2 ?? 0UL;
			}
			set
			{
				this._uid2 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uid2Specified
		{
			get
			{
				return this._uid2 != null;
			}
			set
			{
				bool flag = value == (this._uid2 == null);
				if (flag)
				{
					this._uid2 = (value ? new ulong?(this.uid2) : null);
				}
			}
		}

		private bool ShouldSerializeuid2()
		{
			return this.uid2Specified;
		}

		private void Resetuid2()
		{
			this.uid2Specified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "isUsedStone", DataFormat = DataFormat.Default)]
		public bool isUsedStone
		{
			get
			{
				return this._isUsedStone ?? false;
			}
			set
			{
				this._isUsedStone = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isUsedStoneSpecified
		{
			get
			{
				return this._isUsedStone != null;
			}
			set
			{
				bool flag = value == (this._isUsedStone == null);
				if (flag)
				{
					this._isUsedStone = (value ? new bool?(this.isUsedStone) : null);
				}
			}
		}

		private bool ShouldSerializeisUsedStone()
		{
			return this.isUsedStoneSpecified;
		}

		private void ResetisUsedStone()
		{
			this.isUsedStoneSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ArtifactDeityStoveOpType? _type;

		private ulong? _uid1;

		private ulong? _uid2;

		private bool? _isUsedStone;

		private IExtension extensionObject;
	}
}
