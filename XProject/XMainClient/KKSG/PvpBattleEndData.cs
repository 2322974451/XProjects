using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpBattleEndData")]
	[Serializable]
	public class PvpBattleEndData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "wingroup", DataFormat = DataFormat.TwosComplement)]
		public int wingroup
		{
			get
			{
				return this._wingroup ?? 0;
			}
			set
			{
				this._wingroup = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wingroupSpecified
		{
			get
			{
				return this._wingroup != null;
			}
			set
			{
				bool flag = value == (this._wingroup == null);
				if (flag)
				{
					this._wingroup = (value ? new int?(this.wingroup) : null);
				}
			}
		}

		private bool ShouldSerializewingroup()
		{
			return this.wingroupSpecified;
		}

		private void Resetwingroup()
		{
			this.wingroupSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "isAllEnd", DataFormat = DataFormat.Default)]
		public bool isAllEnd
		{
			get
			{
				return this._isAllEnd ?? false;
			}
			set
			{
				this._isAllEnd = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isAllEndSpecified
		{
			get
			{
				return this._isAllEnd != null;
			}
			set
			{
				bool flag = value == (this._isAllEnd == null);
				if (flag)
				{
					this._isAllEnd = (value ? new bool?(this.isAllEnd) : null);
				}
			}
		}

		private bool ShouldSerializeisAllEnd()
		{
			return this.isAllEndSpecified;
		}

		private void ResetisAllEnd()
		{
			this.isAllEndSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public PVP_ONEGAMEEND_REASON reason
		{
			get
			{
				return this._reason ?? PVP_ONEGAMEEND_REASON.PVP_OGE_LEADER_DIE;
			}
			set
			{
				this._reason = new PVP_ONEGAMEEND_REASON?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? new PVP_ONEGAMEEND_REASON?(this.reason) : null);
				}
			}
		}

		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _wingroup;

		private bool? _isAllEnd;

		private PVP_ONEGAMEEND_REASON? _reason;

		private IExtension extensionObject;
	}
}
