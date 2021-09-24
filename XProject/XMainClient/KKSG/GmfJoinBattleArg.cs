using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfJoinBattleArg")]
	[Serializable]
	public class GmfJoinBattleArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public uint leftTime
		{
			get
			{
				return this._leftTime ?? 0U;
			}
			set
			{
				this._leftTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new uint?(this.leftTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _leftTime;

		private IExtension extensionObject;
	}
}
