using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StepMoveData")]
	[Serializable]
	public class StepMoveData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "EntityID", DataFormat = DataFormat.TwosComplement)]
		public ulong EntityID
		{
			get
			{
				return this._EntityID ?? 0UL;
			}
			set
			{
				this._EntityID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool EntityIDSpecified
		{
			get
			{
				return this._EntityID != null;
			}
			set
			{
				bool flag = value == (this._EntityID == null);
				if (flag)
				{
					this._EntityID = (value ? new ulong?(this.EntityID) : null);
				}
			}
		}

		private bool ShouldSerializeEntityID()
		{
			return this.EntityIDSpecified;
		}

		private void ResetEntityID()
		{
			this.EntityIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "PosXZ", DataFormat = DataFormat.TwosComplement)]
		public int PosXZ
		{
			get
			{
				return this._PosXZ ?? 0;
			}
			set
			{
				this._PosXZ = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool PosXZSpecified
		{
			get
			{
				return this._PosXZ != null;
			}
			set
			{
				bool flag = value == (this._PosXZ == null);
				if (flag)
				{
					this._PosXZ = (value ? new int?(this.PosXZ) : null);
				}
			}
		}

		private bool ShouldSerializePosXZ()
		{
			return this.PosXZSpecified;
		}

		private void ResetPosXZ()
		{
			this.PosXZSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "Stoppage", DataFormat = DataFormat.Default)]
		public bool Stoppage
		{
			get
			{
				return this._Stoppage ?? false;
			}
			set
			{
				this._Stoppage = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool StoppageSpecified
		{
			get
			{
				return this._Stoppage != null;
			}
			set
			{
				bool flag = value == (this._Stoppage == null);
				if (flag)
				{
					this._Stoppage = (value ? new bool?(this.Stoppage) : null);
				}
			}
		}

		private bool ShouldSerializeStoppage()
		{
			return this.StoppageSpecified;
		}

		private void ResetStoppage()
		{
			this.StoppageSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "Face", DataFormat = DataFormat.TwosComplement)]
		public int Face
		{
			get
			{
				return this._Face ?? 0;
			}
			set
			{
				this._Face = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool FaceSpecified
		{
			get
			{
				return this._Face != null;
			}
			set
			{
				bool flag = value == (this._Face == null);
				if (flag)
				{
					this._Face = (value ? new int?(this.Face) : null);
				}
			}
		}

		private bool ShouldSerializeFace()
		{
			return this.FaceSpecified;
		}

		private void ResetFace()
		{
			this.FaceSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _EntityID;

		private int? _PosXZ;

		private bool? _Stoppage;

		private int? _Face;

		private IExtension extensionObject;
	}
}
