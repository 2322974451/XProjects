using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AutoBreakAtlasArg")]
	[Serializable]
	public class AutoBreakAtlasArg : IExtensible
	{

		[ProtoMember(1, Name = "quilts", DataFormat = DataFormat.TwosComplement)]
		public List<uint> quilts
		{
			get
			{
				return this._quilts;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "groupId", DataFormat = DataFormat.TwosComplement)]
		public uint groupId
		{
			get
			{
				return this._groupId ?? 0U;
			}
			set
			{
				this._groupId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupIdSpecified
		{
			get
			{
				return this._groupId != null;
			}
			set
			{
				bool flag = value == (this._groupId == null);
				if (flag)
				{
					this._groupId = (value ? new uint?(this.groupId) : null);
				}
			}
		}

		private bool ShouldSerializegroupId()
		{
			return this.groupIdSpecified;
		}

		private void ResetgroupId()
		{
			this.groupIdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _quilts = new List<uint>();

		private uint? _groupId;

		private IExtension extensionObject;
	}
}
