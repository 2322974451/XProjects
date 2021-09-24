using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SynCardAttr")]
	[Serializable]
	public class SynCardAttr : IExtensible
	{

		[ProtoMember(1, Name = "addAttr", DataFormat = DataFormat.Default)]
		public List<CardAttr> addAttr
		{
			get
			{
				return this._addAttr;
			}
		}

		[ProtoMember(2, Name = "addper", DataFormat = DataFormat.Default)]
		public List<CardAttr> addper
		{
			get
			{
				return this._addper;
			}
		}

		[ProtoMember(3, Name = "allAttr", DataFormat = DataFormat.Default)]
		public List<CardAttr> allAttr
		{
			get
			{
				return this._allAttr;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "groupId", DataFormat = DataFormat.TwosComplement)]
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

		private readonly List<CardAttr> _addAttr = new List<CardAttr>();

		private readonly List<CardAttr> _addper = new List<CardAttr>();

		private readonly List<CardAttr> _allAttr = new List<CardAttr>();

		private uint? _groupId;

		private IExtension extensionObject;
	}
}
