using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatIssueCountNtf")]
	[Serializable]
	public class GroupChatIssueCountNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "rolecount", DataFormat = DataFormat.TwosComplement)]
		public uint rolecount
		{
			get
			{
				return this._rolecount ?? 0U;
			}
			set
			{
				this._rolecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolecountSpecified
		{
			get
			{
				return this._rolecount != null;
			}
			set
			{
				bool flag = value == (this._rolecount == null);
				if (flag)
				{
					this._rolecount = (value ? new uint?(this.rolecount) : null);
				}
			}
		}

		private bool ShouldSerializerolecount()
		{
			return this.rolecountSpecified;
		}

		private void Resetrolecount()
		{
			this.rolecountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "groupcount", DataFormat = DataFormat.TwosComplement)]
		public uint groupcount
		{
			get
			{
				return this._groupcount ?? 0U;
			}
			set
			{
				this._groupcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupcountSpecified
		{
			get
			{
				return this._groupcount != null;
			}
			set
			{
				bool flag = value == (this._groupcount == null);
				if (flag)
				{
					this._groupcount = (value ? new uint?(this.groupcount) : null);
				}
			}
		}

		private bool ShouldSerializegroupcount()
		{
			return this.groupcountSpecified;
		}

		private void Resetgroupcount()
		{
			this.groupcountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _rolecount;

		private uint? _groupcount;

		private IExtension extensionObject;
	}
}
