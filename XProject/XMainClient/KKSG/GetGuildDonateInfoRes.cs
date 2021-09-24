using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildDonateInfoRes")]
	[Serializable]
	public class GetGuildDonateInfoRes : IExtensible
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

		[ProtoMember(2, Name = "info", DataFormat = DataFormat.Default)]
		public List<GuildMemberAskInfo> info
		{
			get
			{
				return this._info;
			}
		}

		[ProtoMember(3, Name = "rankitem", DataFormat = DataFormat.Default)]
		public List<GuildMemberDonateRankItem> rankitem
		{
			get
			{
				return this._rankitem;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "donatenum", DataFormat = DataFormat.TwosComplement)]
		public uint donatenum
		{
			get
			{
				return this._donatenum ?? 0U;
			}
			set
			{
				this._donatenum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool donatenumSpecified
		{
			get
			{
				return this._donatenum != null;
			}
			set
			{
				bool flag = value == (this._donatenum == null);
				if (flag)
				{
					this._donatenum = (value ? new uint?(this.donatenum) : null);
				}
			}
		}

		private bool ShouldSerializedonatenum()
		{
			return this.donatenumSpecified;
		}

		private void Resetdonatenum()
		{
			this.donatenumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<GuildMemberAskInfo> _info = new List<GuildMemberAskInfo>();

		private readonly List<GuildMemberDonateRankItem> _rankitem = new List<GuildMemberDonateRankItem>();

		private uint? _donatenum;

		private IExtension extensionObject;
	}
}
