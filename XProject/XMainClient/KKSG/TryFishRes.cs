using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TryFishRes")]
	[Serializable]
	public class TryFishRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, Name = "item", DataFormat = DataFormat.Default)]
		public List<ItemBrief> item
		{
			get
			{
				return this._item;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "fish_level", DataFormat = DataFormat.TwosComplement)]
		public uint fish_level
		{
			get
			{
				return this._fish_level ?? 0U;
			}
			set
			{
				this._fish_level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fish_levelSpecified
		{
			get
			{
				return this._fish_level != null;
			}
			set
			{
				bool flag = value == (this._fish_level == null);
				if (flag)
				{
					this._fish_level = (value ? new uint?(this.fish_level) : null);
				}
			}
		}

		private bool ShouldSerializefish_level()
		{
			return this.fish_levelSpecified;
		}

		private void Resetfish_level()
		{
			this.fish_levelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "experiences", DataFormat = DataFormat.TwosComplement)]
		public uint experiences
		{
			get
			{
				return this._experiences ?? 0U;
			}
			set
			{
				this._experiences = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool experiencesSpecified
		{
			get
			{
				return this._experiences != null;
			}
			set
			{
				bool flag = value == (this._experiences == null);
				if (flag)
				{
					this._experiences = (value ? new uint?(this.experiences) : null);
				}
			}
		}

		private bool ShouldSerializeexperiences()
		{
			return this.experiencesSpecified;
		}

		private void Resetexperiences()
		{
			this.experiencesSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<ItemBrief> _item = new List<ItemBrief>();

		private uint? _fish_level;

		private uint? _experiences;

		private IExtension extensionObject;
	}
}
