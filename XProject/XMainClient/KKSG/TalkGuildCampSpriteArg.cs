using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TalkGuildCampSpriteArg")]
	[Serializable]
	public class TalkGuildCampSpriteArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "enemy_id", DataFormat = DataFormat.TwosComplement)]
		public ulong enemy_id
		{
			get
			{
				return this._enemy_id ?? 0UL;
			}
			set
			{
				this._enemy_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool enemy_idSpecified
		{
			get
			{
				return this._enemy_id != null;
			}
			set
			{
				bool flag = value == (this._enemy_id == null);
				if (flag)
				{
					this._enemy_id = (value ? new ulong?(this.enemy_id) : null);
				}
			}
		}

		private bool ShouldSerializeenemy_id()
		{
			return this.enemy_idSpecified;
		}

		private void Resetenemy_id()
		{
			this.enemy_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _enemy_id;

		private IExtension extensionObject;
	}
}
