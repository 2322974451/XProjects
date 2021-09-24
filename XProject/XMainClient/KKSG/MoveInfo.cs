using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MoveInfo")]
	[Serializable]
	public class MoveInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "Common", DataFormat = DataFormat.TwosComplement)]
		public int Common
		{
			get
			{
				return this._Common ?? 0;
			}
			set
			{
				this._Common = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool CommonSpecified
		{
			get
			{
				return this._Common != null;
			}
			set
			{
				bool flag = value == (this._Common == null);
				if (flag)
				{
					this._Common = (value ? new int?(this.Common) : null);
				}
			}
		}

		private bool ShouldSerializeCommon()
		{
			return this.CommonSpecified;
		}

		private void ResetCommon()
		{
			this.CommonSpecified = false;
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

		[ProtoMember(3, IsRequired = false, Name = "DesXZ", DataFormat = DataFormat.TwosComplement)]
		public int DesXZ
		{
			get
			{
				return this._DesXZ ?? 0;
			}
			set
			{
				this._DesXZ = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool DesXZSpecified
		{
			get
			{
				return this._DesXZ != null;
			}
			set
			{
				bool flag = value == (this._DesXZ == null);
				if (flag)
				{
					this._DesXZ = (value ? new int?(this.DesXZ) : null);
				}
			}
		}

		private bool ShouldSerializeDesXZ()
		{
			return this.DesXZSpecified;
		}

		private void ResetDesXZ()
		{
			this.DesXZSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _Common;

		private int? _PosXZ;

		private int? _DesXZ;

		private IExtension extensionObject;
	}
}
