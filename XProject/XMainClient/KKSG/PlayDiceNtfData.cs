using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlayDiceNtfData")]
	[Serializable]
	public class PlayDiceNtfData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isDiceFull", DataFormat = DataFormat.Default)]
		public bool isDiceFull
		{
			get
			{
				return this._isDiceFull ?? false;
			}
			set
			{
				this._isDiceFull = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isDiceFullSpecified
		{
			get
			{
				return this._isDiceFull != null;
			}
			set
			{
				bool flag = value == (this._isDiceFull == null);
				if (flag)
				{
					this._isDiceFull = (value ? new bool?(this.isDiceFull) : null);
				}
			}
		}

		private bool ShouldSerializeisDiceFull()
		{
			return this.isDiceFullSpecified;
		}

		private void ResetisDiceFull()
		{
			this.isDiceFullSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "mapID", DataFormat = DataFormat.TwosComplement)]
		public int mapID
		{
			get
			{
				return this._mapID ?? 0;
			}
			set
			{
				this._mapID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mapIDSpecified
		{
			get
			{
				return this._mapID != null;
			}
			set
			{
				bool flag = value == (this._mapID == null);
				if (flag)
				{
					this._mapID = (value ? new int?(this.mapID) : null);
				}
			}
		}

		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public int slot
		{
			get
			{
				return this._slot ?? 0;
			}
			set
			{
				this._slot = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new int?(this.slot) : null);
				}
			}
		}

		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isDiceFull;

		private int? _mapID;

		private int? _slot;

		private IExtension extensionObject;
	}
}
