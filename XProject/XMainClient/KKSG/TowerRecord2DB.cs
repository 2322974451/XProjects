using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TowerRecord2DB")]
	[Serializable]
	public class TowerRecord2DB : IExtensible
	{

		[ProtoMember(1, Name = "records", DataFormat = DataFormat.Default)]
		public List<TowerRecord> records
		{
			get
			{
				return this._records;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "m_updateTime", DataFormat = DataFormat.TwosComplement)]
		public int m_updateTime
		{
			get
			{
				return this._m_updateTime ?? 0;
			}
			set
			{
				this._m_updateTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool m_updateTimeSpecified
		{
			get
			{
				return this._m_updateTime != null;
			}
			set
			{
				bool flag = value == (this._m_updateTime == null);
				if (flag)
				{
					this._m_updateTime = (value ? new int?(this.m_updateTime) : null);
				}
			}
		}

		private bool ShouldSerializem_updateTime()
		{
			return this.m_updateTimeSpecified;
		}

		private void Resetm_updateTime()
		{
			this.m_updateTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "useResetCount", DataFormat = DataFormat.TwosComplement)]
		public int useResetCount
		{
			get
			{
				return this._useResetCount ?? 0;
			}
			set
			{
				this._useResetCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool useResetCountSpecified
		{
			get
			{
				return this._useResetCount != null;
			}
			set
			{
				bool flag = value == (this._useResetCount == null);
				if (flag)
				{
					this._useResetCount = (value ? new int?(this.useResetCount) : null);
				}
			}
		}

		private bool ShouldSerializeuseResetCount()
		{
			return this.useResetCountSpecified;
		}

		private void ResetuseResetCount()
		{
			this.useResetCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<TowerRecord> _records = new List<TowerRecord>();

		private int? _m_updateTime;

		private int? _useResetCount;

		private IExtension extensionObject;
	}
}
