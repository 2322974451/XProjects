using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AntiAddictionRemindInfo")]
	[Serializable]
	public class AntiAddictionRemindInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public AntiAddictionReportType type
		{
			get
			{
				return this._type ?? AntiAddictionReportType.ReportTypeSingle;
			}
			set
			{
				this._type = new AntiAddictionReportType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new AntiAddictionReportType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "remindmsg", DataFormat = DataFormat.Default)]
		public string remindmsg
		{
			get
			{
				return this._remindmsg ?? "";
			}
			set
			{
				this._remindmsg = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool remindmsgSpecified
		{
			get
			{
				return this._remindmsg != null;
			}
			set
			{
				bool flag = value == (this._remindmsg == null);
				if (flag)
				{
					this._remindmsg = (value ? this.remindmsg : null);
				}
			}
		}

		private bool ShouldSerializeremindmsg()
		{
			return this.remindmsgSpecified;
		}

		private void Resetremindmsg()
		{
			this.remindmsgSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private AntiAddictionReportType? _type;

		private string _remindmsg;

		private IExtension extensionObject;
	}
}
