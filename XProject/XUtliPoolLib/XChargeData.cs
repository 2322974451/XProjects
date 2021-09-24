using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XChargeData : XBaseData
	{

		public XChargeData()
		{
			this.StandOnAtEnd = true;
		}

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		[SerializeField]
		[DefaultValue(0f)]
		public float Offset;

		[SerializeField]
		[DefaultValue(0f)]
		public float Height;

		[SerializeField]
		[DefaultValue(0f)]
		public float Velocity;

		[SerializeField]
		[DefaultValue(0f)]
		public float Rotation_Speed;

		[SerializeField]
		[DefaultValue(false)]
		public bool Using_Curve;

		[SerializeField]
		[DefaultValue(false)]
		public bool Control_Towards;

		[SerializeField]
		public string Curve_Forward = null;

		[SerializeField]
		public string Curve_Side = null;

		[SerializeField]
		[DefaultValue(false)]
		public bool Using_Up;

		[SerializeField]
		public string Curve_Up = null;

		[SerializeField]
		[DefaultValue(true)]
		public bool StandOnAtEnd;

		[SerializeField]
		[DefaultValue(false)]
		public bool AimTarget;
	}
}
