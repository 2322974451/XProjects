using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarPVEArg")]
	[Serializable]
	public class ResWarPVEArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "mine", DataFormat = DataFormat.TwosComplement)]
		public uint mine
		{
			get
			{
				return this._mine ?? 0U;
			}
			set
			{
				this._mine = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mineSpecified
		{
			get
			{
				return this._mine != null;
			}
			set
			{
				bool flag = value == (this._mine == null);
				if (flag)
				{
					this._mine = (value ? new uint?(this.mine) : null);
				}
			}
		}

		private bool ShouldSerializemine()
		{
			return this.mineSpecified;
		}

		private void Resetmine()
		{
			this.mineSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _mine;

		private IExtension extensionObject;
	}
}
