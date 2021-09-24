using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildSettingChanged")]
	[Serializable]
	public class GuildSettingChanged : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "Icon", DataFormat = DataFormat.TwosComplement)]
		public int Icon
		{
			get
			{
				return this._Icon ?? 0;
			}
			set
			{
				this._Icon = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool IconSpecified
		{
			get
			{
				return this._Icon != null;
			}
			set
			{
				bool flag = value == (this._Icon == null);
				if (flag)
				{
					this._Icon = (value ? new int?(this.Icon) : null);
				}
			}
		}

		private bool ShouldSerializeIcon()
		{
			return this.IconSpecified;
		}

		private void ResetIcon()
		{
			this.IconSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "RecuitPPT", DataFormat = DataFormat.TwosComplement)]
		public int RecuitPPT
		{
			get
			{
				return this._RecuitPPT ?? 0;
			}
			set
			{
				this._RecuitPPT = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool RecuitPPTSpecified
		{
			get
			{
				return this._RecuitPPT != null;
			}
			set
			{
				bool flag = value == (this._RecuitPPT == null);
				if (flag)
				{
					this._RecuitPPT = (value ? new int?(this.RecuitPPT) : null);
				}
			}
		}

		private bool ShouldSerializeRecuitPPT()
		{
			return this.RecuitPPTSpecified;
		}

		private void ResetRecuitPPT()
		{
			this.RecuitPPTSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "needApproval", DataFormat = DataFormat.TwosComplement)]
		public int needApproval
		{
			get
			{
				return this._needApproval ?? 0;
			}
			set
			{
				this._needApproval = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool needApprovalSpecified
		{
			get
			{
				return this._needApproval != null;
			}
			set
			{
				bool flag = value == (this._needApproval == null);
				if (flag)
				{
					this._needApproval = (value ? new int?(this.needApproval) : null);
				}
			}
		}

		private bool ShouldSerializeneedApproval()
		{
			return this.needApprovalSpecified;
		}

		private void ResetneedApproval()
		{
			this.needApprovalSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "annoucement", DataFormat = DataFormat.Default)]
		public string annoucement
		{
			get
			{
				return this._annoucement ?? "";
			}
			set
			{
				this._annoucement = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool annoucementSpecified
		{
			get
			{
				return this._annoucement != null;
			}
			set
			{
				bool flag = value == (this._annoucement == null);
				if (flag)
				{
					this._annoucement = (value ? this.annoucement : null);
				}
			}
		}

		private bool ShouldSerializeannoucement()
		{
			return this.annoucementSpecified;
		}

		private void Resetannoucement()
		{
			this.annoucementSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _Icon;

		private int? _RecuitPPT;

		private int? _needApproval;

		private string _annoucement;

		private IExtension extensionObject;
	}
}
