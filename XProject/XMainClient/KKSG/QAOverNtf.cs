using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QAOverNtf")]
	[Serializable]
	public class QAOverNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "total", DataFormat = DataFormat.TwosComplement)]
		public uint total
		{
			get
			{
				return this._total ?? 0U;
			}
			set
			{
				this._total = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalSpecified
		{
			get
			{
				return this._total != null;
			}
			set
			{
				bool flag = value == (this._total == null);
				if (flag)
				{
					this._total = (value ? new uint?(this.total) : null);
				}
			}
		}

		private bool ShouldSerializetotal()
		{
			return this.totalSpecified;
		}

		private void Resettotal()
		{
			this.totalSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "correct", DataFormat = DataFormat.TwosComplement)]
		public uint correct
		{
			get
			{
				return this._correct ?? 0U;
			}
			set
			{
				this._correct = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool correctSpecified
		{
			get
			{
				return this._correct != null;
			}
			set
			{
				bool flag = value == (this._correct == null);
				if (flag)
				{
					this._correct = (value ? new uint?(this.correct) : null);
				}
			}
		}

		private bool ShouldSerializecorrect()
		{
			return this.correctSpecified;
		}

		private void Resetcorrect()
		{
			this.correctSpecified = false;
		}

		[ProtoMember(3, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<ItemBrief> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _total;

		private uint? _correct;

		private readonly List<ItemBrief> _dataList = new List<ItemBrief>();

		private IExtension extensionObject;
	}
}
