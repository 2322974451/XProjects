using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TargetHurtInfo")]
	[Serializable]
	public class TargetHurtInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "UnitID", DataFormat = DataFormat.TwosComplement)]
		public ulong UnitID
		{
			get
			{
				return this._UnitID ?? 0UL;
			}
			set
			{
				this._UnitID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool UnitIDSpecified
		{
			get
			{
				return this._UnitID != null;
			}
			set
			{
				bool flag = value == (this._UnitID == null);
				if (flag)
				{
					this._UnitID = (value ? new ulong?(this.UnitID) : null);
				}
			}
		}

		private bool ShouldSerializeUnitID()
		{
			return this.UnitIDSpecified;
		}

		private void ResetUnitID()
		{
			this.UnitIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "Result", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DamageResult Result
		{
			get
			{
				return this._Result;
			}
			set
			{
				this._Result = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _UnitID;

		private DamageResult _Result = null;

		private IExtension extensionObject;
	}
}
