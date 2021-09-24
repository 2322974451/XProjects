using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GardenCookingFoodRes")]
	[Serializable]
	public class GardenCookingFoodRes : IExtensible
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

		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "cooking_level", DataFormat = DataFormat.TwosComplement)]
		public uint cooking_level
		{
			get
			{
				return this._cooking_level ?? 0U;
			}
			set
			{
				this._cooking_level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cooking_levelSpecified
		{
			get
			{
				return this._cooking_level != null;
			}
			set
			{
				bool flag = value == (this._cooking_level == null);
				if (flag)
				{
					this._cooking_level = (value ? new uint?(this.cooking_level) : null);
				}
			}
		}

		private bool ShouldSerializecooking_level()
		{
			return this.cooking_levelSpecified;
		}

		private void Resetcooking_level()
		{
			this.cooking_levelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "cooking_experiences", DataFormat = DataFormat.TwosComplement)]
		public uint cooking_experiences
		{
			get
			{
				return this._cooking_experiences ?? 0U;
			}
			set
			{
				this._cooking_experiences = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cooking_experiencesSpecified
		{
			get
			{
				return this._cooking_experiences != null;
			}
			set
			{
				bool flag = value == (this._cooking_experiences == null);
				if (flag)
				{
					this._cooking_experiences = (value ? new uint?(this.cooking_experiences) : null);
				}
			}
		}

		private bool ShouldSerializecooking_experiences()
		{
			return this.cooking_experiencesSpecified;
		}

		private void Resetcooking_experiences()
		{
			this.cooking_experiencesSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		private uint? _cooking_level;

		private uint? _cooking_experiences;

		private IExtension extensionObject;
	}
}
