using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetWeddingInviteInfoRes")]
	[Serializable]
	public class GetWeddingInviteInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "permitstranger", DataFormat = DataFormat.Default)]
		public bool permitstranger
		{
			get
			{
				return this._permitstranger ?? false;
			}
			set
			{
				this._permitstranger = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool permitstrangerSpecified
		{
			get
			{
				return this._permitstranger != null;
			}
			set
			{
				bool flag = value == (this._permitstranger == null);
				if (flag)
				{
					this._permitstranger = (value ? new bool?(this.permitstranger) : null);
				}
			}
		}

		private bool ShouldSerializepermitstranger()
		{
			return this.permitstrangerSpecified;
		}

		private void Resetpermitstranger()
		{
			this.permitstrangerSpecified = false;
		}

		[ProtoMember(3, Name = "friends", DataFormat = DataFormat.Default)]
		public List<WeddingRoleBrief> friends
		{
			get
			{
				return this._friends;
			}
		}

		[ProtoMember(4, Name = "guildmembers", DataFormat = DataFormat.Default)]
		public List<WeddingRoleBrief> guildmembers
		{
			get
			{
				return this._guildmembers;
			}
		}

		[ProtoMember(5, Name = "invitelist", DataFormat = DataFormat.Default)]
		public List<WeddingRoleBrief> invitelist
		{
			get
			{
				return this._invitelist;
			}
		}

		[ProtoMember(6, Name = "invite_enter", DataFormat = DataFormat.Default)]
		public List<bool> invite_enter
		{
			get
			{
				return this._invite_enter;
			}
		}

		[ProtoMember(7, Name = "applylist", DataFormat = DataFormat.Default)]
		public List<WeddingRoleBrief> applylist
		{
			get
			{
				return this._applylist;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "weddingid", DataFormat = DataFormat.TwosComplement)]
		public ulong weddingid
		{
			get
			{
				return this._weddingid ?? 0UL;
			}
			set
			{
				this._weddingid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weddingidSpecified
		{
			get
			{
				return this._weddingid != null;
			}
			set
			{
				bool flag = value == (this._weddingid == null);
				if (flag)
				{
					this._weddingid = (value ? new ulong?(this.weddingid) : null);
				}
			}
		}

		private bool ShouldSerializeweddingid()
		{
			return this.weddingidSpecified;
		}

		private void Resetweddingid()
		{
			this.weddingidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private bool? _permitstranger;

		private readonly List<WeddingRoleBrief> _friends = new List<WeddingRoleBrief>();

		private readonly List<WeddingRoleBrief> _guildmembers = new List<WeddingRoleBrief>();

		private readonly List<WeddingRoleBrief> _invitelist = new List<WeddingRoleBrief>();

		private readonly List<bool> _invite_enter = new List<bool>();

		private readonly List<WeddingRoleBrief> _applylist = new List<WeddingRoleBrief>();

		private ulong? _weddingid;

		private IExtension extensionObject;
	}
}
