using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "JadeSealInfo")]
	[Serializable]
	public class JadeSealInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "equipPos", DataFormat = DataFormat.TwosComplement)]
		public uint equipPos
		{
			get
			{
				return this._equipPos ?? 0U;
			}
			set
			{
				this._equipPos = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool equipPosSpecified
		{
			get
			{
				return this._equipPos != null;
			}
			set
			{
				bool flag = value == (this._equipPos == null);
				if (flag)
				{
					this._equipPos = (value ? new uint?(this.equipPos) : null);
				}
			}
		}

		private bool ShouldSerializeequipPos()
		{
			return this.equipPosSpecified;
		}

		private void ResetequipPos()
		{
			this.equipPosSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "jadeSealID", DataFormat = DataFormat.TwosComplement)]
		public uint jadeSealID
		{
			get
			{
				return this._jadeSealID ?? 0U;
			}
			set
			{
				this._jadeSealID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool jadeSealIDSpecified
		{
			get
			{
				return this._jadeSealID != null;
			}
			set
			{
				bool flag = value == (this._jadeSealID == null);
				if (flag)
				{
					this._jadeSealID = (value ? new uint?(this.jadeSealID) : null);
				}
			}
		}

		private bool ShouldSerializejadeSealID()
		{
			return this.jadeSealIDSpecified;
		}

		private void ResetjadeSealID()
		{
			this.jadeSealIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _equipPos;

		private uint? _jadeSealID;

		private IExtension extensionObject;
	}
}
