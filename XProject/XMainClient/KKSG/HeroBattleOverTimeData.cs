using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleOverTimeData")]
	[Serializable]
	public class HeroBattleOverTimeData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "millisecond", DataFormat = DataFormat.TwosComplement)]
		public ulong millisecond
		{
			get
			{
				return this._millisecond ?? 0UL;
			}
			set
			{
				this._millisecond = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool millisecondSpecified
		{
			get
			{
				return this._millisecond != null;
			}
			set
			{
				bool flag = value == (this._millisecond == null);
				if (flag)
				{
					this._millisecond = (value ? new ulong?(this.millisecond) : null);
				}
			}
		}

		private bool ShouldSerializemillisecond()
		{
			return this.millisecondSpecified;
		}

		private void Resetmillisecond()
		{
			this.millisecondSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _millisecond;

		private IExtension extensionObject;
	}
}
