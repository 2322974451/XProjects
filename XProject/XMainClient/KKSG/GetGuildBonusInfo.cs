using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildBonusInfo")]
	[Serializable]
	public class GetGuildBonusInfo : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
		public string roleName
		{
			get
			{
				return this._roleName ?? "";
			}
			set
			{
				this._roleName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleNameSpecified
		{
			get
			{
				return this._roleName != null;
			}
			set
			{
				bool flag = value == (this._roleName == null);
				if (flag)
				{
					this._roleName = (value ? this.roleName : null);
				}
			}
		}

		private bool ShouldSerializeroleName()
		{
			return this.roleNameSpecified;
		}

		private void ResetroleName()
		{
			this.roleNameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "getNum", DataFormat = DataFormat.TwosComplement)]
		public uint getNum
		{
			get
			{
				return this._getNum ?? 0U;
			}
			set
			{
				this._getNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getNumSpecified
		{
			get
			{
				return this._getNum != null;
			}
			set
			{
				bool flag = value == (this._getNum == null);
				if (flag)
				{
					this._getNum = (value ? new uint?(this.getNum) : null);
				}
			}
		}

		private bool ShouldSerializegetNum()
		{
			return this.getNumSpecified;
		}

		private void ResetgetNum()
		{
			this.getNumSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "getTime", DataFormat = DataFormat.TwosComplement)]
		public uint getTime
		{
			get
			{
				return this._getTime ?? 0U;
			}
			set
			{
				this._getTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getTimeSpecified
		{
			get
			{
				return this._getTime != null;
			}
			set
			{
				bool flag = value == (this._getTime == null);
				if (flag)
				{
					this._getTime = (value ? new uint?(this.getTime) : null);
				}
			}
		}

		private bool ShouldSerializegetTime()
		{
			return this.getTimeSpecified;
		}

		private void ResetgetTime()
		{
			this.getTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "canThank", DataFormat = DataFormat.Default)]
		public bool canThank
		{
			get
			{
				return this._canThank ?? false;
			}
			set
			{
				this._canThank = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canThankSpecified
		{
			get
			{
				return this._canThank != null;
			}
			set
			{
				bool flag = value == (this._canThank == null);
				if (flag)
				{
					this._canThank = (value ? new bool?(this.canThank) : null);
				}
			}
		}

		private bool ShouldSerializecanThank()
		{
			return this.canThankSpecified;
		}

		private void ResetcanThank()
		{
			this.canThankSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleID;

		private string _roleName;

		private uint? _getNum;

		private uint? _getTime;

		private bool? _canThank;

		private IExtension extensionObject;
	}
}
