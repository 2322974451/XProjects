using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfOneBattleEnd")]
	[Serializable]
	public class GmfOneBattleEnd : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public GMFFailReason reason
		{
			get
			{
				return this._reason ?? GMFFailReason.GMF_FAIL_NONE;
			}
			set
			{
				this._reason = new GMFFailReason?(value);
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
					this._reason = (value ? new GMFFailReason?(this.reason) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "winrole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfRoleBrief winrole
		{
			get
			{
				return this._winrole;
			}
			set
			{
				this._winrole = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "loselrole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfRoleBrief loselrole
		{
			get
			{
				return this._loselrole;
			}
			set
			{
				this._loselrole = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "winguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief winguild
		{
			get
			{
				return this._winguild;
			}
			set
			{
				this._winguild = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "loseguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief loseguild
		{
			get
			{
				return this._loseguild;
			}
			set
			{
				this._loseguild = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GMFFailReason? _reason;

		private GmfRoleBrief _winrole = null;

		private GmfRoleBrief _loselrole = null;

		private GmfGuildBrief _winguild = null;

		private GmfGuildBrief _loseguild = null;

		private IExtension extensionObject;
	}
}
