using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnterWatchBattleArg")]
	[Serializable]
	public class EnterWatchBattleArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "liveID", DataFormat = DataFormat.TwosComplement)]
		public uint liveID
		{
			get
			{
				return this._liveID ?? 0U;
			}
			set
			{
				this._liveID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool liveIDSpecified
		{
			get
			{
				return this._liveID != null;
			}
			set
			{
				bool flag = value == (this._liveID == null);
				if (flag)
				{
					this._liveID = (value ? new uint?(this.liveID) : null);
				}
			}
		}

		private bool ShouldSerializeliveID()
		{
			return this.liveIDSpecified;
		}

		private void ResetliveID()
		{
			this.liveIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public LiveType type
		{
			get
			{
				return this._type ?? LiveType.LIVE_RECOMMEND;
			}
			set
			{
				this._type = new LiveType?(value);
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
					this._type = (value ? new LiveType?(this.type) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _liveID;

		private LiveType? _type;

		private IExtension extensionObject;
	}
}
