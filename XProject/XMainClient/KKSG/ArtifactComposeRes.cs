using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArtifactComposeRes")]
	[Serializable]
	public class ArtifactComposeRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "newuid", DataFormat = DataFormat.TwosComplement)]
		public ulong newuid
		{
			get
			{
				return this._newuid ?? 0UL;
			}
			set
			{
				this._newuid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool newuidSpecified
		{
			get
			{
				return this._newuid != null;
			}
			set
			{
				bool flag = value == (this._newuid == null);
				if (flag)
				{
					this._newuid = (value ? new ulong?(this.newuid) : null);
				}
			}
		}

		private bool ShouldSerializenewuid()
		{
			return this.newuidSpecified;
		}

		private void Resetnewuid()
		{
			this.newuidSpecified = false;
		}

		[ProtoMember(3, Name = "newuids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> newuids
		{
			get
			{
				return this._newuids;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private ulong? _newuid;

		private readonly List<ulong> _newuids = new List<ulong>();

		private IExtension extensionObject;
	}
}
