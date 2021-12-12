using AI;
using Interactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using UnityEngine;

namespace Factories
{
	public class FactoryWorkmanAI : SingletonMono<FactoryWorkmanAI>, IFactory<WorkmanAI>
	{
		[SerializeField] private WorkmanAI _workmanPrefab;
		public WorkmanAI Create(int count)
		{
			return Instantiate(_workmanPrefab, Vector3.zero, Quaternion.identity);
		}
	}
}
