using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildCampPartyRewardArg")]
	[Serializable]
	public class GetGuildCampPartyRewardArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "reward_id", DataFormat = DataFormat.TwosComplement)]
		public uint reward_id
		{
			get
			{
				return this._reward_id ?? 0U;
			}
			set
			{
				this._reward_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reward_idSpecified
		{
			get
			{
				return this._reward_id != null;
			}
			set
			{
				bool flag = value == (this._reward_id == null);
				if (flag)
				{
					this._reward_id = (value ? new uint?(this.reward_id) : null);
				}
			}
		}

		private bool ShouldSerializereward_id()
		{
			return this.reward_idSpecified;
		}

		private void Resetreward_id()
		{
			this.reward_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _reward_id;

		private IExtension extensionObject;
	}
}
