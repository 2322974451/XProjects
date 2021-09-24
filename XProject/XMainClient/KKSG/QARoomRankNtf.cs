using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QARoomRankNtf")]
	[Serializable]
	public class QARoomRankNtf : IExtensible
	{

		[ProtoMember(1, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<QARoomRankData> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "myscore", DataFormat = DataFormat.TwosComplement)]
		public uint myscore
		{
			get
			{
				return this._myscore ?? 0U;
			}
			set
			{
				this._myscore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool myscoreSpecified
		{
			get
			{
				return this._myscore != null;
			}
			set
			{
				bool flag = value == (this._myscore == null);
				if (flag)
				{
					this._myscore = (value ? new uint?(this.myscore) : null);
				}
			}
		}

		private bool ShouldSerializemyscore()
		{
			return this.myscoreSpecified;
		}

		private void Resetmyscore()
		{
			this.myscoreSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<QARoomRankData> _dataList = new List<QARoomRankData>();

		private uint? _myscore;

		private IExtension extensionObject;
	}
}
