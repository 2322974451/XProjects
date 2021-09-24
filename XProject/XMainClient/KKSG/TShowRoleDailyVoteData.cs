using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TShowRoleDailyVoteData")]
	[Serializable]
	public class TShowRoleDailyVoteData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "freeCount", DataFormat = DataFormat.TwosComplement)]
		public int freeCount
		{
			get
			{
				return this._freeCount ?? 0;
			}
			set
			{
				this._freeCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool freeCountSpecified
		{
			get
			{
				return this._freeCount != null;
			}
			set
			{
				bool flag = value == (this._freeCount == null);
				if (flag)
				{
					this._freeCount = (value ? new int?(this.freeCount) : null);
				}
			}
		}

		private bool ShouldSerializefreeCount()
		{
			return this.freeCountSpecified;
		}

		private void ResetfreeCount()
		{
			this.freeCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "costCount", DataFormat = DataFormat.TwosComplement)]
		public int costCount
		{
			get
			{
				return this._costCount ?? 0;
			}
			set
			{
				this._costCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool costCountSpecified
		{
			get
			{
				return this._costCount != null;
			}
			set
			{
				bool flag = value == (this._costCount == null);
				if (flag)
				{
					this._costCount = (value ? new int?(this.costCount) : null);
				}
			}
		}

		private bool ShouldSerializecostCount()
		{
			return this.costCountSpecified;
		}

		private void ResetcostCount()
		{
			this.costCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleID;

		private int? _freeCount;

		private int? _costCount;

		private IExtension extensionObject;
	}
}
