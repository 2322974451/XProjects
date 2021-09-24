using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MarriageRelationOpArg")]
	[Serializable]
	public class MarriageRelationOpArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "opType", DataFormat = DataFormat.TwosComplement)]
		public MarriageOpType opType
		{
			get
			{
				return this._opType ?? MarriageOpType.MarriageOpType_MarryApply;
			}
			set
			{
				this._opType = new MarriageOpType?(value);
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
					this._opType = (value ? new MarriageOpType?(this.opType) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingType type
		{
			get
			{
				return this._type ?? WeddingType.WeddingType_Normal;
			}
			set
			{
				this._type = new WeddingType?(value);
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
					this._type = (value ? new WeddingType?(this.type) : null);
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

		[ProtoMember(3, IsRequired = false, Name = "destRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong destRoleID
		{
			get
			{
				return this._destRoleID ?? 0UL;
			}
			set
			{
				this._destRoleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool destRoleIDSpecified
		{
			get
			{
				return this._destRoleID != null;
			}
			set
			{
				bool flag = value == (this._destRoleID == null);
				if (flag)
				{
					this._destRoleID = (value ? new ulong?(this.destRoleID) : null);
				}
			}
		}

		private bool ShouldSerializedestRoleID()
		{
			return this.destRoleIDSpecified;
		}

		private void ResetdestRoleID()
		{
			this.destRoleIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private MarriageOpType? _opType;

		private WeddingType? _type;

		private ulong? _destRoleID;

		private IExtension extensionObject;
	}
}
