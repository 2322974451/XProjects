using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiftFirstPassRewardArg")]
	[Serializable]
	public class RiftFirstPassRewardArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "opType", DataFormat = DataFormat.TwosComplement)]
		public RiftFirstPassOpType opType
		{
			get
			{
				return this._opType ?? RiftFirstPassOpType.Rift_FirstPass_Op_GetInfo;
			}
			set
			{
				this._opType = new RiftFirstPassOpType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opTypeSpecified
		{
			get
			{
				return this._opType != null;
			}
			set
			{
				bool flag = value == (this._opType == null);
				if (flag)
				{
					this._opType = (value ? new RiftFirstPassOpType?(this.opType) : null);
				}
			}
		}

		private bool ShouldSerializeopType()
		{
			return this.opTypeSpecified;
		}

		private void ResetopType()
		{
			this.opTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public uint floor
		{
			get
			{
				return this._floor ?? 0U;
			}
			set
			{
				this._floor = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool floorSpecified
		{
			get
			{
				return this._floor != null;
			}
			set
			{
				bool flag = value == (this._floor == null);
				if (flag)
				{
					this._floor = (value ? new uint?(this.floor) : null);
				}
			}
		}

		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RiftFirstPassOpType? _opType;

		private uint? _floor;

		private IExtension extensionObject;
	}
}
