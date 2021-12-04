using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "product", menuName = "Shop/Product")]
public class Product : ScriptableObject
{
	public int Id;
	public TypeProduct Type;
	
}

