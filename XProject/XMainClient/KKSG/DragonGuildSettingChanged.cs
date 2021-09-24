using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGuildSettingChanged")]
	[Serializable]
	public class DragonGuildSettingChanged : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "recuitPPT", DataFormat = DataFormat.TwosComplement)]
		public uint recuitPPT
		{
			get
			{
				return this._recuitPPT ?? 0U;
			}
			set
			{
				this._recuitPPT = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool recuitPPTSpecified
		{
			get
			{
				return this._recuitPPT != null;
			}
			set
			{
				bool flag = value == (this._recuitPPT == null);
				if (flag)
				{
					this._recuitPPT = (value ? new uint?(this.recuitPPT) : null);
				}
			}
		}

		private bool ShouldSerializerecuitPPT()
		{
			return this.recuitPPTSpecified;
		}

		private void ResetrecuitPPT()
		{
			this.recuitPPTSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "needApproval", DataFormat = DataFormat.TwosComplement)]
		public uint needApproval
		{
			get
			{
				return this._needApproval ?? 0U;
			}
			set
			{
				this._needApproval = new uint?(value);
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
					this._needApproval = (value ? new uint?(this.needApproval) : null);
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

		[ProtoMember(3, IsRequired = false, Name = "annoucement", DataFormat = DataFormat.Default)]
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

		private uint? _recuitPPT;

		private uint? _needApproval;

		private string _annoucement;

		private IExtension extensionObject;
	}
}
