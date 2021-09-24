using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XManipulationData : XBaseData
	{

		public XManipulationData()
		{
			this.TargetIsOpponent = true;
		}

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetX;

		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetZ;

		[SerializeField]
		[DefaultValue(0f)]
		public float Degree;

		[SerializeField]
		[DefaultValue(0f)]
		public float Radius;

		[SerializeField]
		[DefaultValue(0f)]
		public float Force;

		[SerializeField]
		[DefaultValue(true)]
		public bool TargetIsOpponent;
	}
}
