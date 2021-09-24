using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqPlatFriendRankListRes")]
	[Serializable]
	public class ReqPlatFriendRankListRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, Name = "platFriends", DataFormat = DataFormat.Default)]
		public List<PlatFriendRankInfo2Client> platFriends
		{
			get
			{
				return this._platFriends;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "selfInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatFriendRankInfo2Client selfInfo
		{
			get
			{
				return this._selfInfo;
			}
			set
			{
				this._selfInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private readonly List<PlatFriendRankInfo2Client> _platFriends = new List<PlatFriendRankInfo2Client>();

		private PlatFriendRankInfo2Client _selfInfo = null;

		private IExtension extensionObject;
	}
}
