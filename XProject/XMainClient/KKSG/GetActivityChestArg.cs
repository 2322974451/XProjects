using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetActivityChestArg")]
	[Serializable]
	public class GetActivityChestArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ChestIndex", DataFormat = DataFormat.TwosComplement)]
		public uint ChestIndex
		{
			get
			{
				return this._ChestIndex ?? 0U;
			}
			set
			{
				this._ChestIndex = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ChestIndexSpecified
		{
			get
			{
				return this._ChestIndex != null;
			}
			set
			{
				bool flag = value == (this._ChestIndex == null);
				if (flag)
				{
					this._ChestIndex = (value ? new uint?(this.ChestIndex) : null);
				}
			}
		}

		private bool ShouldSerializeChestIndex()
		{
			return this.ChestIndexSpecified;
		}

		private void ResetChestIndex()
		{
			this.ChestIndexSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _ChestIndex;

		private IExtension extensionObject;
	}
}
