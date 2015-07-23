﻿using UnityEngine;
using System.Collections;

namespace CSG
{
	public class BSPOperations
	{
		public static BSPTree Subtract(BSPTree a, BSPTree b)
		{
			BSPTree aClone = a.Clone();
			BSPTree bClone = b.Clone();

			aClone.Invert();
			aClone.ClipByTree(bClone);
			bClone.ClipByTree(aClone);
			bClone.Invert();
			bClone.ClipByTree(aClone);
			bClone.Invert();
			aClone.AddTriangles(bClone.GetAllTriangles());
			aClone.Invert();

			return aClone;
		}
	}
}
